using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Project.Models
{
    class Student
    {
        public string Fullname;
        public string GroupNo;
        public bool Type;        
        public Student(string fullname, string groupno, bool type)
        {           
            Fullname = fullname;
            GroupNo = groupno;
            Type = type;
        }
        public override string ToString()
        {            
            string statusType = Type ? "Warranted" : "Not Warranted";
            
            return $"Fullname: {Fullname}, GroupNo: {GroupNo}, Type: {statusType}";
        }
    }
}
