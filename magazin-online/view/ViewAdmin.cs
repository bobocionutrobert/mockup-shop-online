using System;
using System.Collections.Generic;
using System.Text;

namespace magazin_online
{
    class ViewAdmin
    {
        private Clienti clienti;
        private ControllerClienti controlclienti;
        private ControllerComenzi controlcomenzi;
        private ControllerDetaliiComenzi controldetalii;
        private ControllerProduse controlproduse;

        public ViewAdmin(Clienti clienti)
        {
            this.clienti = clienti;
            controlclienti = new ControllerClienti();
            controlcomenzi = new ControllerComenzi();
            controldetalii = new ControllerDetaliiComenzi();
            controlproduse = new ControllerProduse();
        }

        public void meniu()
        {
            Console.WriteLine("===================Meniu Admin================");
            Console.WriteLine($"Bun venit, {clienti.getNume()}");
            Console.WriteLine("Apasati tasta 1 pentru a adauga un produs nou ");
            Console.WriteLine("Apasati tasta 2 pentru a sterge un produs din lista");
            Console.WriteLine("Apasati tasta 3 pentru a modifica stocul unui produs");

            //
        }

        public void play()
        {
            bool running = true;

            while(running == true)
            {
                meniu();

                int alegere = Int32.Parse(Console.ReadLine());

                switch (alegere) 
                {

                    case 1:
                        adaugareprodus();

                        break;
                    case 2:
                        stergereprodus();
                        break;

                
                }


            }
        }


        public void adaugareprodus()
        {


            Random rnd = new Random();
            int id = rnd.Next();

            Console.WriteLine("Introduceti numele produsului pe care doriti sa il adaugati : ");

            string numeprodus = Console.ReadLine();

            Console.WriteLine("Introduceti pretul pentru noul produs : ");

            int pretprodus = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti stocul pentru noul produs : ");

            int stocprodus = Int32.Parse(Console.ReadLine());

            Produs produs = new Produs(id, numeprodus, pretprodus, stocprodus);

            controlproduse.add(produs);

            controlproduse.Save();  


        }

        public void stergereprodus()
        {
            Console.WriteLine("Introduceti numele produsului pe care doriti sa il stergeti din lista");

            string numeprodus = Console.ReadLine();

            controlproduse.deletedupanume(numeprodus);

            controlproduse.Save();
            
        }


        public void modificarestoc()
        {
            Console.WriteLine("Introduceti numele produsului al carui stoc doriti sa il modificati");

            string numeprodus = Console.ReadLine();

            Console.WriteLine("Introduceti cantitatea noua de stoc pentru produs");

            int stocnou = Int32.Parse(Console.ReadLine());

            controlproduse.updateStocdupanume(numeprodus, stocnou);

            controlproduse.Save();
        }



    }
}
