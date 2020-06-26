using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2
{
    public class Student
    {
        public Student(string name, string pass, List<StudentAddressBook> li)
        {
            this.UserName = name;
            this.Password = pass;
            this.setList(li);
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<StudentAddressBook> dataList = new List<StudentAddressBook>();
        public void setList(List<StudentAddressBook> li)
        {
            this.dataList = li;
        }
        public List<StudentAddressBook> getList()
        {
            return this.dataList;
        }
        //private List<StudentAddressBook> book = new List<StudentAddressBook>();
        public override string ToString()
        {
            return this.UserName + " " + this.Password;
        }
    }
}
