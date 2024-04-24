using System;
using System.Collections.Generic;
using System.Runtime;
namespace EBBill;
class Program
{
    public static void Main(string[] args)
    {
        List<BillDetails> bill = new List<BillDetails>();
        string choose = "";

        do
        {

            Console.WriteLine("1.Registration \n2.Login \n3.Exit");
            Console.Write("Enter your option: ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    {
                        BillDetails billDetails = new BillDetails();

                        Console.Write("Enter your UserName: ");
                        billDetails.Username = Console.ReadLine();
                        Console.Write("Enter your Phone Number: ");
                        billDetails.Phone = long.Parse(Console.ReadLine());
                        Console.Write("Enter your MailID : ");
                        billDetails.MailId = Console.ReadLine();
                        Console.WriteLine("Your EB Id: " + billDetails.MeterID);


                        bill.Add(billDetails);

                        break;
                    }
                case 2:
                    {
                        Console.Write("Enter your Meter Id: ");
                        string id = Console.ReadLine();
                        foreach (BillDetails eb in bill)
                        {
                            if (eb.MeterID == id)
                            {
                                Console.WriteLine("1.Calculate Amount \n2.Display User Details \n3.Exit ");
                                Console.Write("Enter the option: ");
                                int opt = int.Parse(Console.ReadLine());
                                switch (opt)
                                {
                                    case 1:
                                        {
                                            Console.Write("Enter the Unit: ");
                                            int unit=int.Parse(Console.ReadLine());
                                            int amount=eb.CalculateAmount(unit);
                            
                                            Console.WriteLine("Meter ID: " + eb.MeterID);
                                            Console.WriteLine("Username: " + eb.Username);
                                            Console.WriteLine("Unit: " + eb.Unit);
                                            Console.WriteLine("Amount: "+amount);
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("Meter ID: " + eb.MeterID);
                                            Console.WriteLine("Username: " + eb.Username);
                                            Console.WriteLine("Phone Number: " + eb.Phone);
                                            Console.WriteLine("Mail ID: " + eb.MailId);
                                            break;
                                        }
                                    case 3:
                                        {
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid User");
                            }

                        }
                        break;


                    }
                case 3:
                    {
                        Environment.Exit(0);
                        break;
                    }

            }

            Console.Write("Do you want to continue yes/no: ");
            choose = Console.ReadLine();

        } while (choose == "yes");
    }
}
