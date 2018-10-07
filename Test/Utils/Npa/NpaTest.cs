using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data.Common;
using Newtonsoft.Json;
using Common.Utils.Npa.Interface;

namespace Test.Utils.Npa
{
    public partial class NpaTest : Form
    {
        private UserDao userDao = new UserDao();

        public NpaTest()
        {
            InitializeComponent();
            //User list = userDao.find();
            //List<User> list = userDao.findAll();
            List<Dept> depts = userDao.getDepts();
        }

        public void test()
        {
            //Byte[] bytes = File.ReadAllBytes(@"D:\WeixinIcon.ico");
            IDataAccess dataAccess = new MySqlDataAccess("Host=192.168.199.196;Database=baby;Username=root;Password=root");
            String findSql = @"SELECT ID, NAME, GENDER, BIRTH, IMAGE FROM USERS WHERE ID ='e9369004bfdb11e8b74df079595d62ca'";
            String prepareSql = @"UPDATE USERS SET NAME = @Name WHERE ID ='e9369004bfdb11e8b74df079595d62ca'";
            String sql = @"INSERT INTO users (ID, NAME, GENDER, BIRTH) VALUES (@Id, @Name, @Gender, @Birth)";
            List<DbParameter> list = new List<DbParameter>();

            DbParameter id = new MySqlParameter("@Id", MySqlDbType.VarChar);
            id.Value = Guid.NewGuid().ToString("N").ToUpper();
            list.Add(id);

            DbParameter name = new MySqlParameter("@Name", MySqlDbType.VarChar);
            name.Value = "Jiu";
            list.Add(name);

            DbParameter gender = new MySqlParameter("@Gender", MySqlDbType.VarChar);
            gender.Value = "F";
            list.Add(gender);

            DbParameter birth = new MySqlParameter("@Birth", MySqlDbType.Timestamp);
            birth.Value = "1990-09-09 09:09:09";
            list.Add(birth);
            //int i = dataAccess.insert(sql, id, gender, birth, name);

            DataSet ds = dataAccess.select(findSql);
            foreach (DataRow var in ds.Tables[0].Rows)
            {
                String str = JsonConvert.SerializeObject(var.ItemArray);
            }
            //DbParameter para = new MySqlParameter("@Name", MySqlDbType.VarChar);
            //para.Value = "Mama";

            //foreach (DbParameter var in adapter.UpdateCommand.Parameters)
            //{
            //    String str = var.Value.ToString();
            //}
            //String json = JsonConvert.SerializeObject(adapter.UpdateCommand.Parameters);
            //DataSet ds = new DataSet();
            //adapter.Fill(ds);
            //foreach (DataRow var in ds.Tables[0].Rows)
            //{
            //    String str = var.ToString();
            //}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            testNpa();
            MessageBox.Show("更新成功");
        }

        public void testNpa()
        {
            User u = new User();
            u.Id = tbId.Text.Trim();
            //u.Name = tbName.Text.Trim();
            //u.Sex = cbGender.Text.Trim();
            u.Birth = dtpBirth.Value.ToString("yyyy-MM-dd HH:mm:ss");
            if (!String.IsNullOrEmpty(lbImage.Text))
            {
                u.Image = File.ReadAllBytes(lbImage.Text);
            }
            userDao.updateWithNull(u);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "C# Corner Open File Dialog";
            fdlg.InitialDirectory = @"d:\";   //@是取消转义字符的意思
            fdlg.Filter = "All files（*.*）|*.*|All files(*.*)|*.* ";
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                lbImage.Text = fdlg.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbId.Text = Guid.NewGuid().ToString("N").ToUpper();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.Id = tbId.Text.Trim();
            u.Name = tbName.Text.Trim();
            u.Sex = cbGender.Text.Trim();
            u.Birth = dtpBirth.Value.ToString("yyyy-MM-dd HH:mm:ss");
            if (!String.IsNullOrEmpty(lbImage.Text))
            {
                u.Image = File.ReadAllBytes(lbImage.Text);
            }
            userDao.insert(u);
            MessageBox.Show("保存成功");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.Id = tbId.Text.Trim();
            userDao.delete(u);
            MessageBox.Show("删除成功");
        }
    }
}