using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.SqlCond.Enum;

namespace Common.Utils.SqlCond.Attributes
{
    /// <summary>
    /// Created by wenzq on 2018/7/20.
    /// 生成SQL条件组件：模糊查询全模糊
    /// </summary>
    public class CondLike : BaseCond
    {
        private const String VALUE_TEMPLATE_ALL = @"'%{0}%'";
        const String VALUE_TEMPLATE_LEFT = @"'%{0}'";
        const String VALUE_TEMPLATE_RIGHT = @"'{0}%'";

        private String _valueTemplate = VALUE_TEMPLATE_ALL;
        /// <summary>
        /// 格式化值的模板
        /// </summary>
        public String ValueTemplate
        {
            get { return _valueTemplate; }
            set { _valueTemplate = value; }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        public CondLike() : base("LIKE") { }

        /// <summary>
        /// 通过Value模板，格式化不同的值
        /// </summary>
        /// <param name="template">Value模板枚举</param>
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
        /// 格式化值
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
        /// 格式化Value模板枚举
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
