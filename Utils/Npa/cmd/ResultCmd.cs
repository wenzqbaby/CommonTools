using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;

namespace Common.Utils.Npa.cmd
{
    /// <summary>
    /// 结果集配置指令
    /// </summary>
    public class ResultCmd
    {
        public ResultCmd(String prop, String columnName)
        {
            this.Property = prop;
            this.ColumnName = columnName;
        }

        public ResultCmd(String prop, String columnName, ITypeHandler typeHandler)
        {
            this.Property = prop;
            this.ColumnName = columnName;
            this.TypeHandler = typeHandler;
        }

        private String _property;
        /// <summary>
        /// 对象的属性名
        /// </summary>
        public String Property
        {
            get { return _property; }
            set { _property = value; }
        }

        private String _columnName;
        /// <summary>
        /// 数据库的列名
        /// </summary>
        public String ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }

        private ITypeHandler _typeHandler;
        /// <summary>
        /// 使用的类型转换器
        /// </summary>
        public ITypeHandler TypeHandler
        {
            get { return _typeHandler; }
            set { _typeHandler = value; }
        }
    }
}
