using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Cmd;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/7
    /// desc:   �����нӿ�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDelete<T>
    {
        /// <summary>
        /// ����ʵ���������������ɾ��SQL��䣬�����������������Ҳ���Ϊ��
        /// </summary>
        /// <param name="t">ʵ��</param>
        /// <returns>SQL���</returns>
        String getSql(T t);

        /// <summary>
        /// ����ʵ��������������ɲ�������ɾ��SQL��䣬�����������������Ҳ���Ϊ��
        /// </summary>
        /// <param name="t">ʵ��</param>
        /// <returns>������ָ��</returns>
        PreparedCmd getPreparedSql(T t);
    }
}
