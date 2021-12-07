using System;
using System.Collections.Generic;
using System.Text;

namespace magazin_online
{
    public class Order
    {
        private int id;
        private string type;
        private int idclient;
        private int ammount;
        private string deliveryaddress;



        public Order(string proprietati)
        {
            string[] prop = proprietati.Split(",");

            this.id=Int32.Parse(prop[0]);
            this.type=prop[1];
            this.idclient=Int32.Parse(prop[2]);
            this.ammount=Int32.Parse(prop[3]);
            this.deliveryaddress=prop[4];
        }

        public Order(int id,string type,int idclient, int ammount, string deliveryaddress)
        {
            this.id = id;
            this.type = type;
            this.idclient = idclient;
            this.ammount = ammount;
            this.deliveryaddress = deliveryaddress;
        }

        public int Id {
            
            get { return id; } 
            set { id = value; } 
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public int ClientId
        {
            get { return idclient; }
            set { idclient = value; }
        }

        public int Ammount
        {
            get { return ammount; }
            set { ammount = value; }

        }

        public string Deliveryaddress
        {
            get { return deliveryaddress; }
            set { deliveryaddress = value; }
        }


        public string orderDetails()
        {
            string text = "";
            text += "Order id : " + id + "\n";
            text += "Order type : " +type + "\n";
            text += "Client id : " + idclient + "\n";
            text += "Ammount : " + ammount + "\n";
            text += "Delivery address : " + deliveryaddress + "\n";


            return text;
        }

        public string toSave()
        {
            return this.id + "," +this.type+","+ this.idclient + "," + this.ammount + "," + this.deliveryaddress;
        }
    }
}
