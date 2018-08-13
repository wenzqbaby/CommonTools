using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.SqlCond.Enum;

namespace Common.Utils.SqlCond.Attributes
{
    /// <summary>
    /// Created by wenzq on 2018/7/20.
    /// ����SQL���������ģ����ѯȫģ��
    /// </summary>
    public class CondLike : BaseCond
    {
        private const String VALUE_TEMPLATE_ALL = @"'%{0}%'";
        const String VALUE_TEMPLATE_LEFT = @"'%{0}'";
        const String VALUE_TEMPLATE_RIGHT = @"'{0}%'";

        private String _valueTemplate = VALUE_TEMPLATE_ALL;
        /// <summary>
        /// ��ʽ��ֵ��ģ��
        /// </summary>
        public String ValueTemplate
        {
            get { return _valueTemplate; }
            set { _valueTemplate = value; }
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        public CondLike() : base("LIKE") { }

        /// <summary>
        /// ͨ��Valueģ�壬��ʽ����ͬ��ֵ
        /// </summary>
        /// <param name="template">Valueģ��ö��</param>
        public CondLike(Template template)
            : base("LIKE")
        {
            switch (template)
            {
                case Template.LEFT:
                    ValueTemplate = VALUE_TEMPLATE_LEFT;
                    break;
                case Template.RIGHT:
                    ValueTemplate = VALUE_TEMPLATE_RIGHT;
                    break;
                default:
                    ValueTemplate = VALUE_TEMPLATE_ALL;
                    break;
            }
        }

        /// <summary>
        /// ��ʽ��ֵ
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override string formatValue(object value)
        {
            if (value == null || !(value is String) || value.ToString().Length < 1)
            {
                return null;
            }
            return String.Format(ValueTemplate, value.ToString());
        }

        /// <summary>
        /// ��ʽ��Valueģ��ö��
        /// </summary>
        public enum Template
        {
            /// <summary>
            /// '%xxx%'
            /// </summary>
            ALL,
            /// <summary>
            /// '%xxx'
            /// </summary>
            LEFT,
            /// <summary>
            /// 'xxx%'
            /// </summary>
            RIGHT,
        }
    }
}
