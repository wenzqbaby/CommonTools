using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.SqlCond.Attributes
{
    /// <summary>
    /// Created by wenzq on 2018/7/20.
    /// ����SQL�������������
    /// </summary>
    public class CondGt: BaseCond
    {
        /// <summary>
        /// ���췽��
        /// </summary>
        public CondGt() : base(">") { }
    }
}
