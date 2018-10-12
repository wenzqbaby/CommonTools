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
    /// desc:   更新语句获取接口实现
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
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

        #region 私有方法，生成语句方法

        /// <summary>
        /// 通过属性名获取数据列接口, 若为空则返回默认
        /// </summary>
        /// <param name="list">属性名集合</param>
        /// <param name="listDefault">默认数据列</param>
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
        /// 获取更新的SQL语句
        /// </summary>
        /// <param name="updates">要更新的属性</param>
        /// <param name="conds">更新条件属性</param>
        /// <param name="t">实体</param>
        /// <returns>SQL语句</returns>
        private String getSql(List<IColumn> updates, List<IColumn> conds, T t)
        {
            validate(updates, conds);
            return String.Format(SqlCst.UPDATE_SQL, mFullTable, getUpdateSql(updates, t), getCondSql(conds, t));
        }

        /// <summary>
        /// 获取更新的参数化指令
        /// </summary>
        /// <param name="updates">要更新的属性</param>
        /// <param name="conds">更新条件属性</param>
        /// <param name="t">实体</param>
        /// <returns>参数化指令</returns>
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
        /// 获取更新的SQL语句，要更新的属性为空的设为NULL
        /// </summary>
        /// <param name="updates">要更新的属性</param>
        /// <param name="conds">更新条件属性</param>
        /// <param name="t">实体</param>
        /// <returns>SQL语句</returns>
        private String getSqlWithNull(List<IColumn> updates, List<IColumn> conds, T t)
        {
            validate(updates, conds);
            return String.Format(SqlCst.UPDATE_SQL, mFullTable, getUpdateSqlWithNull(updates, t), getCondSql(conds, t));
        }

        /// <summary>
        /// 获取更新的参数化指令，要更新的属性为空的设为NULL
        /// </summary>
        /// <param name="updates">要更新的属性</param>
        /// <param name="conds">更新条件属性</param>
        /// <param name="t">实体</param>
        /// <returns>参数化指令</returns>
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
        /// 校验，失败会抛出异常
        /// </summary>
        /// <param name="updates">要更新的属性</param>
        /// <param name="conds">更新条件属性</param>
        /// <returns></returns>
        private Boolean validate(List<IColumn> updates, List<IColumn> conds)
        {
            if (conds == null || conds.Count < 1)
            {
                throw new Exception(String.Format("{0} 更新失败, {1} 没设置主键映射字段", TAG, mType));
            }
            if (updates == null || updates.Count < 1)
            {
                throw new Exception(String.Format("{0} 更新失败, {1} 映射字段为空", TAG, mType));
            }
            return true;
        }

        /// <summary>
        /// 获取条件SQL语句(WHERE后面)
        /// </summary>
        /// <param name="conds">条件属性</param>
        /// <param name="t">实体</param>
        /// <returns>SQL语句</returns>
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
                throw new Exception(String.Format("{0} 更新失败，更新条件不能全为空", TAG));
            }
            return condSql.Substring(SqlCst.AND.Length);
        }

        /// <summary>
        /// 获取条件参数化语句(WHERE后面)
        /// </summary>
        /// <param name="conds">条件属性</param>
        /// <param name="t">实体</param>
        /// <param name="parameters">参数集合，生成的参数会添加到这里</param>
        /// <returns>SQL语句</returns>
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
                throw new Exception(String.Format("{0} 更新失败，更新条件不能全为空", TAG));
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
                throw new Exception(String.Format("{0} 更新失败，更新的字段不能全为空", TAG));
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
                throw new Exception(String.Format("{0} 更新失败，更新的字段不能全为空", TAG));
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
                throw new Exception(String.Format("{0} 更新失败，更新的字段不能全为空", TAG));
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
                throw new Exception(String.Format("{0} 更新失败，更新的字段不能全为空", TAG));
            }
            return updateSql.Substring(SqlCst.SEPARATOR.Length);
        }

        #endregion

    }
}
