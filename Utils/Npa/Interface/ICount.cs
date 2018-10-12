using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Cmd;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/10
    /// desc:   �����нӿ�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICount<T>
    {
        /// <summary>
        /// ���ݴ������Ϊ�յ�����Ϊ���������ɲ�ѯ�������
        /// </summary>
        /// <param name="t">ʵ��</param>
        /// <returns>SQL���</returns>
        String count(T t);

        /// <summary>
        /// ���ݴ������Ϊ�յ�����Ϊ���������ɲ�ѯ����������ָ��
        /// </summary>
        /// <param name="t">ʵ��</param>
        /// <returns>������ָ��</returns>
        PreparedCmd countPrepared(T t);

        /// <summary>
        /// ���ݴ���������������Ϊ����(�������Բ���Ϊ��)�����ɲ�ѯ�������
        /// </summary>
        /// <param name="t">ʵ��</param>
        /// <returns>SQL���</returns>
        String countById(T t);

        /// <summary>
        /// ���ݴ���������������Ϊ����(�������Բ���Ϊ��)�����ɲ�ѯ�������
        /// </summary>
        /// <param name="t">ʵ��</param>
        /// <returns>������ָ��</returns>
        PreparedCmd countPreparedById(T t);
    }
}
