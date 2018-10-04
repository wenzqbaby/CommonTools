using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;

namespace Common.Utils.Npa.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class Entity : Attribute, IEntity
    {
        private String _tableName;

        public String TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        private String _scheme;

        public String Scheme
        {
            get { return _scheme; }
            set { _scheme = value; }
        }

        #region IEntity ≥…‘±

        public string getTableName()
        {
            return this.TableName;
        }

        public string getScheme()
        {
            return this.Scheme;
        }

        #endregion
    }
}
