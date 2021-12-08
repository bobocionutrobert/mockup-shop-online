using System;
using System.Collections.Generic;
using System.Text;

namespace magazin_online.model
{
    public class Client : Person
    {
        private string password;

        public Client(string password,int id,string type,string email,string name,string country,string address,int phonenumber) : base(id,"Client",email,name,address,country,phonenumber)
        {
            this.password = password;
        }

        public Client(string proprietati) : base(

            Int32.Parse(proprietati.Split(",")[0]),
            proprietati.Split(",")[1],
            proprietati.Split(",")[2],
            proprietati.Split(",")[3],
            proprietati.Split(",")[4],
            proprietati.Split(",")[5],
            Int32.Parse(proprietati.Split(",")[6])


            )
        {
            string[] prop = proprietati.Split(",");

            this.password = prop[7];


        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }


        public override string personDetails()
        {

            string text = base.personDetails();

            text += "Client password : " + password + "\n";

            return text;

        }
    }
}
