using System;
using System.Collections.Generic;
using System.Text;

namespace code_challenge.ict_1
{
    class mainclass
    {
        static void Main(string[] args)
        {
            DistanceValidator dv = new DistanceValidator();
            TicketDetail td = null; ;
            List<TicketDetail> list = new List<TicketDetail>();
            TicketBooking tb = new TicketBooking();
            Console.WriteLine("Enter Ticket Details:");


            while (true)
            {
                td = new TicketDetail();
                Console.WriteLine("Enter Passenger Id:");
                string pid = Console.ReadLine();
                td.Passengerid = pid;

                Console.WriteLine("Enter Passenger Name:");
                string pname = Console.ReadLine();
                td.PassengerName = pname;
                Console.WriteLine("Enter Travel Date:");
                string date = Console.ReadLine();
                td.TravelDate = date;
                Console.WriteLine("Enter Distance Travelled:");
                int dis = int.Parse(Console.ReadLine());
                

                string res = dv.ValidateTravelDistance(dis);
                if (res!= null)
                {
                    Console.WriteLine(res);
                    Console.WriteLine("Enter Distance Travelled:");
                    dis = int.Parse(Console.ReadLine());

                    res = dv.ValidateTravelDistance(dis);

                }
                else
                {
                    td.DistanceTravel = dis;
                    tb.AddTicket(td);


                }
                list.Add(td);


                Console.WriteLine("Book Another Ticket[y/n]:");
                string choice = Console.ReadLine();
                if(choice.Equals("n"))
                {
                    break;
                }

            }
            Console.WriteLine();
            for(int i=0;i<list.Count;i++)
            {
                Console.WriteLine(list[i].Passengerid + "\n" + list[i].PassengerName + "\n" + list[i].TravelDate + "\n" + list[i].DistanceTravel + "\n" + "Ticket Cost:" + list[i].TicketCost);
                Console.WriteLine();
            }
            

        }
    }
}
