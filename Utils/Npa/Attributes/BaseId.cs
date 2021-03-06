using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;
using Common.Utils.Npa.TypeHandler;

namespace Common.Utils.Npa.Attributes
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/6
    /// desc:   主键数据列注解抽象实现，默认类型为字符串类型
    /// </summary>
    public abstract class BaseId : BaseColumn
    {
        public override bool isIdColumn()
        {
            return true;
        }
    }
}
