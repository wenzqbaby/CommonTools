using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.TypeHandler;
using System.Data.Common;

namespace Common.Utils.Npa.Attributes
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/8
    /// desc:   整型数据列注解抽象实现
    /// </summary>
    public abstract class BaseInt : BaseColumn
    {
        public BaseInt()
        {
            this.TypeHandler = IntTypeHandler.getInstance();
        }
    }
}
