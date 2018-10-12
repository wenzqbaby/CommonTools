using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Common.Utils.Npa.Cmd;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/5
    /// desc:   ���ݷ��ʽӿ�
    /// </summary>
    public interface IDataAccess
    {
        /// <summary>
        /// ������־
        /// </summary>
        /// <param name="t"></param>
        void setLog(Type t);

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <returns></returns>
        DbTransaction getTrans();

        /// <summary>
        /// ��ʼ����
        /// </summary>
        void beginTrans();

        /// <summary>
        /// �ύ����
        /// </summary>
        void commit();

        /// <summary>
        /// �ع�����
        /// </summary>
        void rollBack();

        /// <summary>
        /// ִ�����ݲ������
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <returns>��Ӱ�������</returns>
        int insert(String sql);

        /// <summary>
        /// ִ�����ݲ������
        /// </summary>
        /// <param name="preparedSql">�����б�</param>
        /// <param name="parameters">������SQL���</param>
        /// <returns>��Ӱ�������</returns>
        int insert(List<DbParameter> parameters, string preparedSql);

        /// <summary>
        /// ִ�����ݲ������
        /// </summary>
        /// <param name="preparedSql">������SQL���</param>
        /// <param name="parameters">����</param>
        /// <returns>��Ӱ�������</returns>
        int insert(String preparedSql, params DbParameter[] parameters);

        /// <summary>
        /// ִ�����ݲ������
        /// </summary>
        /// <param name="cmd">������ָ��</param>
        /// <returns>��Ӱ�������</returns>
        int insert(PreparedCmd cmd);

        /// <summary>
        /// ִ������ɾ������
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <returns></returns>
        int delete(String sql);

        /// <summary>
        /// ִ������ɾ������
        /// </summary>
        /// <param name="preparedSql">������SQL���</param>
        /// <param name="parameters">�����б�</param>
        /// <returns>��Ӱ�������</returns>
        int delete(List<DbParameter> parameters, String preparedSql);

        /// <summary>
        /// ִ������ɾ������
        /// </summary>
        /// <param name="preparedSql">������SQL���</param>
        /// <param name="parameters">����</param>
        /// <returns>��Ӱ�������</returns>
        int delete(String preparedSql, params DbParameter[] parameters);

        /// <summary>
        /// ִ������ɾ������
        /// </summary>
        /// <param name="cmd">������ָ��</param>
        /// <returns>��Ӱ�������</returns>
        int delete(PreparedCmd cmd);

        /// <summary>
        /// ִ�����ݸ��²���
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <returns></returns>
        int update(String sql);

        /// <summary>
        /// ִ�����ݸ��²���
        /// </summary>
        /// <param name="preparedSql">������SQL���</param>
        /// <param name="parameters">�����б�</param>
        /// <returns></returns>
        int update(List<DbParameter> parameters, String preparedSql);

        /// <summary>
        /// ִ�����ݸ��²���
        /// </summary>
        /// <param name="preparedSql">������SQL���</param>
        /// <param name="parameters">����</param>
        /// <returns>��Ӱ�������</returns>
        int update(String preparedSql, params DbParameter[] parameters);

        /// <summary>
        /// ִ�����ݸ��²���
        /// </summary>
        /// <param name="cmd">������ָ��</param>
        /// <returns>��Ӱ�������</returns>
        int update(PreparedCmd cmd);

        /// <summary>
        /// ִ�����ݲ�ѯ����
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <returns>��ѯ��������ݼ�</returns>
        DataSet select(String sql);

        /// <summary>
        /// ִ�в�ѯ���
        /// </summary>
        /// <param name="preparedSql"></param>
        /// <param name="parameters"></param>
        /// <returns>��ѯ��������ݼ�</returns>
        DataSet select(List<DbParameter> parameters, String preparedSql);

        /// <summary>
        /// ִ�в�ѯ���
        /// </summary>
        /// <param name="preparedSql">������SQL���</param>
        /// <param name="parameters">����</param>
        /// <returns>��ѯ��������ݼ�</returns>
        DataSet select(String preparedSql, params DbParameter[] parameters);

        /// <summary>
        /// ִ�в�ѯ���
        /// </summary>
        /// <param name="cmd">������ָ��</param>
        /// <returns>��ѯ��������ݼ�</returns>
        DataSet select(PreparedCmd cmd);
    }
}
