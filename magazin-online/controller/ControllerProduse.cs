using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace magazin_online
{
    public class ControllerProduse
    {

        private List<Product> products;

        public ControllerProduse()
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

        
        public void 
        
        

        public void load()
        {

            StreamReader read = new StreamReader(@"C:\Users\catas\Desktop\FullStackC#\Incapsularea\magazin-online\magazin-online\resources\produse.txt");

            string line = "";

            while ((line = read.ReadLine()) != null)
            {
                string[] prop = line.Split(",");

                int id = Int32.Parse(prop[0]);
                string nume = prop[1];
                double pret = double.Parse(prop[2]);
                int cantitate = Int32.Parse(prop[3]);

                Product produs = new Product(id, nume, pret, cantitate);

                produse.Add(produs);




            }
            read.Close();


        }

        public string toSave()
        {
            string text = "";

            int i = 0;

            for (i = 0; i < produse.Count-1; i++)
            {
                text += produse[i].toSave() + "\n";
            }

            text += produse[i].toSave();

            return text;
        }

        public void Save()
        {
            StreamWriter write = new StreamWriter(@"C:\Users\catas\Desktop\FullStackC#\Incapsularea\magazin-online\magazin-online\resources\produse.txt");

            write.Write(toSave());

            write.Close();




        }
    }
}

