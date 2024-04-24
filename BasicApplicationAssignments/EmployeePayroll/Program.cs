using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
namespace EmployeePayroll;
class Program
{
    public static void Main(string[] args)
    {
        List<EmployeeDetails> emp = new List<EmployeeDetails>();
        string choose = "";

        do
        {
            EmployeeDetails employee = new EmployeeDetails();
            Console.WriteLine("1.Registration \n2.Login \n3.Exit");
            Console.Write("Enter your option: ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    {
                        Console.Write("Enter your Name: ");
                        employee.EmployeeName = Console.ReadLine();
                        Console.Write("Enter your Role: ");
                        employee.Role = Console.ReadLine();
                        Console.Write("Enter your Location---AnnaNagar/Kilpauk/Canada/US : ");
                        Location Location = Enum.Parse<Location>(Console.ReadLine(), true);
                        Console.Write("Enter your Team Name: ");
                        employee.TeamName = Console.ReadLine();
                        Console.Write("Enter your Date of Joining: ");
                        employee.DateOfJoining = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                        Console.Write("Enter the working days in month: ");
                        employee.NoOfWorking = int.Parse(Console.ReadLine());
                        Console.Write("Enter the number of leave taken: ");
                        employee.NoOfLeave = int.Parse(Console.ReadLine());
                        Console.Write("Enter your Gender---Male/Female : ");
                        Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);

                        emp.Add(employee);
                        Console.WriteLine("Your are successfully registered.Your Employee Id is: " + employee.EmployeeId);

                        break;
                    }
                case 2:
                    {
                        Console.Write("Enter your Employee Id: ");
                        string id = Console.ReadLine();
                        foreach (EmployeeDetails empo in emp)
                        {
                            if (empo.EmployeeId == id)
                            {
                                Console.WriteLine("Choose an option: \n1.Calculate Salary \n2.Display Details \n3.Exit ");
                                int opt = int.Parse(Console.ReadLine());
                                switch (opt)
                                {
                                    case 1:
                                        {
                                            employee.SalaryCalculation(empo.NoOfWorking, empo.NoOfLeave);

                                            break;
                                        }
                                    case 2:
                                        {
                                            empo.Details(empo.EmployeeName, empo.Role, empo.TeamName, empo.DateOfJoining, empo.NoOfWorking, empo.NoOfLeave);
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
