using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2
{
    public class StudentAddressBook
    {
        public StudentAddressBook(string fn, string ln, string cn, string jt, string email, string address, string countryCode, string ph, string pht)
        {
            this.FirstName = fn;
            this.LastName = ln;
            this.CompanyName = cn;
            this.JobTitle = jt;
            this.Email = email;
            this.Address = address;
            this.CountryCode = countryCode;
            this.PhNumber = ph;
            this.Photo = pht;

        }
        public StudentAddressBook()
        { }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string CountryCode { get; set; }
        public string PhNumber { get; set; }
        public string Photo { get; set; }
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName + " " + this.CompanyName + " " + this.JobTitle + " " + this.Email + " " + this.Address + " " + this.CountryCode + " " + this.PhNumber + " " + this.Photo;
        }
    }
}
