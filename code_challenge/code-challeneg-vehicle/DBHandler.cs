using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace code_challenge.code_challeneg_vehicle
{
    class DBHandler
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection SqlCon = new SqlConnection("Password=Admin@123;Persist Security Info=True;User ID=sa;Initial Catalog=VehicleRegistrationDB;Data Source=DESKTOP-6FSVS29");
            SqlCon.Open();
            return SqlCon;

        }
    }
}
