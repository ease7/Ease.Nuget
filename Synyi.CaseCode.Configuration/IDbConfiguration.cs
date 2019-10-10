using Synyi.CaseCode.Configuration.Entity;
using System;

namespace Synyi.CaseCode.Configuration
{
    public interface IDbConfiguration
    {
        /// <summary>
        /// 获取配置项
        /// </summary>
        /// <param name="key">配置项key</param>
        /// <returns>返回内容</returns>
        string this[string key] { get; }

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="category"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        bool Save(string key, string value, string category = "", string description = "");
    }
}
