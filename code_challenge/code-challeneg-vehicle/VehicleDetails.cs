using System;
using System.Collections.Generic;
using System.Text;

namespace code_challenge.code_challeneg_vehicle
{
    class VehicleDetails
    {

        string vehicleNo;
        string brand;
        DateTime dateofManufacture;
        DateTime dateofRegistration;
        string vehicleType;
        string vehicleBuyer;
        float cost;
        double regcost;

        public string VehicleNo { get => vehicleNo; set => vehicleNo = value; }
        public string Brand { get => brand; set => brand = value; }
        public DateTime DateofManufacture { get => dateofManufacture; set => dateofManufacture = value; }
        public DateTime DateofRegistration { get => dateofRegistration; set => dateofRegistration = value; }
        public string VehicleType { get => vehicleType; set => vehicleType = value; }
        public string VehicleBuyer { get => vehicleBuyer; set => vehicleBuyer = value; }
        public float Cost { get => cost; set => cost = value; }
        public double Regcost { get => regcost; set => regcost = value; }
    }
}
