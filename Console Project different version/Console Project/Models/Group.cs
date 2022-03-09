using System;
using System.Collections.Generic;
using System.Text;
using Console_Project.Enums;

namespace Console_Project.Models
{
    class Group
    {        
        public string No;        
        public bool IsOnline;
        public byte Limit;
        public List<Student> Students;
        public Categories Category;
        public static int P_count = 100;
        public static int D_count = 100;
        public static int S_count = 100;

        public Group(Categories category, bool isonline)
        {
            IsOnline = isonline;
            Students = new List<Student>();           
            switch (category)
            {
                case Categories.Programming:
                    No = $"P{P_count}";
                    P_count++;
                    break;
                case Categories.Design:
                    No = $"D{D_count}";
                    D_count++;
                    break;
                case Categories.SystemAdministration:
                    No = $"S{S_count}";
                    S_count++;
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The class you chose does not exist. Please choose valid option");
                    break;
            }         
            Category = category;
        }
        public override string ToString()
        {
            string status = IsOnline ? "Online" : "Offline";
            return $"GroupNo: {No.ToUpper().Trim()}, Category: {Category}, StudentCount: {Students.Count}, Status: {status.ToUpper()}";
        }
    }
}