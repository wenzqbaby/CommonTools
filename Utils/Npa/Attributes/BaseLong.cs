using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.TypeHandler;

namespace Common.Utils.Npa.Attributes
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/8
    /// desc:   ������������ע�����ʵ��
    /// </summary>
    public abstract class BaseLong : BaseColumn
    {
        public BaseLong()
        {
            this.TypeHandler = LongTypeHandler.getInstance();
        }
    }
}
