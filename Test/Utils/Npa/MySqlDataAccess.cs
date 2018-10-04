using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.DataAccess;
using MySql.Data.MySqlClient;

namespace Test.Utils.Npa
{
    public class MySqlDataAccess : AbstractDataAccess
    {
        private MySqlConnection _Connection;

        public MySqlConnection Connection
        {
            get { return _Connection; }
            set { _Connection = value; }
        }

        public MySqlDataAccess(String connStr)
        {
            this.Connection = new MySqlConnection(connStr);
            this.Connection.Open();
        }

        public override System.Data.Common.DbDataAdapter getAdapter()
        {
            return new MySqlDataAdapter();
        }

        public override System.Data.Common.DbConnection getConnection()
        {
            return this.Connection;
        }
    }
}
