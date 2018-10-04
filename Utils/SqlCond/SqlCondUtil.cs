using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.SqlCond.Attributes;
using System.Reflection;
using Common.Utils.Annotation;
using Common.Utils.Reflection;

namespace Common.Utils.SqlCond
{
    /// <summary>
    /// Created by wenzq on 2018/7/20.
    /// 用于生成SQL语句WHERE条件的工具
    /// </summary>
    public class SqlCondUtil
    {
        private const String COND_AND = "AND";
        private const String COND_OR = "OR";

        private SqlCondUtil() { }

        /// <summary>
        /// Created by dengyq on 2018/7/20.
        /// 根据传入的对象和插槽集合，生成Where后的条件语句，插槽集合将覆盖对象所属类的配置
        /// 若条件对象属性都不会生成条件语句时，则返回空字符串
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="slot">插槽，Key为属性名称，Value为BaseCond</param>
        /// <returns>WHERE条件后面的语句，不带Where</returns>
        public static String getWhereCond(Object obj, Dictionary<String, BaseCond> slot)
        {
            String whereCond = String.Empty;
            if (obj == null)
            {
                return whereCond;
            }
            if (slot == null)
            {
                slot = new Dictionary<string, BaseCond>(0);
            }
            Dictionary<String, Annotation<BaseCond>> attrs = AttributeUtil.get<BaseCond>(obj.GetType());
            foreach (KeyValuePair<String, Annotation<BaseCond>> kv in attrs)
            {
                //判断是否存在新注解
                if (slot.ContainsKey(kv.Key))
                {
                    if (String.IsNullOrEmpty(slot[kv.Key].ColumnName))
                    {
                        slot[kv.Key].ColumnName = formatColums(kv.Key);
                    }
                    whereCond += slot[kv.Key].getCondSql(PropertyUtil.getValue<Object>(obj, kv.Value.PropInfo));
                    continue;
                }

                Annotation<BaseCond> attr = kv.Value;

                if (attr.Attr.ColumnName == null)
                {
                    attr.Attr.ColumnName = formatColums(attr.PropName);
                }
                whereCond += kv.Value.Attr.getCondSql(PropertyUtil.getValue<Object>(obj, kv.Value.PropInfo));
            }

            whereCond = whereCond.Trim();
            //截取第一个运算符 AND OR
            if (whereCond.StartsWith(COND_AND))
            {
                return whereCond.Substring(COND_AND.Length) + " ";
            }
            if (whereCond.StartsWith(COND_OR))
            {
                return whereCond.Substring(COND_OR.Length) + " ";
            }
            return whereCond;
        }

        /// <summary>
        /// 根据传入的实体，生成Where后的条件语句
        /// 若条件对象属性都不会生成条件语句时，则返回空字符串
        /// </summary>
        /// <param name="obj">条件对象</param>
        /// <returns>WHERE条件后面的语句，不带Where</returns>
        public static String getWhereCond(Object obj)
        {
            return getWhereCond(obj, null);
        }

        /// <summary>
        /// 格式化字符串
        /// 1.小写转为大写
        /// 2.大写前补"_"
        /// 比如: IsVaild  -> IS_VALID
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string formatColums(String str)
        {
            Char[] tempArry = str.ToCharArray();
            string newStr = string.Empty;
            foreach (Char var in tempArry)
            {
                newStr += Char.IsLower(var) ? Char.ToUpper(var).ToString() : String.Format("_{0}", var);
            }

            if (newStr.StartsWith("_"))
            {
                newStr = newStr.Substring(1, newStr.Length - 1);
            }
            return newStr;
        }
    }
}
