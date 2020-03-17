using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace code_challenge
{
    class ElectricityBoard
    {


        public SqlConnection SqlCon 
 
        {
            
            get
            {

               
                return DBHandler.GetConnection();
                
            }
        }

        

      
       

        
        
       
       public void AddBill(ElectricityBill ebill)
        {

            try
            {

                
               SqlCommand cmd = new SqlCommand("insert into ElectricityBill values(@cno,@cname,@u,@bill)", SqlCon);
                cmd.Parameters.AddWithValue("@cno", ebill.ConsumerNumber);
                cmd.Parameters.AddWithValue("@cname", ebill.ConsumerName);
                cmd.Parameters.AddWithValue("@u", ebill.UnitsConsumed);
                CalculateBill(ebill);
                cmd.Parameters.AddWithValue("@bill", ebill.BillAmount);
               // SqlCon.Open();
                int r = cmd.ExecuteNonQuery();

            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {

                SqlCon.Close();
            }
            
        }
       public void CalculateBill(ElectricityBill ebill)
        {
            int un = ebill.UnitsConsumed;
            double amt = ebill.BillAmount;
            if(un<=100)
            {
                amt = 0;
            }

            else if(un>100 && un<=300)
            {

                amt = amt + 100 * 0 + (un - 100) * 1.5;

            }
            else if(un>300 && un<=600)
            {
                amt = amt + 100 * 0 + 200 * 1.5 + (un - 300) * 3.5;
            }
            else if(un>600 && un<=1000)
            {
                amt = amt + 100 * 0 + 200 * 1.5 + 300 * 3.5+(un-600)*5.5;
            }
            else if(un>1000)
            {
                amt = amt + 100 * 0 + 200 * 1.5 + 300 * 3.5 + 600 * 5.5+(un-1000)*7.5;
            }
            ebill.BillAmount = amt;
            

        }
         public List<ElectricityBill> Generate_N_BillDetails(int num)
        {
            List<ElectricityBill> list = new List<ElectricityBill>();
            SqlCommand cmd = new SqlCommand();
            try
            {
               // SqlCon.Open();
               

               // ElectricityBill eb = new ElectricityBill();

                cmd = new SqlCommand("select top "+num+" * from ElectricityBill order by consumer_number desc",SqlCon);
                SqlDataReader r = cmd.ExecuteReader();
               // DataSet d = new DataSet();
               // d.Tables.Add("e");
               // d.Tables["e"].Load(r);

                for (int i = 0; i < num; i++)
                {
                    ElectricityBill eb = new ElectricityBill();
                    r.Read();
                    eb.ConsumerNumber = r[0].ToString();
                    eb.ConsumerName = r[1].ToString();
                    eb.UnitsConsumed = int.Parse(r[2].ToString());
                    eb.BillAmount = double.Parse(r[3].ToString());
                    list.Add(eb);

                }





               
            }
            finally
            {
                SqlCon.Close();
            }

            return list;

        }
        
    }
}
