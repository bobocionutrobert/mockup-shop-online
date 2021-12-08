using magazin_online.model;
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
            Console.WriteLine("Press 1 to log as admin");

            Console.WriteLine("Press 2 to log as client");

            Console.WriteLine("Press 3 to register");

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

                        LoginAdmin();

                        break;
                    case 2:

                        LoginClient();  
                        break;

                    case 3:
                        Register();
                        break;



                }
            }
        }

        public void LoginAdmin()
        {
            Console.WriteLine("Insert e-mail");
            string email = Console.ReadLine();

            Console.WriteLine("Insert password");
            string password = Console.ReadLine();



            Person p = control.returnAdminByEmailPassword(email, password); 
            

            
           
            if(p != null)
            {
                if (p.Type.Equals("Admin"))
                {
                    ViewAdmin v = new ViewAdmin(p);

                    v.play();

                    Console.WriteLine("Logged as admin");

                }
            }
            else
            {
                
                Console.WriteLine("Client doesn't exist");
            }
        }

        public void LoginClient()
        {
            Console.WriteLine("Insert e-mail");
            string email = Console.ReadLine();

            Console.WriteLine("Insert password");
            string password = Console.ReadLine();


            Person p = control.returnClientByEmailPassword(email, password);

            


            if (p != null)
            {
                if (p.Type.Equals("Client"))
                {


                    ViewClient client = new ViewClient(p);

                    client.play();

                    Console.WriteLine("Logged as client");

                }
            }
            else
            {

                Console.WriteLine("Client doesn't exist");
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
    

