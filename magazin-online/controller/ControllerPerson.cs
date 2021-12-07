using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using magazin_online.model;

namespace magazin_online
{
    public class ControllerPerson
    {

        private List<Person> persons;

        public ControllerPerson()
        {
            persons = new List<Person>();


            load();
           


        }

        public void displayListofPersons()
        {
            for (int i = 0; i < persons.Count; i++)
            {
                Console.WriteLine(persons[i].personDetails());
            }
        }

        public int positionById(int personid)
        {
            for(int i =0;i< persons.Count; i++)
            {
                if(persons[i].Id == personid)
                {
                    return i;
                }
            }
            return -1;
        }

        public int positionByName(string personname)
        {
            for(int i=0;i< persons.Count; i++)
            {
                if (persons[i].Name.Equals(personname))
                {
                    return i;
                }
            }
            return -1;
        }

        public Person returnPersonbyId(int personid)
        {
            foreach(Person person in persons)
            {
                if(person.Id == personid)
                {
                    return person;
                }
            }
            return null;
        }

        public Person returnPersonByName(string personname)
        {
            foreach(Person person in persons)
            {
                if (person.Name.Equals(personname))
                {
                    return person;
                }
            }
            return null;
        }

        public bool addPerson(Person person)
        {
            int poz = positionById(person.Id);

            if(poz != -1)
            {
                Console.WriteLine("Person already in list");
                return false;
            }
            else
            {
                persons.Add(person);
                Console.WriteLine("Person added to list");
                return true;
            }
        }

        public bool deletePersonById(int personid)
        {
            int poz = positionById(personid);

            if (poz == -1)
            {
                Console.WriteLine("Person isn't in the list");
                return false;
            }
            else
            {
                persons.RemoveAt(poz);
                Console.WriteLine("Person deleted from list");
                return true;
            }
        }

        public bool deletePersonByName(string personname)
        {
            int poz = positionByName(personname);
            if(poz == -1)
            {
                Console.WriteLine("Person isn't in the list");
                return false;
            }
            else
            {
                persons.RemoveAt(poz);
                Console.WriteLine("Person deleted from list");
                return true;
            }
        }

        public void updatePersonEmail(int personid,string newpersonemail)
        {
            foreach(Person person in persons)
            {
                if(person.Id == personid)
                {
                    person.Email = newpersonemail;
                }
            }
        }

        public void updatePersonName(int personid,string newpersoname)
        {
            foreach(Person person in persons)
            {
                if(person.Id == personid)
                {
                    person.Name = newpersoname;
                }
            }
        }

        public void updatePersonAddress(int personid, string newpersonaddress)
        {
            foreach(Person person in persons)
            {
                if(person.Id == personid)
                {
                    person.Address = newpersonaddress;
                }
            }
        }

        public void updatePersonCountry(int personid, string newpersoncountry)
        {
            foreach( Person person in persons)
            {
                if(person.Id == personid)
                {
                    person.Country = newpersoncountry;
                }
            }
        }

        public void updatePersonPhoneNumber(int personid,int newpersonphonenumber)
        {
            foreach(Person person in persons)
            {
                if(person.Id == personid)
                {
                    person.Phone = newpersonphonenumber;
                }
            }
        }

        public void updateClientPassword(int personid,string newpassword)
        {
            foreach(Person person in persons)
            {
                if(person.Id == personid)
                {
                    Client client = person as Client;

                    client.Password = newpassword;
                }
            }
        }

        public void updateAdminPassword(int personid,string newpassword)
        {
            foreach(Person person in persons)
            {
                if(person.Id == personid)
                {
                    Admin admin = person as Admin;

                    admin.Password = newpassword;
                }
            }
        }

        public void updateAdminSalary(int personid, int newsalary)
        {
            foreach(Person person in persons)
            {
                if(person.Id == personid)
                {
                   Admin admin = person as Admin;

                    admin.Salary = newsalary;
                }
            }
        }

        public void load()
        {
            StreamReader read = new StreamReader(@"C:\Users\Asus\source\repos\mockup-shop-online\magazin-online\resources\persons.txt");

            this.persons.Clear();

            string line = "";

            while ((line = read.ReadLine()) != null)
            {
                string[] prop = line.Split(",");


                if (prop[1].Equals("Client"))
                {
                    this.persons.Add(new Client(line));
                }
                else
                {
                    this.persons.Add(new Admin(line));
                }

            }

            read.Close();
        }

        public string toSave()
        {

            string text = "";

            int i = 0;


            for(i = 0; i < persons.Count-1; i++)
            {

                text += persons[i].toSave() + "\n";

            }

            text += persons[i].toSave();

            return text;
        }

        public void Save()
        {
            StreamWriter write = new StreamWriter(@"C:\Users\Asus\source\repos\mockup-shop-online\magazin-online\resources\persons.txt");

            write.Write(toSave());

            write.Close();
        }
    }
}

