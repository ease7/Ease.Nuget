using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Synyi.CaseCode.Configuration.Entity;

namespace Synyi.CaseCode.Configuration
{
    /// <summary>
    /// 系统配置项数据访问类
    /// </summary>
    internal class ConfigurationDalService : IConfigurationDalService
    {
        /// <summary>
        /// DB上下文
        /// </summary>
        private readonly ConfigurationDbContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public ConfigurationDalService(ConfigurationDbContext dbContext)
        {
            _dbContext = dbContext;
        }





        /// <summary>
        /// 获取配置项集合
        /// </summary>
        /// <returns>返回符合条件的结果集</returns>
        public async Task<List<SystemConfiguration>> GetAll()
        {
            return await _dbContext.DbConfiguration.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 保存配置项
        /// </summary>
        /// <param name="model">保存的对象实例</param>
        /// <returns>成功返回true，否则返回false</returns>
        public async Task<bool> Save(SystemConfiguration model)
        {
            var exist = _dbContext.DbConfiguration.AsNoTracking()
                .FirstOrDefault(o => o.Key == model.Key);

            if (exist != null)
            {
                exist.Value = model.Value;
                exist.Description = model.Description;
                exist.Category = model.Category;

                _dbContext.Update(exist);
            }
            else
            {
                await _dbContext.DbConfiguration.AddAsync(model);
            }
            _dbContext.SaveChanges();

            return model.Id > 0;
        }

        /// <summary>
        /// 删除配置项
        /// </summary>
        /// <param name="key">关键字</param>
        /// <returns>成功返回true，否则返回false</returns>
        public async Task<bool> Delete(string key)
        {
            var model = _dbContext.DbConfiguration.AsNoTracking()
                .FirstOrDefault(o => o.Key == key);

            if (model == null)
                return false;
            else
                _dbContext.DbConfiguration.Remove(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
