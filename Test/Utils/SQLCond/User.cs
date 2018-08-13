using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.SqlCond.Attributes;
using Common.Utils.SqlCond.Enum;

namespace Test.Utils.SqlCond
{
    public class User
    {
        private String _name;
        [CondEq]
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private String _birth;
        [CondElt]
        public String Birth
        {
            get { return _birth; }
            set { _birth = value; }
        }

        private CondBetween.Holder _gender = new CondBetween.Holder();
        [CondBetween(SqlType = SqlType.NUMBER)]
        public CondBetween.Holder Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
    }
}
