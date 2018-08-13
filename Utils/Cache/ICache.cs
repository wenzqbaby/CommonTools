using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Cache
{
    /// <summary>
    /// Created by wenzq on 2018/8/6.
    /// ����ӿ�
    /// </summary>
    /// <typeparam name="K">����Key����������</typeparam>
    /// <typeparam name="V">����Value����������</typeparam>
    public interface ICache<K,V>
    {
        /// <summary>
        /// ��ȡ���еĻ���
        /// </summary>
        /// <returns></returns>
        Dictionary<K, V> getAll();

        /// <summary>
        /// ��ӵ�����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        Boolean put(K key, V value);

        /// <summary>
        /// ����Keyֵ�ӻ����л�ȡֵ�������򷵻�null
        /// </summary>
        /// <param name="key">Keyֵ</param>
        /// <returns></returns>
        V get(K key);

        /// <summary>
        /// ��ǰ����Ĵ�С
        /// </summary>
        /// <returns></returns>
        int size();

        /// <summary>
        /// ������л���
        /// </summary>
        /// <returns></returns>
        void clear();

        /// <summary>
        /// ����key�Ƴ�����
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Boolean remove(K key);
    }
}
