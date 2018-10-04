using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;
using System.Data.Common;
using System.Data;

namespace Common.Utils.Npa.DataAccess
{
    public abstract class AbstractDataAccess:IDataAccess
    {
        public abstract DbConnection getConnection();

        public abstract DbDataAdapter getAdapter();

        public virtual DbCommand getCmd()
        {
            return this.getConnection().CreateCommand();
        }

        #region IDataAccess ≥…‘±

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
                using (DbDataAdapter adapter = getAdapter())
                {
                    adapter.InsertCommand = cmd;
                    if (parameters != null)
                    {
                        adapter.InsertCommand.Parameters.AddRange(parameters);
                    }
                    return adapter.InsertCommand.ExecuteNonQuery();
                }
            }
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
                using (DbDataAdapter adapter = getAdapter())
                {
                    adapter.DeleteCommand = cmd;
                    if (parameters != null)
                    {
                        adapter.DeleteCommand.Parameters.AddRange(parameters);
                    }
                    return adapter.DeleteCommand.ExecuteNonQuery();
                }
            }
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
                using (DbDataAdapter adapter = getAdapter())
                {
                    adapter.UpdateCommand = cmd;
                    if (parameters != null)
                    {
                        adapter.UpdateCommand.Parameters.AddRange(parameters);
                    }
                    return adapter.UpdateCommand.ExecuteNonQuery();
                }
            }
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
                cmd.CommandText = preparedSql;
                using (DbDataAdapter adapter = getAdapter())
                {
                    adapter.SelectCommand = cmd;
                    if (parameters != null)
                    {
                        adapter.SelectCommand.Parameters.AddRange(parameters);
                    }
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds;
                }
            }
        }

        #endregion 
    }
}
