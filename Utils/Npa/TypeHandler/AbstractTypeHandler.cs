using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;

namespace Common.Utils.Npa.TypeHandler
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/6
    /// desc:   类型转换接口抽象实现
    /// </summary>
    public abstract class AbstractTypeHandler : ITypeHandler
    {
        #region ITypeHandler 成员

        public abstract object getResult(System.Data.DataRow dataRow, string columnName);

        public virtual object formatProp(object value) {
            return value;
        }

        public abstract string formatToSql(object value);

        public abstract object formatToProp(object dbValue);

        #endregion
    }
}
