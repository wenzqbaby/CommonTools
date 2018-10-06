using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;
using Common.Utils.Npa.Cst;
using Common.Utils.Npa.cmd;
using System.Data.Common;

namespace Common.Utils.Npa.Sql
{
    public class Delete<T> : BaseSql, IDelete<T>
    {
        public Delete(String scheme, String table, Dictionary<String, IColumn> columnDic, List<IColumn> idColumns, String tag)
            : base(scheme, table, columnDic, idColumns)
        {
            mType = typeof(T);
            TAG = tag;
        }

        #region IDelete<T> 成员

        public string getSql(T t)
        {
            validate(mIds);
            String condSql = String.Empty;
            foreach (IColumn item in mIds)
            {
                String value = item.getSqlValue(t);
                if (value != null)
                {
                    condSql += SqlCst.AND + item.getColumn() + SqlCst.EQUAL + value;
                }
            }
            if (condSql == String.Empty)
            {
                throw new Exception(String.Format("{0} 删除失败，{1} 所有主键属性都为空", TAG, mType));
            }
            return String.Format(SqlCst.DELETE_SQL, mFullTable, condSql.Substring(SqlCst.AND.Length));
        }

        public PreparedCmd getPreparedSql(T t)
        {
            validate(mIds);
            String condSql = String.Empty;
            PreparedCmd cmd = new PreparedCmd();
            foreach (IColumn item in mIds)
            {
                DbParameter value = item.getDbParameter(t);
                if (value != null)
                {
                    condSql += SqlCst.AND + item.getColumn() + SqlCst.EQUAL + item.getPrepareProp();
                    cmd.Parameters.Add(value);
                }
            }
            if (condSql == String.Empty)
            {
                throw new Exception(String.Format("{0} 删除失败，{1} 所有主键属性都为空", TAG, mType));
            }
            cmd.Sql = String.Format(SqlCst.DELETE_SQL, mFullTable, condSql.Substring(SqlCst.AND.Length));
            return cmd;
        }

        #endregion

        private Boolean validate(List<IColumn> list)
        {
            if (list == null || list.Count < 1)
            {
                throw new Exception(String.Format("{0} 删除失败, {1} 没设置主键映射字段", TAG, mType));
            }
            return true;
        }
    }
}
