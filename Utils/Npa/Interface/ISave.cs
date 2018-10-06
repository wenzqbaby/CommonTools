using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.cmd;

namespace Common.Utils.Npa.Interface
{
    public interface ISave<T>
    {
        String getSql(T t);

        PreparedCmd getPreparedSql(T t);
    }
}
