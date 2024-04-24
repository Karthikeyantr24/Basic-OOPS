using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace StudentAdmission
{
    //Static Class
    public static class Operations
    {
        //Local/Global Object Creation
        static StudentDetails currentLoggedInStudent;
        //Static List Creation
      public  static List<StudentDetails> studentList = new List<StudentDetails>();
       public static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
       public static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();

       public static void MainMenu()
       {
            Console.WriteLine("************Welcome to Syncfusion College************");
            

            string mainChoice = "yes";

            do
            {
                //Need to show the main menu option.
                Console.WriteLine("MainMenu\n1. Registration \n2. Login \n3. Departmentwise Seat Availability \n4. Exit");
                //Need to get an input from user and validate.
                Console.Write("Select an option: ");
                int mainOption = int.Parse(Console.ReadLine());
                //Need to create mainmenu structure.
                switch (mainOption)
                {
                    case 1:
                        {
                            Console.WriteLine("************Student Registration************");
                            StudentRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("************Student Login************");
                            StudentLogin();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("************Departmentwise Seat Availability************");
                            DepartmentwiseSeatAvailability();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Application Exited Successfully.");
                            mainChoice="no";
                            break;
                        }
                }
                //Need to iterate untill the option is exit.

            } while (mainChoice=="yes");
        }//Main menu ends.

        //Student Registration
        public static void StudentRegistration()
        {
            //Need to get required details
            Console.Write("Enter your name: ");
            string studentName = Console.ReadLine();
            Console.Write("Enter your father name: ");
            string fatherName = Console.ReadLine();
            Console.Write("Enter your DOB as specified DD/MM/YYYY: ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.Write("Enter your gender (Male/Female): ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.Write("Enter your physics mark: ");
            int physicsmark = int.Parse(Console.ReadLine());
            Console.Write("Enter your chemistry mark: ");
            int chemsitryMark = int.Parse(Console.ReadLine());
            Console.Write("Enter your maths mark: ");
            int mathsMark = int.Parse(Console.ReadLine());
            //Need to create an object
            StudentDetails student = new StudentDetails(studentName,fatherName,dob,gender,physicsmark,chemsitryMark,mathsMark);
            //Need to add in the list
            studentList.Add(student);
            //Need to display confirmation message and ID.
            Console.WriteLine($"Registration successful. Student ID: {student.StudentID}");


        }//Student Registration Ends.

        //Student Login
        public static void StudentLogin()
        {
            //Need to get ID input
            Console.Write("Enter your student ID: ");
            string loginID=Console.ReadLine().ToUpper();
            //validate by its presence in the list
            bool flag = true;
            foreach(StudentDetails student in studentList)
            {
                if(loginID.Equals(student.StudentID))
                {
                    flag=false;
                    //Assigning current user to global variable
                    currentLoggedInStudent = student;
                    Console.WriteLine("Logged In successfully");
                    //Need to call submenu
                    SubMenu();
                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid ID or ID is not present");
            }
            //If not - Invalid 
        }//Student Login Ends

        public static void SubMenu()
        {
            string subChoice = "yes";
            do
            {
                Console.WriteLine("**********Sub Menu**********");
                //Need to show sub menu option.
                Console.WriteLine("Select an option\n1. Check Eligibility \n2. Show Details \n3. Take Admission \n4. Cancel Admission \n5. Show Admission Details \n6. Exit");
                //Getting user option.
                Console.Write("Enter your option: ");
                int subOption=int.Parse(Console.ReadLine());
                //Need to create sub menu structure
                switch(subOption)
                {
                    case 1:
                    {
                        Console.WriteLine("*************Check Eligibility*************");
                        CheckEligibility();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("*************Show Details*************");
                        ShowDetails();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("*************Take Admission*************");
                        TakeAdmission();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("*************Cancel Admission*************");
                        CancelAdmission();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("*************Admission Details*************");
                        AdmissionDetails();
                        break;
                    }
                    case 6:
                    {
                       Console.WriteLine("Taking back to MainMenu");
                       subChoice="no";
                        break;
                    }
                }
                //iterate till the option is exit

            }while(subChoice=="yes");
        }//SubMenu Ends

        //Check Eligibility
        public static void CheckEligibility()
        {
            //Get the cut off value as input
            Console.Write("Enter the cutoff value: ");
            double cutoff=double.Parse(Console.ReadLine());
            //Check Eligible or not
            if(currentLoggedInStudent.CheckEligibility(cutoff))
            {
                Console.WriteLine("Student is eligible");
            }
            else
            {
                Console.WriteLine("Student is not eligible ");
            }

        }//Check Eligibility Ends

        //Show Details
        public static void ShowDetails()
        {
            //Need to show current student's details.
            Console.WriteLine("|Student ID|Student Name|Father Name|DOB|Gender|Physics Mark|Chemistry Mark|Maths Mark|");
            Console.WriteLine($"|{currentLoggedInStudent.StudentID}|{currentLoggedInStudent.StudentName}|{currentLoggedInStudent.FatherName}|{currentLoggedInStudent.DOB}|{currentLoggedInStudent.Gender}|{currentLoggedInStudent.PhysicsMark}|{currentLoggedInStudent.ChemistryMark}|{currentLoggedInStudent.MathsMark}");
           
        }//Show Details Ends

        //Take Admission
        public static void TakeAdmission()
        {
            //Need to show available department details
            DepartmentwiseSeatAvailability();
            //Ask department ID from user
            Console.Write("Select a Department ID: ");
            string departmentID=Console.ReadLine().ToUpper();
            //Check the ID is present or not
            bool flag=true;
            foreach(DepartmentDetails department in departmentList)
            {
                if(departmentID.Equals(department.DepartmentID))
                {
                    flag=false;
                    //Check the student is eligible or not
                    if(currentLoggedInStudent.CheckEligibility(75.0))
                    {
                        //Check the seat availability
                        if(department.NumberOfSeats>0)
                        {
                            //Check student already taken any admission
                            int count = 0;
                            foreach(AdmissionDetails admission in admissionList)
                            {
                                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                                {
                                    count++;
                                }
                            }
                            if(count==0)
                            {
                                //Create admission object
                                AdmissionDetails admissionTaken = new AdmissionDetails(currentLoggedInStudent.StudentID,department.DepartmentID,DateTime.Now,AdmissionStatus.Admitted);
                                //Reduce seat count
                                department.NumberOfSeats--;
                                //Add to the admission list
                                admissionList.Add(admissionTaken);
                                //Display admission successful message
                                Console.WriteLine($"You have taken admission successfully. Admission ID: {admissionTaken.AdmissionID}");
                            }
                            else
                            {
                                Console.WriteLine("you have already taken as admission");
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Seats are not available");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("You are not eligible due to low cutoff");
                    }
                    
                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid ID or ID not present");
            }
            

        }//Take Admission Ends

        //Cancel Admission
        public static void CancelAdmission()
        {
            bool flag = true;
            //Check the student is taken any admission and display it
            foreach(AdmissionDetails admission in admissionList)
            {
                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID)&&admission.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                {
                    //cancel the found admission
                    admission.AdmissionStatus=AdmissionStatus.Cancelled;
                    //return the seat to department
                    foreach(DepartmentDetails department in departmentList)
                    {
                        if(admission.DepartmentID.Equals(department.DepartmentID))
                        {
                            department.NumberOfSeats++;
                            break;
                        }
                    }
                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("You have not admission to cancel");
            }
            
        }//Cancel Admission Ends

        //Admission Details
        public static void AdmissionDetails()
        {
            //Need to show current logged in student admission details
            Console.WriteLine("|Admission ID|Student ID|Departmment ID|Admission Date|Admission Status|");
            foreach(AdmissionDetails admission in admissionList)
            {
                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID)){
                    Console.WriteLine($"|{admission.AdmissionID}|{admission.StudentID}|{admission.DepartmentID}|{admission.AdmissionDate}|{admission.AdmissionStatus}");
                }
            }
        }//Admission Details Ends


        //Departmentwise Seat Availability
        public static void DepartmentwiseSeatAvailability()
        {
            Console.WriteLine($"|departmentId|DepartmentName|NumberOfSeats|");
            foreach(DepartmentDetails department in departmentList)
            {
                Console.WriteLine($"|{department.DepartmentID}|{department.DepartmentName}|{department.NumberOfSeats}");
            }
            Console.WriteLine();
        }//Departmentwise Seat Availability Ends

       //Adding Default Data
       public static void AddDefaultData()
       {
            //Student Details
            StudentDetails student1 = new StudentDetails("Ravichandran E","Ettapparajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            StudentDetails student2 = new StudentDetails("Baskaran S","Sethurajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            //studentList.Add(student1);
            //studentList.Add(student2);

            studentList.AddRange(new List<StudentDetails>(){student1,student2});

            //Department Details
            DepartmentDetails department1 = new DepartmentDetails("EEE",29);
            DepartmentDetails department2 = new DepartmentDetails("CSE",29);
            DepartmentDetails department3 = new DepartmentDetails("MECH",30);
            DepartmentDetails department4 = new DepartmentDetails("ECE",30);

            departmentList.AddRange(new List<DepartmentDetails>(){department1,department2,department3,department4});

            //Admission Details
            AdmissionDetails admission1 = new AdmissionDetails(student1.StudentID,department1.DepartmentID,new DateTime(2022,05,11),AdmissionStatus.Admitted);
            AdmissionDetails admission2 = new AdmissionDetails("SF3002","DID102",new DateTime(2022,05,12),AdmissionStatus.Admitted);

            admissionList.AddRange(new List<AdmissionDetails>(){admission1,admission2});

            


       }
    }
}