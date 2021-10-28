using System;
using System.Collections.Generic;
using System.Text;

namespace magazin_online
{
    class ViewLogin
    {

        private ControllerClienti control;

        public ViewLogin()
        {
            control = new ControllerClienti();
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

                        Registrare();
                        break;

                    case 3:

                        break;



                }
            }
        }

        public void Login()
        {
            Console.WriteLine("Introduceti email-ul");
            string email = Console.ReadLine();

            Console.WriteLine("Introduceti parola");
            string password = Console.ReadLine();



            Clienti p = control.returnClienti(email, password); ;


            if(p != null)
            {
                if (p.getAdmin() == true)
                {
                    ViewAdmin v = new ViewAdmin(p);

                    v.play();

                    Console.WriteLine("Autentificat cu rolul de admin");

                }
                else if (p.getAdmin() == false)
                {
                    ViewClient c = new ViewClient(p);

                    c.play();

                    Console.WriteLine("autentificat cu rolul de client");
                }
            }
            else
            {
                //registrare
                Console.WriteLine("Clientul nu exista");
            }
        }


        public void Registrare()
        {  //id,email,parola,nume,adresa,tara,telefon
            Random random = new Random();
            int idrandom = random.Next(100, 10000);

            Console.WriteLine("Introduceti emailul dumneavoastra : ");

            string emailnou = Console.ReadLine();

            Console.WriteLine("Introduceti parola pentru contul dumneavoastra : ");

            string parolautilizator = Console.ReadLine();

            Console.WriteLine("Introduceeti numele dumneavostra : ");
            string numenou = Console.ReadLine();
            Console.WriteLine("Introduceti adresa de livrare pentru produse :");
            string adresalivrare = Console.ReadLine();
            Console.WriteLine("Introduceti tara : ");
            string taranoua = Console.ReadLine();
            Console.WriteLine("Introduceti numarul de telefon : ");
            int nrtelefonnou = Int32.Parse(Console.ReadLine());

            bool adminnou = false;
            Clienti c = new Clienti(idrandom, emailnou, parolautilizator, numenou, adresalivrare, taranoua, nrtelefonnou,adminnou);

            control.add(c);

            control.Save();




        }




    }


}
    

