using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Cmd;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/6
    /// desc:   ��ѯ������ɽӿ�
    /// </summary>
    public interface ISelect<T>
    {
        /// <summary>
        /// ���ɲ�ѯ��������SQL���
        /// </summary>
        /// <returns>SQL���</returns>
        String find();

        /// <summary>
        /// ���ɲ�ѯ�������ݲ�����ָ��
        /// </summary>
        /// <returns>������ָ��</returns>
        PreparedCmd findPrepared();

        /// <summary>
        /// ���ݴ�����������Ϊ���������ɲ�ѯ��������SQL���
        /// </summary>
        /// <param name="t">����ʵ��</param>
        /// <returns>SQL���</returns>
        String find(T t);

        /// <summary>
        /// ���ݴ�����������Ϊ���������ɲ�ѯ�������ݲ�����ָ��
        /// </summary>
        /// <param name="t">����ʵ��</param>
        /// <returns>������ָ��</returns>
        PreparedCmd findPrepared(T t);

        /// <summary>
        /// ���ݴ���������������Ϊ���������ɲ�ѯSQL���
        /// </summary>
        /// <param name="t">����ʵ��</param>
        /// <returns>SQL���</returns>
        String findById(T t);

        /// <summary>
        /// ���ݴ���������������Ϊ���������ɲ�ѯ������ָ��
        /// </summary>
        /// <param name="t">����ʵ��</param>
        /// <returns>������ָ��</returns>
        PreparedCmd findPreparedById(T t);
    }
}
