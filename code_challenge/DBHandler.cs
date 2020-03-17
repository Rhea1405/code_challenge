using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace code_challenge
{
    class DBHandler
    {
        public static SqlConnection GetConnection()
        {




            SqlConnection SqlCon = new SqlConnection("Password=Admin@123;Persist Security Info=True;User ID=sa;Initial Catalog=ElectricityBillDB;Data Source=DESKTOP-6FSVS29");;
            SqlCon.Open();
            return SqlCon;


        }




    }
}
