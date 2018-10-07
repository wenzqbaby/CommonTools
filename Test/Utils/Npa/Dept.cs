using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Utils.Npa
{
    public class Dept
    {
        private String _deptCode;

        public String DeptCode
        {
            get { return _deptCode; }
            set { _deptCode = value; }
        }

        private String _name;

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private List<User> _users;

        public List<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }

         
    // override object.Equals
        public override bool Equals(object obj)
        {

        //       
        // See the full list of guidelines at
        //   http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconequals.asp    
        // and also the guidance for operator== at
        //   http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconimplementingequalsoperator.asp
        //

            if (obj == null || GetType() != obj.GetType()) 
            {
                return false;
            }
            Dept d = obj as Dept;
            return this.DeptCode.Equals(d.DeptCode) && this.Name.Equals(d.Name);
     
        }
    
        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.DeptCode.GetHashCode() + this.Name.GetHashCode();
        }

    }
}
