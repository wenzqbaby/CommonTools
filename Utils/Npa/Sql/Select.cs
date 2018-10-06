using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;
using Common.Utils.Npa.Cst;
using Common.Utils.Npa.cmd;
using System.Data.Common;

namespace Common.Utils.Npa.Sql
{
    public class Select<T> : BaseSql, ISelect<T>
    {
        private String mSelectSql;
        //private List<IColumn> mIColumn;

        public Select(String scheme, String table, Dictionary<String, IColumn> columnDic, String tag)
            : base(scheme, table, columnDic, null)
        {
            mType = typeof(T);
            TAG = tag;
            //mIColumn = new List<IColumn>();
            //mIColumn.AddRange(columnDic.Values);
            mSelectSql = getSelectColumn(columnDic.Values);
        }

        private String getSelectColumn(ICollection<IColumn> list)
        {
            if (list == null || list.Count < 0)
            {
                throw new Exception("{0} 查询失败，{1} 该类没有配置任何字段属性");
            }
            String column = String.Empty;
            foreach (IColumn item in list)
            {
                column += SqlCst.SEPARATOR + item.getColumn();
            }
            return String.Format(SqlCst.SELECT_SQL, column.Substring(SqlCst.SEPARATOR.Length), mFullTable);
        }

        #region ISelect<T> 成员

        public string find()
        {
            return mSelectSql;
        }

        public PreparedCmd findPrepared()
        {
            PreparedCmd cmd = new PreparedCmd();
            cmd.Sql = mSelectSql;
            return cmd;
        }

        public string find(T t)
        {
            String whereSql = String.Empty;
            foreach (IColumn item in mColumns.Values)
            {
                String value = item.getSqlValue(t);
                if (value != null)
                {
                    whereSql += SqlCst.AND + item.getColumn() + SqlCst.EQUAL + value;
                }
            }
            if (whereSql != String.Empty)
            {
                return mSelectSql + whereSql.Substring(SqlCst.AND.Length);
            }
            return mSelectSql;
        }

        public PreparedCmd findPrepared(T t)
        {
            String whereSql = String.Empty;
            PreparedCmd cmd = new PreparedCmd();
            foreach (IColumn item in mColumns.Values)
            {
                DbParameter value = item.getDbParameter(t);
                if (value != null)
                {
                    whereSql += SqlCst.AND + item.getColumn() + SqlCst.EQUAL + item.getPrepareProp();
                    cmd.Parameters.Add(value);
                }
            }
            cmd.Sql = mSelectSql;
            if (whereSql != String.Empty)
            {
                cmd.Sql += whereSql.Substring(SqlCst.AND.Length);
            }
            return cmd;
        }

        #endregion
    }
}
