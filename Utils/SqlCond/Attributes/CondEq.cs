using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.SqlCond.Enum;

namespace Common.Utils.SqlCond.Attributes
{
    /// <summary>
    /// Created by wenzq on 2018/7/20.
    /// 生成SQL条件组件：等于
    /// </summary>
    public class CondEq : BaseCond
    {
        /// <summary>
        /// 默认属性：
        /// 条件连接类型CondLink：CondLink.AND
        /// 数据库字段名称ColumnName：对应属性名的小写转大写，大写前补"_"，例如：属性名：UserName -> ColumnName：USER_NAME
        /// 条件符CondChar：=
        /// 数据库字段类型SqlType：SqlType.STRING
        /// </summary>
        public CondEq():base("=") { }
    }
}
