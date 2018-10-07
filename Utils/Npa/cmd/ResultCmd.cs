using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;

namespace Common.Utils.Npa.cmd
{
    /// <summary>
    /// ���������ָ��
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
        /// �����������
        /// </summary>
        public String Property
        {
            get { return _property; }
            set { _property = value; }
        }

        private String _columnName;
        /// <summary>
        /// ���ݿ������
        /// </summary>
        public String ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }

        private ITypeHandler _typeHandler;
        /// <summary>
        /// ʹ�õ�����ת����
        /// </summary>
        public ITypeHandler TypeHandler
        {
            get { return _typeHandler; }
            set { _typeHandler = value; }
        }
    }
}
