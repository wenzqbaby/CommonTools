using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.SqlCond.Attributes
{
    /// <summary>
    /// Created by wenzq on 2018/7/20.
    /// ����SQL����������ǿ�
    /// </summary>
    public class CondNotNull : CondNull
    {
        /// <summary>
        /// ��ʽ��ֵ
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override string formatValue(object value)
        {
            return "NOT NULL";
        }
    }
}
