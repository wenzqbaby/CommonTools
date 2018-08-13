using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.Utils.Cache;

namespace Test.Utils.Cache
{
    /// <summary>
    /// Created by wenzq on 2018/8/6.
    /// ICache测试
    /// </summary>
    public partial class CacheTest : Form
    {
        private ICache<String,User> cache = new MyCache();
        private ICache<String, String> cachea = new ACache();

        public CacheTest()
        {
            InitializeComponent();
            cache.put("aaa", new User("Baby", "20"));
            cachea.put("A", "Apple");
            cachea.put("B", "Baby");
            cachea.put("C", "Cat");
            cachea.put("D", null);
            cachea.put(null, "NULL");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User value = cache.get("aaa");
            if (value == null)
            {
                MessageBox.Show("无此缓存");
                return;
            }
            value.Name = "hahah";
            MessageBox.Show(String.Format("缓存对象：{0}\r\n新对象：{1}", cache.get("aaa"), value.ToString()));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<String, User> dd = cache.getAll();
            MessageBox.Show(dd.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String s = cachea.get(null);
            if (s == null)
            {
                MessageBox.Show("无此缓存");
                return;
            }
        }

        #region 缓存内部类

        private class MyCache : BaseCache<String, User>
        {
            public MyCache() : base(100) { }

            protected override User cloneValue(User value)
            {
                return new User(value.Name, value.Sex);
            }
        }

        private class ACache : BaseCache<String, String>
        {
            public ACache() : base(100) { }

            protected override string cloneValue(string value)
            {
                return value.Clone() as String;
            }
        }

        #endregion
        
        #region 实体类

        private class User
        {
            private String name;

            public String Name
            {
                get { return name; }
                set { name = value; }
            }
            private String sex;

            public String Sex
            {
                get { return sex; }
                set { sex = value; }
            }

            public User() { }

            public User(String name, String sex)
            {
                this.name = name;
                this.sex = sex;
            }

            public override string ToString()
            {
                return String.Format("[User(name = {0}, sex = {1})]", name, sex);
            }
        }

        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            cache.clear();
        }
        
    }
}