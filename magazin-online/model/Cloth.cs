using System;
using System.Collections.Generic;
using System.Text;

namespace magazin_online.model
{
    public class Cloth : Product
    {
        private string size;
        private string color;
        private bool kidssize;

        public Cloth(string size, string color,bool kidssize, int productid, string producttype, string productname, int price, int productstock) : base(productid, "Cloth", productname, price, productstock)
        {

            this.size = size;
            this.color = color;
            this.kidssize = kidssize;
        }

        public Cloth(string proprietati) : base(


            Int32.Parse(proprietati.Split(",")[0]),
            proprietati.Split(",")[1],
            proprietati.Split(",")[2],
            Int32.Parse(proprietati.Split(",")[3]),
            Int32.Parse(proprietati.Split(",")[4])

            )
        {

            string[] prop = proprietati.Split(",");

            this.size = prop[5];
            this.color = prop[6];
            this.kidssize = bool.Parse(prop[7]);

        }

        public string setClothSize()
        {
            return this.size;
        }

        public void setClothSize(string size)
        {
            this.size = size;
        }

        public string getClothColor()
        {
            return this.color;
        }

        public void setClothColor(string color)
        {
            this.color = color;
        }

        public bool setKidCloth()
        {
            return this.kidssize;
        }

        public void setKidCloth(bool kidssize)
        {
            this.kidssize = kidssize;
        }

        public override string productDetails()
        {
            string text = base.productDetails();

            text += "Cloth size is : " + size + "\n";
            text += "Cloth color : " + color + "\n";
            text += "Kids size ? " + kidssize + "\n";

            return text;
        }

        public override string toSave()
        {
            return base.toSave() + "," + this.size + "," + this.color + ","+ this.kidssize;
        }

    }
}
