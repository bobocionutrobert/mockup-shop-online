using System;
using System.Collections.Generic;
using System.Text;

namespace magazin_online
{
    public class OrderDetails
    {
        private int id;
        private int orderid;
        private int productid;
        private int price;
        private int quantity;

        public OrderDetails(string proprietati)
        {
            string[] prop = proprietati.Split(",");

            this.id = Int32.Parse(prop[0]);
            this.orderid = Int32.Parse(prop[1]);
            this.productid = Int32.Parse(prop[2]);
            this.price = Int32.Parse(prop[3]);
            this.quantity = Int32.Parse(prop[4]);
        }

        public OrderDetails(int id, int orderid,int productid,int price,int quantity)
        {
            this.id = id;
            this.orderid = orderid;
            this.productid = productid;
            this.price = price;
            this.quantity = quantity;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Orderid
        {
            get { return orderid; }
            set { orderid = value; }
        }

        public int Productid
        {
            get { return productid; }
            set { productid = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }


        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }


        public string orderDetails()
        {
            string text = "";

            text += "Id : " + id + "\n";
            text += "Order id : " + orderid + "\n";
            text += "Product id : " + productid + "\n";
            text += "Product price : " + price + "\n";
            text += "Quantity : " + quantity + "\n";

            return text;
        }

        public string toSave()
        {
            return this.id + "," + this.orderid + "," + this.productid + "," + this.price + "," + this.quantity;
        }
    }
}
