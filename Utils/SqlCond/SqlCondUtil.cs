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
    /// ��������SQL���WHERE�����Ĺ���
    /// </summary>
    public class SqlCondUtil
    {
        private const String COND_AND = "AND";
        private const String COND_OR = "OR";

        private SqlCondUtil() { }

        /// <summary>
        /// Created by dengyq on 2018/7/20.
        /// ���ݴ���Ķ���Ͳ�ۼ��ϣ�����Where���������䣬��ۼ��Ͻ����Ƕ��������������
        /// �������������Զ����������������ʱ���򷵻ؿ��ַ���
        /// </summary>
        /// <param name="obj">����</param>
        /// <param name="slot">��ۣ�KeyΪ�������ƣ�ValueΪBaseCond</param>
        /// <returns>WHERE�����������䣬����Where</returns>
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
                //�ж��Ƿ������ע��
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
            //��ȡ��һ������� AND OR
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
        /// ���ݴ����ʵ�壬����Where����������
        /// �������������Զ����������������ʱ���򷵻ؿ��ַ���
        /// </summary>
        /// <param name="obj">��������</param>
        /// <returns>WHERE�����������䣬����Where</returns>
        public static String getWhereCond(Object obj)
        {
            return getWhereCond(obj, null);
        }

        /// <summary>
        /// ��ʽ���ַ���
        /// 1.СдתΪ��д
        /// 2.��дǰ��"_"
        /// ����: IsVaild  -> IS_VALID
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
