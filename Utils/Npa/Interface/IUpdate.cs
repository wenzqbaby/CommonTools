using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Cmd;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/6
    /// desc:   ��������ȡ�ӿ�
    /// </summary>
    /// <typeparam name="T">ʵ������</typeparam>
    public interface IUpdate<T>
    {
        /// <summary>
        /// ���ݶ����������ɸ���SQL��䣬����������������Ҳ���Ϊ��
        /// </summary>
        /// <param name="t">ʵ��</param>
        /// <returns>SQL���</returns>
        String getSql(T t);

        /// <summary>
        /// ���ݶ����������ɸ��²�������䣬����������������Ҳ���Ϊ��
        /// </summary>
        /// <param name="t">ʵ��</param>
        /// <returns>������ָ��</returns>
        PreparedCmd getPreparedSql(T t);

        /// <summary>
        /// ����ָ���������ɸ���SQL���
        /// </summary>
        /// <param name="t">ʵ��</param>
        /// <param name="propConds">���µ�����(ʵ���������)����Ϊ�ջ�ռ�����ΪID���������Բ���Ϊ��</param>
        /// <param name="propUpdates">���µ�����(ʵ���������)����Ϊ�ջ�ռ�����Ϊȫ������</param>
        /// <returns></returns>
        String getSql(T t, List<String> propConds, List<String> propUpdates);

        /// <summary>
        /// ����ָ���������ɸ���SQL���
        /// </summary>
        /// <param name="t">ʵ��</param>
        /// <param name="propConds">���µ�����(ʵ���������)����Ϊ�ջ�ռ�����ΪID���������Բ���Ϊ��</param>
        /// <param name="propUpdates">���µ�����(ʵ���������)����Ϊ�ջ�ռ�����Ϊȫ������</param>
        /// <returns>������ָ��</returns>
        PreparedCmd getPreparedSql(T t, List<String> propConds, List<String> propUpdates);

        /// <summary>
        /// ���ݶ����������ɸ���SQL��䣬����������������Ҳ���Ϊ��
        /// ������Ϊ�������Ϊnullֵ
        /// </summary>
        /// <param name="t">ʵ��</param>
        /// <returns>SQL���</returns>
        String getSqlWithNull(T t);

        /// <summary>
        /// ���ݶ����������ɸ��²�������䣬����������������Ҳ���Ϊ��
        /// ������Ϊ�������Ϊnullֵ
        /// </summary>
        /// <param name="t">ʵ��</param>
        /// <returns>������ָ��</returns>
        PreparedCmd getPSqlWithNull(T t);
    }
}
