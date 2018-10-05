using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Reflection;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// ���ݿ��������ӿ�
    /// </summary>
    public interface IColumn
    {
        /// <summary>
        /// �Ƿ�Ϊ������
        /// </summary>
        /// <returns></returns>
        Boolean isIdColumn();

        /// <summary>
        /// ��ȡ���Ե�����
        /// </summary>
        /// <returns></returns>
        String getProp();

        /// <summary>
        /// ��ȡ@+���Ե�����
        /// </summary>
        /// <returns></returns>
        String getPrepareProp();

        /// <summary>
        /// ��ȡ���Զ�Ӧ�����ݱ�����
        /// </summary>
        /// <returns></returns>
        String getColumn();

        /// <summary>
        /// ��ȡ��������Ե�ֵ
        /// </summary>
        /// <param name="obj">����</param>
        /// <returns></returns>
        Object getValue(Object obj);

        /// <summary>
        /// ��ȡ��������Ե����ݿ�ֵ
        /// </summary>
        /// <param name="obj">����</param>
        /// <returns>����ֵ</returns>
        String getSqlValue(Object obj);

        /// <summary>
        /// ���������ø����Ե�ֵ
        /// </summary>
        /// <param name="obj">����</param>
        /// <param name="value">Ҫ���õ�ֵ</param>
        void setDbValue(Object obj, Object value);

        /// <summary>
        /// ��ȡDbCommand�Ĳ���
        /// </summary>
        /// <returns></returns>
        DbParameter getDbParameter(Object value);

        void setPropertyInfo(PropertyInfo propertyInfo);
    }
}
