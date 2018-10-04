using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;
using System.Reflection;
using Common.Utils.Npa.Attributes;
using Common.Utils.Annotation;

namespace Common.Utils.Npa
{
    public abstract class BaseNpa<T>
    {
        protected String TAG = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString();
        protected Type mType;
        protected String mTable;
        protected String mScheme;

        protected Dictionary<String, IColumn> columnsDic;
        private IDataAccess mIDataAccess;

        public BaseNpa(IDataAccess iDataAccess)
        {
            mIDataAccess = iDataAccess;
            mType = typeof(T);
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
                        (attr as IColumn).setPropertyInfo(pi);
                        columnsDic[pi.Name] = attr as IColumn;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(String.Format("{0} 获取类 {1} 的属性 {2} 注解异常：{3}", TAG, mType.Name, pi.Name, e.Message));
                }

            }
        }


    }
}
