using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Attributes;
using MySql.Data.MySqlClient;

namespace Test.Utils.Npa
{
    public class MySqlTimestamp : BaseTimestamp
    {
        public override System.Data.Common.DbParameter getDbParameter(object value)
        {
            System.Data.Common.DbParameter parameter = new MySqlParameter(getPrepareProp(), MySqlDbType.Timestamp);
            parameter.Value = value;
            return parameter;
        }
    }
}
