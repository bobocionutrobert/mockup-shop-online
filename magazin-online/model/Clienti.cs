using System;
using System.Collections.Generic;
using System.Text;

namespace magazin_online
{
    public class Clienti
    {
        private int id;
        private string email;
        private string parola;
        private string nume;
        private string adresa;
        private string tara;
        private int nrtelefon;

        public Clienti()
        {

        }

        public Clienti(int id, string email, string parola, string nume, string adresa, string tara, int nrtelefon)
        {
            this.id = id;
            this.email = email;
            this.parola = parola;
            this.nume = nume;
            this.adresa = adresa;
            this.tara = tara;
            this.nrtelefon = nrtelefon;
        }

        public int getId()
        {
            return this.id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public string getEmail()
        {
            return this.email;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public string getParola()
        {
            return this.parola;
        }

        public void setParola(string parola)
        {
            this.parola = parola;
        }

        public string getNume()
        {
            return this.nume;
        }

        public void setNume(string nume)
        {
            this.nume = nume;
        }

        public string getAdresa()
        {
            return this.adresa;
        }

        public void setAdersa(string adresa)
        {
            this.adresa = adresa;
        }

        public string getTara()
        {
            return this.tara;
        }

        public void setTara(string tara)
        {
            this.tara = tara;
        }

        public int getNrtelefon()
        {
            return this.nrtelefon;
        }

        public void setNrtelefon(int nrtelefon)
        {
            this.nrtelefon = nrtelefon;
        }

        public string descriere()
        {
            string text = "";

            text += "Id-ul clientului : " + id + "\n";
            text += "Emailul clientului : " + email + "\n";
            text += "Parola clientului : " + parola + "\n";
            text += "Numele clientului : " + nume + "\n";
            text += "Adresa clientului : " + adresa + "\n";
            text += "Tara : " + tara + "\n";
            text += "Numarul de telefon al clientului : " + nrtelefon + "\n";

            return text;
        }

        public string toSave()
        {
            return this.id + "," + this.nume + "," + this.parola + "," + this.email + "," + this.adresa + "," + this.tara + "," + this.nrtelefon;
        }
    }
}

