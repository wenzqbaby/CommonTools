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
    /// date:   2018/10/8
    /// desc:   ��ѯ��������ȡ�ӿ�ʵ��
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Count<T> : BaseSql, ICount<T>
    {
        private String CSQL;

        public Count(String scheme, String table, Dictionary<String, IColumn> columnDic, List<IColumn> idColumns, String tag)
            : base(scheme, table, columnDic, idColumns)
        {
            mType = typeof(T);
            TAG = tag;
            CSQL = String.Format(SqlCst.COUNT_SQL, mFullTable);
        }

        #region ICount<T> ��Ա

        public string count(T t)
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
                return CSQL + String.Format(SqlCst.COND_SQL, whereSql.Substring(SqlCst.AND.Length));
            }
            return CSQL;
        }

        public PreparedCmd countPrepared(T t)
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
            if (whereSql != String.Empty)
            {
                cmd.Sql = CSQL + String.Format(SqlCst.COND_SQL, whereSql.Substring(SqlCst.AND.Length));
            }
            else
            {
                cmd.Sql = CSQL;
            }
            return cmd;
        }

        public string countById(T t)
        {
            String whereSql = String.Empty;
            foreach (IColumn item in mIds)
            {
                String value = item.getSqlValue(t);
                if (value == null)
                {
                    throw new Exception(String.Format("{0} ����ID��ѯ��¼�������������� {1} ����Ϊ��", TAG, item.getProp()));
                }
                whereSql += SqlCst.AND + item.getColumn() + SqlCst.EQUAL + value;
            }
            if (String.IsNullOrEmpty(whereSql))
            {
                throw new Exception(String.Format("{0} ����ID��ѯ��¼������������������Ϊ��", TAG));
            }
            return CSQL + String.Format(SqlCst.COND_SQL, whereSql.Substring(SqlCst.AND.Length));
        }

        public PreparedCmd countPreparedById(T t)
        {
            String whereSql = String.Empty;
            PreparedCmd cmd = new PreparedCmd();
            foreach (IColumn item in mIds)
            {
                DbParameter value = item.getDbParameter(t);
                if (value == null)
                {
                    throw new Exception(String.Format("{0} ����ID��ѯ��¼�������������� {1} ����Ϊ��", TAG, item.getProp()));
                }
                whereSql += SqlCst.AND + item.getColumn() + SqlCst.EQUAL + item.getPrepareProp();
                cmd.Parameters.Add(value);
            }
            if (String.IsNullOrEmpty(whereSql))
            {
                throw new Exception(String.Format("{0} ����ID��ѯ��¼������������������Ϊ��", TAG));
            }
            cmd.Sql = CSQL + String.Format(SqlCst.COND_SQL, whereSql.Substring(SqlCst.AND.Length));
            return cmd;
        }

        #endregion
    }
}
