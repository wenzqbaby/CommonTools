using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;
using System.Reflection;
using Common.Utils.Cache;
using System.Data;
using Common.Utils.Reflection;
using Common.Utils.Npa.Cmd;
using Common.Utils.Npa.TypeHandler;

namespace Common.Utils.Npa.Reflection
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/7
    /// desc:   数据集创建对象接口实现
    /// </summary>
    public class Creator : ICreate
    {
        private DataTable validate(DataSet ds)
        {
            if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 0)
            {
                return null;
            }
            return ds.Tables[0];
        }

        private Dictionary<String, PropertyInfo> getPropertyInfo(DataTable dt, Type tp)
        {
            Dictionary<String, PropertyInfo> dic = new Dictionary<String, PropertyInfo>(dt.Columns.Count);
            foreach (DataColumn item in dt.Columns)
            {
                PropertyInfo p = tp.GetProperty(NameUtil.getPropName(item.ColumnName));
                if (p != null)
                {
                    dic.Add(item.ColumnName, p);
                }
            }
            return dic;
        }

        private T create<T>(DataRow dr, Dictionary<String, PropertyInfo> propertys, Dictionary<String, ITypeHandler> typeHanlders)
        {
            T t = Activator.CreateInstance<T>();
            foreach (String key in propertys.Keys)
            {
                ITypeHandler typeHandler = getTypeHandler(typeHanlders, propertys[key].Name, propertys[key].PropertyType);
                if (typeHandler != null)
                {
                    PropertyUtil.setValue(t, propertys[key], typeHandler.getResult(dr, key));
                }
            }
            return t;
        }

        private T create<T>(DataRow dr, List<ResultCmd> cmds)
        {
            T t = Activator.CreateInstance<T>();
            foreach (ResultCmd c in cmds)
            {
                PropertyInfo pi;
                try
                {
                    pi = typeof(T).GetProperty(c.Property);
                }
                catch (Exception)
                {
                    throw new Exception(String.Format("{0} 对象没有属性 {1}", typeof(T).ToString(), c.Property));
                }
                ITypeHandler typeHandler = c.TypeHandler;
                if (typeHandler == null)
                {
                    typeHandler = TypeHandlerFactory.get(pi.PropertyType);
                }
                if (typeHandler != null)
                {
                    PropertyUtil.setValue(t, pi, typeHandler.getResult(dr, c.ColumnName));
                }
            }
            return t;
        }

        private List<T> create<T, E>(DataTable dt, List<ResultCmd> cmds, ResultCollectionCmd<E> resultCollection)
        {
            Dictionary<T, List<E>> dic = new Dictionary<T, List<E>>();
            List<T> list = new List<T>();
            foreach (DataRow dr in dt.Rows)
            {
                T t = create<T>(dr, cmds);
                E e = create<E>(dr, resultCollection.getResultList());
                if (!dic.ContainsKey(t))
                {
                    dic[t] = new List<E>();
                    list.Add(t);
                }
                dic[t].Add(e);
            }
            foreach (KeyValuePair<T, List<E>> item in dic)
            {
                PropertyUtil.setValue(item.Key, resultCollection.Property, item.Value);
            }
            return list;
        }

        private ITypeHandler getTypeHandler(Dictionary<String, ITypeHandler> typeHanlders, String propName, Type type)
        {
            if (typeHanlders != null || typeHanlders.Count > 1)
            {
                try
                {
                    return typeHanlders[propName];
                }
                catch (Exception) { }
            }
            return TypeHandlerFactory.get(type);
        }

        #region ICreate 成员

        public T get<T>(DataSet ds)
        {
            DataTable dt = validate(ds);
            if (dt == null)
            {
                return default(T);
            }
            Dictionary<String, PropertyInfo> propertys = getPropertyInfo(dt, typeof(T));
            return create<T>(dt.Rows[0], propertys, null);
        }

        public T get<T>(DataSet ds, List<ResultCmd> results)
        {
            DataTable dt = validate(ds);
            if (dt == null)
            {
                return default(T);
            }
            return create<T>(dt.Rows[0], results);
        }

        public T get<T, E>(DataSet ds, List<ResultCmd> results, ResultCollectionCmd<E> resultCollection)
        {
            DataTable dt = validate(ds);
            if (dt == null)
            {
                return default(T);
            }
            throw new Exception("The method or operation is not implemented.");
        }

        public List<T> getList<T>(System.Data.DataSet ds)
        {
            DataTable dt = validate(ds);
            List<T> list = new List<T>();
            if (dt == null)
            {
                return list;
            }
            Dictionary<String, PropertyInfo> propertys = getPropertyInfo(dt, typeof(T));
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(create<T>(dr, propertys, null));
            }
            return list;
        }

        public List<T> getList<T>(DataSet ds, List<ResultCmd> results)
        {
            DataTable dt = validate(ds);
            List<T> list = new List<T>();
            if (dt == null)
            {
                return list;
            }
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(create<T>(dr, results));
            }
            return list;
        }

        public List<T> getList<T, E>(DataSet ds, List<ResultCmd> results, ResultCollectionCmd<E> resultCollection)
        {
            DataTable dt = validate(ds);
            if (dt == null)
            {
                return new List<T>();
            }
            return create<T, E>(dt, results, resultCollection);
        }

        public int getCount(DataSet ds)
        {
            DataTable dt = validate(ds);
            if (dt == null)
            {
                throw new Exception("结果集不包含任何数据");
            }
            try
            {
                return Convert.ToInt32(dt.Rows[0][0]);
            }
            catch (Exception e)
            {
                throw new Exception("结果不是有效的INT类型数据 " + e.Message);
            }
        }

        #endregion
    }
}
