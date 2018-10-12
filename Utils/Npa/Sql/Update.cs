using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;
using Common.Utils.Npa.Cst;
using System.Data.Common;
using Common.Utils.Npa.Cmd;

namespace Common.Utils.Npa.Sql
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/6
    /// desc:   ��������ȡ�ӿ�ʵ��
    /// </summary>
    /// <typeparam name="T">ʵ������</typeparam>
    public class Update<T> : BaseSql, IUpdate<T>
    {
        public Update(String scheme, String table, Dictionary<String, IColumn> columnDic, List<IColumn> idColumns, String tag)
            : base(scheme, table, columnDic, idColumns)
        {
            mType = typeof(T);
            TAG = tag;
        }

        #region IUpdate<T> ��Ա

        public string getSql(T t)
        {
            List<IColumn> list = new List<IColumn>();
            list.AddRange(mColumns.Values);
            return getSql(list, mIds, t);
        }

        public PreparedCmd getPreparedSql(T t)
        {
            List<IColumn> list = new List<IColumn>();
            list.AddRange(mColumns.Values);
            return getPrepare(list, mIds, t);
        }

        public string getSql(T t, List<string> propConds, List<string> propUpdates)
        {
            List<IColumn> conds = getColumn(propConds, mIds);
            List<IColumn> props = getColumn(propUpdates, mColumns.Values);
            return this.getSql(props, conds, t);
        }

        public PreparedCmd getPreparedSql(T t, List<string> propConds, List<string> propUpdates)
        {
            List<IColumn> conds = getColumn(propConds, mIds);
            List<IColumn> props = getColumn(propUpdates, mColumns.Values);
            return this.getPrepare(props, conds, t);
        }

        public string getSqlWithNull(T t)
        {
            List<IColumn> list = new List<IColumn>();
            list.AddRange(mColumns.Values);
            return getSqlWithNull(list, mIds, t);
        }

        public PreparedCmd getPSqlWithNull(T t)
        {
            List<IColumn> list = new List<IColumn>();
            list.AddRange(mColumns.Values);
            return getPrepareWithNull(list, mIds, t);
        }

        #endregion

        #region ˽�з�����������䷽��

        /// <summary>
        /// ͨ����������ȡ�����нӿ�, ��Ϊ���򷵻�Ĭ��
        /// </summary>
        /// <param name="list">����������</param>
        /// <param name="listDefault">Ĭ��������</param>
        /// <returns></returns>
        private List<IColumn> getColumn(List<String> list, IEnumerable<IColumn> listDefault)
        {
            List<IColumn> clo = new List<IColumn>();
            foreach (String item in list)
            {
                try
                {
                    clo.Add(mColumns[item]);
                }
                catch (Exception) { }
            }
            if (clo.Count < 1)
            {
                clo.AddRange(listDefault);
            }
            return clo;
        }

        /// <summary>
        /// ��ȡ���µ�SQL���
        /// </summary>
        /// <param name="updates">Ҫ���µ�����</param>
        /// <param name="conds">������������</param>
        /// <param name="t">ʵ��</param>
        /// <returns>SQL���</returns>
        private String getSql(List<IColumn> updates, List<IColumn> conds, T t)
        {
            validate(updates, conds);
            return String.Format(SqlCst.UPDATE_SQL, mFullTable, getUpdateSql(updates, t), getCondSql(conds, t));
        }

        /// <summary>
        /// ��ȡ���µĲ�����ָ��
        /// </summary>
        /// <param name="updates">Ҫ���µ�����</param>
        /// <param name="conds">������������</param>
        /// <param name="t">ʵ��</param>
        /// <returns>������ָ��</returns>
        private PreparedCmd getPrepare(List<IColumn> updates, List<IColumn> conds, T t)
        {
            validate(updates, conds);
            PreparedCmd preparedSql = new PreparedCmd();
            foreach (IColumn item in conds)
            {
                updates.Remove(item);
            }
            preparedSql.Sql = String.Format(SqlCst.UPDATE_SQL, mFullTable, getUpdatePSql(updates, t, preparedSql.Parameters), getCondPSql(conds, t, preparedSql.Parameters));
            return preparedSql;
        }

        /// <summary>
        /// ��ȡ���µ�SQL��䣬Ҫ���µ�����Ϊ�յ���ΪNULL
        /// </summary>
        /// <param name="updates">Ҫ���µ�����</param>
        /// <param name="conds">������������</param>
        /// <param name="t">ʵ��</param>
        /// <returns>SQL���</returns>
        private String getSqlWithNull(List<IColumn> updates, List<IColumn> conds, T t)
        {
            validate(updates, conds);
            return String.Format(SqlCst.UPDATE_SQL, mFullTable, getUpdateSqlWithNull(updates, t), getCondSql(conds, t));
        }

        /// <summary>
        /// ��ȡ���µĲ�����ָ�Ҫ���µ�����Ϊ�յ���ΪNULL
        /// </summary>
        /// <param name="updates">Ҫ���µ�����</param>
        /// <param name="conds">������������</param>
        /// <param name="t">ʵ��</param>
        /// <returns>������ָ��</returns>
        private PreparedCmd getPrepareWithNull(List<IColumn> updates, List<IColumn> conds, T t)
        {
            validate(updates, conds);
            PreparedCmd preparedSql = new PreparedCmd();
            foreach (IColumn item in conds)
            {
                updates.Remove(item);
            }
            preparedSql.Sql = String.Format(SqlCst.UPDATE_SQL, mFullTable, getUpdatePSqlWithNull(updates, t, preparedSql.Parameters), getCondPSql(conds, t, preparedSql.Parameters));
            return preparedSql;
        }

        /// <summary>
        /// У�飬ʧ�ܻ��׳��쳣
        /// </summary>
        /// <param name="updates">Ҫ���µ�����</param>
        /// <param name="conds">������������</param>
        /// <returns></returns>
        private Boolean validate(List<IColumn> updates, List<IColumn> conds)
        {
            if (conds == null || conds.Count < 1)
            {
                throw new Exception(String.Format("{0} ����ʧ��, {1} û��������ӳ���ֶ�", TAG, mType));
            }
            if (updates == null || updates.Count < 1)
            {
                throw new Exception(String.Format("{0} ����ʧ��, {1} ӳ���ֶ�Ϊ��", TAG, mType));
            }
            return true;
        }

        /// <summary>
        /// ��ȡ����SQL���(WHERE����)
        /// </summary>
        /// <param name="conds">��������</param>
        /// <param name="t">ʵ��</param>
        /// <returns>SQL���</returns>
        private String getCondSql(List<IColumn> conds, T t)
        {
            String condSql = String.Empty;
            foreach (IColumn item in conds)
            {
                String value = item.getSqlValue(t);
                if (value != null)
                {
                    condSql += SqlCst.AND + item.getColumn() + SqlCst.EQUAL + value.ToString();
                }
            }
            if (condSql == String.Empty)
            {
                throw new Exception(String.Format("{0} ����ʧ�ܣ�������������ȫΪ��", TAG));
            }
            return condSql.Substring(SqlCst.AND.Length);
        }

        /// <summary>
        /// ��ȡ�������������(WHERE����)
        /// </summary>
        /// <param name="conds">��������</param>
        /// <param name="t">ʵ��</param>
        /// <param name="parameters">�������ϣ����ɵĲ�������ӵ�����</param>
        /// <returns>SQL���</returns>
        private String getCondPSql(List<IColumn> conds, T t, List<DbParameter> parameters)
        {
            String condSql = String.Empty;
            foreach (IColumn item in conds)
            {
                DbParameter value = item.getDbParameter(t);
                if (value != null)
                {
                    condSql += SqlCst.AND + item.getColumn() + SqlCst.EQUAL + item.getPrepareProp();
                    parameters.Add(value);
                }
            }
            if (condSql == String.Empty)
            {
                throw new Exception(String.Format("{0} ����ʧ�ܣ�������������ȫΪ��", TAG));
            }
            return condSql.Substring(SqlCst.AND.Length);
        }

        private String getUpdateSql(List<IColumn> updates, T t)
        {
            String updateSql = String.Empty;
            foreach (IColumn item in updates)
            {
                String value = item.getSqlValue(t);
                if (value != null)
                {
                    updateSql += SqlCst.SEPARATOR + item.getColumn() + SqlCst.EQUAL + value;
                }
            }
            if (updateSql == String.Empty)
            {
                throw new Exception(String.Format("{0} ����ʧ�ܣ����µ��ֶβ���ȫΪ��", TAG));
            }
            return updateSql.Substring(SqlCst.SEPARATOR.Length);
        }

        private String getUpdatePSql(List<IColumn> updates, T t, List<DbParameter> parameters)
        {
            String updateSql = String.Empty;
            foreach (IColumn item in updates)
            {
                DbParameter value = item.getDbParameter(t);
                if (value != null)
                {
                    updateSql += SqlCst.SEPARATOR + item.getColumn() + SqlCst.EQUAL + item.getPrepareProp();
                    parameters.Add(value);
                }
            }
            if (updateSql == String.Empty)
            {
                throw new Exception(String.Format("{0} ����ʧ�ܣ����µ��ֶβ���ȫΪ��", TAG));
            }
            return updateSql.Substring(SqlCst.SEPARATOR.Length);
        }

        private String getUpdateSqlWithNull(List<IColumn> updates, T t)
        {
            String updateSql = String.Empty;
            foreach (IColumn item in updates)
            {
                String value = item.getSqlValue(t);
                if (value != null)
                {
                    updateSql += SqlCst.SEPARATOR + item.getColumn() + SqlCst.EQUAL + value;
                }
                else
                {
                    updateSql += SqlCst.SEPARATOR + item.getColumn() + SqlCst.EQUAL + SqlCst.NULL;
                }
            }
            if (updateSql == String.Empty)
            {
                throw new Exception(String.Format("{0} ����ʧ�ܣ����µ��ֶβ���ȫΪ��", TAG));
            }
            return updateSql.Substring(SqlCst.SEPARATOR.Length);
        }

        private String getUpdatePSqlWithNull(List<IColumn> updates, T t, List<DbParameter> parameters)
        {
            String updateSql = String.Empty;
            foreach (IColumn item in updates)
            {
                DbParameter value = item.getDbParameter(t);
                if (value != null)
                {
                    updateSql += SqlCst.SEPARATOR + item.getColumn() + SqlCst.EQUAL + item.getPrepareProp();
                    parameters.Add(value);
                }
                else
                {
                    updateSql += SqlCst.SEPARATOR + item.getColumn() + SqlCst.EQUAL + SqlCst.NULL;
                }
            }
            if (updateSql == String.Empty)
            {
                throw new Exception(String.Format("{0} ����ʧ�ܣ����µ��ֶβ���ȫΪ��", TAG));
            }
            return updateSql.Substring(SqlCst.SEPARATOR.Length);
        }

        #endregion

    }
}
