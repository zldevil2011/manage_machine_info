using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace WindowsFormsApplication6.publicClass
{
    class MySQLDataHelper
    {
        /// <summary>
        /// 建立数据库连接.
        /// </summary>
        /// <returns>返回MySqlConnection对象</returns>
        public MySqlConnection getmysqlcon()
        {
            string M_str_sqlcon = "server=localhost;user id=root;password=root;database=machine"; //根据自己的设置
            MySqlConnection myCon = new MySqlConnection(M_str_sqlcon);
            return myCon;
        }
        /// <summary>
        /// 执行MySqlCommand
        /// </summary>
        /// <param name="M_str_sqlstr">SQL语句</param>
        public void getmysqlcom(string M_str_sqlstr)
        {
            MySqlConnection mysqlcon = this.getmysqlcon();
            mysqlcon.Open();
            MySqlCommand mysqlcom = new MySqlCommand(M_str_sqlstr, mysqlcon);
            mysqlcom.ExecuteNonQuery();
            mysqlcom.Dispose();
            mysqlcon.Close();
            mysqlcon.Dispose();
        }
        public void get_query()
        {
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
