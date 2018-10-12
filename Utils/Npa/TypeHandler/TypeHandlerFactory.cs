using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;

namespace Common.Utils.Npa.TypeHandler
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/7
    /// desc:   类型转换接口工厂
    /// </summary>
    public class TypeHandlerFactory
    {
        private static Dictionary<Type, ITypeHandler> factory = new Dictionary<Type, ITypeHandler>();

        static TypeHandlerFactory()
        {
            factory[typeof(String)] = StringTypeHandler.getInstance();
            factory[typeof(DateTime)] = TimestampTypeHandler.getInstance();
            factory[typeof(Byte[])] = BlobTypeHandler.getInstance();
            factory[typeof(int)] = IntTypeHandler.getInstance();
            factory[typeof(long)] = LongTypeHandler.getInstance();
            factory[typeof(Decimal)] = DecimalTypeHandler.getInstance();
        }

        private TypeHandlerFactory() { }

        public static ITypeHandler get(Type t)
        {
            try
            {
                return factory[t];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
