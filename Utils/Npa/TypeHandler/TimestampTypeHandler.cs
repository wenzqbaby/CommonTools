using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;

namespace Common.Utils.Npa.TypeHandler
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/5
    /// desc:   时间类型转换接口实现
    /// </summary>
    public class TimestampTypeHandler : AbstractTypeHandler
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
        const String LONG_TIME = @"yyyy-MM-dd HH:mm:ss";

        #region AbstractTypeHandler 成员

        public override object getResult(System.Data.DataRow dataRow, string columnName)
        {
            return formatToProp(dataRow[columnName]);
        }

        public override String formatToSql(object value)
        {
            return value == null ? null : String.Format(formatStr, Convert.ToDateTime(value.ToString()).ToString(LONG_TIME));
        }

        public override object formatToProp(object dbValue)
        {
            return dbValue == DBNull.Value ? null : Convert.ToDateTime(dbValue.ToString()).ToString(LONG_TIME);
        }

        #endregion
    }
}
