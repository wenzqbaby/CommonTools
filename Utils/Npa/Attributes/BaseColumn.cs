using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;
using Common.Utils.Reflection;
using Common.Utils.Npa.TypeHandler;
using System.Reflection;

namespace Common.Utils.Npa.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public abstract class BaseColumn: Attribute, IColumn
    {
        private PropertyInfo mPropertyInfo;
        private String mPropName;
        private String mPreparePropName;

        public BaseColumn()
        {
            this.TypeHandler = StringTypeHandler.getInstance();
        }

        private String _name;
        
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private ITypeHandler _typeHandler;

        public ITypeHandler TypeHandler
        {
            get { return _typeHandler; }
            set { _typeHandler = value; }
        }

        #region IColumn ≥…‘±

        public virtual bool isIdColumn()
        {
            return false;
        }

        public string getProp()
        {
            return mPropName;
        }

        public string getColumn()
        {
            return Name;
        }

        public virtual Object getValue(Object obj)
        {
            return PropertyUtil.getValue<Object>(obj, mPropertyInfo);
        }

        public virtual String getSqlValue(object obj)
        {
            return this.TypeHandler.formatToSql(PropertyUtil.getValue<Object>(obj, mPropertyInfo));
        }

        public virtual void setDbValue(object obj, object value)
        {
            PropertyUtil.setValue(obj, mPropertyInfo, this.TypeHandler.formatToProp(value));
        }

        public virtual string getPrepareProp()
        {
            return mPreparePropName;
        }

        public virtual void setPropertyInfo(PropertyInfo propertyInfo)
        {
            mPropertyInfo = propertyInfo;
            mPropName = propertyInfo.Name;
            mPreparePropName = "@" + mPropName;
            if (String.IsNullOrEmpty(Name))
            {
                Name = NameUtil.getSqlName(mPropName);
            }
           
        }

        public abstract System.Data.Common.DbParameter getDbParameter(object value);
       
        #endregion
    }
}
