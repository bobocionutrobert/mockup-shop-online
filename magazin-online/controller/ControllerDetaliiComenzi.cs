using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace magazin_online
{
    public class ControllerDetaliiComenzi
    {

        private List<DetaliiComenzi> detaliicomenzi;
        
        

        public ControllerDetaliiComenzi()
        {
            detaliicomenzi = new List<DetaliiComenzi>();
          

            load();
        }

        public string afisare()
        {
            string text = "";
            for(int i = 0; i < detaliicomenzi.Count; i++)
            {
                text += detaliicomenzi[i].descriere() + "\n";
            }

            return text;
        }

        public int pozitie(int id)
        {
            for(int i = 0; i < detaliicomenzi.Count; i++)
            {
                if(detaliicomenzi[i].getId()==id)
                {
                    return i;
                }
            }
            return -1;
        }

        public int nextid()
        {
            if (detaliicomenzi.Count == 0)
            {
                return 1;
            }
            else
            {


                return detaliicomenzi[detaliicomenzi.Count - 1].getId() + 1;
            }
        }

        public DetaliiComenzi detaliicomanda(int id)
        {
            for(int i = 0; i < detaliicomenzi.Count;i++)
            {
                if(detaliicomenzi[i].getId() == id)
                {
                    return detaliicomenzi[i];
                }
            }
            return null;
        }

        public bool add(DetaliiComenzi detaliicomanda)
        {
            
                detaliicomenzi.Add(detaliicomanda);
                Console.WriteLine("true");
                return true;
            
        }

        public bool delete(int id)
        {
            int poz = pozitie(id);

            if( poz == -1)
            {
                
                Console.WriteLine("false");
                return false;
            }
            else
            {
                detaliicomenzi.RemoveAt(poz);
                Console.WriteLine("true");
                return true;

            }
        }


        public bool updatePret(int id, int pretnou) 
        {
            int poz = pozitie(id);

            if( poz == -1)
            {
                return false;
            }
            else
            {

                detaliicomenzi[poz].setPret(pretnou);
                return true;
            }
        
        
        }

        public void load()
        {
            string line = "";

            StreamReader read = new StreamReader(@"C:\Users\catas\Desktop\FullStackC#\Incapsularea\magazin-online\magazin-online\resources\detaliicomenzi.txt");

            while ((line = read.ReadLine()) != null)
            {
                string[] prop = line.Split(",");

                int id = Int32.Parse(prop[0]);
                int idcomanda = Int32.Parse(prop[1]);
                int idprodus = Int32.Parse(prop[2]);
                int pret = Int32.Parse(prop[3]);
                int cantitate = Int32.Parse(prop[4]);

                DetaliiComenzi detaliicomanda = new DetaliiComenzi(id, idcomanda, idprodus, pret, cantitate);

                detaliicomenzi.Add(detaliicomanda);
            }

            read.Close();

        }


        public string toSave()
        {
            string text = "";
            int i = 0;
            for(i =0;i<detaliicomenzi.Count - 1; i++)
            {
                text += detaliicomenzi[i].toSave() + "\n";
            }

            text += detaliicomenzi[i].toSave();

            return text;
        }

        public void Save()
        {
            StreamWriter write = new StreamWriter(@"C:\Users\catas\Desktop\FullStackC#\Incapsularea\magazin-online\magazin-online\resources\detaliicomenzi.txt");

            write.Write(toSave());

            write.Close();
        }

        //orderId
        //=>toate orderDetails care are orderId

        public List<DetaliiComenzi> getDetaliicomenzi(int id)
        {
            List<DetaliiComenzi> detalii = new List<DetaliiComenzi>();



            for(int i = 0; i < detaliicomenzi.Count; i++)
            {
                if(detaliicomenzi[i].getId() == id)
                {


                    detalii.Add(detaliicomenzi[i]);

                   
                     
                }
            }


            return detalii;
        }

        public List<DetaliiComenzi> Updatecantitate(int orderid, int cantitatenoua)
        {
            List<DetaliiComenzi> detalii = new List<DetaliiComenzi>();
            for (int i = 0; i < detaliicomenzi.Count; i++)
            {
                if (detaliicomenzi[i].getIdcomanda() == orderid)
                {


                    detalii[i].setCantitate(cantitatenoua);



                }
            }


            return detalii;
        }

        public void istoriccomenzi(int orderid)
        {
            for(int i = 0; i < detaliicomenzi.Count; i++)
            {
                if(detaliicomenzi[i].getIdcomanda() == orderid)
                {
                    Console.WriteLine(detaliicomenzi[i].getIdcomanda());
                }
            }
        }
    }
}
