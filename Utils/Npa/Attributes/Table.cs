using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;

namespace Common.Utils.Npa.Attributes
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/5
    /// desc:   ���ݱ�ע��
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class Table : Attribute, ITable
    {
        private String _name;
        /// <summary>
        /// ����
        /// </summary>
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private String _scheme;
        /// <summary>
        /// ���ݿ���
        /// </summary>
        public String Scheme
        {
            get { return _scheme; }
            set { _scheme = value; }
        }

        #region IEntity ��Ա

        public string getTableName()
        {
            return this.Name;
        }

        public string getScheme()
        {
            return this.Scheme;
        }

        public void setType(Type t)
        {
            if (String.IsNullOrEmpty(this.Name))
            {
                this.Name = NameUtil.getSqlName(t.Name);
            }
        }

        #endregion
    }
}
