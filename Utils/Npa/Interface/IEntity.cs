using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Npa.Interface
{
    /// <summary>
    /// ����ʵ��ӿ�
    /// </summary>
    public interface IEntity
    {
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
