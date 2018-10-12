using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Npa.TypeHandler
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/8
    /// desc:   整形类型转换接口实现
    /// </summary>
    public class IntTypeHandler : AbstractTypeHandler
    {
        protected IntTypeHandler() { }

        public static IntTypeHandler getInstance()
        {
            return SingleTon.getTypeHandler(); 
        }

        private static class SingleTon
        {
            private static IntTypeHandler mTypeHandler = new IntTypeHandler();

            public static IntTypeHandler getTypeHandler()
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
            return value == null ? null : Convert.ToInt32(value).ToString();
        }

        public override object formatToProp(object dbValue)
        {
            return dbValue == DBNull.Value ? null : Convert.ToInt32(dbValue).ToString();
        }
    }
}
