using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace code_challenge.code_challeneg_vehicle
{
    class VehicleRegister
    {
        public SqlConnection SqlCon
        {
            get
            {
                return DBHandler.GetConnection();
            }
        }
        public void AddVehicle(VehicleDetails detail)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into VehicleDetails values(@vno,@brand,@dom,@dor,@vehtype,@vehbuyer,@cost,@rcost)", SqlCon); 
                cmd.Parameters.AddWithValue("@vno", detail.VehicleNo);

                cmd.Parameters.AddWithValue("@brand", detail.Brand);
                cmd.Parameters.AddWithValue("@dom", detail.DateofManufacture);
                cmd.Parameters.AddWithValue("@dor", detail.DateofRegistration);
                cmd.Parameters.AddWithValue("@vehtype", detail.VehicleType);
                cmd.Parameters.AddWithValue("@vehbuyer", detail.VehicleBuyer);
                cmd.Parameters.AddWithValue("@cost", detail.Cost);
                cmd.Parameters.AddWithValue("@rcost", detail.Regcost);
                
                int r = cmd.ExecuteNonQuery();

            }
          
            finally
            {
                SqlCon.Close();
            }
        }
        public int CalculateCost(VehicleDetails detail)
        {
            double cost = detail.Cost;
            DateTime dom = detail.DateofManufacture;
            DateTime now = DateTime.Now;
            TimeSpan t = now.Subtract(dom);
            int lifetime = (int)t.TotalDays / 365;

            if(detail.VehicleBuyer=="New")
            {
                if(detail.VehicleType=="2 Wheeler")
                {
                    detail.Regcost = 12 * (cost) / 100;
                }
                if (detail.VehicleType == "4 Wheeler")
                {
                    detail.Regcost = 14 *(cost) / 100;
                }
            }

            if (detail.VehicleBuyer == "Old")
            {
                if (detail.VehicleType == "2 Wheeler")
                {

                    if (lifetime >= 5)
                    {
                        detail.Regcost = 8 * (cost) / 100;
                    }
                    else if (lifetime >= 3 && lifetime < 5)
                    {
                        detail.Regcost = 9 * (cost) / 100;
                    }
                    else if (lifetime < 3)
                    {
                        detail.Regcost = 10 * (cost) / 100;
                    }

                }
                if (detail.VehicleType == "4 Wheeler")
                {
                    if (lifetime >= 5)
                    {
                        detail.Regcost = 9 *(cost) / 100;
                    }
                    else if (lifetime >= 3 && lifetime < 5)
                    {
                        detail.Regcost = (float)(10.5 * (cost) / 100);
                    }
                    else if (lifetime < 3)
                    {
                        detail.Regcost = (float)(12.5 * (cost) / 100);
                    }

                }


                }

            return lifetime;
        }


       public List<VehicleDetails> DisplayDetails(DateTime startDate, DateTime endDate)
        {
            List<VehicleDetails> lv = new List<VehicleDetails>();
            try
            {

               
                SqlCommand cmd = new SqlCommand("select * from VehicleDetails where Date_of_Registration between @s and @e", SqlCon);
                cmd.Parameters.AddWithValue("@s", startDate);
                cmd.Parameters.AddWithValue("@e", endDate);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())

                {
                    VehicleDetails vd = new VehicleDetails();
                    vd.VehicleNo = r[0].ToString();
                    vd.Brand = r[1].ToString();
                    vd.DateofManufacture = DateTime.Parse(r[2].ToString());
                    vd.DateofRegistration = DateTime.Parse(r[3].ToString());
                    vd.VehicleType = r[4].ToString();
                    vd.VehicleBuyer = r[5].ToString();
                    vd.Cost = int.Parse(r[6].ToString());
                    vd.Regcost = double.Parse(r[7].ToString());
                    lv.Add(vd);

                }
            }
            catch(SqlException s)
            {
                Console.WriteLine(s.Message);
            }
            finally
            {
                SqlCon.Close();
            }


            return lv;

        }


    }
}
