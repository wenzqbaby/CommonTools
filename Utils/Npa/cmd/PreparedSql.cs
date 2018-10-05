using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;

namespace Common.Utils.Npa.cmd
{
    public class PreparedSql
    {
        private String _sql;
        /// <summary>
        /// Prepare SQLÓï¾ä
        /// </summary>
        public String Sql
        {
            get { return _sql; }
            set { _sql = value; }
        }

        private List<DbParameter> _parameters = new List<DbParameter>();
        /// <summary>
        /// ²ÎÊý
        /// </summary>
        public List<DbParameter> Parameters
        {
            get { return _parameters; }
        }
    }
}
