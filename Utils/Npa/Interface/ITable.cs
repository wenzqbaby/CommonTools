using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/6
    /// desc:   ���ݱ�ӿ�
    /// </summary>
    public interface ITable
    {
        /// <summary>
        /// ���õ�ǰ��������
        /// </summary>
        /// <param name="t"></param>
        void setType(Type t);

        /// <summary>
        /// ��ȡ���ݱ���
        /// </summary>
        /// <returns></returns>
        String getTableName();

        /// <summary>
        /// ��ȡ�����ռ���
        /// </summary>
        /// <returns></returns>
        String getScheme();
    }
}
