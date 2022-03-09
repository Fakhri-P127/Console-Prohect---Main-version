using Console_Project.Models;
using Console_Project.Operations;
using System;

namespace Console_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            string strNum;
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Course Managment Application");
                Console.WriteLine("1. Create Group");
                Console.WriteLine("2. Show All Groups");
                Console.WriteLine("3. Edit Group");
                Console.WriteLine("4. Show Students in Group");
                Console.WriteLine("5. Show all Students");
                Console.WriteLine("6. Create Student");
                Console.WriteLine("0.Exit");
                strNum = Console.ReadLine();
                //string isletdim cunki enter e falan basanda proqramdan atmasin. int verende tryagain ile etmek olar amma hele kecmemisik.
                switch (strNum)
                {
                    case "1":
                        MenuServices.MenuCreateGroup();
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.Green;
                        MenuServices.MenuShowAllGroups();
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.White;
                        MenuServices.MenuEditGroupNo();
                        break;
                    case "4":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        MenuServices.MenuShowStudentsInGroup();
                        break;
                    case "5":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        MenuServices.MenuShowAllStudents();
                        break;
                    case "6":
                        MenuServices.MenuCreateStudent();
                        break;
                    case "0":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You exited the application");
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter a valid number: ");
                        break;
                }            
            } while (strNum != "0");
        }
    }
}
