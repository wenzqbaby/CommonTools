using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.TypeHandler;

namespace Common.Utils.Npa.Attributes
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/8
    /// desc:   С������������ע�����ʵ��
    /// </summary>
    public abstract class BaseDecimal : BaseColumn
    {
        public BaseDecimal()
        {
            this.TypeHandler = DecimalTypeHandler.getInstance();
        }
    }
}
