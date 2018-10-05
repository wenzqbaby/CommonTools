using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Attributes;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace Test.Utils.Npa
{
    class MySqlBlob : BaseBlob
    {
        public override DbParameter getDbParameter(object value)
        {
            Object val = getValue(value);
            if (val == null)
            {
                return null;
            }
            System.Data.Common.DbParameter parameter = new MySqlParameter(getPrepareProp(), MySqlDbType.Blob);
            parameter.Value = val;
            return parameter;
        }
    }
}
