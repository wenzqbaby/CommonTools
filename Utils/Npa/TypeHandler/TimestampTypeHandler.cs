using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;

namespace Common.Utils.Npa.TypeHandler
{
    public class TimestampTypeHandler:ITypeHandler
    {
        protected TimestampTypeHandler() { }

        public static TimestampTypeHandler getInstance()
        {
            return SingleTon.getTypeHandler(); 
        }

        private static class SingleTon
        {
            private static TimestampTypeHandler mTypeHandler = new TimestampTypeHandler();

            public static TimestampTypeHandler getTypeHandler()
            {
                return mTypeHandler;
            }
        }

        const String formatStr = @"TIMESTAMP('{0}')";

        #region ITypeHandler ≥…‘±

        public object getResult(System.Data.DataRow dataRow, string columnName)
        {
            return dataRow[columnName].ToString();
        }

        public object formatToDb(object value)
        {
            return String.Format(formatStr, value.ToString());
        }

        public object formatToProp(object dbValue)
        {
            return dbValue.ToString();
        }

        #endregion
    }
}
