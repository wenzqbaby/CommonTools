using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;

namespace Common.Utils.Npa.TypeHandler
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/8
    /// desc:   键值对类型转换接口实现
    /// </summary>
    public class KvTypeHandler : AbstractTypeHandler
    {
        private Dictionary<String, String> mKvDic = new Dictionary<string, string>();
        private Dictionary<String, String> mVkDic = new Dictionary<string, string>();
        public String mDefault;
        const String POINT = "'";
        const String POINT_DOUBLIC = "''";

        public KvTypeHandler(Dictionary<String, String> kvDic, String another)
        {
            if (kvDic == null || kvDic.Count < 1)
            {
                throw new Exception(this.GetType().ToString() + "没设置要转换的键值对");
            }
            foreach (KeyValuePair<String, String> item in kvDic)
            {
                mKvDic.Add(item.Key.Trim(), item.Value.Trim());
                mVkDic.Add(item.Value.Trim(), item.Key.Trim());
            }
            mDefault = another;
        }

        public String getKey(String value)
        {
            try
            {
                return POINT + mVkDic[value].Replace(POINT, POINT_DOUBLIC) + POINT;
            }
            catch (Exception)
            {
                
                return null;
            }
        }

        public String getValue(String key)
        {
            try
            {
                return mKvDic[key];
            }
            catch (Exception)
            {
                if (key != null)
                {
                    return mDefault;
                }
                return null;
            }
        }

        #region AbstractTypeHandler 成员

        public override object getResult(System.Data.DataRow dataRow, string columnName)
        {
            return formatToProp(dataRow[columnName]);
        }

        public override object formatProp(object value)
        {
            return value == null ? null :getKey(value.ToString());
        }

        public override string formatToSql(object value)
        {
            if (value == null)
            {
                return null;
            }
            String v = getKey(value.ToString());
            if (v == null)
            {
                return null;
            }
            return POINT + v.Replace(POINT, POINT_DOUBLIC) + POINT;
        }

        public override object formatToProp(object dbValue)
        {
            return dbValue == DBNull.Value ? null : getValue(dbValue.ToString()); 
        }

        #endregion
    }
}
