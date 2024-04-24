using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Xml.Serialization;
namespace BankAccount;
class Program
{
    public static void Main(string[] args)
    {
        List<CustomerDetails> customerList = new List<CustomerDetails>();

        string option = "";
        do
        {
            
            Console.WriteLine("1.Registration \n2.Login \n3.Exit");
            Console.Write("Choose an option: ");
            int choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    {

                        Console.WriteLine("Enter your Customer Name: ");
                        string customerName = Console.ReadLine();
                        Console.WriteLine("enter your Balance: ");
                        int balance = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the gender Male Female Transgender: ");
                        Gender gender = Gender.Parse<Gender>(Console.ReadLine(), true);
                        Console.WriteLine("Enter your Phone Number: ");
                        long phone = long.Parse(Console.ReadLine());
                        Console.WriteLine("Enter your Mail Id: ");
                        string mailId = Console.ReadLine();
                        Console.WriteLine("Enter your Date Of Birth dd/MM/yyyy: ");
                        DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);


                        CustomerDetails customer = new CustomerDetails(customerName, balance, gender, phone, mailId, dob);
                        customerList.Add(customer);
                        Console.WriteLine("You are Successfully registered.Your Customer ID is: " + customer.CustomerId);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Enter Your Customer Id: ");
                        string id = Console.ReadLine();
                        foreach (CustomerDetails cust in customerList)
                        {
                            if (cust.CustomerId == id)
                            {
                                Console.WriteLine("1.Deposit \n2.Withdraw \n3.Balance Check \n4.Exit");
                                int option1 = int.Parse(Console.ReadLine());
                                switch (option1)
                                {
                                    case 1:
                                        {
                                            Console.Write("Enter your Deposit Amount: ");
                                            int depositMoney = int.Parse(Console.ReadLine());
                                            cust.Deposit(depositMoney);
                                            Console.WriteLine("Your Account Balance is : " + cust.Balance);
                                            break;

                                        }
                                    case 2:
                                        {
                                            Console.Write("Enter your Withdraw Amount: ");
                                            int withdrawAmount = int.Parse(Console.ReadLine());
                                            cust.Withdraw(withdrawAmount);
                                            Console.WriteLine("Your Account Balance: " + cust.Balance);
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("Your Current Balance: " + cust.Balance);
                                            break;
                                        }
                                    case 4:
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
            option = Console.ReadLine();
        } while (option == "yes");



    }
}
