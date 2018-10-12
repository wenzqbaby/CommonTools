using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Cmd;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/6
    /// desc:   ��������ȡ�ӿ�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISave<T>
    {
        /// <summary>
        /// ����ʵ�����ɲ����SQL���
        /// </summary>
        /// <param name="t">ʵ��</param>
        /// <returns>SQL���</returns>
        String getSql(T t);

        /// <summary>
        /// ����ʵ�����ɲ���Ĳ�����SQL���
        /// </summary>
        /// <param name="t">ʵ��</param>
        /// <returns>SQL���</returns>
        PreparedCmd getPreparedSql(T t);
    }
}
