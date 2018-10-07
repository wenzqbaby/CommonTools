using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Npa.TypeHandler
{
    public class LongTypeHandler : AbstractTypeHandler
    {
        protected LongTypeHandler() { }

        public static LongTypeHandler getInstance()
        {
            return SingleTon.getTypeHandler(); 
        }

        private static class SingleTon
        {
            private static LongTypeHandler mTypeHandler = new LongTypeHandler();

            public static LongTypeHandler getTypeHandler()
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
            return value == null ? null : Convert.ToInt64(value).ToString();
        }

        public override object formatToProp(object dbValue)
        {
            return dbValue == DBNull.Value ? null : Convert.ToInt64(dbValue).ToString();
        }
    }
}
