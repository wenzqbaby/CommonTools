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
    /// desc:   ����������ע�����ʵ��
    /// </summary>
    public abstract class BaseInt : BaseColumn
    {
        public BaseInt()
        {
            this.TypeHandler = IntTypeHandler.getInstance();
        }
    }
}
