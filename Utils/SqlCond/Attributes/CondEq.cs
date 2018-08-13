using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.SqlCond.Enum;

namespace Common.Utils.SqlCond.Attributes
{
    /// <summary>
    /// Created by wenzq on 2018/7/20.
    /// ����SQL�������������
    /// </summary>
    public class CondEq : BaseCond
    {
        /// <summary>
        /// Ĭ�����ԣ�
        /// ������������CondLink��CondLink.AND
        /// ���ݿ��ֶ�����ColumnName����Ӧ��������Сдת��д����дǰ��"_"�����磺��������UserName -> ColumnName��USER_NAME
        /// ������CondChar��=
        /// ���ݿ��ֶ�����SqlType��SqlType.STRING
        /// </summary>
        public CondEq():base("=") { }
    }
}
