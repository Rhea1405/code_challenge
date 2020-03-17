using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace code_challenge
{
    class BillValidator
    {

        public String ValidateUnitsConsumed(int UnitsConsumed)
        {
            


            if (UnitsConsumed<0)
            {
                return "Given units is invalid";
            }
            else
            {
                return null;
            }
            
            
        }


    }
}
