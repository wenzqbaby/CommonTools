using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Npa.Interface
{
    public interface IDelete<T>
    {
        int delete(T t);
    }
}
