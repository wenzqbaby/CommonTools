using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.cmd;

namespace Common.Utils.Npa.Interface
{
    public interface IDelete<T>
    {
        String getSql(T t);

        PreparedCmd getPreparedSql(T t);
    }
}
