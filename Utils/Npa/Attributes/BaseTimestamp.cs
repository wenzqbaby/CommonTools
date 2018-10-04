using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.TypeHandler;

namespace Common.Utils.Npa.Attributes
{
    public abstract class BaseTimestamp:BaseColumn
    {
        public BaseTimestamp()
        {
            this.TypeHandler = TimestampTypeHandler.getInstance();
        }
    }
}
