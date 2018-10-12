using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Interface;

namespace Common.Utils.Npa.Sql
{
    /// <summary>
    /// author: wenzq
    /// date:   2018/10/5
    /// desc:   ����ȡ����
    /// </summary>
    public abstract class BaseSql
    {
        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="scheme">���ݿ���</param>
        /// <param name="table">���ݱ���</param>
        /// <param name="columnDic">��������Ӧ�������нӿڼ���</param>
        /// <param name="idColumns">�������Ե������нӿڼ���</param>
        public BaseSql(String scheme, String table, Dictionary<String, IColumn> columnDic, List<IColumn> idColumns)
        {
            TAG = this.GetType().ToString();
            mScheme = scheme;
            mTable = table;
            mColumns = columnDic;
            mIds = idColumns;
            if (!String.IsNullOrEmpty(mScheme))
            {
                mFullTable = mScheme + ".";
            }
            mFullTable += mTable;
        }

        protected String TAG;

        /// <summary>
        /// ���ݿ���
        /// </summary>
        protected String mScheme;

        /// <summary>
        /// ���ݱ���
        /// </summary>
        protected String mTable;

        /// <summary>
        /// ���ݱ�ȫ��
        /// </summary>
        protected String mFullTable = String.Empty;

        /// <summary>
        /// ��������Ӧ�������нӿڼ���
        /// </summary>
        protected Dictionary<String, IColumn> mColumns;

        /// <summary>
        /// �������Ե������нӿڼ���
        /// </summary>
        protected List<IColumn> mIds;

        /// <summary>
        /// ʵ������
        /// </summary>
        protected Type mType;
    }
}
