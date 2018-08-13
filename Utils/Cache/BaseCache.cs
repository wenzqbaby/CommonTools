using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Cache
{
    /// <summary>
    /// Created by wenzq on 2018/8/6.
    /// 字典缓存接口实现基类
    /// </summary>
    /// <typeparam name="K">字典Key的数据类型</typeparam>
    /// <typeparam name="V">字典Value的数据类型</typeparam>
    public abstract class BaseCache<K, V> : ICache<K, V>
    {
        /// <summary>
        /// 当前类名
        /// </summary>
        protected static string TAG;
        private int max;
        private Dictionary<K, V> cache;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="cacheSize">缓存的大小</param>
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
        /// 返回对象的克隆对象，建议引用对象重新new一个
        /// </summary>
        /// <param name="value">要克隆的值</param>
        /// <returns>克隆后的值</returns>
        protected abstract V cloneValue(V value);

        #region ICache<K,V> 成员

        /// <summary>
        /// 获取所有的缓存
        /// </summary>
        /// <returns>缓存</returns>
        public Dictionary<K, V> getAll()
        {
            return cache;
        }

        /// <summary>
        /// 添加到缓存,若key为空或者缓存数量已满或者已有该Key作为缓存则不添加到缓存
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
        /// 根据字典的Key值从缓存中获取值，若无则返回null
        /// </summary>
        /// <param name="key">字典的Key值</param>
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
        /// 当前缓存的大小
        /// </summary>
        /// <returns></returns>
        public int size()
        {
            return cache.Count;
        }

        /// <summary>
        /// 清空所有缓存
        /// </summary>
        /// <returns></returns>
        public void clear()
        {
            cache.Clear();
        }

        /// <summary>
        /// 根据key移除缓存
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
