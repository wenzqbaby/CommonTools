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
        public NpaTest()
        {
            InitializeComponent();
            //Byte[] bytes = File.ReadAllBytes(@"D:\WeixinIcon.ico");
            UserDao userDao = new UserDao();
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
    }
}