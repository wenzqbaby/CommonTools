using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/6
    /// desc:   类型转换接口
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
        /// 获取格式化后的值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Object formatProp(Object value);

        /// <summary>
        /// 格式化属性的值为SQL语句的值
        /// </summary>
        /// <param name="obj">要格式化的值</param>
        /// <returns></returns>
        String formatToSql(Object value);

        /// <summary>
        /// 格式化数据库的值为属性的值
        /// </summary>
        /// <param name="dbValue"></param>
        /// <returns></returns>
        Object formatToProp(Object dbValue);
    }
}
