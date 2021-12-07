using System;
using System.Collections.Generic;
using System.Text;

namespace magazin_online
{
    public class Comenzi
    {
        private int id;
        private int idclient;
        private int ammount;
        private string adresalivrare;



        public Comenzi()
        {

        }

        public Comenzi(int id,int idclient, int ammount, string adresalivrare)
        {
            this.id = id;
            this.idclient = idclient;
            this.ammount = ammount;
            this.adresalivrare = adresalivrare;
        }

        public int getId()
        {
            return this.id;
        }

        public void setId(int id)
        {
            this.id = id;
        }


        public int getIdclient()
        {
            return this.idclient;
        }

        public void setIdclient(int idclient)
        {
            this.idclient = idclient ;
        }

      

        public int getAmmount()
        {
            return this.ammount;
        }

        public void setAmmount(int ammount)
        {
            this.ammount = ammount;
        }

        public string getAdresalivrare()
        {
            return this.adresalivrare;
        }

        public void setAdresalivrare(string adresalivrare)
        {
            this.adresalivrare = adresalivrare;
        }

        public string descriere()
        {
            string text = "";
            text += "Id-ul comenzii" + id + "\n";
            text += "Id-ul clientului : " + idclient + "\n";
            text += "Cantitatea : " + ammount + "\n";
            text += "Adresa de livrare a comenzii : " + adresalivrare + "\n";


            return text;
        }

        public string toSave()
        {
            return this.id + "," + this.idclient + "," + this.ammount + "," + this.adresalivrare;
        }
    }
}
