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
            string longitude = this.longitude.Text.ToString();
            System.Console.WriteLine(longitude);
            string latitude = this.latitude.Text.ToString();
            System.Console.WriteLine(latitude);
            string query = "select * from t_user";
            MySqlConnection myConnection = new MySqlConnection("server=localhost;user id=root;password=root;database=machine");
            MySqlCommand myCommand = new MySqlCommand(query, myConnection);
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            MySqlDataReader myDataReader = myCommand.ExecuteReader();
            string bookres = "";
            while (myDataReader.Read() == true)
            {
                bookres += myDataReader["id"];
                bookres += myDataReader["name"];
                bookres += myDataReader["password"];
            }
            myDataReader.Close();
            myConnection.Close();
            Console.WriteLine(bookres);
        }
    }
}
