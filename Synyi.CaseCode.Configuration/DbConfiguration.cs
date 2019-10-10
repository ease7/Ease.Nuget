
using Microsoft.Extensions.Configuration;
using Synyi.CaseCode.Configuration.Entity;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.Linq;

namespace Synyi.CaseCode.Configuration
{
    public class DbConfiguration : IDbConfiguration
    {
        private readonly IConfigurationDalService _configurationDalService;

        private readonly IConfiguration _configuration;

        private static ConcurrentBag<SystemConfiguration> _items = new ConcurrentBag<SystemConfiguration>();

        private string Env { get; set; }


        public DbConfiguration(ConfigurationDbContext context, IConfiguration config)
        {
            _configurationDalService = new ConfigurationDalService(context);

            this.Env = string.IsNullOrEmpty(config["ASPNETCORE_ENVIRONMENT"]) ?
                "Release" : config["ASPNETCORE_ENVIRONMENT"];

            _configuration = config;

            InitAllKeys();
        }

        /// <summary>
        /// 取值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string this[string key]
        {

            get
            {
                var configValue = _configuration[key];

                if (string.IsNullOrEmpty(configValue))
                {
                    configValue = _items.FirstOrDefault(o => o.Category == Env && o.Key == key).Value;
                }

                return configValue;
            }
        }


        /// <summary>
        /// 初始化所有键值配置
        /// </summary>
        private void InitAllKeys()
        {
            var list = _configurationDalService.GetAll().Result;
            _items.Clear();

            foreach (var item in list)
            {
                _items.Add(item);
            }
        }

        /// <summary>
        /// 根据类别获取配置项集合
        /// </summary>
        /// <param name="category">类别名称</param>
        /// <returns>返回符合条件的结果集</returns>
        public List<SystemConfiguration> GetByCategory(string category)
        {
            return _items.Where(o => o.Category == category).ToList();
        }


        /// <summary>
        /// 删除配置项
        /// </summary>
        /// <param name="key">配置的ID编号</param>
        /// <returns>成功返回true，否则返回false</returns>
        public bool Delete(string key)
        {
            var result = _configurationDalService.Delete(key).Result;

            InitAllKeys();

            return result;
        }

        /// <summary>
        /// 保存配置项
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool Save(string key, string value, string category = "", string description = "")
        {
            if (string.IsNullOrEmpty(category)) category = Env;

            var model = new SystemConfiguration()
            {
                Key = key,
                Value = value,
                Category = category,
                Description = description
            };

            var result = _configurationDalService.Save(model).Result;

            InitAllKeys();

            return result;
        }
    }
}
