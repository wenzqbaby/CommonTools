using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

namespace Common.Utils.Npa.Cmd
{
    /// <summary>
    /// ������ָ��
    /// </summary>
    public class PreparedCmd
    {
        private String _sql;
        /// <summary>
        /// ������SQL���
        /// </summary>
        public String Sql
        {
            get { return _sql; }
            set { _sql = value; }
        }

        private List<DbParameter> _parameters = new List<DbParameter>();
        /// <summary>
        /// ��������
        /// </summary>
        public List<DbParameter> Parameters
        {
            get { return _parameters; }
        }
    }
}
