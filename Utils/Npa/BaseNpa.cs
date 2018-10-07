using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;
using System.Reflection;
using Common.Utils.Npa.Attributes;
using Common.Utils.Annotation;
using Common.Utils.Npa.Sql;
using Common.Utils.Npa.cmd;
using Common.Utils.Npa.Reflection;
using System.Data;

namespace Common.Utils.Npa
{
    public abstract class BaseNpa<T>:INpa<T>
    {
        protected String TAG = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString();
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
        protected IGenerate<T> mIGenerate;
        protected ICreate mICreate;

        public BaseNpa(IDataAccess iDataAccess)
        {
            mType = typeof(T);
            TAG = this.GetType().ToString();
            mIDataAccess = iDataAccess;
            MemberInfo memberInfo = mType;
            try
            {
                Entity entity = (Attribute.GetCustomAttribute(memberInfo, typeof(Entity)) as Entity);
                mTable = entity.TableName;
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
            mIGenerate = new Generate<T>(columnsDic, TAG);
            mICreate = new Creator();
        }

        public virtual void save(T t)
        {
            String sql = mISave.getSql(t);
            mIDataAccess.insert(sql);
        }

        public virtual void insert(T t)
        {
            PreparedCmd preparedSql = mISave.getPreparedSql(t);
            mIDataAccess.insert(preparedSql);
        }

        public void updateWithSql(T t)
        {
            String sql = mIUpdate.getSql(t);
            mIDataAccess.update(sql);
        }

        public void updateWithNull(T t)
        {
            PreparedCmd preparedSql = mIUpdate.getPSqlWithNull(t);
            mIDataAccess.update(preparedSql);
        }

        public void delete(T t)
        {
            PreparedCmd cmd = mIDelete.getPreparedSql(t);
            int i = mIDataAccess.delete(cmd);
        }

        public T find()
        {
            PreparedCmd cmd = mISelect.findPrepared();
            DataSet ds = mIDataAccess.select(cmd);
            return mIGenerate.get(ds);
        }

        public List<T> findAll()
        {
            PreparedCmd cmd = mISelect.findPrepared();
            DataSet ds = mIDataAccess.select(cmd);
            return mIGenerate.getList(ds);
        }

        public List<E> query<E>(String sql)
        {
            DataSet ds = mIDataAccess.select(sql);
            return mICreate.getList<E>(ds);
        }

        public List<E> query<E, U>(String sql, List<ResultCmd> cmds, ResultCollectionCmd<U> colet)
        {
            return mICreate.getList<E, U>(mIDataAccess.select(sql), cmds, colet);
        }

        #region INpa<T> 成员

        public void update(T t)
        {
            PreparedCmd preparedSql = mIUpdate.getPreparedSql(t);
            mIDataAccess.update(preparedSql);
        }

        #endregion
    }
}
