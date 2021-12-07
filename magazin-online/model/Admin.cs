using System;
using System.Collections.Generic;
using System.Text;

namespace magazin_online.model
{
    public class Admin : Person
    {
        private string password;
        private int salary;

        public Admin(string password, int salary, int id, string type,string email, string name, string country, string address, int phonenumber) : base(id,"Admin", email, name, address, country, phonenumber)
        {
            this.password = password;
            this.salary = salary;
        }

        public Admin(string proprietati) : base(proprietati)
        {
            string[] prop = proprietati.Split(",");

            this.password = prop[7];
            this.salary = Int32.Parse(prop[8]);


        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public int Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }

        public override string personDetails()
        {
            string text = base.personDetails();

            text += "Admin password is : " + password + "\n";
            text +="Admin salary is " + salary + "\n";

            return text;
        }


    }
}
