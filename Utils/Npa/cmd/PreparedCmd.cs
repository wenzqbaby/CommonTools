using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

namespace Common.Utils.Npa.cmd
{
    /// <summary>
    /// 预备Sql的指令对象
    /// </summary>
    public class PreparedCmd
    {
        private String _sql;
        /// <summary>
        /// Prepared SQL语句
        /// </summary>
        public String Sql
        {
            get { return _sql; }
            set { _sql = value; }
        }

        private List<DbParameter> _parameters = new List<DbParameter>();
        /// <summary>
        /// 参数集合
        /// </summary>
        public List<DbParameter> Parameters
        {
            get { return _parameters; }
        }
    }
}
