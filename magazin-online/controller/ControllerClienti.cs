using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace magazin_online
{
    public class ControllerClienti
    {

        private List<Clienti> clienti;

        public ControllerClienti()
        {
            clienti = new List<Clienti>();


            load();
           


        }

        public void afisare()
        {
            for (int i = 0; i < clienti.Count; i++)
            {
                Console.WriteLine(clienti[i].descriere());
            }
        }

        public int pozitie(int id)
        {
            for (int i = 0; i < clienti.Count; i++)
            {
                if (clienti[i].getId() == id)
                {
                    return i;
                }

            }
            return -1;
        }

        public Clienti client(int id)
        {
            for (int i = 0; i < clienti.Count; i++)
            {
                if (clienti[i].getId() == id)
                {
                    return clienti[i];
                }

            }
            return null;
        }

        public Clienti returnClienti(string email, string parola)
        {
            for(int i = 0; i < clienti.Count; i++)
            {
                if(clienti[i].getEmail().Equals(email) && clienti[i].getParola().Equals(parola))
                {
                    return clienti[i];
                }
            }
            return null;
        }

        public bool add(Clienti client)
        {
            int poz = pozitie(client.getId());

            if (poz != -1)
            {
                Console.WriteLine("Clientul exista in lista ");
                return false;
            }
            else
            {
                clienti.Add(client);
                Console.WriteLine("Clientul a fost adaugata");
                return true;
            }
        }

        public bool delete(int id)
        {
            int poz = pozitie(id);

            if (poz == -1)
            {
                Console.WriteLine("Clientul nu exista in lista");
                return false;
            }
            else
            {
                clienti.RemoveAt(poz);
                Console.WriteLine("Clientul a fost stearsa din lista");
                return true;
            }
        }

        public bool updateNume(int id)
        {
            int poz = pozitie(id);

            if (poz == -1)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Introduceti un numele nou : ");
                string numenou = Console.ReadLine();
                clienti[poz].setNume(numenou);
                Console.WriteLine("Numele profilului a fost modificat");
                return true;
            }
        }

        public bool updateEmail(int id)
        {
            int poz = pozitie(id);

            if (poz == -1)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Introduceti emailul nou : ");
                string emailnou = Console.ReadLine();
                clienti[poz].setEmail(emailnou);
                return true;
            }
        }

        public bool updateParola(int id)
        {
            int poz = pozitie(id);

            if(poz == -1)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Introduceti parola noua : ");
                string parolanoua = Console.ReadLine();

                clienti[poz].setParola(parolanoua);
                return true;
            }

        }

        public bool updateAdresa(int id)
        {
            int poz = pozitie(id);
            if (poz == -1)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Introduceti o adresa noua : ");
                string adresanoua = Console.ReadLine();
                clienti[poz].setAdersa(adresanoua);
                return false;
            }
        }

        public bool updateTara(int id)
        {
            int poz = pozitie(id);
            if (poz == -1)
            {
                return false;
            }
            else
            {
                Console.WriteLine(" Introduceti numele tarii : ");
                string taranoua = Console.ReadLine();
                clienti[poz].setTara(taranoua);
                return true;
            }
        }

        public bool updateNrTelefon(int id)
        {
            int poz = pozitie(id);
            if (poz == -1)
            {
                return false;
            }
            else
            {
                Console.WriteLine("introduceti numarul de telefon:");
                int telefonnou = Int32.Parse(Console.ReadLine());
                clienti[poz].setNrtelefon(telefonnou);
                return true;
            }
        }


        public void load()
        {
            StreamReader read = new StreamReader(@"C:\Users\catas\Desktop\FullStackC#\Incapsularea\magazin-online\magazin-online\resources\clienti.txt");

            string line = "";

            while ((line = read.ReadLine()) != null)
            {
                string[] prop = line.Split(",");


                int id = Int32.Parse(prop[0]);
                string email = prop[1];
                string parola = prop[2];
                string nume = prop[3];
                string adresa = prop[4];
                string tara = prop[5];
                int nrtelefon = Int32.Parse(prop[6]);

                Clienti client = new Clienti(id,email,parola,nume,adresa,tara,nrtelefon);

                clienti.Add(client);

            }

            read.Close();
        }

        public string toSave()
        {

            string text = "";

            int i = 0;


            for(i = 0; i < clienti.Count-1; i++)
            {

                text += clienti[i].toSave() + "\n";

            }

            text += clienti[i].toSave();

            return text;
        }

        public void Save()
        {
            StreamWriter write = new StreamWriter(@"C:\Users\catas\Desktop\FullStackC#\Incapsularea\magazin-online\magazin-online\resources\clienti.txt");

            write.Write(toSave());

            write.Close();
        }
    }
}

