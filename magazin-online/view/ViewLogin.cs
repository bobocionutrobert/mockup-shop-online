using System;
using System.Collections.Generic;
using System.Text;

namespace magazin_online
{
    class ViewLogin
    {

        private ControllerPerson control;

        public ViewLogin()
        {
            control = new ControllerPerson();
        }

        public void meniu()
        {
            Console.WriteLine("Apasati tasta 1 pentru a va loga");

            Console.WriteLine("Apasati tasta 2 pentru a va inregistra");

            Console.WriteLine("Apasati tasta 3 pentru a iesi");

        }

        public void play()
        {

            bool running = true;

            while (running == true)
            {

                meniu();

                int alegere = Int32.Parse(Console.ReadLine());


                switch (alegere)
                {
                    case 1:

                        Login();

                        break;
                    case 2:

                        Register();
                        break;

                    case 3:

                        break;



                }
            }
        }

        public void Login()
        {
            Console.WriteLine("Insert e-mail");
            string email = Console.ReadLine();

            Console.WriteLine("Insert password");
            string password = Console.ReadLine();



            Person p = control.returnAdminByEmailPassword(email, password); 
            Person c = control.returnClientByEmailPassword(email,password);

            if(p != null)
            {
                if (p.Type.Equals("Admin"))
                {
                    ViewAdmin v = new ViewAdmin(p);

                    v.play();

                    Console.WriteLine("Logged as admin");

                }
                else if (c.Type.Equals("Client"))
                {
                    ViewClient client = new ViewClient(c);

                    client.play();

                    Console.WriteLine("Logged as client");
                }
            }
            else
            {
                //registrare
                Console.WriteLine("Clientul doesn't exist");
            }
        }


        public void Register()
        {  //id,email,parola,nume,adresa,tara,telefon
            Random random = new Random();
            int idrandom = random.Next(100, 10000);

            Console.WriteLine("Insert your email : ");

            string email = Console.ReadLine();

            Console.WriteLine("Insert type (Admin/Client) : ");

            string type = Console.ReadLine();

            Console.WriteLine("Insert name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Insert delivery address :");
            string address = Console.ReadLine();
            Console.WriteLine("Insert country : ");
            string country = Console.ReadLine();
            Console.WriteLine("Insert phone number : ");
            int phonenumber = Int32.Parse(Console.ReadLine());

            

            Person c = new Person(idrandom,type,email,name,address,country,phonenumber);

            control.addPerson(c);

            control.Save();




        }




    }


}
    

