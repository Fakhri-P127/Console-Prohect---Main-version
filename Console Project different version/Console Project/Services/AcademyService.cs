using System;
using System.Collections.Generic;
using System.Text;
using Console_Project.Enums;
using Console_Project.Interfaces;
using Console_Project.Models;

namespace Console_Project.Operations
{
    class AcademyService : IAcademyServices
    {
        public List<Group> AllGroups { get; } = new List<Group>();

        public List<Student> AllStudents { get; } = new List<Student>();

        public void CreateGroup(Categories category, bool isonline)
        {                                              
            Group group = new Group(category, isonline);
            if (!CheckGroupNo(group))
            {
                ClearAndColor();
                Console.WriteLine($"{group.No.ToUpper().Trim()} already exists.");
                return;
            }            
            group.Limit = isonline ? group.Limit = 15 : group.Limit = 10;
            AllGroups.Add(group);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Created GroupNo: {group.No.ToUpper().Trim()}\n");                       
        }
        public bool CheckGroupNo(Group currentGroup)
        {
            //if the groupNo of the group changed, this makes sure that you can't create group with the same groupNo
            //Example: created groupNo P100 then edited to P101. After this if we create P101 it will create another group with t
            foreach (Group group in AllGroups)
            {
                if (group.No.ToLower().Trim() == currentGroup.No.ToLower().Trim())
                {
                    return false;
                }                
            }
            return true;
        }        
        public void ShowAllGroups()
        {
            if (AllGroups.Count == 0)
            {
                ClearAndColor();
                Console.WriteLine("There's no group that exists");
                return;
            }
            foreach (Group group in AllGroups)
            {
                Console.WriteLine(group);                
            }
        }
        public void EditGroupNo(string no, string newNo)
        {
            Group existGroup = FindGroup(no);
            if (!CheckGroupNo(newNo))
            {
                return;
            }                        
            if (string.IsNullOrEmpty(newNo))
            {
                ClearAndColor();
                Console.WriteLine("Can't input any white space");
                return;
            }
            if (string.IsNullOrWhiteSpace(newNo))
            {
                ClearAndColor();
                Console.WriteLine("Can't input any white space");
                return;
            }
            if (existGroup == null)
            {
                ClearAndColor();
                Console.WriteLine("Please enter a groupNo that exists");
                return;
            }
            foreach (Group group in AllGroups)
            {
                if (group.No.ToLower().Trim() == newNo.ToLower().Trim())
                {
                    ClearAndColor();
                    Console.WriteLine($"{group.No.ToUpper().Trim()} already exists");
                    return;
                }
            }
            //switch (categories)
            //{
            switch (existGroup.Category)
            {
                case Categories.Programming:
                    if (newNo[0] == 'p' || newNo[0] == 'P')
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The groupNo you're trying to enter is not from the same category");
                        return;
                    }                    
                case Categories.Design:
                    if (newNo[0] == 'd' || newNo[0] == 'D')
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The groupNo you're trying to enter is not from the same category");
                        return;
                    }                    
                case Categories.SystemAdministration:
                    if (newNo[0] == 's' || newNo[0] == 'S')
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The groupNo you're trying to enter is not from the same category");
                        return;
                    }                    
                default:
                    Console.WriteLine("Group name doesn't start with the categories");
                    return;                    
            }
            existGroup.No = newNo;            

            //When calling ShowAllStudents() after EditGroupNo() it shows the old groupNo. This code is preventing that.                                                   
            foreach (Student student in existGroup.Students)
            {
                student.GroupNo = newNo;
            }
            Console.WriteLine($"{no.ToUpper().Trim()} Hall has been successfuly changed to {newNo.ToUpper().Trim()}\n");
        }       
        public static bool CheckGroupNo(string groupno)
        {
            string group = groupno.Trim();
            if (group.Length <= 4 && char.IsUpper(group[0]) && char.IsDigit(group[1]) && char.IsDigit(group[2]) && char.IsDigit(group[3]))
            {
                return true;
            }
            else
            {
                Console.WriteLine("GroupNo needs to be 4 character long. First character must be a letter and last 3 characters should be all digits");
                return false;
            }
        }
        public Group FindGroup(string no)
        {            
            foreach (Group group in AllGroups)
            {
                if (group.No.ToLower().Trim() == no.ToLower().Trim())
                {
                    return group;
                }
            }
            return null;
        }
        public Group FindGroup(Group currentGroup)
        {
            foreach (Group group in AllGroups)
            {
                if (group.No.ToLower().Trim() == currentGroup.No.ToLower().Trim())
                {
                    return group;
                }
            }
            return null;
        }
        public void ShowStudentsInGroup(string no)
        {            
            Group group = FindGroup(no);
            if (group == null)
            {
                ClearAndColor();
                Console.WriteLine("Please enter valid groupNo.");
                return;
            }
            if (group.Students.Count == 0)
            {
                ClearAndColor();
                Console.WriteLine("There's no students in this group.");
                return;
            }
            string statusOnline = group.IsOnline ? "Online" : "Offline";
            if (no.ToLower().Trim() == group.No.ToLower().Trim())
            {
                foreach (Student student in group.Students)
                {                         
                    Console.WriteLine($"{student}, Status: {statusOnline}");                    
                }
            }       
        }        
        public void ShowAllStudents()
        {            
            if (AllStudents.Count == 0)
            {
                ClearAndColor();
                Console.WriteLine("There's no students.");
                return;
            }
            
            foreach (Group group in AllGroups)
            {
                string statusOnline = group.IsOnline ? "Online" : "Offline";
                foreach (Student student in group.Students)
                {
                    Console.WriteLine($"{student}, Status: {statusOnline}");
                }                
            }                       
        }       
        public void CreateStudent(string fullname,string groupNo, bool type)
        {                                   
            Group group = FindGroup(groupNo);

            if (group == null)
            {
                ClearAndColor();
                Console.WriteLine("Enter a group that exists");
                return;
            }                                                                                        
            if (group.Limit-1 < group.Students.Count)
            {
                ClearAndColor();
                Console.WriteLine($"You passed the limit. Group {groupNo}'s max limit is {group.Limit}");
                return;
            }            
            Student student = new Student(fullname, groupNo, type);            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Created Student {fullname.ToUpper().Trim()}\n");            
            AllStudents.Add(student);
            group.Students.Add(student);
            Console.WriteLine($"Students in group {groupNo.ToUpper().Trim()}:\n");
            string statusOnline = group.IsOnline ? "Online" : "Offline";
            foreach (Student stud in group.Students)
            {
                Console.WriteLine($"{stud}, Status: {statusOnline}");
            }
            
        }
        public static bool CheckFullname(string fullname)
        {
            if (fullname.Length > 30)
            {
                AcademyService.ClearAndColor();
                Console.WriteLine($"{fullname.ToUpper().Trim()} is too long. Enter less than 30 characters.");
                return false;
            }
            foreach (char letter in fullname)
            {
                if (char.IsDigit(letter))
                {
                    ClearAndColor();
                    Console.WriteLine("No digits allowed.");
                    return false;
                }
            }            
            string[] splitFullname = fullname.Split(" ");            
            if ((splitFullname.Length == 2)) //2 because(name and surname)
            {
                if ((splitFullname[0].Length >= 3 && splitFullname[1].Length >= 3))
                {
                    return true;
                }
                AcademyService.ClearAndColor();
                Console.WriteLine("Both Name and Surname needs to be at least 3 characters.");
                return false;
            }
            AcademyService.ClearAndColor();
            Console.WriteLine("Fullname must include: Name + Space + Surname. Example(Fakhri Afandiyev)");
            return false;
        }
        public static void ClearAndColor()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }
}