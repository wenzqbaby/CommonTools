using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.TypeHandler;

namespace Common.Utils.Npa.Attributes
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/6
    /// desc:   字节数组类型数据列注解抽象实现
    /// </summary>
    public abstract class BaseBlob : BaseColumn
    {
        public BaseBlob()
        {
            this.TypeHandler = BlobTypeHandler.getInstance();
        }
    }
}
