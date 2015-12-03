using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication6
{
    public partial class add_mschine : Form
    {
        private MySqlConnection conn;
        private DataTable data;
        private MySqlDataAdapter da;
        private MySqlCommandBuilder cb;
        private DataGrid dataGrid;
        public add_mschine()
        {
            InitializeComponent();
        }

        private void add_machine_save_Click(object sender, EventArgs e)
        {
            string machine_name = this.machine_name.Text.ToString();
            string location = this.location.Text.ToString();
            string install_time = this.install_time.Text.ToString();
            string longitude = this.longitude.Text.ToString();
            string latitude = this.latitude.Text.ToString();
            System.Console.WriteLine(machine_name);
            System.Console.WriteLine(location);
            System.Console.WriteLine(install_time);
            System.Console.WriteLine(longitude);
            System.Console.WriteLine(latitude);

            MySqlConnection myConnection = new MySqlConnection("server=localhost;user id=root;password=root;database=machine;Charset=utf8");
            myConnection.Open();

            string get_max_id = "SELECT * FROM machine_info ORDER BY id DESC LIMIT 0, 1 ;";
            MySqlCommand myCommand_getid = new MySqlCommand(get_max_id, myConnection);
            myCommand_getid.ExecuteNonQuery();
            MySqlDataReader myDataReader = myCommand_getid.ExecuteReader();
            string maxid = "";
            while (myDataReader.Read() == true)
            {
                maxid += myDataReader["id"];
                break;
            }
            myDataReader.Close();
            myConnection.Close();
            System.Console.WriteLine("--------" + maxid);
            int max_id = int.Parse(maxid) +　1;
            myConnection.Open();
            string query = "INSERT INTO machine_info VALUES('" + max_id +"','" + machine_name + "','" + location + "','" + install_time + "','" + longitude + "','" + latitude + "');";
            MySqlCommand myCommand_insert = new MySqlCommand(query, myConnection);
            myCommand_insert.ExecuteNonQuery();
            //MySqlDataReader myDataReader_insert = myCommand_insert.ExecuteReader();
            //string ret = "";
            //while (myDataReader.Read() == true)
            //{
            //    ret += myDataReader;
            //}
            //Console.WriteLine(ret);
            //myDataReader_insert.Close();
            MessageBox.Show("插入成功", "插入结果");
            myConnection.Close();
            this.Close();
        }

        private void add_machine_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;//关键:发送信息
            this.Close();  
            //System.Environment.Exit(System.Environment.ExitCode);
            //this.Dispose();
            //this.Close();
        }
    }
}
