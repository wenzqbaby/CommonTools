using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// 数据实体接口
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// 获取数据表名
        /// </summary>
        /// <returns></returns>
        String getTableName();

        /// <summary>
        /// 获取命名空间名
        /// </summary>
        /// <returns></returns>
        String getScheme();
    }
}
