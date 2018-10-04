using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa;

namespace Test.Utils.Npa
{
    class UserDao : BaseNpa<User>
    {
        public UserDao()
            : base(new MySqlDataAccess("Host=192.168.199.196;Database=baby;Username=root;Password=root"))
        {

        }
    }
}
