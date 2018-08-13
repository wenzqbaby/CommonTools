using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Reflection;

namespace Common.Utils.SqlCond.Attributes
{
    /// <summary>
    /// Created by dengyq on 2018/7/20.
    /// 生成SQL条件组件：Between
    /// 使用该注解的属性类型必须为Common.Utils.SQLCond.CondAttribute.CondBetween.Holder，否则无效
    /// </summary>
    public class CondBetween : BaseCond
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public CondBetween() : base("BETWEEN") { }

        /// <summary>
        /// 格式化值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override string formatValue(object value)
        {
            if (value == null || !(value is Holder))
            {
                return null;
            }
            try
            {
                object valueMax = value.GetType().GetProperty("Max").GetValue(value, null);
                if (valueMax == null || String.IsNullOrEmpty(valueMax.ToString()))
                {
                    return null;
                }
                object valueMin = value.GetType().GetProperty("Min").GetValue(value, null);

                if (valueMin == null || String.IsNullOrEmpty(valueMin.ToString()))
                {
                    return null;
                }

                return string.Format(@"{0} and {1}", base.formatValue(valueMin.ToString()), base.formatValue(valueMax.ToString()));
            }
            catch (Exception)
            {
            }
            return null;
        }

        /// <summary>
        /// Between实体，用于CondSql功能
        /// </summary>
        public class Holder
        {
            private Object min;
            /// <summary>
            /// 小于
            /// </summary>
            public Object Min
            {
                get { return min; }
                set { min = value; }
            }

            private Object max;
            /// <summary>
            /// 大于
            /// </summary>
            public Object Max
            {
                get { return max; }
                set { max = value; }
            }
        }
    }

    
}
