using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// 类型句柄接口
    /// </summary>
    public interface ITypeHandler
    {
        /// <summary>
        /// 从数据库获取格式化为属性的结果
        /// </summary>
        /// <param name="dataRow">数据行</param>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
        Object getResult(DataRow dataRow, String columnName);

        /// <summary>
        /// 格式化属性的值为数据库的值
        /// </summary>
        /// <param name="obj">要格式化的值</param>
        /// <param name="propName">数据库的值</param>
        /// <returns></returns>
        Object formatToDb(Object value);

        /// <summary>
        /// 格式化数据库的值为属性的值
        /// </summary>
        /// <param name="dbValue"></param>
        /// <returns></returns>
        Object formatToProp(Object dbValue);
    }
}
