using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Attributes;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace Test.Utils.Npa
{
    public class MySqlKv : BaseKv
    {
        public MySqlKv(params String[] kvs):base(kvs) { }

        public override DbParameter getDbParameter(object value)
        {
            Object val = getValue(value);
            if (val == null)
            {
                return null;
            }
            System.Data.Common.DbParameter parameter = new MySqlParameter(getPrepareProp(), MySqlDbType.VarChar);
            parameter.Value = val;
            return parameter;
        }
    }
}
