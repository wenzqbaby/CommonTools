using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// ���ݷ��ʽӿ�
    /// </summary>
    public interface IDataAccess
    {
        /// <summary>
        /// ִ�в������
        /// </summary>
        /// <param name="sql">Ҫִ�е�SQL���</param>
        /// <returns></returns>
        int insert(String sql);

        /// <summary>
        /// ִ�в������
        /// </summary>
        /// <param name="preparedSql">������SQL���</param>
        /// <param name="parameters">�����б�</param>
        /// <returns></returns>
        int insert(List<DbParameter> parameters, string preparedSql);

        int insert(String preparedSql, params DbParameter[] parameters);

        /// <summary>
        /// ִ��ɾ�����
        /// </summary>
        /// <param name="sql">Ҫִ�е�SQL���</param>
        /// <returns></returns>
        int delete(String sql);

        /// <summary>
        /// ִ��ɾ�����
        /// </summary>
        /// <param name="preparedSql">������SQL���</param>
        /// <param name="parameters">�����б�</param>
        /// <returns></returns>
        int delete(List<DbParameter> parameters, String preparedSql);

        int delete(String preparedSql, params DbParameter[] parameters);

        /// <summary>
        /// ִ�и������
        /// </summary>
        /// <param name="sql">Ҫִ�е�SQL���</param>
        /// <returns></returns>
        int update(String sql);

        /// <summary>
        /// ִ�и������
        /// </summary>
        /// <param name="preparedSql">������SQL���</param>
        /// <param name="parameters">�����б�</param>
        /// <returns></returns>
        int update(List<DbParameter> parameters, String preparedSql);

        int update(String preparedSql, params DbParameter[] parameters);

        /// <summary>
        /// ִ�в�ѯ���
        /// </summary>
        /// <param name="sql">Ҫִ�е�SQL���</param>
        /// <returns>��ѯ��������ݼ�</returns>
        DataSet select(String sql);

        /// <summary>
        /// ִ�в�ѯ���
        /// </summary>
        /// <param name="preparedSql"></param>
        /// <param name="parameters"></param>
        /// <returns>��ѯ��������ݼ�</returns>
        DataSet select(List<DbParameter> parameters, String preparedSql);

        DataSet select(String preparedSql, params DbParameter[] parameters);
    }
}
