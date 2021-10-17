using System;
using System.Collections.Generic;
using System.Text;

namespace magazin_online
{
    //-->view produsele
    //-->add cos
    //-->edit cos
    //-->remove cos
    //trimite comamnda
    class ViewClient
    {

        private Clienti clienti;
        private ControllerProduse controlproduse;
        private ControllerComenzi controlcomenzi;
        private ControllerDetaliiComenzi controldetaliicomenzi;

        private Comenzi comanda;
        

        public ViewClient(Clienti clienti)
        {

            this.clienti = clienti;
            controlproduse = new ControllerProduse();
            controlcomenzi = new ControllerComenzi();
            controldetaliicomenzi = new ControllerDetaliiComenzi();


            comanda = new Comenzi(controlcomenzi.nextid(), clienti.getId(), 0, "");


        

        }

        public void meniu()
        {
            Console.WriteLine("===================Meniu Client================");
            Console.WriteLine($"Bun venit, {clienti.getNume()}");
            Console.WriteLine("Apasati tasta 1 pentru a vizualiza produsele");
            Console.WriteLine("Apasati tasta 2 pentru a adauga un produs in cos");
            Console.WriteLine("Apasati tasta 3 pentru a vedea produsele din cos ");
            Console.WriteLine("Apasati tasta 4 pentru a sterge un produs din cos");
            Console.WriteLine("Apasati tasta 5 pentru a edita cosul");
            Console.WriteLine("Apasati tasta 6 pentru a finaliza comanda");
            Console.WriteLine("Apasati tasta 7 pentru a vedea istoricul comenzilor");
            //istoricul comenzilor
            //sortarea comenzilor in ordinea preturilor
            //produsele dintr-o anumita comanda
            //editare client profile



        }
                
        public void play()
        {
            
            bool running = true;
            while (running == true) {

                meniu();
                int alegere = Int32.Parse(Console.ReadLine());

                switch (alegere)
                {
                    case 1:
                        controlproduse.afisare();
                        break;
                    case 2:
                        adaugareincos();
                        break;
                    case 3:
                        vizualizarecos();
                        break;

                    case 4:
                        stergeredincos();
                        break;
                    case 5:
                        editarecos();
                        break;
                    case 6:
                        finalizarecomanda();
                        break;
                    case 7:
                        istoriculcomenzilor();
                        break;
                         
                }


            }

        }
        public void adaugareincos()
        {

            Console.WriteLine("Introduceti numele produsului pe care il doriti");
            string produsdorit = Console.ReadLine();

            //verifica,m daca produsul dorit exista

            


            Produs produs = controlproduse.produs(produsdorit);



            if( produs != null)
            {

                Console.WriteLine("Introduceti cantitatea pentru produsul dorit");

                int cantiatatedorita = Int32.Parse(Console.ReadLine());

                //exista cantiatatea dorita

                if( produs.getStoc() >= cantiatatedorita)
                {
                    //adauga in cos

                    DetaliiComenzi comandanoua = new DetaliiComenzi(controldetaliicomenzi.nextid(), comanda.getId(), produs.getId(), cantiatatedorita*(int)produs.getPret(),cantiatatedorita);



                    controldetaliicomenzi.add(comandanoua);

                    //update  produse


                    controlproduse.updateStoc(controlproduse.produs(produsdorit).getId(), produs.getStoc() - cantiatatedorita);


                    Console.WriteLine("Produsul s-a adaugat in cos");

                    

                }
                 
            }
            else
            {

            }


    }

        public void vizualizarecos()
        {

            List<DetaliiComenzi> detalii = controldetaliicomenzi.getDetaliicomenzi(comanda.getId());

            for (int i = 0; i < detalii.Count; i++)
            {
                string text = "Id produs : " + detalii[i].getId() + "\n";

                text += "Numele produsului : " + controlproduse.produsdupaid(detalii[i].getId()).getNume() + "\n";

                text += "Cantitate :  " + detalii[i].getCantitate() + "\n";

                text += "Pret : " + detalii[i].getPret() + "\n";

                Console.WriteLine(text);
            }
                

        }

        public void stergeredincos()
        {
            Console.WriteLine("Va rugam introduceti numele produsului pe care doriti sa il stergeti din cos");

            string stergeprodus = Console.ReadLine();

            List<DetaliiComenzi> detalii = controldetaliicomenzi.getDetaliicomenzi(comanda.getId());

            for(int i = 0; i < detalii.Count; i++)
            {
                if (controlproduse.produsdupaid(detalii[i].getId()).getNume().Equals(stergeprodus))
                {
                    controldetaliicomenzi.delete(detalii[i].getId());
                    Console.WriteLine($"Produsul {controlproduse.produsdupaid(detalii[i].getId()).getNume()} a fost sters din cosul de cumparaturi");
                }
            }
        }

        public void editarecos()
        {
            Console.WriteLine("Va rugam introduceti numele produsului din cos a carui cantitate doriti sa o modificati");

            string modificacantitateprodus = Console.ReadLine();

            List<DetaliiComenzi> detalii = controldetaliicomenzi.getDetaliicomenzi(comanda.getId());

            for(int i = 0; i < detalii.Count; i++)
            {
                if (controlproduse.produsdupaid(detalii[i].getId()).getNume().Equals(modificacantitateprodus))
                {
                    Console.WriteLine($"Aveti in cos {detalii[i].getCantitate()} produse de acel tip in cos");

                    Console.WriteLine("Introduceti cantitatea noua pentru acest produs");

                    int cantitatenoua = Int32.Parse(Console.ReadLine());

                    if (cantitatenoua >= 0)
                    {
                        detalii[i].setCantitate(cantitatenoua);

                        Console.WriteLine("Cosul a fost editat");
                    }
                    else
                    {
                        Console.WriteLine("Produsul nu exista in cos");
                    }
                }
            }
        }

        public void finalizarecomanda()
        {
            Console.WriteLine("Sunteti sigur ca doriti sa finalizati comanda da/nu");

            string sigur = Console.ReadLine();

            if (sigur == "da")
            {
                Console.WriteLine("Acesta este cosul dumneavoastra de cumparaturi");
                vizualizarecos();

                Console.WriteLine("Doriti sa plasati comanda? da/nu");

                string dasaunu = Console.ReadLine();

                if (dasaunu == "da")
                {
                    controldetaliicomenzi.toSave();
                    Console.WriteLine($"Comanda va fi livrata in cel mai scurt timp la adresa {comanda.getAdresalivrare()}");
                    controldetaliicomenzi.delete(comanda.getId());
                }
                else
                {
                    Console.WriteLine("Ati fost redirectionat catre meniul principal");
                    meniu();
                }

            }
            else if( sigur == "nu")
            {
                meniu();
            }
            else
            {
                meniu();
            }

        }

        public void istoriculcomenzilor()
        {
            controldetaliicomenzi.istoriccomenzi(comanda.getIdclient());
        }

        public void ordinecomenzi()
        {

        }

        public void vizualizarecomandaprecedenta()
        {

        }

        public void editareprofil()
        {

        }


    }
   
}
