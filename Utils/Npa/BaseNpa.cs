using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;
using System.Reflection;
using Common.Utils.Npa.Attributes;
using Common.Utils.Annotation;
using Common.Utils.Npa.Sql;
using Common.Utils.Npa.Cmd;
using Common.Utils.Npa.Reflection;
using System.Data;
using Common.Utils.Npa.Cst;

namespace Common.Utils.Npa
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/7
    /// desc:   .Net Persistence API 持久层操作基类
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public abstract class BaseNpa<T> : INpa<T>
    {
        protected String TAG;
        protected Type mType;
        protected String mTable;
        protected String mScheme;

        protected Dictionary<String, IColumn> columnsDic;
        protected List<IColumn> idList = new List<IColumn>();
        protected IDataAccess mIDataAccess;
        protected ISave<T> mISave;
        protected IUpdate<T> mIUpdate;
        protected IDelete<T> mIDelete;
        protected ISelect<T> mISelect;
        protected ICount<T> mICount;
        protected IGenerate<T> mIGenerate;
        protected ICreate mICreate;

        public BaseNpa(IDataAccess iDataAccess)
        {
            mType = typeof(T);
            TAG = this.GetType().ToString();
            mIDataAccess = iDataAccess;
            mIDataAccess.setLog(this.GetType());
            MemberInfo memberInfo = mType;
            try
            {
                Table entity = (Attribute.GetCustomAttribute(memberInfo, typeof(Table)) as Table);
                entity.setType(mType);
                mTable = entity.Name;
                mScheme = entity.Scheme;
            }
            catch (Exception ex)
            {
                throw new Exception(TAG + "获取映射表名异常：" + memberInfo.Name + " " + ex.Message);
            }

            PropertyInfo[] propertyInfos = mType.GetProperties();
            columnsDic = new Dictionary<String, IColumn>(propertyInfos.Length);
            foreach (PropertyInfo pi in propertyInfos)
            {
                try
                {
                    Attribute attr = Attribute.GetCustomAttribute(pi, typeof(BaseColumn));
                    if (attr != null)
                    {
                        IColumn column = attr as IColumn;
                        column.setPropertyInfo(pi);
                        columnsDic[pi.Name] = column;
                        if (column.isIdColumn())
                        {
                            idList.Add(column);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(String.Format("{0} 获取类 {1} 的属性 {2} 注解异常：{3}", TAG, mType.Name, pi.Name, e.Message));
                }
            }
            mISave = new Insert<T>(mScheme, mTable, columnsDic, idList, TAG);
            mIUpdate = new Update<T>(mScheme, mTable, columnsDic, idList, TAG);
            mIDelete = new Delete<T>(mScheme, mTable, columnsDic, idList, TAG);
            mISelect = new Select<T>(mScheme, mTable, columnsDic, TAG);
            mICount = new Count<T>(mScheme, mTable, columnsDic, idList, TAG);
            mIGenerate = new Generate<T>(columnsDic, TAG);
            mICreate = new Creator();
        }

        public List<E> query<E, U>(String sql, List<ResultCmd> cmds, ResultCollectionCmd<U> colet)
        {
            return mICreate.getList<E, U>(mIDataAccess.select(sql), cmds, colet);
        }

        #region INpa<T> 成员

        public int insert(T t)
        {
            PreparedCmd preparedSql = mISave.getPreparedSql(t);
            return mIDataAccess.insert(preparedSql);
        }

        public int insert(string sql)
        {
            return mIDataAccess.insert(sql);
        }

        public int insert(PreparedCmd cmd)
        {
            return mIDataAccess.insert(cmd);
        }

        public int update(T t)
        {
            String sql = mIUpdate.getSql(t);
            return mIDataAccess.update(sql);
        }

        public int updateWithNull(T t)
        {
            PreparedCmd preparedSql = mIUpdate.getPSqlWithNull(t);
            return mIDataAccess.update(preparedSql);
        }

        public int update(T t, params string[] propertys)
        {
            PreparedCmd preparedSql = mIUpdate.getPreparedSql(t, null, new List<string>(propertys));
            return mIDataAccess.update(preparedSql);
        }

        public int update(T t, List<String> conds, List<String> propertys)
        {
            PreparedCmd preparedSql = mIUpdate.getPreparedSql(t, conds, propertys);
            return mIDataAccess.update(preparedSql);
        }

        public int update(PreparedCmd cmd)
        {
            return mIDataAccess.update(cmd);
        }

        public int update(string sql)
        {
            return mIDataAccess.update(sql);
        }

        public int insertOrUpdate(T t)
        {
            PreparedCmd cmd = mICount.countPreparedById(t);
            DataSet ds = mIDataAccess.select(cmd);
            if (mICreate.getCount(ds) != 0)
            {
                return mIDataAccess.insert(mISave.getPreparedSql(t));
            }
            else
            {
                return mIDataAccess.update(mIUpdate.getPreparedSql(t));
            }
        }

        public int delete(T t)
        {
            PreparedCmd cmd = mIDelete.getPreparedSql(t);
            return mIDataAccess.delete(cmd);
        }

        public int delete(string sql)
        {
            return mIDataAccess.delete(sql);
        }

        public int delete(PreparedCmd cmd)
        {
            return mIDataAccess.delete(cmd);
        }

        public T find(T t)
        {
            PreparedCmd cmd = mISelect.findPrepared();
            DataSet ds = mIDataAccess.select(cmd);
            return mIGenerate.get(ds);
        }

        public T find(string cond)
        {
            PreparedCmd cmd = mISelect.findPrepared();
            if (!String.IsNullOrEmpty(cond))
            {
                cmd.Sql += SqlCst.WHERE + SqlCst.SPACE + cond;
            }
            DataSet ds = mIDataAccess.select(cmd);
            return mIGenerate.get(ds);
        }

        public List<T> findAll()
        {
            PreparedCmd cmd = mISelect.findPrepared();
            DataSet ds = mIDataAccess.select(cmd);
            return mIGenerate.getList(ds);
        }

        public List<T> findAll(string cond)
        {
            PreparedCmd cmd = mISelect.findPrepared();
            if (!String.IsNullOrEmpty(cond))
            {
                cmd.Sql += SqlCst.WHERE + SqlCst.SPACE + cond;
            }
            DataSet ds = mIDataAccess.select(cmd);
            return mIGenerate.getList(ds);
        }

        public List<T> findAll(T t)
        {
            PreparedCmd cmd = mISelect.findPrepared(t);
            DataSet ds = mIDataAccess.select(cmd);
            return mIGenerate.getList(ds);
        }

        public DataSet select(string sql)
        {
            return mIDataAccess.select(sql);
        }

        public DataSet select(PreparedCmd cmd)
        {
            return mIDataAccess.select(cmd);
        }

        public int count(T t)
        {
            PreparedCmd cmd = mICount.countPrepared(t);
            return mICreate.getCount(mIDataAccess.select(cmd));
        }

        public int count(string sql)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int count(PreparedCmd cmd)
        {
            return mICreate.getCount(mIDataAccess.select(cmd));
        }

        #endregion
    }
}
