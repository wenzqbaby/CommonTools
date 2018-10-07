using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Npa.TypeHandler
{
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
