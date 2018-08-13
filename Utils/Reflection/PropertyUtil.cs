using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Common.Utils.Reflection
{
    /// <summary>
    /// Created by wenzq on 2018/7/17.
    /// 属性工具类
    /// </summary>
    public class PropertyUtil
    {
        private static string TAG = typeof(PropertyUtil).Name;

        private PropertyUtil() { }

        /// <summary>
        /// 设置对象的属性值
        /// </summary>
        /// <param name="obj">要设置的对象</param>
        /// <param name="propertyName">属性的名称</param>
        /// <param name="value">设置的值</param>
        public static void setValue(Object obj, String propertyName, Object value)
        {
            PropertyInfo pi = obj.GetType().GetProperty(propertyName);
            setValue(obj, pi, value);
        }

        /// <summary>
        /// 设置对象的属性值
        /// </summary>
        /// <param name="obj">要设置的对象</param>
        /// <param name="propertyInfo">属性的PropertyInfo对象</param>
        /// <param name="value">设置的值</param>
        public static void setValue(Object obj, PropertyInfo propertyInfo, Object value)
        {
            try
            {
                propertyInfo.SetValue(obj, value, null);
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("{0} setValue设置属性 {1} 值失败：{2}", TAG, propertyInfo.Name, e.Message));
            }
        }

        /// <summary>
        /// 获取对象指定属性的值
        /// </summary>
        /// <typeparam name="T">属性的数据类型</typeparam>
        /// <param name="obj">要获取的对象</param>
        /// <param name="propertyName">属性名</param>
        /// <returns></returns>
        public static T getValue<T>(Object obj, String propertyName)
        {
            PropertyInfo pi = obj.GetType().GetProperty(propertyName);
            return getValue<T>(obj, pi);
        }

        /// <summary>
        /// 获取对象指定属性的值
        /// </summary>
        /// <typeparam name="T">属性的数据类型</typeparam>
        /// <param name="obj">要获取的对象</param>
        /// <param name="propertyInfo">属性的PropertyInfo对象</param>
        /// <returns></returns>
        public static T getValue<T>(Object obj, PropertyInfo propertyInfo)
        {
            try
            {
                return (T)propertyInfo.GetValue(obj, null);
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("{0} getValue获取属性 {1} 值失败：{2}", TAG, propertyInfo.Name, e.Message));
            }
        }
    }
}
