using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;
using System.Data.Common;
using System.Data;
using Common.Utils.Npa.Cmd;
using log4net;

namespace Common.Utils.Npa.DataAccess
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/5
    /// desc:   数据访问接口抽象实现
    /// </summary>
    public abstract class AbstractDataAccess : IDataAccess
    {
        protected ILog log;

        private DbTransaction _transaction;

        protected DbTransaction Transaction
        {
            get { return _transaction; }
            set { _transaction = value; }
        }

        public AbstractDataAccess() 
        {
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        private void logCmd(DbCommand cmd)
        {
            if (cmd != null)
            {
                if (cmd.CommandText != null)
                {
                    log.Info(String.Format("==>  Preparing: {0}", cmd.CommandText));
                }
                if (cmd.Parameters != null && cmd.Parameters.Count > 1)
                {
                    String msg = String.Empty;
                    foreach (DbParameter p in cmd.Parameters)
                    {
                        msg += string.Format("{0}={1}({2}), ", p.ParameterName, p.Value, p.DbType);
                    }
                    if (msg != String.Empty)
                    {
                        log.Info(String.Format("==> Parameters: {0}", msg.Substring(0, msg.Length - 2)));
                    }
                }
            }
        }

        public abstract DbConnection getConnection();

        public abstract DbDataAdapter getAdapter();

        public virtual DbCommand getCmd()
        {
            return this.getConnection().CreateCommand();
        }

        #region IDataAccess 成员

        public virtual int insert(string sql)
        {
            return this.insert(sql, null);
        }

        public virtual int insert(List<DbParameter> parameters, string preparedSql)
        {
            return this.insert(preparedSql, parameters.ToArray());
        }

        public virtual int insert(string preparedSql, params DbParameter[] parameters)
        {
            using (DbCommand cmd = this.getCmd())
            {
                cmd.CommandText = preparedSql;
                if (getTrans() != null)
                {
                    cmd.Transaction = getTrans();
                }
                using (DbDataAdapter adapter = getAdapter())
                {
                    adapter.InsertCommand = cmd;
                    if (parameters != null)
                    {
                        adapter.InsertCommand.Parameters.AddRange(parameters);
                    }
                    logCmd(adapter.InsertCommand);
                    return adapter.InsertCommand.ExecuteNonQuery();
                }
            }
        }

        public virtual int insert(PreparedCmd cmd)
        {
            return this.insert(cmd.Parameters, cmd.Sql);
        }

        public virtual int delete(string sql)
        {
            return this.delete(sql, null);
        }

        public virtual int delete(List<DbParameter> parameters, string preparedSql)
        {
            return this.delete(preparedSql, parameters.ToArray());
        }

        public virtual int delete(String preparedSql, params DbParameter[] parameters)
        {
            using (DbCommand cmd = this.getCmd())
            {
                cmd.CommandText = preparedSql;
                if (getTrans() != null)
                {
                    cmd.Transaction = getTrans();
                }
                using (DbDataAdapter adapter = getAdapter())
                {
                    adapter.DeleteCommand = cmd;
                    if (parameters != null)
                    {
                        adapter.DeleteCommand.Parameters.AddRange(parameters);
                    }
                    logCmd(adapter.DeleteCommand);
                    return adapter.DeleteCommand.ExecuteNonQuery();
                }
            }
        }

        public virtual int delete(PreparedCmd cmd)
        {
            return this.delete(cmd.Parameters, cmd.Sql);
        }

        public virtual int update(string sql)
        {
            return this.update(sql, null);
        }

        public virtual int update(List<DbParameter> parameters, string preparedSql)
        {
            return this.update(preparedSql, parameters.ToArray());
        }

        public virtual int update(String preparedSql, params DbParameter[] parameters)
        {
            using (DbCommand cmd = this.getCmd())
            {
                cmd.CommandText = preparedSql;
                if (getTrans() != null)
                {
                    cmd.Transaction = getTrans();
                }
                using (DbDataAdapter adapter = getAdapter())
                {
                    adapter.UpdateCommand = cmd;
                    if (parameters != null)
                    {
                        adapter.UpdateCommand.Parameters.AddRange(parameters);
                    }
                    logCmd(adapter.UpdateCommand);
                    return adapter.UpdateCommand.ExecuteNonQuery();
                }
            }
        }

        public virtual int update(PreparedCmd cmd)
        {
            return this.update(cmd.Parameters, cmd.Sql);
        }

        public virtual DataSet select(string sql)
        {
            return this.select(sql, null);
        }

        public virtual DataSet select(List<DbParameter> parameters, string preparedSql)
        {
            return this.select(preparedSql, parameters.ToArray());
        }

        public virtual DataSet select(String preparedSql, params DbParameter[] parameters)
        {
            using (DbCommand cmd = this.getCmd())
            {
                if (getTrans() != null)
                {
                    cmd.Transaction = getTrans();
                }
                cmd.CommandText = preparedSql;
                using (DbDataAdapter adapter = getAdapter())
                {
                    adapter.SelectCommand = cmd;
                    if (parameters != null)
                    {
                        adapter.SelectCommand.Parameters.AddRange(parameters);
                    }
                    logCmd(adapter.SelectCommand);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds;
                }
            }
        }

        public virtual DataSet select(PreparedCmd cmd)
        {
            return this.select(cmd.Parameters, cmd.Sql);
        }

        public void setLog(Type t)
        {
            log = LogManager.GetLogger(t);
        }

        public virtual DbTransaction getTrans()
        {
            return this.Transaction;
        }

        public virtual void beginTrans()
        {
            try
            {
                this.Transaction = getConnection().BeginTransaction(IsolationLevel.ReadCommitted);
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                this.rollBack();
                this.Transaction = getConnection().BeginTransaction(IsolationLevel.ReadCommitted);
            }
        }

        public virtual void commit()
        {
            try
            {
                this.Transaction.Commit();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
        }

        public virtual void rollBack()
        {
            try
            {
                this.Transaction.Rollback();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw;
            }
        }

        #endregion
    }
}
