using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.SqlCond.Enum;

namespace Common.Utils.SqlCond.Attributes
{
    /// <summary>
    /// Created by wenzq on 2018/7/20.
    /// 生成SQL条件组件：NULL
    /// </summary>
    public class CondNull : BaseCond
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public CondNull():base("IS") { }
        
        /// <summary>
        /// 格式化值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override string formatValue(object value)
        {
            return "NULL";
        }
    }
}
