using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.SqlCond.Enum;

namespace Common.Utils.SqlCond.Attributes
{
    /// <summary>
    /// Created by wenzq on 2018/7/20.
    /// ���ߵ�ע����࣬���е�ע�⣬����Ҫ�̳дλ���
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public abstract class BaseCond : Attribute
    {
        #region ���췽��
        /// <summary>
        /// Ĭ�����ԣ�
        /// ������������CondLink��CondLink.AND
        /// ���ݿ��ֶ�����ColumnName����Ӧ��������Сдת��д����дǰ��"_"�����磺��������UserName -> ColumnName��USER_NAME
        /// ������CondChar��=
        /// ���ݿ��ֶ�����SqlType��SqlType.STRING
        /// </summary>
        protected BaseCond() 
        {
            if (_condChar == null)
            {
                _condChar = "=";
            }
        }

        /// <summary>
        /// Ĭ�����ԣ�
        /// ������������CondLink��CondLink.AND
        /// ���ݿ��ֶ�����ColumnName����Ӧ��������Сдת��д����дǰ��"_"�����磺��������UserName -> ColumnName��USER_NAME
        /// ���ݿ��ֶ�����SqlType��SqlType.STRING
        /// </summary>
        /// <param name="condChar">������</param>
        protected BaseCond(String condChar):this()
        {
            _condChar = condChar;
        }

        #endregion

        #region ����
        
        private String _condChar;
        /// <summary>
        /// ������
        /// </summary>
        protected String CondChar
        {
            get { return _condChar; }
        }

        private CondLink _condLink = CondLink.AND;
        /// <summary>
        /// �������ӷ���ʹ��ö��Common.Utils.SQLCond.Enum.CondLink
        /// </summary>
        public CondLink CondLink
        {
            get { return _condLink; }
            set { _condLink = value; }
        }

        private String _columnName;
        /// <summary>
        /// �����ֶ�����
        /// </summary>
        public String ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }

        private SqlType _sqlType = SqlType.STRING;
        /// <summary>
        /// ���ݿ��ֶε���������
        /// </summary>
        public SqlType SqlType
        {
            get { return _sqlType; }
            set { _sqlType = value; }
        }

        #endregion

        #region ����
        /// <summary>
        /// Ĭ�ϻ�ȡsql�����ַ���
        /// </summary>
        /// <param name="value">���Ե�ֵ</param>
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
        /// Ĭ�ϸ�ʽ��ֵ������������NULL������������generateCondSql������NULL�˷�������Ч
        /// </summary>
        /// <param name="value">���Ե�ֵ</param>
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
        /// ����SQL��������������NULL�������Ϊ׼��������NULL�����Ĭ�����ɷ���
        /// </summary>
        /// <param name="value">���Ե�ֵ</param>
        /// <returns></returns>
        protected virtual String generateCondSql(Object value)
        {
            return null;
        }

        /// <summary>
        /// ��ȡSQL���ӷ�
        /// </summary>
        /// <returns></returns>
        private String getCondLinkStr()
        {
            return this.CondLink == CondLink.AND ? "AND" : "OR";
        }
        #endregion

    }
}
