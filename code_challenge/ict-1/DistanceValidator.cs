using System;
using System.Collections.Generic;
using System.Text;

namespace code_challenge.ict_1
{
    class DistanceValidator
    {
        public string ValidateTravelDistance(int TravelDistance)
        {
            if(TravelDistance<0)
            {
                return "Given distance is invalid";

            }
            else
            {
                return null;
            }
        }



    }
}
