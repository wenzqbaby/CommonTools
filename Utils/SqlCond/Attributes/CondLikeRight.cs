using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.SqlCond.Attributes
{
    /// <summary>
    /// Created by wenzq on 2018/7/20.
    /// 生成SQL条件组件：模糊查询右模糊
    /// </summary>
    public class CondLikeRight : CondLike
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public CondLikeRight() : base(Common.Utils.SqlCond.Attributes.CondLike.Template.RIGHT) { }
    }
}
