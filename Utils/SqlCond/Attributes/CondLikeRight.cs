using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.SqlCond.Attributes
{
    /// <summary>
    /// Created by wenzq on 2018/7/20.
    /// ����SQL���������ģ����ѯ��ģ��
    /// </summary>
    public class CondLikeRight : CondLike
    {
        /// <summary>
        /// ���췽��
        /// </summary>
        public CondLikeRight() : base(Common.Utils.SqlCond.Attributes.CondLike.Template.RIGHT) { }
    }
}
