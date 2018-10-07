using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa;
using Common.Utils.Npa.cmd;

namespace Test.Utils.Npa
{
    class UserDao : BaseNpa<User>
    {
        public UserDao()
            : base(new MySqlDataAccess("Host=192.168.199.196;Database=baby;Username=root;Password=root"))
        {
            
        }

        public List<Dept> getDepts()
        {
            String sql = @"SELECT
  dept.DEPT_CODE DEPT_CODE,
  dept.NAME DEPT_NAME,
  ID ID,
  users.NAME NAME,
  GENDER GENDER,
  BIRTH BIRTH,
  IMAGE IMAGE
FROM baby.dept LEFT JOIN users
    ON dept.DEPT_CODE = users.DEPT_CODE";
            List<ResultCmd> rcmds = new List<ResultCmd>();
            rcmds.Add(new ResultCmd("DeptCode", "DEPT_CODE"));
            rcmds.Add(new ResultCmd("Name", "DEPT_NAME"));
            ResultCollectionCmd<User> colect = new ResultCollectionCmd<User>();
            colect.Property = "Users";
            colect.Results = new Dictionary<string, ResultCmd>();
            colect.Results["ID"] = new ResultCmd("Id", "ID");
            colect.Results["NAME"] = new ResultCmd("Name", "NAME");
            colect.Results["GENDER"] = new ResultCmd("Sex", "GENDER");
            colect.Results["BIRTH"] = new ResultCmd("Birth", "BIRTH");
            colect.Results["IMAGE"] = new ResultCmd("Image", "IMAGE");
            return this.query<Dept, User>(sql, rcmds, colect);
        }
    }
}
