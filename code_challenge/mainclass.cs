using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace code_challenge
{
    class mainclass
    {
        static void Main(string[] args)
        {
            BillValidator bv = new BillValidator();
            ElectricityBoard ebd = new ElectricityBoard();
            ElectricityBill eb = null;
            List<ElectricityBill> l = new List<ElectricityBill>();
           
            string pattern = @"(^[E][B][0-9]{5}$)";


            Console.WriteLine("Enter Number of bills to be added:");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                try
                {
                    eb = new ElectricityBill();

                    Console.WriteLine("Enter Consumer Number:");
                    string cno = Console.ReadLine();
                    eb.ConsumerNumber = cno;
                    bool check = Regex.IsMatch(cno, pattern);
                    if (check == false)
                    {
                        throw new FormatException("Invalid Consumer Number");
                    }
                }
                catch (FormatException f)
                {
                    Console.WriteLine(f.Message);
                    break;

                }






                Console.WriteLine("Enter Consumer Name:");
                    string cname = Console.ReadLine();
                    eb.ConsumerName = cname;

                    Console.WriteLine("Enter Units Consumed:");
                    int u = int.Parse(Console.ReadLine());
                    string s = bv.ValidateUnitsConsumed(u);
                    if (s != null)
                    {
                        Console.WriteLine(s);
                        Console.WriteLine("Enter Units Consumed:");
                        u = int.Parse(Console.ReadLine());
                        s = bv.ValidateUnitsConsumed(u);

                    }
                    else
                    {
                        eb.UnitsConsumed = u;
                        ebd.AddBill(eb);
                    }
                
              

                l.Add(eb);
                }
                
           
            Console.WriteLine("Enter Last 'N' Number of Bills To Generate:");
            int N = int.Parse(Console.ReadLine());

          List<ElectricityBill> list= ebd.Generate_N_BillDetails(N);
            Console.WriteLine();

            for(int i=0;i<l.Count;i++)
            {
                Console.WriteLine(l[i].ConsumerNumber + "\n" + l[i].ConsumerName + "\n" + l[i].UnitsConsumed + "\n" + "Bill amount:" + l[i].BillAmount);
            }
            Console.WriteLine();
            Console.WriteLine("Details of last "+N+" bills:");
                for(int j=0;j<N;j++)
                {
                    Console.WriteLine("Ebill for "+list[j].ConsumerName+" is "+list[j].BillAmount);
                //Console.WriteLine();
                }

            

            Console.Read();
            
        }

        }
    }


