using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Reflection;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// 数据库表的列名接口
    /// </summary>
    public interface IColumn
    {
        /// <summary>
        /// 是否为主键列
        /// </summary>
        /// <returns></returns>
        Boolean isIdColumn();

        /// <summary>
        /// 获取属性的名称
        /// </summary>
        /// <returns></returns>
        String getProp();

        /// <summary>
        /// 获取@+属性的名称
        /// </summary>
        /// <returns></returns>
        String getPrepareProp();

        /// <summary>
        /// 获取属性对应的数据表列名
        /// </summary>
        /// <returns></returns>
        String getColumn();

        /// <summary>
        /// 获取对象该属性的值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        Object getValue(Object obj);

        /// <summary>
        /// 获取对象该属性的数据库值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>属性值</returns>
        String getSqlValue(Object obj);

        /// <summary>
        /// 给对象设置该属性的值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="value">要设置的值</param>
        void setDbValue(Object obj, Object value);

        /// <summary>
        /// 获取DbCommand的参数
        /// </summary>
        /// <returns></returns>
        DbParameter getDbParameter(Object value);

        void setPropertyInfo(PropertyInfo propertyInfo);
    }
}
