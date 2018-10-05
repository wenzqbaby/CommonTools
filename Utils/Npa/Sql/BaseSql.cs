using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;

namespace Common.Utils.Npa.Sql
{
    public abstract class BaseSql
    {
        public BaseSql(String scheme, String table, Dictionary<String, IColumn> columnDic, List<IColumn> idColumns)
        {
            TAG = this.GetType().ToString();
            mScheme = scheme;
            mTable = table;
            mColumns = columnDic;
            mIds = idColumns;
            if (!String.IsNullOrEmpty(mScheme))
            {
                mFullTable = mScheme + ".";
            }
            mFullTable += mTable;
        }
        protected String TAG;
        protected String mScheme;
        protected String mTable;
        protected String mFullTable = String.Empty;
        protected Dictionary<String, IColumn> mColumns;
        protected List<IColumn> mIds;
        protected Type mType;
    }
}
