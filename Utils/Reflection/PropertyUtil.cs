using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Common.Utils.Reflection
{
    /// <summary>
    /// Created by wenzq on 2018/7/17.
    /// ���Թ�����
    /// </summary>
    public class PropertyUtil
    {
        private static string TAG = typeof(PropertyUtil).Name;

        private PropertyUtil() { }

        /// <summary>
        /// ���ö��������ֵ
        /// </summary>
        /// <param name="obj">Ҫ���õĶ���</param>
        /// <param name="propertyName">���Ե�����</param>
        /// <param name="value">���õ�ֵ</param>
        public static void setValue(Object obj, String propertyName, Object value)
        {
            PropertyInfo pi = obj.GetType().GetProperty(propertyName);
            setValue(obj, pi, value);
        }

        /// <summary>
        /// ���ö��������ֵ
        /// </summary>
        /// <param name="obj">Ҫ���õĶ���</param>
        /// <param name="propertyInfo">���Ե�PropertyInfo����</param>
        /// <param name="value">���õ�ֵ</param>
        public static void setValue(Object obj, PropertyInfo propertyInfo, Object value)
        {
            try
            {
                propertyInfo.SetValue(obj, value, null);
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("{0} setValue�������� {1} ֵʧ�ܣ�{2}", TAG, propertyInfo.Name, e.Message));
            }
        }

        /// <summary>
        /// ��ȡ����ָ�����Ե�ֵ
        /// </summary>
        /// <typeparam name="T">���Ե���������</typeparam>
        /// <param name="obj">Ҫ��ȡ�Ķ���</param>
        /// <param name="propertyName">������</param>
        /// <returns></returns>
        public static T getValue<T>(Object obj, String propertyName)
        {
            PropertyInfo pi = obj.GetType().GetProperty(propertyName);
            return getValue<T>(obj, pi);
        }

        /// <summary>
        /// ��ȡ����ָ�����Ե�ֵ
        /// </summary>
        /// <typeparam name="T">���Ե���������</typeparam>
        /// <param name="obj">Ҫ��ȡ�Ķ���</param>
        /// <param name="propertyInfo">���Ե�PropertyInfo����</param>
        /// <returns></returns>
        public static T getValue<T>(Object obj, PropertyInfo propertyInfo)
        {
            try
            {
                return (T)propertyInfo.GetValue(obj, null);
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("{0} getValue��ȡ���� {1} ֵʧ�ܣ�{2}", TAG, propertyInfo.Name, e.Message));
            }
        }
    }
}
