using System;
namespace StudentAdmission;

class Program{
    public static void Main(string[] args)
    {
        //Create folder and file
        FileHandling.Create();
        //ReadFile
        FileHandling.ReadFromCSV();
        //Calling AddDefaultData 
        //Operations.AddDefaultData();

        //Calling MainMenu
        Operations.MainMenu();
        //Data are write into the file
        FileHandling.WriteToCSV();
            
    }
}

