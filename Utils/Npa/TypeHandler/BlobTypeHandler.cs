using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;

namespace Common.Utils.Npa.TypeHandler
{
    public class BlobTypeHandler : AbstractTypeHandler
    {
        protected BlobTypeHandler() { }

        public static BlobTypeHandler getInstance()
        {
            return SingleTon.getTypeHandler();
        }

        private static class SingleTon
        {
            private static BlobTypeHandler mTypeHandler = new BlobTypeHandler();

            public static BlobTypeHandler getTypeHandler()
            {
                return mTypeHandler;
            }
        }

        #region ITypeHandler ≥…‘±

        public override object getResult(System.Data.DataRow dataRow, string columnName)
        {
            return formatToProp(dataRow[columnName]);
        }

        public override String formatToSql(object value)
        {
            return null;
        }

        public override object formatToProp(object dbValue)
        {
            return dbValue == DBNull.Value ? null : dbValue as Byte[];
        }

        #endregion
    }
}
