using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;

namespace Common.Utils.Npa.TypeHandler
{
    public class StringTypeHandler : AbstractTypeHandler
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

        const String POINT = "'";
        const String POINT_DOUBLIC = "''";

        #region AbstractTypeHandler ≥…‘±

        public override object getResult(System.Data.DataRow dataRow, string columnName)
        {
            return formatToProp(dataRow[columnName]);
        }

        public override String formatToSql(object value)
        {
            if (value == null)
            {
                return null;
            }

            return POINT + value.ToString().Replace(POINT, POINT_DOUBLIC) + POINT;
        }

        public override object formatToProp(object dbValue)
        {
            return dbValue == DBNull.Value ? null : dbValue.ToString();
        }

        #endregion
    }
}
