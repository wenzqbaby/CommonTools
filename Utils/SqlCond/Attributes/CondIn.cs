using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.SqlCond.Attributes
{
    /// <summary>
    /// Created by wenzq on 2018/7/20.
    /// 生成SQL条件组件：IN
    /// 该注解只支持属性类型为<![CDATA[ List<String> ]]> 和String[]
    /// </summary>
    public class CondIn : BaseCond
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public CondIn() : base("IN") { }

        /// <summary>
        /// 格式化值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override string formatValue(object value)
        {
            if (value == null)
            {
                return null;
            }
            String result = String.Empty;
            try
            {
                List<String> list = value as List<String>;
                if (list== null || list.Count < 1)
                {
                    return null;
                }
                foreach (String s in list)
                {
                    if (String.IsNullOrEmpty(s))
                    {
                        continue;
                    }
                    result += String.Format("'{0}',", s);
                }
                return String.Format("({0})", result.Substring(0, result.Length - 1));
            }
            catch (Exception) { }

            try
            {
                String[] array = value as String[];
                if (array == null || array.Length < 1)
                {
                    return null;
                }
                foreach (String s in array)
                {
                    if (String.IsNullOrEmpty(s))
                    {
                        continue;
                    }
                    result += String.Format("'{0}',", s);
                }
                return String.Format("({0})", result.Substring(0, result.Length - 1));
            }
            catch (Exception) { }
            return null;
        }
    }
}
