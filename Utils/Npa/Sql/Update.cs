using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;
using Common.Utils.Npa.Cst;
using System.Data.Common;
using Common.Utils.Npa.cmd;

namespace Common.Utils.Npa.Sql
{
    public class Update<T> : BaseSql, IUpdate<T>
    {
        public Update(String scheme, String table, Dictionary<String, IColumn> columnDic, List<IColumn> idColumns, String tag)
            : base(scheme, table, columnDic, idColumns)
        {
            mType = typeof(T);
            TAG = tag;
        }


        #region IUpdate<T> 成员

        public string getSql(T t)
        {
            if (mColumns == null || mColumns.Count < 1)
            {
                throw new Exception(String.Format("{0} 更新失败, {1} 映射字段为空", TAG, mType));
            }
            String setSql = String.Empty;
            String whereSql = String.Empty;
            if (mIds != null && mIds.Count > 0)
            {
                foreach (IColumn col in mIds)
                {
                    String value = col.getSqlValue(t);
                    if (col.getSqlValue(t) != null)
                    {
                        whereSql += SqlCst.AND + col.getColumn() + SqlCst.EQUAL + value.ToString();
                    }
                }
            }
            else
            {
                throw new Exception(String.Format("{0} 更新失败, {1} 没设置主键映射字段", TAG, mType));
            }

            if (whereSql == String.Empty)
            {
                throw new Exception(String.Format("{0} 更新失败，更新条件不能全为空", TAG));
            }

            foreach (KeyValuePair<String, IColumn> item in mColumns)
            {
                String value = item.Value.getSqlValue(t);
                if (value != null)
                {
                    setSql += SqlCst.SEPARATOR + item.Value.getColumn() + SqlCst.EQUAL + value.ToString();
                }
            }

            if (setSql == String.Empty)
            {
                throw new Exception(String.Format("{0} 更新失败，更新的字段不能全为空", TAG));
            }
            return String.Format(SqlCst.UPDATE_SQL, mFullTable, setSql.Substring(SqlCst.SEPARATOR.Length),
                whereSql.Substring(SqlCst.AND.Length));
        }

        public PreparedSql getPreparedSql(T t)
        {
            if (mColumns == null || mColumns.Count < 1)
            {
                throw new Exception(String.Format("{0} 更新失败, {1} 映射字段为空", TAG, mType));
            }
            String setSql = String.Empty;
            String whereSql = String.Empty;
            PreparedSql preparedSql = new PreparedSql();
            if (mIds != null && mIds.Count > 0)
            {
                foreach (IColumn col in mIds)
                {
                    DbParameter value = col.getDbParameter(t);
                    if (col.getSqlValue(t) != null)
                    {
                        whereSql += SqlCst.AND + col.getColumn() + SqlCst.EQUAL + col.getPrepareProp();
                        preparedSql.Parameters.Add(value);
                    }
                }
            }
            else
            {
                throw new Exception(String.Format("{0} 更新失败, {1} 没设置主键映射字段", TAG, mType));
            }

            if (whereSql == String.Empty)
            {
                throw new Exception(String.Format("{0} 更新失败，更新条件不能全为空", TAG));
            }

            foreach (KeyValuePair<String, IColumn> item in mColumns)
            {
                if (item.Value.isIdColumn())
                {
                    continue;
                }
                DbParameter value = item.Value.getDbParameter(t);
                if (value != null)
                {
                    setSql += SqlCst.SEPARATOR + item.Value.getColumn() + SqlCst.EQUAL + item.Value.getPrepareProp();
                    preparedSql.Parameters.Add(value);
                }
            }

            if (setSql == String.Empty)
            {
                throw new Exception(String.Format("{0} 更新失败，更新的字段不能全为空", TAG));
            }
            preparedSql.Sql = String.Format(SqlCst.UPDATE_SQL, mFullTable, setSql.Substring(SqlCst.SEPARATOR.Length),
                whereSql.Substring(SqlCst.AND.Length));
            return preparedSql;
        }

        public string getSqlWithNull(T t)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public PreparedSql getPSqlWithNull(T t)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
