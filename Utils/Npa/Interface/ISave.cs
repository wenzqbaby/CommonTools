using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Npa.Interface
{
    public interface ISave<T>
    {
        int insert(T t);
    }
}
