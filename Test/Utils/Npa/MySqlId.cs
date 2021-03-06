using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Attributes;
using MySql.Data.MySqlClient;

namespace Test.Utils.Npa
{
    class MySqlId:BaseId
    {
        public override System.Data.Common.DbParameter getDbParameter(object value)
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
