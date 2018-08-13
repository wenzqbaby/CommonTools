using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.SqlCond.Enum
{
    /// <summary>
    /// Created by wenzq on 2018/7/20.
    /// ���ݿ��ֶ�����ö��
    /// </summary>
    public enum SqlType
    {
        /// <summary>
        /// �ַ����ͣ�������VARCHAR, CHAR��
        /// </summary>
        STRING,
        /// <summary>
        /// �������ͣ�������INTEGER��SHORT��DECIMAL��
        /// </summary>
        NUMBER,
        /// <summary>
        /// ʱ�����͸�ʽ��TIMESTAMP
        /// ����������Ϊ�ַ��������ʽΪyyyy-MM-dd HH:mm:ss
        /// </summary>
        TIMESTAMP,
    }
}
