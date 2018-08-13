using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Cache
{
    /// <summary>
    /// Created by wenzq on 2018/8/6.
    /// 缓存接口
    /// </summary>
    /// <typeparam name="K">缓存Key的数据类型</typeparam>
    /// <typeparam name="V">缓存Value的数据类型</typeparam>
    public interface ICache<K,V>
    {
        /// <summary>
        /// 获取所有的缓存
        /// </summary>
        /// <returns></returns>
        Dictionary<K, V> getAll();

        /// <summary>
        /// 添加到缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        Boolean put(K key, V value);

        /// <summary>
        /// 根据Key值从缓存中获取值，若无则返回null
        /// </summary>
        /// <param name="key">Key值</param>
        /// <returns></returns>
        V get(K key);

        /// <summary>
        /// 当前缓存的大小
        /// </summary>
        /// <returns></returns>
        int size();

        /// <summary>
        /// 清空所有缓存
        /// </summary>
        /// <returns></returns>
        void clear();

        /// <summary>
        /// 根据key移除缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Boolean remove(K key);
    }
}
