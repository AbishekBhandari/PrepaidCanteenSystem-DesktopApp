using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen_Management_System
{
    internal class MyConnection
    {
        public SqlConnection con;
        public MyConnection()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstring"].ConnectionString);

        }
        public static string role;
        public static string username;
        public static string registration;
        public static string balance;
        public static int ID;

    }

   
}
