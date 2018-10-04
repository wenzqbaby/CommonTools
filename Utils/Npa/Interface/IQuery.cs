using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Npa.Interface
{
    public interface IQuery<T>
    {
        T get(T t);

        List<T> find(T t);
    }
}
