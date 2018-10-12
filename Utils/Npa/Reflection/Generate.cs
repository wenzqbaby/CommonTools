using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;
using System.Data;

namespace Common.Utils.Npa.Reflection
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/7
    /// desc:   数据集生成对象接口
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public class Generate<T> : IGenerate<T>
    {
        protected String TAG;
        protected Dictionary<String, IColumn> mColumns;
        protected Type mType;

        public Generate(Dictionary<String, IColumn> columns, String tag)
        {
            mColumns = columns;
            TAG = tag;
            mType = typeof(T);
        }

        private DataTable validate(DataSet ds)
        {
            if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 0)
            {
                return null;
            }
            return ds.Tables[0];
        }

        private T create(DataRow dr)
        {
            T t = Activator.CreateInstance<T>();
            foreach (IColumn item in mColumns.Values)
            {
                item.setDbValue(t, dr[item.getColumn()]);
            }
            return t;
        }

        #region IGenerate<T> 成员

        public T get(DataSet ds)
        {
            DataTable dt = validate(ds);
            if (dt == null)
            {
                return default(T);
            }
            return create(dt.Rows[0]);
        }

        public List<T> getList(DataSet ds)
        {
            DataTable dt = validate(ds);
            List<T> list = new List<T>();
            if (dt == null)
            {
                return list;
            }

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(create(dr));
            }
            return list;
        }

        #endregion
    }
}
