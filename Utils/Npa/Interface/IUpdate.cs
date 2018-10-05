using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.cmd;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// ��������ȡ�ӿ�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IUpdate<T>
    {
        /// <summary>
        /// ��ȡ���ݶ�������������䣬����������������Ҳ���Ϊ��
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        String getSql(T t);

        /// <summary>
        /// ��ȡ���ݶ�����������Ԥ������䣬����������������Ҳ���Ϊ��
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        PreparedSql getPreparedSql(T t);

        /// <summary>
        /// ��ȡ���ݶ�������������䣬����������������Ҳ���Ϊ��
        /// ������Ϊ�������Ϊnullֵ
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        String getSqlWithNull(T t);

        /// <summary>
        /// ��ȡ���ݶ�����������Ԥ������䣬����������������Ҳ���Ϊ��
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        PreparedSql getPSqlWithNull(T t);
    }
}
