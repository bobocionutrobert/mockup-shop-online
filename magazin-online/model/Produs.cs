using System;
using System.Collections.Generic;
using System.Text;

namespace magazin_online
{
    public class Produs
    {

        private int id;
        private string numeprodus;
        private double pret;
        private int stoc;
        


        public Produs()
        {


        }
        public Produs(int id, string numeprodus, double pret, int stoc)
        {
            this.id = id;
            this.numeprodus = numeprodus;
            this.pret = pret;
            this.stoc = stoc;
        }

        public int getId()
        {
            return this.id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public string getNume()
        {
            return this.numeprodus;
        }

        public void setNume(string numeprodus)
        {
            this.numeprodus = numeprodus;
        }

        public double getPret()
        {
            return this.pret;
        }

        public void setPret(double pret)
        {
            this.pret = pret;
        }

        public int getStoc()
        {
            return this.stoc;
        }

        public void setStoc(int stoc)
        {
            this.stoc = stoc;
        }


        public string descriere()
        {
            string text = "";

            text += "Numele produsului : " + numeprodus + "\n";
            text += "Pretul produsului : " + pret + "\n";
            text += "Cantitatea disponibila in stoc : " + stoc + "\n";

            return text;
        }

        public string toSave()
        {
            return this.id + "," + this.numeprodus + "," + this.pret + "," + this.stoc;
        }
    }
}
