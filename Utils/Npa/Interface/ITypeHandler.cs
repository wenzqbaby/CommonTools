using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// ���;���ӿ�
    /// </summary>
    public interface ITypeHandler
    {
        /// <summary>
        /// �����ݿ��ȡ��ʽ��Ϊ���ԵĽ��
        /// </summary>
        /// <param name="dataRow">������</param>
        /// <param name="columnName">����</param>
        /// <returns></returns>
        Object getResult(DataRow dataRow, String columnName);

        /// <summary>
        /// ��ʽ�����Ե�ֵΪ���ݿ��ֵ
        /// </summary>
        /// <param name="obj">Ҫ��ʽ����ֵ</param>
        /// <param name="propName">���ݿ��ֵ</param>
        /// <returns></returns>
        Object formatToDb(Object value);

        /// <summary>
        /// ��ʽ�����ݿ��ֵΪ���Ե�ֵ
        /// </summary>
        /// <param name="dbValue"></param>
        /// <returns></returns>
        Object formatToProp(Object dbValue);
    }
}
