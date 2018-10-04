using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Npa.Interface
{
    public interface IUpdate<T>
    {
        int update(T t);
    }
}
