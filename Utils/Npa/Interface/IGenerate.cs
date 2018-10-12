using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/7
    /// desc:   �������ݼ����ɶ���ӿ�
    /// </summary>
    /// <typeparam name="T">ʵ������</typeparam>
    public interface IGenerate<T>
    {
        /// <summary>
        /// �������ݼ���һ����ĵ�һ���������ɶ���
        /// </summary>
        /// <param name="ds">���ݼ�</param>
        /// <returns>ʵ��</returns>
        T get(DataSet ds);

        /// <summary>
        /// �������ݼ���һ������������ɶ��󼯺�
        /// </summary>
        /// <param name="ds">���ݼ�</param>
        /// <returns>ʵ�弯��</returns>
        List<T> getList(DataSet ds);
    }
}
