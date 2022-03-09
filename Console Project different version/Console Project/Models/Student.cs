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
        //public bool Online;

        public Student(string fullname, string groupno, bool type)
        {
            //Online = isonline;
            Fullname = fullname;
            GroupNo = groupno;
            Type = type;
        }
        public override string ToString()
        {
            ////string statusOnline = Online ? "Online" : "Offline";
            string statusType = Type ? "Warranted" : "Not Warranted";
            
            return $"Fullname: {Fullname.ToUpper().Trim()}, GroupNo: {GroupNo.ToUpper().Trim()}, Type: {statusType}";
        }
    }
}
