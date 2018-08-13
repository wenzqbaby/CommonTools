using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.SqlCond.Attributes
{
    /// <summary>
    /// Created by wenzq on 2018/7/20.
    /// 生成SQL条件组件：大于等于
    /// </summary>
    public class CondEgt: BaseCond
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public CondEgt():base(">=") { }
    }
}
