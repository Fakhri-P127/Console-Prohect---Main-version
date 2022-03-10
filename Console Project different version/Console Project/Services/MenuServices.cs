using Console_Project.Enums;
using Console_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Project.Operations
{
    static class MenuServices
    {
        public static AcademyService academyService = new AcademyService();

        public static void MenuCreateGroup()
        {
            bool isonline=false;
            int num;            
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Is this group online?(Press 1 or 2)\n1.Yes\n2.No\n\n0.Return to the Menu\n");
                string strNum = Console.ReadLine();
                bool resultOnline = int.TryParse(strNum, out num);
                if (resultOnline)
                {
                    switch (num)
                    {
                        case 1:
                            isonline = true;                            
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The Group will be Online\n");
                            break;
                        case 2:
                            isonline = false;                            
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("The Group will be Offline\n");
                            break;
                        case 0:
                            AcademyService.ClearAndColor();
                            Console.WriteLine("You returned to the menu");
                            return;
                        default:
                            AcademyService.ClearAndColor();
                            Console.WriteLine("Please choose a valid option");
                            break;
                    }
                }
                else
                {
                    AcademyService.ClearAndColor();
                    Console.WriteLine("Input valid num value");                    
                }
            } while (num != 1 && num != 2);

            int category;
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Choose the category(Press 1, 2 or 3)");
                foreach (Categories item in Enum.GetValues(typeof(Categories)))
                {
                    Console.WriteLine($"{(int)item}.{item}");
                }
                Console.WriteLine("\n0.Return to the Menu\n");
                string strCategory = Console.ReadLine();
                bool result = int.TryParse(strCategory, out category);
                if (result)
                {
                    switch (category)
                    {
                        case (int)Categories.Programming:
                            academyService.CreateGroup(Categories.Programming, isonline);
                            break;
                        case (int)Categories.Design:
                            academyService.CreateGroup(Categories.Design, isonline);
                            break;
                        case (int)Categories.SystemAdministration:
                            academyService.CreateGroup(Categories.SystemAdministration, isonline);
                            break;
                        case 0:
                            AcademyService.ClearAndColor();
                            Console.WriteLine("You returned to the Menu");
                            return;
                        default:
                            AcademyService.ClearAndColor();
                            Console.WriteLine("Please choose a valid option");
                            break;
                    }
                }
                else
                {
                    AcademyService.ClearAndColor();
                    Console.WriteLine("Input num value(Press 1, 2 or 3)");
                }                                
            } while (category != 1 && category != 2 && category != 3);            
        }

        public static void MenuShowAllGroups()
        {
            academyService.ShowAllGroups();
        }

        public static void MenuEditGroupNo()
        {
            if ((academyService.AllGroups.Count == 0))
            {
                AcademyService.ClearAndColor();
                Console.WriteLine("There's no group to edit");
                return;
            }
            Console.WriteLine("Enter the group no you want to change");
            string no = Console.ReadLine().ToUpper().Trim();
            Console.WriteLine("Enter the group no you want to change into");
            string newNo = Console.ReadLine().ToUpper().Trim();
            academyService.EditGroupNo(no, newNo);
        }

        public static void MenuShowStudentsInGroup()
        {
            if ((academyService.AllGroups.Count == 0))
            {
                AcademyService.ClearAndColor();
                Console.WriteLine("There's no group to look for");
                return;
            }
            Console.WriteLine("Which group's students do you want to see?");
            string no = Console.ReadLine().ToUpper().Trim();
            academyService.ShowStudentsInGroup(no); ;
        }

        public static void MenuShowAllStudents()
        {            
            academyService.ShowAllStudents();
        }

        public static void MenuCreateStudent()
        {
            if((academyService.AllGroups.Count == 0))
            {
                AcademyService.ClearAndColor();
                Console.WriteLine("There's no group to add Students");
                return;
            }
            
            Console.WriteLine("Enter Students Fullname");
            string fullname = Console.ReadLine().ToUpper().Trim();
            if (!AcademyService.CheckFullname(fullname))
            {
                return;
            }
            
            string groupNo;
            bool containsGroupNo = false;
            do
            {
                Console.WriteLine("Enter the groupno");
                groupNo = Console.ReadLine();
                
                foreach (Group group in academyService.AllGroups)
                {
                    if (group.No.ToLower().Trim()==groupNo.ToLower().Trim())
                    {
                        containsGroupNo = true;                       
                    }
                }
                if (!containsGroupNo)
                {
                    Console.WriteLine($"{groupNo.ToUpper().Trim()} Doesn't exist\n\nAvailable groups:");//We could write a code that wouldn't show full groups
                    foreach (Group group in academyService.AllGroups)
                    {
                        Console.WriteLine(group.No);
                    } 
                }
            } while (!containsGroupNo);

            bool type=false;
            int numType;
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Choose Type:(Press 1 or 2)\n1.Warranted\n2.Not Warranted\n\n0.Return to the Menu\n");
                string strType = Console.ReadLine();
                bool resultType = int.TryParse(strType, out numType);
                if (resultType)
                {
                    switch (numType)
                    {
                        case 1:
                            type = true;
                            break;
                        case 2:
                            type = false;
                            break;
                        case 0:
                            AcademyService.ClearAndColor();
                            Console.WriteLine("You returned to the Menu");
                            return;
                        default:
                            AcademyService.ClearAndColor();
                            Console.WriteLine("Please choose valid option");
                            break;
                    }
                }
                else
                {
                    AcademyService.ClearAndColor();
                    Console.WriteLine("Input valid num value");
                }
            } while (numType != 1 && numType != 2);

            academyService.CreateStudent(fullname, groupNo, type);

        }

        public static void MenuDeleteStudent()
        {
            if (academyService.AllStudents.Count == 0)
            {
                AcademyService.ClearAndColor();
                Console.WriteLine("No students to remove");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter the fullname you want to delete:");
            string fullname = Console.ReadLine().ToUpper().Trim();           
            Student student = academyService.AllStudents.Find(x => x.Fullname == fullname);
            if (student == null)
            {
                AcademyService.ClearAndColor();
                Console.WriteLine($"{fullname} doesn't exist.");
                return;
            }
            academyService.DeleteStudent(student);            
        }

        public static void MenuDeleteGroup()
        {
            if (academyService.AllGroups.Count == 0)
            {
                AcademyService.ClearAndColor();
                Console.WriteLine("No groups to remove");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter the groupNo you want to delete:");
            string groupNo = Console.ReadLine().ToUpper().Trim();
            Group group = academyService.AllGroups.Find(x => x.No == groupNo);
            if (group == null)
            {
                AcademyService.ClearAndColor();
                Console.WriteLine($"{groupNo} doesn't exist.");
                return;
            }
            academyService.DeleteGroup(group);
        }
    }
}