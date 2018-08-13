using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Cache
{
    /// <summary>
    /// Created by wenzq on 2018/8/6.
    /// �ֵ仺��ӿ�ʵ�ֻ���
    /// </summary>
    /// <typeparam name="K">�ֵ�Key����������</typeparam>
    /// <typeparam name="V">�ֵ�Value����������</typeparam>
    public abstract class BaseCache<K, V> : ICache<K, V>
    {
        /// <summary>
        /// ��ǰ����
        /// </summary>
        protected static string TAG;
        private int max;
        private Dictionary<K, V> cache;

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="cacheSize">����Ĵ�С</param>
        public BaseCache(int cacheSize)
        {
            TAG = this.GetType().Name;
            if (cacheSize < 1)
            {
                throw new Exception(String.Format("{0}: The cache size must greater than 0.", TAG));
            }
            this.max = cacheSize;
            this.cache = new Dictionary<K, V>(max);
        }

        /// <summary>
        /// ���ض���Ŀ�¡���󣬽������ö�������newһ��
        /// </summary>
        /// <param name="value">Ҫ��¡��ֵ</param>
        /// <returns>��¡���ֵ</returns>
        protected abstract V cloneValue(V value);

        #region ICache<K,V> ��Ա

        /// <summary>
        /// ��ȡ���еĻ���
        /// </summary>
        /// <returns>����</returns>
        public Dictionary<K, V> getAll()
        {
            return cache;
        }

        /// <summary>
        /// ��ӵ�����,��keyΪ�ջ��߻������������������и�Key��Ϊ��������ӵ�����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Boolean put(K key, V value)
        {
            if (key != null && cache.Count <= max && !cache.ContainsKey(key))
            {
                cache[key] = value;
                return true;
            }
            return false;
        }

        /// <summary>
        /// �����ֵ��Keyֵ�ӻ����л�ȡֵ�������򷵻�null
        /// </summary>
        /// <param name="key">�ֵ��Keyֵ</param>
        /// <returns></returns>
        public V get(K key)
        {
            try
            {
                V v = cache[key];
                return cloneValue(v);
            }
            catch (Exception)
            {
                return default(V);
            }
        }

        /// <summary>
        /// ��ǰ����Ĵ�С
        /// </summary>
        /// <returns></returns>
        public int size()
        {
            return cache.Count;
        }

        /// <summary>
        /// ������л���
        /// </summary>
        /// <returns></returns>
        public void clear()
        {
            cache.Clear();
        }

        /// <summary>
        /// ����key�Ƴ�����
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool remove(K key)
        {
            if (key == null)
            {
                return false;
            }
            return cache.Remove(key);
        }

        #endregion
    }
}
