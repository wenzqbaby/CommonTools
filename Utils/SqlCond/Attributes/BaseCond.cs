using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.SqlCond.Enum;

namespace Common.Utils.SqlCond.Attributes
{
    /// <summary>
    /// Created by wenzq on 2018/7/20.
    /// 工具的注解基类，所有的注解，都需要继承次基类
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public abstract class BaseCond : Attribute
    {
        #region 构造方法
        /// <summary>
        /// 默认属性：
        /// 条件连接类型CondLink：CondLink.AND
        /// 数据库字段名称ColumnName：对应属性名的小写转大写，大写前补"_"，例如：属性名：UserName -> ColumnName：USER_NAME
        /// 条件符CondChar：=
        /// 数据库字段类型SqlType：SqlType.STRING
        /// </summary>
        protected BaseCond() 
        {
            if (_condChar == null)
            {
                _condChar = "=";
            }
        }

        /// <summary>
        /// 默认属性：
        /// 条件连接类型CondLink：CondLink.AND
        /// 数据库字段名称ColumnName：对应属性名的小写转大写，大写前补"_"，例如：属性名：UserName -> ColumnName：USER_NAME
        /// 数据库字段类型SqlType：SqlType.STRING
        /// </summary>
        /// <param name="condChar">条件符</param>
        protected BaseCond(String condChar):this()
        {
            _condChar = condChar;
        }

        #endregion

        #region 属性
        
        private String _condChar;
        /// <summary>
        /// 条件符
        /// </summary>
        protected String CondChar
        {
            get { return _condChar; }
        }

        private CondLink _condLink = CondLink.AND;
        /// <summary>
        /// 条件连接符，使用枚举Common.Utils.SQLCond.Enum.CondLink
        /// </summary>
        public CondLink CondLink
        {
            get { return _condLink; }
            set { _condLink = value; }
        }

        private String _columnName;
        /// <summary>
        /// 条件字段名称
        /// </summary>
        public String ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }

        private SqlType _sqlType = SqlType.STRING;
        /// <summary>
        /// 数据库字段的数据类型
        /// </summary>
        public SqlType SqlType
        {
            get { return _sqlType; }
            set { _sqlType = value; }
        }

        #endregion

        #region 方法
        /// <summary>
        /// 默认获取sql条件字符串
        /// </summary>
        /// <param name="value">属性的值</param>
        /// <returns></returns>
        public String getCondSql(Object value)
        {
            String condSql = generateCondSql(value);
            if (condSql != null)
            {
                return condSql;
            }
            String valueSql = formatValue(value);
            if(String.IsNullOrEmpty(this.ColumnName) || valueSql == null)
            {
                return String.Empty;
            }
            condSql = String.Format("{0} {1} {2} {3} ", getCondLinkStr(), this.ColumnName, this.CondChar, this.formatValue(value));
            return condSql;
        }

        /// <summary>
        /// 默认格式化值方法，若返回NULL则不生成条件，generateCondSql不返回NULL此方法不生效
        /// </summary>
        /// <param name="value">属性的值</param>
        /// <returns></returns>
        protected virtual String formatValue(Object value)
        {
            if (value == null)
            {
                return null;
            }
            switch (this.SqlType)
            {
                case SqlType.STRING:
                    return String.Format(@"'{0}'", value);
                case SqlType.NUMBER:
                    return String.Format(@"{0}", value);
                case SqlType.TIMESTAMP:
                    if (value is DateTime)
                    {
                        return String.Format(@"TIMESTAMP('{0}')", ((DateTime)value).ToString(@"yyyy-MM-dd HH:mm:ss")); 
                    }
                    return String.Format(@"TIMESTAMP('{0}')", value);
                default:
                    return null;
            }
        }

        /// <summary>
        /// 生成SQL条件，若不返回NULL则已这个为准，若返回NULL则调用默认生成方法
        /// </summary>
        /// <param name="value">属性的值</param>
        /// <returns></returns>
        protected virtual String generateCondSql(Object value)
        {
            return null;
        }

        /// <summary>
        /// 获取SQL连接符
        /// </summary>
        /// <returns></returns>
        private String getCondLinkStr()
        {
            return this.CondLink == CondLink.AND ? "AND" : "OR";
        }
        #endregion

    }
}
