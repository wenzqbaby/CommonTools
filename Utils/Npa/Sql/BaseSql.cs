using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;

namespace Common.Utils.Npa.Sql
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/5
    /// desc:   语句获取基类
    /// </summary>
    public abstract class BaseSql
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="scheme">数据库名</param>
        /// <param name="table">数据表名</param>
        /// <param name="columnDic">属性名对应的数据列接口集合</param>
        /// <param name="idColumns">主键属性的数据列接口集合</param>
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

        /// <summary>
        /// 数据库名
        /// </summary>
        protected String mScheme;

        /// <summary>
        /// 数据表名
        /// </summary>
        protected String mTable;

        /// <summary>
        /// 数据表全名
        /// </summary>
        protected String mFullTable = String.Empty;

        /// <summary>
        /// 属性名对应的数据列接口集合
        /// </summary>
        protected Dictionary<String, IColumn> mColumns;

        /// <summary>
        /// 主键属性的数据列接口集合
        /// </summary>
        protected List<IColumn> mIds;

        /// <summary>
        /// 实体类型
        /// </summary>
        protected Type mType;
    }
}
