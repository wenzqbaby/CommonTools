using System;
using System.Collections.Generic;
using System.Text;
using Common.Utils.Npa.Attributes;

namespace Test.Utils.Npa
{
    [Entity(TableName = "USERS")]
    class User
    {
        private String _id;
        [MySqlColumn]
        public String Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private String _name;
        [MySqlColumn]
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private String _birth;
        [MySqlTimestamp]
        public String Birth
        {
            get { return _birth; }
            set { _birth = value; }
        }

        private byte[] _image;

        public byte[] Image
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}
