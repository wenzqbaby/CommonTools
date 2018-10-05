using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;

namespace Common.Utils.Npa.TypeHandler
{
    public class BlobTypeHandler : ITypeHandler
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

        public virtual object getResult(System.Data.DataRow dataRow, string columnName)
        {
            return dataRow[columnName] as Byte[];
        }

        public virtual String formatToSql(object value)
        {
            return null;
        }

        public virtual object formatToProp(object dbValue)
        {
            return dbValue as Byte[];
        }

        #endregion
    }
}
