using System;
using System.Collections.Generic;
using System.Text;

namespace code_challenge.ict_1
{
    class TicketDetail
    {
        string passengerid;
        string passengerName;
        string travelDate;
        int distanceTravel;
        double ticketCost;

        public string Passengerid { get => passengerid; set => passengerid = value; }
        public string PassengerName { get => passengerName; set => passengerName = value; }
        public string TravelDate { get => travelDate; set => travelDate = value; }
        public int DistanceTravel { get => distanceTravel; set => distanceTravel = value; }
        public double TicketCost { get => ticketCost; set => ticketCost = value; }
    }
}
