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
            Console.WriteLine("Is this group online?(Press 1 or 2)\n1.Yes\n2.No");
            bool isonline;
            string str = Console.ReadLine();
            bool resultOnline = byte.TryParse(str, out byte num);
            if (resultOnline)
            {
                switch (num)
                {
                    case 1:
                        isonline = true;
                        break;
                    case 2:
                        isonline = false;
                        break;
                    default:
                        AcademyService.ClearAndColor();
                        Console.WriteLine("Input valid num value");
                        return;
                }
            }
            else
            {
                AcademyService.ClearAndColor();
                Console.WriteLine("Input valid num value");
                return;
            }
            Console.WriteLine("Choose the category(Press 1, 2 or 3)");
            foreach (Categories item in Enum.GetValues(typeof(Categories)))
            {
                Console.WriteLine($"{(int)item}.{item}");
            }
            string strCategory = Console.ReadLine();
            bool result = int.TryParse(strCategory, out int category);
            if (result)
            {
                switch (category)
                {
                    case (int)Categories.Programming:
                        academyService.CreateGroup(Categories.Programming, isonline);
                        return;
                    case (int)Categories.Design:
                        academyService.CreateGroup(Categories.Design, isonline);
                        return;
                    case (int)Categories.SystemAdministration:
                        academyService.CreateGroup(Categories.SystemAdministration, isonline);
                        return;
                    default:
                        AcademyService.ClearAndColor();
                        Console.WriteLine("Please choose a valid option");
                        return;
                }
            }
            AcademyService.ClearAndColor();
            Console.WriteLine("Input num value(Press 1, 2 or 3)");
            return;
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
            string no = Console.ReadLine();
            Console.WriteLine("Enter the group no you want to change into");
            string newNo = Console.ReadLine();
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
            string no = Console.ReadLine();
            academyService.ShowStudentsInGroup(no);
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
            string fullname = Console.ReadLine();
            if (!AcademyService.CheckFullname(fullname))
            {
                return;
            }
            bool containsGroupNo = false;
            string groupNo;
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
                    Console.WriteLine($"{groupNo.ToUpper().Trim()} Doesn't exist\n\nAvailable groups:");//qrup dolubsa onlari gostermemekde olar 
                    foreach (Group group in academyService.AllGroups)
                    {
                        Console.WriteLine(group.No);
                    } 
                }
            } while (!containsGroupNo);
            // belke hamisini while loopuna saldim
             

            //Console.WriteLine("Choose:(Press 1 or 2)\n1.Online\n2.Offline ");
            //bool isonline;           
            //string strOnline = Console.ReadLine();
            //bool resultOnline = byte.TryParse(strOnline, out byte numOnline);
            //if (resultOnline)
            //{
            //    switch (numOnline)
            //    {
            //        case 1:
            //            isonline = true;
            //            break;
            //        case 2:
            //            isonline = false;
            //            break;
            //        default:
            //            AcademyService.ClearAndColor();
            //            Console.WriteLine("Input valid num value");
            //            return;
            //    }
            //}
            //else
            //{
            //    AcademyService.ClearAndColor();
            //    Console.WriteLine("Input valid num value");
            //    return;
            //}
            Console.WriteLine("Choose Type:(Press 1 or 2)\n1.Warranted\n2.Not Warranted");
            bool type;
            string strType = Console.ReadLine();
            bool resultType = byte.TryParse(strType, out byte numType);
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
                    default:
                        AcademyService.ClearAndColor();
                        Console.WriteLine("Input valid num value");
                        return;
                }
            }
            else
            {
                AcademyService.ClearAndColor();
                Console.WriteLine("Input valid num value");
                return;
            }
            academyService.CreateStudent(fullname, groupNo, type);
        }        
    }
}