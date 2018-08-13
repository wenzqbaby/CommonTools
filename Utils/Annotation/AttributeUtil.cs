using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Common.Utils.Annotation
{
    /// <summary>
    /// Created by wenzq on 2018/7/17.
    /// 注解工具类，用于获取类中的注解
    /// </summary>
    public class AttributeUtil
    {
        private static string TAG = typeof(AttributeUtil).Name;
        private static int MAX_CACHE = 100;
        private static Dictionary<Type, Object> cache = new Dictionary<Type, Object>();

        private AttributeUtil() { }

        /// <summary>
        /// 获取类中指定的注解
        /// </summary>
        /// <typeparam name="T">要获取的注解类型</typeparam>
        /// <param name="type">要获取的类</param>
        /// <returns>注解集合，key为属性名，值为</returns>
        public static Dictionary<String, Annotation<T>> get<T>(Type type) where T: Attribute
        {
            Dictionary<String, Annotation<T>> dictionary = getByCache<T>(type);
            if (dictionary != null)
            {
                return dictionary;
            }

            PropertyInfo[] propertyInfos = type.GetProperties();
            dictionary = new Dictionary<string, Annotation<T>>(propertyInfos.Length);
            foreach (PropertyInfo pi in propertyInfos)
            {
                try
                {
                    Attribute attr = Attribute.GetCustomAttribute(pi, typeof(T));
                    if (attr != null)
                    {
                        dictionary[pi.Name] = new Annotation<T>(pi, attr as T);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(String.Format("{0} 获取类 {1} 的属性 {2} 注解异常：{3}", TAG, type.Name, pi.Name, e.Message));
                }
                
            }
            addCache<T>(type, dictionary);
            return copyDic<T>(dictionary);
        }

        private static Dictionary<String, Annotation<T>> getByCache<T>(Type t) where T : Attribute
        {
            try
            {
                Dictionary<String, Annotation<T>> dictionary = cache[t] as Dictionary<String, Annotation<T>>;
                return copyDic<T>(dictionary);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static void addCache<T>(Type t, Dictionary<String, Annotation<T>> dic) where T : Attribute
        {
            if (cache.Count < MAX_CACHE && !cache.ContainsKey(t))
            {
                cache[t] = dic;
            }
        }

        private static Dictionary<String, Annotation<T>> copyDic<T>(Dictionary<String, Annotation<T>> dictionary) where T : Attribute
        {
            if (dictionary == null)
            {
                return null;
            }
            Dictionary<String, Annotation<T>> cloneDic = new Dictionary<String, Annotation<T>>();
            foreach (KeyValuePair<String, Annotation<T>> var in dictionary)
            {
                cloneDic[var.Key] = new Annotation<T>(var.Value);
            }
            return cloneDic;
        }
    }
}
