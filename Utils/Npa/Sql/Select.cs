using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;
using Common.Utils.Npa.Cst;
using Common.Utils.Npa.Cmd;
using System.Data.Common;

namespace Common.Utils.Npa.Sql
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/6
    /// desc:   查询语句获取接口实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
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
                return mSelectSql + String.Format(SqlCst.COND_SQL, whereSql.Substring(SqlCst.AND.Length));
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
                cmd.Sql += String.Format(SqlCst.COND_SQL, whereSql.Substring(SqlCst.AND.Length));
            }
            return cmd;
        }

        public string findById(T t)
        {
            String whereSql = String.Empty;
            foreach (IColumn item in mIds)
            {
                String value = item.getSqlValue(t);
                if (value == null)
                {
                    throw new Exception(String.Format("{0} 根据ID查询出错，主键属性 {1} 不能为空", TAG, item.getProp()));
                }
                whereSql += SqlCst.AND + item.getColumn() + SqlCst.EQUAL + value;
            }
            if (String.IsNullOrEmpty(whereSql))
            {
                throw new Exception(String.Format("{0} 根据ID查询记录数主键属性条件不能为空", TAG));
            }
            return mSelectSql + String.Format(SqlCst.COND_SQL, whereSql.Substring(SqlCst.AND.Length));
        }

        public PreparedCmd findPreparedById(T t)
        {
            String whereSql = String.Empty;
            PreparedCmd cmd = new PreparedCmd();
            foreach (IColumn item in mIds)
            {
                DbParameter value = item.getDbParameter(t);
                if (value == null)
                {
                    throw new Exception(String.Format("{0} 根据ID查询出错，主键属性 {1} 不能为空", TAG, item.getProp()));
                }
                whereSql += SqlCst.AND + item.getColumn() + SqlCst.EQUAL + item.getPrepareProp();
                cmd.Parameters.Add(value);
            }
            if (String.IsNullOrEmpty(whereSql))
            {
                throw new Exception(String.Format("{0} 根据ID查询记录数主键属性条件不能为空", TAG));
            }
            cmd.Sql = mSelectSql + String.Format(SqlCst.COND_SQL, whereSql.Substring(SqlCst.AND.Length));
            return cmd;
        }

        #endregion
    }
}
