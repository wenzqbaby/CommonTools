using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.SqlCond.Attributes
{
    /// <summary>
    /// Created by wenzq on 2018/7/20.
    /// 生成SQL条件组件：模糊查询左模糊
    /// </summary>
    public class CondLikeLeft : CondLike
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public CondLikeLeft() : base(Common.Utils.SqlCond.Attributes.CondLike.Template.LEFT) { }
    }
}
