using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace magazin_online
{
    public class ControllerComenzi
    {

        private List<Comenzi> comenzi;

       public ControllerComenzi()
        {
            comenzi = new List<Comenzi>();



            load();


        }

        public string afisare()
        {
            string text = "";
            for (int i = 0; i < comenzi.Count; i++)
            {
                text += comenzi[i].descriere() + "\n";
            }

            return text;
        }

        public int pozitie(int id)
        {
            for(int i = 0; i < comenzi.Count; i++)
            {
                if(comenzi[i].getId().Equals(id) == true)
                {
                    return i;
                }
            }
            return -1;
        }

        public int nextid()
        {
            if(comenzi.Count == 0)
            {
                return 1;
            }
            else
            {
                return comenzi[comenzi.Count - 1].getId() + 1;
            }
        }

        public Comenzi comanda(int id)
        {
            for (int i = 0; i < comenzi.Count; i++)
            {
                if (comenzi[i].getId().Equals(id) == true)
                {
                    return comenzi[i];
                }

            }
            return null;
        }

        public bool add(Comenzi comanda)
        {
            int poz = pozitie(comanda.getId());

            if (poz != -1)
            {
                Console.WriteLine("flase");
                return false;
            }
            else
            {
                comenzi.Add(comanda);
                Console.WriteLine("true");
                return true;
            }
        }

        public bool delete(int id)
        {
            int poz = pozitie(id);

            if (poz == -1)
            {
                Console.WriteLine("false");
                return false;
            }
            else
            {
                comenzi.RemoveAt(poz);
                Console.WriteLine("true");
                return true;
            }
        }

        public bool updateAdresalivrare(int id, string adresalivrarenoua)
        {
            int poz = pozitie(id);

            if (poz == -1)
            {
                return false;
            }
            else
            {
                comenzi[poz].setAdresalivrare(adresalivrarenoua);
                return true;
            }
        }

     


        public void load()
        {
            StreamReader read = new StreamReader(@"C:\Users\catas\Desktop\FullStackC#\Incapsularea\magazin-online\magazin-online\resources\comenzi.txt");

            string line = "";

            while ((line = read.ReadLine()) != null)
            {
                string[] prop = line.Split(",");


                int id = Int32.Parse(prop[0]);
                int idclient = Int32.Parse(prop[1]);
                int ammount = Int32.Parse(prop[2]);
                string adresalivrare = prop[3];


                Comenzi comada = new Comenzi(id, idclient, ammount, adresalivrare);

                comenzi.Add(comada);

            }

            read.Close();
        }

        public string toSave()
        {

            string text = "";

            int i = 0;


            for (i = 0; i < comenzi.Count - 1; i++)
            {

                text += comenzi[i].toSave() + "\n";

            }

            text += comenzi[i].toSave();

            return text;
        }

        public void Save()
        {
            StreamWriter write = new StreamWriter(@"C:\Users\catas\Desktop\FullStackC#\Incapsularea\magazin-online\magazin-online\resources\comenzi.txt");

            write.Write(toSave());

            write.Close();
        }

        public List<Comenzi> istoriccomenzi(int clientid)
        {
            List<Comenzi> istoric = new List<Comenzi>();

            for (int i = 0; i < comenzi.Count; i++)
            {
                if (comenzi[i].getIdclient() == clientid)
                {
                    istoric.Add(comenzi[i]);
                }
            }

            return istoric;

        }
    }
}

