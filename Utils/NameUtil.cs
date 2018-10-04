using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils
{
    /// <summary>
    /// ���ƹ���
    /// </summary>
    public class NameUtil
    {
        /// <summary>
        /// ����������ת�������ݿ��Ӧ������
        /// </summary>
        /// <param name="propName">������</param>
        /// <returns></returns>
        public static String getSqlName(String propName)
        {
            Char[] tempArry = propName.ToCharArray();
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

        /// <summary>
        /// �������ݿ���ת����������
        /// </summary>
        /// <param name="sqlName">���ݿ���</param>
        /// <returns></returns>
        public static String getPropName(String sqlName)
        {
            string[] strArray = sqlName.Split('_');
            string newStr = string.Empty;
            foreach (string s in strArray)
            {
                newStr += s.Substring(0, 1).ToUpper() + s.Substring(1, s.Length - 1).ToLower();
            }
            return newStr;
        }
    }
}
