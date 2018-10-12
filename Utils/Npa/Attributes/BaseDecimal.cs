using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.TypeHandler;

namespace Common.Utils.Npa.Attributes
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/8
    /// desc:   小数类型数据列注解抽象实现
    /// </summary>
    public abstract class BaseDecimal : BaseColumn
    {
        public BaseDecimal()
        {
            this.TypeHandler = DecimalTypeHandler.getInstance();
        }
    }
}
