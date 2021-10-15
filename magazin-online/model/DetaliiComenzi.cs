using System;
using System.Collections.Generic;
using System.Text;

namespace magazin_online
{
    public class DetaliiComenzi
    {
        private int id;
        private int idcomanda;
        private int idprodus;
        private int pret;
        private int cantitate;

        public DetaliiComenzi()
        {

        }

        public DetaliiComenzi(int id, int idcomanda, int idprodus, int pret, int cantitate)
        {
            this.id = id;
            this.idcomanda = idcomanda;
            this.idprodus = idprodus;
            this.pret = pret;
            this.cantitate = cantitate;
        }

        public int getId()
        {
            return this.id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getIdcomanda()
        {
            return this.idcomanda;
        }

        public void setIdcomanda(int idcomanda)
        {
            this.idcomanda = idcomanda;
        }

        public int getIdprodus()
        {
            return this.idprodus;
        }

        public void setIdprodus(int idprodus)
        {
            this.idprodus = idprodus;
        }

        public int getPret()
        {
            return this.pret;
        }

        public void setPret(int pret)
        {
            this.pret = pret;
        }

        public int getCantitate()
        {
            return this.cantitate;
        }

        public void setCantitate(int cantitate)
        {
            this.cantitate = cantitate;
        }

        public string descriere()
        {
            string text = "";

            text += "Id" + id + "\n";
            text += "Id-ul comenzii : " + idcomanda + "\n";
            text += "Id-ul produsului : " + idprodus + "\n";
            text += "Pretul produsului : " + pret + "\n";
            text += "Cantitate : " + cantitate + "\n";

            return text;
        }

        public string toSave()
        {
            return this.id + "," + this.idcomanda + "," + this.idprodus + "," + this.pret + "," + this.cantitate;
        }
    }
}
