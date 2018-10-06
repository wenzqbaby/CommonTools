using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Common.Utils.Npa.Interface
{
    public interface IGenerate<T>
    {
        T get(DataSet ds);

        List<T> getList(DataSet ds);
    }
}
