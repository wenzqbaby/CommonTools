using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;

namespace Common.Utils.Npa.TypeHandler
{
    public class StringTypeHandler : ITypeHandler
    {
        protected StringTypeHandler() { }

        public static StringTypeHandler getInstance()
        {
            return SingleTon.getTypeHandler(); 
        }

        private static class SingleTon
        {
            private static StringTypeHandler mTypeHandler = new StringTypeHandler();

            public static StringTypeHandler getTypeHandler()
            {
                return mTypeHandler;
            }
        }


        #region ITypeHandler ≥…‘±

        public object getResult(System.Data.DataRow dataRow, string columnName)
        {
            return dataRow[columnName].ToString();
        }

        public object formatToDb(object value)
        {
            return value.ToString().Replace("'", "''");
        }

        public object formatToProp(object dbValue)
        {
            return dbValue.ToString();
        }

        #endregion
    }
}
