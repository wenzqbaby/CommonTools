using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.TypeHandler;

namespace Common.Utils.Npa.Attributes
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/8
    /// desc:   长整型数据列注解抽象实现
    /// </summary>
    public abstract class BaseLong : BaseColumn
    {
        public BaseLong()
        {
            this.TypeHandler = LongTypeHandler.getInstance();
        }
    }
}
