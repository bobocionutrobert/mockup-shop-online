using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using magazin_online.model;


namespace magazin_online
{
    public class ControllerProduct
    {

        private List<Product> products;

        public ControllerProduct()
        {
            products = new List<Product>();

            load();

        }

        public void productsDisplay()
        {
            for(int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i].productDetails());
            }
        }

        public int positionById(int productid)
        {
            for(int i = 0; i < products.Count; i++)
            {
                if(products[i].getProductId() == productid)
                {
                    return i;
                }

            }
            return -1;
        }

        public int positionByName(string productname)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].getProductName().Equals(productname))
                {
                    return i;
                }

            }
            return -1;
        }


        public int nextId()
        {
            if(products.Count == 0)
            {
                return 1;
            }
            else
            {
                return products[products.Count - 1].getProductId() + 1;
            }
        }


        public Product returnProductById(int productid)
        {
            foreach(Product product in products)
            {
                if(product.getProductId() == productid)
                {
                    return product;
                }
            }

            return null;
        }

        public Product returnProductByName(string productname)
        {
            foreach(Product product in products)
            {
                if (product.getProductName().Equals(productname))
                {
                    return product;
                }
            }
            return null;
        }

        public int[] stockAtRisk()
        {

            int[] list = new int[100];

            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].getProductStock() <= 5)
                {
                    list[products[i].getProductId()] += products[i].getProductStock();
                }
            }

            return list;
        }

        public bool addProduct(Product product)
        {
            int poz = positionById(product.getProductId());

            if (poz != -1)
            {
                Console.WriteLine("Product already in list ");
                return false;
            }
            else
            {
                products.Add(product);
                Console.WriteLine("Product added ");
                return true;
            }
        }

        public bool deleteProductById(int productid)
        {
            int poz = positionById(productid);

            if (poz == -1)
            {
                Console.WriteLine("The Product isn't in the list");
                return false;
            }
            else
            {
                products.RemoveAt(poz);
                Console.WriteLine("Product deleted");
                return true;
            }
        }

        public bool deleteProductByName(string productname)
        {
            int poz = positionByName(productname);

            if(poz == -1)
            {
                Console.WriteLine("Product already in list");
                return false;
            }
            else
            {
                products.RemoveAt(poz);
                Console.WriteLine("Product deleted");
                return true;
            }
        }

        public void updateProductName(int productid, string newproductname)
        {
            foreach(Product product in products)
            {
                if(product.getProductId() == productid)
                {
                    product.setProductName(newproductname);
                }
            }
        }

        public void updateProductPrice(int productid,int newproductprice)
        {
            foreach(Product product in products)
            {
                if (product.getProductId() == productid)
                {
                    product.setProductPrice(newproductprice);
                }
            }
        }

        public void updateProductStock(int productid,int newproductstock)
        {
            foreach(Product product in products)
            {
                if(product.getProductId() == productid)
                {
                    product.setProductStock(newproductstock);
                }
            }
        }

        public void updateClothSize(int productid,string newclothsize)
        {
            foreach(Product product in products)
            {
                if(product.getProductId() == productid)
                {
                    Cloth cloth = product as Cloth;

                    cloth.setClothColor(newclothsize);


                }
            }
        }

        public void updateClothColor(int productid,string newclothcolor)
        {
            foreach(Product product in products)
            {
                if(product.getProductId() == productid)
                {
                    Cloth cloth = product as Cloth;

                    cloth.setClothColor(newclothcolor);
                }
            }
        }

        public void updateKidsCloth(int productid, bool newkidcloth)
        {
            foreach(Product product in products)
            {
                if(product.getProductId() == productid)
                {
                    Cloth cloth = product as Cloth;

                    cloth.setKidCloth(newkidcloth);
                }
            }
        }

        public void updateShoeSize(int productid, int newshoesize)
        {
            foreach(Product product in products)
            {
                if(productid == product.getProductId())
                {
                    Shoe shoe = product as Shoe;

                    shoe.setShoeSize(newshoesize);
                }
            }
        }

        public void updateShoeColor(int productid, string newshoecolor)
        {
            foreach(Product product in products)
            {
                if(product.getProductId() == productid)
                {
                    Shoe shoe = product as Shoe;

                    shoe.setShoeColor(newshoecolor);
                }
            }
        }
        
        
        

        public void load()
        {

            StreamReader read = new StreamReader(@"C:\Users\Asus\source\repos\mockup-shop-online\magazin-online\resources\products.txt");

            this.products.Clear();

            string line = "";

            while ((line = read.ReadLine()) != null)
            {
                string[] prop = line.Split(",");

                if (prop[1].Equals("Cloth"))
                {
                    this.products.Add(new Cloth(line));
                }
                else
                {
                    this.products.Add(new Shoe(line));
                }
              

            }
            read.Close();


        }

        public string toSave()
        {
            string text = "";

            int i = 0;

            for (i = 0; i < products.Count-1; i++)
            {
                text += products[i].toSave() + "\n";
            }

            text += products[i].toSave();

            return text;
        }

        public void Save()
        {
            StreamWriter write = new StreamWriter(@"C:\Users\Asus\source\repos\mockup-shop-online\magazin-online\resources\products.txt");

            write.Write(toSave());

            write.Close();

            


        }
    }
}

