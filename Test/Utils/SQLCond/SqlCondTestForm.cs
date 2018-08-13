using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.Utils.SqlCond;

namespace Test.Utils.SqlCond
{
    public partial class SqlCondTestForm : Form
    {
        public SqlCondTestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.Name = "Baby";
            u.Gender.Max = 18;
            u.Gender.Min = 10;
            u.Birth = "2000-01-01 00:00:00";
            MessageBox.Show(SqlCondUtil.getWhereCond(u));
        }
    }
}