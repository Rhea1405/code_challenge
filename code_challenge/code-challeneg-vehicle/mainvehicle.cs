using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace code_challenge.code_challeneg_vehicle
{
    class mainvehicle
    {
        static void Main(string[] args)
        {
            VehicleRegister VR = new VehicleRegister();
            VehicleValidator vv = new VehicleValidator();
            VehicleDetails vd = new VehicleDetails();
            Console.WriteLine("Enter your choice:");
            Console.WriteLine("1.Add Vehicle and display it");
            Console.WriteLine("2.Get vehicles between 2 dates");
            int ch = int.Parse(Console.ReadLine());
            if (ch == 1)
            {
                Console.WriteLine("Enter Vehicle Details:");
                Console.WriteLine();
                Console.WriteLine("Enter VehicleNo:");
                string vno = Console.ReadLine();

                string res = vv.ValidateVehicle(vno);
                if (res != null)
                {

                    Console.WriteLine(res);

                }
                else
                {
                    vd.VehicleNo = vno;




                    Console.WriteLine("Enter Brand:");
                    string brand = Console.ReadLine();
                    vd.Brand = brand;


                    Console.WriteLine("Enter Date of Manufacture:");
                    DateTime dom = DateTime.ParseExact(Console.ReadLine(), "dd-MMM-yyyy", CultureInfo.InvariantCulture);
                    
                  



                        vd.DateofManufacture = dom;


                        Console.WriteLine("Enter Date of Registration:");
                        DateTime dor = DateTime.ParseExact(Console.ReadLine(),"dd-MMM-yyyy",CultureInfo.InvariantCulture);
                        vd.DateofRegistration = dor;

                        Console.WriteLine("Enter VehicleType:");
                        string vt = Console.ReadLine();
                        vd.VehicleType = vt;

                        Console.WriteLine("Enter Vehicle Buyer:");
                        string vb = Console.ReadLine();
                        vd.VehicleBuyer = vb;

                        Console.WriteLine("Enter Cost:");
                        int cost = int.Parse(Console.ReadLine());
                        vd.Cost = cost;
                    int lifespan = VR.CalculateCost(vd);
                    if (lifespan > 15)
                    {
                        Console.WriteLine("Given Vehicle cannot be registered as it is more than  15  year");
                    }

                    else
                    {


                        Console.WriteLine("Vehicle Details are as follows");
                        VR.CalculateCost(vd);
                        Console.WriteLine("Enter VehicleNo:" + "\t\t\t" + vno);
                        Console.WriteLine("Enter Brand:" + "\t\t\t\t" + brand);
                        Console.WriteLine("Enter Date of Manufacture:"+"\t\t"+dom.ToString("dd-MMM-yyyy"));
                        Console.WriteLine("Enter Date of Registration:" + "\t\t" + dor.ToString("dd-MMM-yyyy"));
                        Console.WriteLine("Enter VehicleType:" + "\t\t\t" + vt);
                        Console.WriteLine("Enter Vehicle Buyer:" + "\t\t\t" + vb);
                        Console.WriteLine("Vehicle Cost" + "\t\t\t\t" + cost);
                        Console.WriteLine("Registration Cost" + "\t\t\t" + vd.Regcost);
                        Console.WriteLine("Vehicle life" + "\t\t\t\t" + lifespan);
                        Console.WriteLine("Confirm the details Y/N?");
                        string choice = Console.ReadLine();
                        if (choice == "Y")
                        {
                            VR.AddVehicle(vd);
                        }
                        else
                        {
                            System.Environment.Exit(0);
                        }

                    }
                }
            }
            else if(ch==2)
            {
                Console.Write("Enter start date:");
                DateTime sd = DateTime.ParseExact(Console.ReadLine(), "dd-MMM-yyyy",CultureInfo.InvariantCulture);
                Console.Write("Enter end date:");
                DateTime ed = DateTime.ParseExact(Console.ReadLine(), "dd-MMM-yyyy", CultureInfo.InvariantCulture);

               List<VehicleDetails> list= VR.DisplayDetails(sd, ed);
                Console.WriteLine("{0,-15} {1,-10} {2,-25} {3,-25} {4,-19} {5,-16} {6,-6} {7,-20}\n","Vehicle No","Brand","Date of Manufacture","Date of Registration","Vehicle Type","Vehicle Buyer","Cost","Registration cost");
                for(int i=0;i<list.Count;i++)
                {
                    Console.WriteLine("{0,-15} {1,-10} {2,-25} {3,-25} {4,-19} {5,-16} {6,-6} {7,-20}\n", list[i].VehicleNo,list[i].Brand,list[i].DateofManufacture.ToString("dd-MMM-yyyy"),list[i].DateofRegistration.ToString("dd-MMM-yyyy"),list[i].VehicleType,list[i].VehicleBuyer,list[i].Cost,list[i].Regcost);
                }


            }





        }


    }
}
