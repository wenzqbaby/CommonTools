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

        #region ISave<T> 成员

        public string getSql(T t)
        {
            List<IColumn> list = new List<IColumn>();
            list.AddRange(mColumns.Values);
            this.valudate(list);
            return getSql(list, t);
        }

        public PreparedCmd getPreparedSql(T t)
        {
            List<IColumn> list = new List<IColumn>();
            list.AddRange(mColumns.Values);
            this.valudate(list);
            return getPreparedSql(list, t);
        }

        #endregion

        #region 私有方法，生成语句方法

        private Boolean valudate(List<IColumn> columns)
        {
            if (columns == null || columns.Count < 1)
            {
                throw new Exception(String.Format("{0} 插入失败, {1} 映射字段为空", TAG, mType));
            }
            return true;
        }

        private String getSql(List<IColumn> columns, T t)
        {
            String columSql = String.Empty;
            String valueSql = String.Empty;
            foreach (IColumn item in columns)
            {
                String value = item.getSqlValue(t);
                if (value != null)
                {
                    columSql += SqlCst.SEPARATOR + item.getColumn();
                    valueSql += SqlCst.SEPARATOR + value;
                }
                else if (item.isIdColumn())
                {
                    throw new Exception(String.Format("{0} 插入失败，{1} 的主键字段属性 {2} 为空", TAG, mType, item.getProp()));
                }
            }
            if (columSql == String.Empty)
            {
                throw new Exception(String.Format("{0} 插入失败，{1} 的所有属性都为空", TAG, mType));
            }
            return String.Format(SqlCst.INSERT_SQL, mFullTable, columSql.Substring(SqlCst.SEPARATOR.Length),
                valueSql.Substring(SqlCst.SEPARATOR.Length));
        }

        private PreparedCmd getPreparedSql(List<IColumn> columns, T t)
        {
            String columSql = String.Empty;
            String valueSql = String.Empty;
            PreparedCmd preparedSql = new PreparedCmd();
            foreach (IColumn item in columns)
            {
                DbParameter value = item.getDbParameter(t);
                if (value != null)
                {
                    columSql += SqlCst.SEPARATOR + item.getColumn();
                    valueSql += SqlCst.SEPARATOR + item.getPrepareProp();
                    preparedSql.Parameters.Add(value);
                }
                else if (item.isIdColumn())
                {
                    throw new Exception(String.Format("{0} 插入失败，{1} 的主键字段属性 {2} 为空", TAG, mType, item.getProp()));
                }
            }
            if (columSql == String.Empty)
            {
                throw new Exception(String.Format("{0} 插入失败，{1} 的所有属性都为空", TAG, mType));
            }
            preparedSql.Sql = String.Format(SqlCst.INSERT_SQL, mTable, columSql.Substring(SqlCst.SEPARATOR.Length),
                valueSql.Substring(SqlCst.SEPARATOR.Length));
            return preparedSql;
        }

        #endregion
    }
}
