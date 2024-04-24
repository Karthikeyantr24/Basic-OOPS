using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public static class FileHandling
    {
        public static void Create()

        {
            //Create Directory
            if(!Directory.Exists("CollegeAdmission"))
            {
                Console.WriteLine("Creating Folder....");
                Directory.CreateDirectory("CollegeAdmission");
            }

            //StudentDetails File
            if(!File.Exists("CollegeAdmission/StudentDetails.csv"))
            {
                Console.WriteLine("Creating File....");
                File.Create("CollegeAdmission/StudentDetails.csv").Close();
            }
            //DepartmentDetails File
            if(!File.Exists("CollegeAdmission/DepartmentDetails.csv"))
            {
                Console.WriteLine("Creating File....");
                File.Create("CollegeAdmission/DepartmentDetails.csv").Close();
            }
            //AdmissionDetails file
            if(!Directory.Exists("CollegeAdmission/AdmissionDetails.csv"))
            {
                Console.WriteLine("Creating File....");
                File.Create("CollegeAdmission/AdmissionDetails.csv").Close();
            }
        }

        public static void WriteToCSV()
        {
            //Student Details
            string[] student = new string[Operations.studentList.Count];

            for(int i=0;i<Operations.studentList.Count;i++)
            {
                student[i] = Operations.studentList[i].StudentID+","+Operations.studentList[i].StudentName+","+Operations.studentList[i].FatherName+","+Operations.studentList[i].DOB.ToString("dd/MM/yyyy")+","+Operations.studentList[i].Gender+","+Operations.studentList[i].PhysicsMark+","+Operations.studentList[i].ChemistryMark+","+Operations.studentList[i].MathsMark ;
            }
            File.WriteAllLines("CollegeAdmission/StudentDetails.csv",student);

            //Department Details
            string[] department = new string[Operations.departmentList.Count];

            for(int i=0;i<Operations.departmentList.Count;i++)
            {
                department[i] = Operations.departmentList[i].DepartmentID+","+Operations.departmentList[i].DepartmentName+","+Operations.departmentList[i].NumberOfSeats;
            }
            File.WriteAllLines("CollegeAdmission/DepartmentDetails.csv",department);

            //Admission Details
            string[] admission = new string[Operations.admissionList.Count];

            for(int i=0;i<Operations.admissionList.Count;i++)
            {
                admission[i] = Operations.admissionList[i].AdmissionID+","+Operations.admissionList[i].StudentID+","+Operations.admissionList[i].DepartmentID+","+Operations.admissionList[i].AdmissionDate.ToString("dd/MM/yyyy")+","+Operations.admissionList[i].AdmissionStatus;           
            }
            File.WriteAllLines("CollegeAdmission/AdmissionDetails.csv",admission);
        }
    
        public static void ReadFromCSV()
        {
            string [] students = File.ReadAllLines("CollegeAdmission/StudentDetails.csv");
            foreach(string student in students)
            {
                StudentDetails student1 = new StudentDetails(student);
                Operations.studentList.Add(student1);
            }

            string [] departments = File.ReadAllLines("CollegeAdmission/DepartmentDetails.csv");
            foreach(string department in departments)
            {
                DepartmentDetails department1 = new DepartmentDetails(department);
                Operations.departmentList.Add(department1);
            }

            string [] admissions = File.ReadAllLines("CollegeAdmission/AdmissionDetails.csv");
            foreach(string admission in admissions)
            {
                AdmissionDetails admission1 =  new AdmissionDetails(admission);
                Operations.admissionList.Add(admission1);

            }
        }
    }
}