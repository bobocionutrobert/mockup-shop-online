using System;
using System.Collections.Generic;
using System.Linq;
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

        private Person clienti;
        private ControllerProduse controlproduse;
        private ControllerOrders controlcomenzi;
        private ControllerOrderDetails controldetaliicomenzi;
        private ControllerPerson controlclienti;

        private Order comanda;
        

        public ViewClient(Person clienti)
        {

            this.clienti = clienti;
            controlproduse = new ControllerProduse();
            controlcomenzi = new ControllerOrders();
            controldetaliicomenzi = new ControllerOrderDetails();
            controlclienti = new ControllerPerson();

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
            Console.WriteLine("Apasati tasta 8 pentru a vedea ultima comanda plasata");
            Console.WriteLine("Apasati tasta 9 pentru a vedea comenzile in ordinea preturilor");
            Console.WriteLine("Apasati tasta 0 pentru a edita profilul dumneaovastra");
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
                    case 8:
                        ultimacomanda();
                        break;
                    case 9:
                        vizualizareordinecomenzi();
                        break;
                    case 0:
                        editareprofil();
                        break;
                         
                }


            }

        }

        public void meniuUpdateprofil()
        {
            Console.WriteLine("===================Meniu Update Client================");
            Console.WriteLine($"Bun venit, {clienti.getNume()}");
            Console.WriteLine("Apasati tasta 1 pentru a edita numele");
            Console.WriteLine("Apasati tasta 2 pentru a edita email-ul");
            Console.WriteLine("Apasati tasta 3 pentru a edita parola");
            Console.WriteLine("Apasati tasta 4 pentru a edita adresa");
            Console.WriteLine("Apasati tasta 5 pentru a edita tara");
            Console.WriteLine("Apasati tasta 6 pentru a edita numarul de telefon");
        }


        
        public void adaugareincos()
        {

            Console.WriteLine("Introduceti numele produsului pe care il doriti");
            string produsdorit = Console.ReadLine();

            //verifica,m daca produsul dorit exista

            


            Product produs = controlproduse.produs(produsdorit);



            if( produs != null)
            {

                Console.WriteLine("Introduceti cantitatea pentru produsul dorit");

                int cantiatatedorita = Int32.Parse(Console.ReadLine());

                //exista cantiatatea dorita

                if( produs.getStoc() >= cantiatatedorita)
                {
                    //adauga in cos

                    OrderDetails comandanoua = new DetaliiComenzi(controldetaliicomenzi.nextid(), comanda.getId(), produs.getId(), cantiatatedorita*(int)produs.getPret(),cantiatatedorita);



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

            List<OrderDetails> detalii = controldetaliicomenzi.getDetaliicomenzi(comanda.getId());

            for (int i = 0; i < detalii.Count; i++)
            {
                string text = "Id produs : " + detalii[i].getIdprodus() + "\n";

                text += "Numele produsului : " + controlproduse.produsdupaid(detalii[i].getIdprodus()).getNume() + "\n";

                text += "Cantitate :  " + detalii[i].getCantitate() + "\n";

                text += "Pret : " + detalii[i].getPret() + "\n";

                Console.WriteLine(text);
            }
                

        }

        public void stergeredincos()
        {
            Console.WriteLine("introduceti numele produsului pe care doriti sa il stergeti din cos");

            string numeprodus = Console.ReadLine();

            Product produs = controlproduse.produs(numeprodus);

            List<OrderDetails> detalii = controldetaliicomenzi.getDetaliicomenzi(comanda.getId());

            for(int i = 0; i < detalii.Count; i++)
            {
                if (controlproduse.produsdupaid(detalii[i].getIdprodus()).getNume().Equals(numeprodus))
                {
                    controldetaliicomenzi.delete(detalii[i].getId());
                   
                }
                else
                {
                    Console.WriteLine("Produsul nu exista in cos");
                }
            }
            
           
        }

        public void editarecos()
        {
            Console.WriteLine("Va rugam introduceti numele produsului din cos a carui cantitate doriti sa o modificati");

            string modificacantitateprodusdupanume = Console.ReadLine();

            Product produs = controlproduse.produs(modificacantitateprodusdupanume);



            List<OrderDetails> detalii = controldetaliicomenzi.getDetaliicomenzi(comanda.getId());

            for(int i = 0; i < detalii.Count; i++)
            {
                if (controlproduse.produsdupaid(detalii[i].getIdprodus()).getNume().Equals(modificacantitateprodusdupanume))


                {
                    Console.WriteLine($"Aveti in cos {detalii[i].getCantitate()} produse de acel tip in cos");

                    Console.WriteLine("Introduceti cantitatea noua pentru acest produs");

                    int cantitatenoua = Int32.Parse(Console.ReadLine());

                    if (cantitatenoua > 0)
                    {
                        int cantiateVeche = detalii[i].getCantitate();

                   


                        controlproduse.updateStocdupanume(modificacantitateprodusdupanume,(produs.getStoc()+cantiateVeche)-cantitatenoua);


                        detalii[i].setCantitate(cantitatenoua);


                        detalii[i].setPret(cantitatenoua * (int)produs.getPret());



                       
                        Console.WriteLine("Cosul a fost editat");
                    }
                    else if (cantitatenoua == 0)
                    {
                        controldetaliicomenzi.delete(detalii[i].getId());
                        Console.WriteLine("Produsul a fost sters din cos");
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
            List<OrderDetails> istoric = controldetaliicomenzi.getDetaliicomenzi(comanda.getIdclient());

            
            for(int i = 0; i < istoric.Count; i++)
            {
                
                Console.WriteLine(istoric[i].descriere());
            }
        }

        public void ultimacomanda()
        {

            List<OrderDetails> istoric = controldetaliicomenzi.getDetaliicomenzi(comanda.getIdclient());

           

             Console.WriteLine(istoric[istoric.Count-1].descriere());
            

        }

        public void vizualizareordinecomenzi()
        {

            List<OrderDetails> istoric = controldetaliicomenzi.getDetaliicomenzi(comanda.getIdclient());


            for(int i = 0; i < istoric.Count-1; i++)
            {
                for(int j = i+1; j < istoric.Count; j++)
                {
                    if(istoric[i].getPret() > istoric[j].getPret())
                    {
                        OrderDetails aux = istoric[i];
                        istoric[i] = istoric[j];
                        istoric[j] = aux;
                    }

                }

            }



            foreach(OrderDetails detalii in istoric)
            {
                Console.WriteLine(detalii.descriere());
            }
          

        }

        public void editareprofil()
        {
            meniuUpdateprofil();

            Console.WriteLine("Alegeti ce doriti sa modificati din profil ");

            int alegere = Int32.Parse(Console.ReadLine());

            switch (alegere)
            {
                case 1:
                    Console.WriteLine("Introduceti un numele nou : ");
                    string numenou = Console.ReadLine();
                    controlclienti.updateNume(clienti.getId(),numenou);
                    controlclienti.Save();
                    break;
                case 2:
                    Console.WriteLine("Introduceti emailul nou : ");
                    string emailnou = Console.ReadLine();
                    controlclienti.updateEmail(clienti.getId(),emailnou);
                    controlclienti.Save();
                    break;

                case 3:
                    Console.WriteLine("Introduceti parola noua : ");
                    string parolanoua = Console.ReadLine();
                    controlclienti.updateParola(clienti.getId(),parolanoua);
                    controlclienti.Save();
                    break;
                case 4:
                    Console.WriteLine("Introduceti o adresa noua : ");
                    string adresanoua = Console.ReadLine();
                    controlclienti.updateAdresa(clienti.getId(),adresanoua);
                    controlclienti.Save();
                    break;
                case 5:
                    Console.WriteLine(" Introduceti numele tarii : ");
                    string taranoua = Console.ReadLine();
                    controlclienti.updateTara(clienti.getId(),taranoua);
                    controlclienti.Save();
                    break;
                case 6:
                    Console.WriteLine("introduceti numarul de telefon:");
                    int telefonnou = Int32.Parse(Console.ReadLine());
                    controlclienti.updateNrTelefon(clienti.getId(),telefonnou);
                    controlclienti.Save();
                    break;
            }
        }


    }
   
}
