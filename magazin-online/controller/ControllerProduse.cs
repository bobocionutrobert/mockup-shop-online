using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace magazin_online
{
    public class ControllerProduse
    {

        private List<Produs> produse;

        public ControllerProduse()
        {
            produse = new List<Produs>();

            load();

        }

        public void afisare()
        {
            for(int i = 0; i < produse.Count; i++)
            {
                Console.WriteLine(produse[i].descriere());
            }
        }

        public int pozitie(int id)
        {
            for(int i = 0; i < produse.Count; i++)
            {
                if(produse[i].getId() == id)
                {
                    return i;
                }

            }
            return -1;
        }

        public int nexid()
        {
            if(produse.Count == 0)
            {
                return 1;
            }
            else
            {
                return produse[produse.Count - 1].getId() + 1;
            }
        }

        public Produs produs(string numeprodus)
        {
            for (int i = 0; i < produse.Count; i++)
            {
                if (produse[i].getNume().Equals(numeprodus) == true)
                {
                    return produse[i];
                }

            }
            return null;
        }

        public Produs produsdupaid(int id)
        {
            for(int i = 0; i < produse.Count; i++)
            {
                if(produse[i].getId() == id)
                {
                    return produse[i];
                }
            }

            return null;
        }

        public bool add(Produs produs)
        {
            int poz = pozitie(produs.getId());

            if (poz != -1)
            {
                Console.WriteLine("Produsul exista in lista ");
                return false;
            }
            else
            {
                produse.Add(produs);
                Console.WriteLine("Produsul a fost adaugata");
                return true;
            }
        }

        public bool delete(int id)
        {
            int poz = pozitie(id);

            if (poz == -1)
            {
                Console.WriteLine("Produsul nu exista in lista");
                return false;
            }
            else
            {
                produse.RemoveAt(poz);
                Console.WriteLine("produsul a fost stearsa din lista");
                return true;
            }
        }

        public bool updatePret(int id, int pretnou)
        {
            int poz = pozitie(id);

            if (poz == 1)
            {
                return false;
            }
            else
            {
                produse[poz].setPret(pretnou);
                return true;
            }
        }

        

        public bool updateStoc(int id, int stocnou)

        {
            int poz = pozitie(id);

            if(poz == 1)
            {
                return false;
            }
            else
            {
                produse[poz].setStoc(stocnou);
                return true;
            }
        }

        

        public void load()
        {

            StreamReader read = new StreamReader(@"C:\Users\catas\Desktop\FullStackC#\Incapsularea\magazin-online\magazin-online\resources\produse.txt");

            string line = "";

            while ((line = read.ReadLine()) != null)
            {
                string[] prop = line.Split(",");

                int id = Int32.Parse(prop[0]);
                string nume = prop[1];
                double pret = double.Parse(prop[2]);
                int cantitate = Int32.Parse(prop[3]);

                Produs produs = new Produs(id, nume, pret, cantitate);

                produse.Add(produs);




            }
            read.Close();


        }

        public string toSave()
        {
            string text = "";

            int i = 0;

            for (i = 0; i < produse.Count-1; i++)
            {
                text += produse[i].toSave() + "\n";
            }

            text += produse[i].toSave();

            return text;
        }

        public void Save()
        {
            StreamWriter write = new StreamWriter(@"C:\Users\catas\Desktop\FullStackC#\Incapsularea\magazin-online\magazin-online\resources\produse.txt");

            write.Write(toSave());

            write.Close();




        }
    }
}

