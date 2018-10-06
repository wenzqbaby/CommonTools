using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.cmd;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// ��ѯ������ɽӿ�
    /// </summary>
    public interface ISelect<T>
    {
        /// <summary>
        /// ��ѯ��������
        /// </summary>
        /// <returns></returns>
        String find();

        /// <summary>
        /// ��ѯ��������
        /// </summary>
        /// <returns></returns>
        PreparedCmd findPrepared();

        /// <summary>
        /// ���ݴ�����������Ϊ������ѯ
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        String find(T t);

        /// <summary>
        /// ���ݴ�����������Ϊ������ѯ
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        PreparedCmd findPrepared(T t);
    }
}
