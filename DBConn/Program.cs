using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace DBConn
{
    class Program
    {
        static void Main(string[] args)
        {


            String connetStr = "server = 127.0.0.1; port = 3306; user = root; " +
                "password = ; database = test;";
            MySqlConnection conn = new MySqlConnection(connetStr);
            try
            {
                conn.Open();
                Console.WriteLine("已经建立连接");
                string sql = "select * from ab";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                //Console.WriteLine(reader.GetString("id") + "   " + reader.GetString("password"));
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString("id") + "   " + reader.GetString("password"));
                }

            }
            catch (MySqlException ex)
            {

                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server, Contact administrator");
                        break;
                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
            }
            finally
            {
                conn.Close();
            }



            Console.ReadKey();

        }
    }
}
