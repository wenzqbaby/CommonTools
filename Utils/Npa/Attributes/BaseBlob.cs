using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.TypeHandler;

namespace Common.Utils.Npa.Attributes
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/6
    /// desc:   �ֽ���������������ע�����ʵ��
    /// </summary>
    public abstract class BaseBlob : BaseColumn
    {
        public BaseBlob()
        {
            this.TypeHandler = BlobTypeHandler.getInstance();
        }
    }
}
