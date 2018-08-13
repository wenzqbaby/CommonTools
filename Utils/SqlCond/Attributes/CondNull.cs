using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.SqlCond.Enum;

namespace Common.Utils.SqlCond.Attributes
{
    /// <summary>
    /// Created by wenzq on 2018/7/20.
    /// ����SQL���������NULL
    /// </summary>
    public class CondNull : BaseCond
    {
        /// <summary>
        /// ���췽��
        /// </summary>
        public CondNull():base("IS") { }
        
        /// <summary>
        /// ��ʽ��ֵ
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override string formatValue(object value)
        {
            return "NULL";
        }
    }
}
