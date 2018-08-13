using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Common.Utils.Annotation
{
    /// <summary>
    /// Created by wenzq on 2018/7/17.
    /// ע�⹤���࣬���ڻ�ȡ���е�ע��
    /// </summary>
    public class AttributeUtil
    {
        private static string TAG = typeof(AttributeUtil).Name;
        private static int MAX_CACHE = 100;
        private static Dictionary<Type, Object> cache = new Dictionary<Type, Object>();

        private AttributeUtil() { }

        /// <summary>
        /// ��ȡ����ָ����ע��
        /// </summary>
        /// <typeparam name="T">Ҫ��ȡ��ע������</typeparam>
        /// <param name="type">Ҫ��ȡ����</param>
        /// <returns>ע�⼯�ϣ�keyΪ��������ֵΪ</returns>
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
                    throw new Exception(String.Format("{0} ��ȡ�� {1} ������ {2} ע���쳣��{3}", TAG, type.Name, pi.Name, e.Message));
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
