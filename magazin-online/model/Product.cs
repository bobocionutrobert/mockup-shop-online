using System;
using System.Collections.Generic;
using System.Text;

namespace magazin_online
{
    public class Product
    {


        private int productid;
        private string producttype;
        private string productname;
        private double price;
        private int productstock;

        
       

        public Product(string proprietati)
        {
            string[] prop = proprietati.Split();

            this.productid = Int32.Parse(prop[0]);
            this.producttype = prop[1];
            this.productname = prop[2];
            this.price = Int32.Parse(prop[3]);
            this.productstock = Int32.Parse(prop[4]);

        }
        public Product(int productid,string producttype,string productname,double price,int productstock)
        {
            this.productid = productid;
            this.producttype = producttype;
            this.productname = productname;
            this.price = price;
            this.productstock = productstock;
        }

       

        public int getProductId()
        {
            return this.productid;
        }
        
        public void setProductId(int productid)
        {
            this.productid = productid;
        }

        private string getProductType()
        {
            return this.producttype;
        }

        private void setProductType(string producttype)
        {
            this.producttype = producttype;
        }

        public string getProductName()
        {
            return this.productname;
        }

        public void setProductName(string productname)
        {
            this.productname = productname;
        }

        public double getProductPrice()
        {
            return this.price;
        }

        public void setProductPrice(double price)
        {
            this.price = price;
        }

        public int getProductStock()
        {
            return this.productstock;
        }

        public void setProductStock(int productstock)
        {
            this.productstock = productstock;
        }


        public virtual string productDetails()
        {
            string text = "";

            text += "Product Name : " + productname + "\n";
            text += "Product Type : " + producttype + "\n";
            text += "Product price : " + price + "\n";
            text += "Available stock : " + productstock + "\n";

            return text;
        }

        public virtual string toSave()
        {
            return this.productid + "," + this.producttype+","+this.productname + "," + this.price + "," + this.productstock + ",";
        }
    }
}
