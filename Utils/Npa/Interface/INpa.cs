using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Npa.Interface
{
    public interface INpa<T>
    {
        void update(T t);
    }
}
