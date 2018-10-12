using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Npa.TypeHandler
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/8
    /// desc:   小数类型转换接口实现
    /// </summary>
    public class DecimalTypeHandler : AbstractTypeHandler
    {
        protected DecimalTypeHandler() { }

        public static DecimalTypeHandler getInstance()
        {
            return SingleTon.getTypeHandler(); 
        }

        private static class SingleTon
        {
            private static DecimalTypeHandler mTypeHandler = new DecimalTypeHandler();

            public static DecimalTypeHandler getTypeHandler()
            {
                return mTypeHandler;
            }
        }

        public override object getResult(System.Data.DataRow dataRow, string columnName)
        {
            return formatToProp(dataRow[columnName]);
        }

        public override string formatToSql(object value)
        {
            return value == null ? null : Convert.ToDecimal(value).ToString();
        }

        public override object formatToProp(object dbValue)
        {
            return dbValue == DBNull.Value ? null : Convert.ToDecimal(dbValue).ToString();
        }
    }
}
