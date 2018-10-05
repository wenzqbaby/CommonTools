using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;
using System.Reflection;
using Common.Utils.Npa.Attributes;
using Common.Utils.Annotation;
using Common.Utils.Npa.Sql;
using Common.Utils.Npa.cmd;

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
        }

        public virtual void save(T t)
        {
            String sql = mISave.getSql(t);
            mIDataAccess.insert(sql);
        }

        public virtual void insert(T t)
        {
            PreparedSql preparedSql = mISave.getPreparedSql(t);
            mIDataAccess.insert(preparedSql.Parameters, preparedSql.Sql);
        }

        #region INpa<T> 成员

        public void update(T t)
        {
            PreparedSql preparedSql = mIUpdate.getPreparedSql(t);
            int i = mIDataAccess.update(preparedSql.Parameters, preparedSql.Sql);
        }

        #endregion
    }
}
