using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll

{
    public enum Location { select, AnnaNagar, Kilpauk, Canada, US }
    public enum Gender { select, Male, Female }
    public class EmployeeDetails
    {
        private static int _employeeId = 1000;

        public string EmployeeId { get; }
        public string EmployeeName { get; set; }
        public string Role { get; set; }
        public string TeamName { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int NoOfWorking { get; set; }
        public int NoOfLeave { get; set; }

        public EmployeeDetails()
        {
            _employeeId++;
            EmployeeId = "SF" + _employeeId;
        }

        public void SalaryCalculation(int NoOfWorking, int NoOfLeave)
        {
            int salary = (NoOfWorking - NoOfLeave) * 500;
            Console.WriteLine("Your Salary is: " + salary);
        }

        public void Details(string EmployeeName, string Role, string TeamName, DateTime DateOfJoining, int NoOfWorking, int NoOfLeave)
        {
            Console.WriteLine("Employee name: " + EmployeeName);
            Console.WriteLine("Role: " + Role);
            Console.WriteLine("Location: " + Location.select);
            Console.WriteLine("Team Name: " + TeamName);
            Console.WriteLine("Date Of Joining: " + DateOfJoining);
            Console.WriteLine("No of Working : " + NoOfWorking);
            Console.WriteLine("No of Leave : " + NoOfLeave);


        }

    }
}