﻿using Console_Project.Models;
using Console_Project.Operations;
using System;

namespace Console_Project
{
    class Program
    {
        static void Main(string[] args)
        {
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
                Console.WriteLine("7. Delete Student");
                Console.WriteLine("8. Delete Group");
                Console.WriteLine("0. Exit");
                string strNum = Console.ReadLine();
                bool result = int.TryParse(strNum, out int num);                
                if (result)
                {
                    switch (num)
                    {
                        case 1:
                            MenuServices.MenuCreateGroup();
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Green;
                            MenuServices.MenuShowAllGroups();
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.White;
                            MenuServices.MenuEditGroupNo();
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            MenuServices.MenuShowStudentsInGroup();
                            break;
                        case 5:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            MenuServices.MenuShowAllStudents();
                            break;
                        case 6:
                            MenuServices.MenuCreateStudent();
                            break;
                        case 7:
                            MenuServices.MenuDeleteStudent();
                            break;
                        case 8:
                            MenuServices.MenuDeleteGroup();
                            break;
                        case 0:
                            AcademyService.ClearAndColor();
                            Console.WriteLine("You exited the application");//there's no code after while loop so we can just return it, program will end.
                            return;
                        default:
                            AcademyService.ClearAndColor();
                            Console.WriteLine("Please choose valid option:");
                            break;
                    }
                }
                else
                {
                    AcademyService.ClearAndColor();
                    Console.WriteLine("Enter a valid number:");
                }
            } while (true);                     
        }
    }
}
