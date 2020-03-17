using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace code_challenge.code_challeneg_vehicle
{
    class VehicleValidator
    {


        public String ValidateVehicle(string VehicleNo)
        {
            
            string pattern = @"^[A-Z]{2}[0-9]{1,2}\s[A-Z]{2}\s[0-9]{4}$";
            bool res = Regex.IsMatch(VehicleNo, pattern);
            if(res==true)
            {
                return null;
            }
            else
            {
                return "Given Vehicle no  is invalid";
            }
            
        }
    }
}
