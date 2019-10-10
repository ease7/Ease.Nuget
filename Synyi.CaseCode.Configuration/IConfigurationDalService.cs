using Synyi.CaseCode.Configuration.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synyi.CaseCode.Configuration
{
    /// <summary>
    /// 系统配置项
    /// </summary>
    internal interface IConfigurationDalService
    {
        /// <summary>
        /// 获取配置项集合
        /// </summary>
        /// <returns>返回符合条件的结果集</returns>
        Task<List<SystemConfiguration>> GetAll();

        /// <summary>
        /// 保存配置项
        /// </summary>
        /// <param name="model">保存的对象实例</param>
        /// <returns>成功返回true，否则返回false</returns>
        Task<bool> Save(SystemConfiguration model);

        /// <summary>
        /// 删除配置项
        /// </summary>
        /// <param name="key">关键字</param>
        /// <returns>成功返回true，否则返回false</returns>
        Task<bool> Delete(string key);
    }
}
