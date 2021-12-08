using System;
using System.Collections.Generic;
using System.Text;

namespace magazin_online.model
{
    public class Shoe : Product
    {
        
        private int size;
        private string color;

        public Shoe(int size, string color,int productid,string producttype,string productname,int price, int productstock): base(productid, "Shoe", productname, price, productstock)
        {

            this.size = size;
            this.color = color;
        }

        public Shoe(string proprietati):base(
            
            
            Int32.Parse(proprietati.Split(",")[0]),
            proprietati.Split(",")[1],
            proprietati.Split(",")[2],
            Int32.Parse(proprietati.Split(",")[3]),
            Int32.Parse(proprietati.Split(",")[4])
            
            )
        {

            string[] prop = proprietati.Split(",");

            this.size = Int32.Parse(prop[5]);
            this.color = prop[6];

        }

        public int getShoeSize()
        {
            return this.size;
        }

        public void setShoeSize(int size)
        {
            this.size = size;
        }

        public string getShoeColor()
        {
            return this.color;
        }

        public void setShoeColor(string color)
        {
            this.color = color;
        }

        public override string productDetails()
        {
            string text = base.productDetails();

            text += "Shoe size is : " + size + "\n";
            text += "Shoe color : " + color + "\n";

            return text;
        }

        public override string toSave()
        {
            return base.toSave() + "," + this.size + "," + this.color;
        }
    }
}
