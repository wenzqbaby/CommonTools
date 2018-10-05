using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;
using Common.Utils.Npa.Cst;
using Common.Utils.Npa.cmd;
using System.Data.Common;

namespace Common.Utils.Npa.Sql
{
    public class Insert<T> : BaseSql, ISave<T>
    {
        public Insert(String scheme, String table, Dictionary<String, IColumn> columnDic, List<IColumn> idColumns, String tag)
            : base(scheme, table, columnDic, idColumns)
        {
            mType = typeof(T);
            TAG = tag;
        }

        private Boolean valudate(T t)
        {
            if (mIds != null && mIds.Count > 0)
            {
                foreach (IColumn col in mIds)
                {
                    if (col.getSqlValue(t) == null)
                    {
                        throw new Exception(String.Format("{0} ����ʧ�ܣ�{1} �������ֶ����� {2} Ϊ��", TAG, mType, col.getProp()));
                    }
                }
            }
            if ((mIds == null || mIds.Count < 1) && (mColumns == null || mColumns.Count < 1))
            {
                throw new Exception(String.Format("{0}����ʧ��, {1} ӳ���ֶ�Ϊ��", TAG, mType));
            }
            return true;
        }

        #region ISave<T> ��Ա

        public string getSql(T t)
        {
            this.valudate(t);
            String columSql = String.Empty;
            String valueSql = String.Empty;
            foreach (KeyValuePair<String, IColumn> item in mColumns)
            {
                String value = item.Value.getSqlValue(t);
                if (value != null)
                {
                    columSql += SqlCst.SEPARATOR + item.Value.getColumn();
                    valueSql += SqlCst.SEPARATOR + value;
                }
            }
            if (columSql == String.Empty)
            {
                throw new Exception(String.Format("{0}����ʧ�ܣ�{1} ���������Զ�Ϊ��", TAG, mType));
            }
            return String.Format(SqlCst.INSERT_SQL, mFullTable, columSql.Substring(SqlCst.SEPARATOR.Length),
                valueSql.Substring(SqlCst.SEPARATOR.Length));
        }

        public PreparedSql getPreparedSql(T t)
        {
            this.valudate(t);
            String columSql = String.Empty;
            String valueSql = String.Empty;
            PreparedSql preparedSql = new PreparedSql();
            foreach (KeyValuePair<String, IColumn> item in mColumns)
            {
                DbParameter value = item.Value.getDbParameter(t);
                if (value != null)
                {
                    columSql += SqlCst.SEPARATOR + item.Value.getColumn();
                    valueSql += SqlCst.SEPARATOR + item.Value.getPrepareProp();
                    preparedSql.Parameters.Add(value);
                }
            }
            if (columSql == String.Empty)
            {
                throw new Exception(String.Format("{0}����ʧ�ܣ�{1} ���������Զ�Ϊ��", TAG, mType));
            }
            preparedSql.Sql = String.Format(SqlCst.INSERT_SQL, mTable, columSql.Substring(SqlCst.SEPARATOR.Length),
                valueSql.Substring(SqlCst.SEPARATOR.Length));
            return preparedSql;
        }

        #endregion
    }
}
