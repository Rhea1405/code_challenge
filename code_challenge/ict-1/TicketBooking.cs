using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace code_challenge.ict_1
{
    class TicketBooking
    {

        public SqlConnection SqlCon
        {
            get
            {
                return DBHandler.GetConnection();
            }
        }
        public void AddTicket(TicketDetail detail)
        {
            try
            {
                SqlCommand cmd = null;
                cmd = new SqlCommand("insert into TicketBooking values(@pid,@pn,@td,@d,@cost)", SqlCon);
                cmd.Parameters.AddWithValue("@pid", detail.Passengerid);
                cmd.Parameters.AddWithValue("@pn", detail.PassengerName);
                cmd.Parameters.AddWithValue("@td", detail.TravelDate);
                cmd.Parameters.AddWithValue("@d", detail.DistanceTravel);
                cmd.Parameters.AddWithValue("@cost", detail.TicketCost);
                CalculateCost(detail);
                int r = cmd.ExecuteNonQuery();
            }
            catch (SqlException s)
            {
                Console.WriteLine(s);
            }
            finally
            {
                SqlCon.Close();
            }

        }
        public void CalculateCost(TicketDetail detail)
        {
            int d = detail.DistanceTravel;
            double cost = detail.TicketCost;
            if(d<=100)
            {
                cost= d*1;
            }
            else if(d>100 && d<=300)
            {

                cost = d * 1.5;
            }
            else if(d>300 && d<=500)
            {
                cost = d * 2.5;

            }
            else if(d>500)
            {
                cost = d * 4.5;
            }


            detail.TicketCost = cost;
        }


    }
}
