using System;
using System.Collections.Generic;
using System.Text;

namespace magazin_online
{
    public class Person
    {
        private int id;
        private string type;
        private string email;
        private string name;
        private string address;
        private string country;
        private int phonenumber;
        
        
        public Person()
        {

        }

        public Person(int id, string type,string email, string name, string address, string country, int phonenumber)
        {
            this.id = id;
            this.type=type;
            this.email = email;
            this.name = name;
            this.address = address;
            this.country = country;
            this.phonenumber = phonenumber;

        }



        public Person(string proprietati)
        {
            string[] prop = proprietati.Split(",");

            this.id = Int32.Parse(prop[0]);
            this.type = prop[1];
            this.email = prop[2];
            this.name = prop[3];
            this.address= prop[4];
            this.country = prop[5];
            this.phonenumber = Int32.Parse(prop[6]);
        }

        public int Id { 
            
            get { return id; } 
            set { this.id = value; }
        
        }

        public string Type 
        {
            get { return type; }
            set { type = value; }
        }

        public string Email
        {
            get { return email; }
            set { this.email = value; }
        }


        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        public string Address
        {
            get { return address; }
            set { this.address = value; }

        }
        public string Country
        {
            get { return country; }
            set { this.country = value; }
        }

        public int Phone
        {
            get { return phonenumber; }
            set { this.phonenumber = value; }
        }
        public virtual string personDetails()
        {
            string text = "";

            text += "Person id : " + id + "\n";
            text += "Person email : " + email + "\n";
            text += "Person Name : " + name + "\n";
            text += "Person address : " + address + "\n";
            text += "Country is from : " + country + "\n";
            text += "Phone number : " + phonenumber + "\n";

            return text;
        }

        public string toSave()
        {
            return this.id + "," + this.type+ "," + this.email + ","+ this.name + "," + this.address + "," + this.country + "," + this.phonenumber;
        }
    }
}

