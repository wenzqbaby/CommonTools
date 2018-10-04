using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;
using Common.Utils.Npa.TypeHandler;

namespace Common.Utils.Npa.Attributes
{
    public abstract class BaseId : BaseColumn
    {
        public override bool isIdColumn()
        {
            return true;
        }
    }
}
