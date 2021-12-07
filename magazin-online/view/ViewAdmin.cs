using System;
using System.Collections.Generic;
using System.Text;

namespace magazin_online
{
    class ViewAdmin
    {
        private Person person;
        private ControllerProduct controlproduct;
        private ControllerOrders controlorder;
        private ControllerOrderDetails controlorderdetails;
        private ControllerPerson controlperson;

        public ViewAdmin(Person person)
        {
            this.person = person;
            controlproduct = new ControllerProduct();
            controlorder = new ControllerOrders();
            controlorderdetails = new ControllerOrderDetails();
            controlperson = new ControllerPerson();
        }               

        public void menu()
        {
            Console.WriteLine("===================Menu Admin================");
            Console.WriteLine($"Bun venit, {person.Name}");
            Console.WriteLine("Press 1 to add new product ");
            Console.WriteLine("Press 2 to delete a product");
            Console.WriteLine("Press 3 to change stock of a product");
            Console.WriteLine("Press 4 to change password");
            Console.WriteLine("Press 5 to delete a client");
            Console.WriteLine("Press 6 to display best selling products");
            Console.WriteLine("Press 7 to display stock at risk");

            

        }

        public void play()
        {
            bool running = true;

            while(running == true)
            {
                menu();

                int alegere = Int32.Parse(Console.ReadLine());

                switch (alegere) 
                {

                    case 1:
                        addProduct();

                        break;
                    case 2:
                        deleteProduct();
                        break;
                    case 3:
                        changeStock();
                        break;
                    case 4:
                        changePassword();
                        break;
                    case 5:
                        deleteClient();
                        break;
                    case 6:
                        displayBestSellingProduct();
                        break;
                    case 7:
                        displayStockAtRisk();
                        break;


                
                }


            }
        }


        public void addProduct()
        {


            Random rnd = new Random();
            int id = rnd.Next();

            Console.WriteLine("Insert new product name : ");

            string productname = Console.ReadLine();

            Console.WriteLine("Insert product type (Cloth/Shoe)");
            string productype = Console.ReadLine();

            Console.WriteLine("Insert product price : ");

            int productprice = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Insert product available stock : ");

            int productstock = Int32.Parse(Console.ReadLine());

            Product product = new Product(id,productype,productname,productprice,productstock);

            controlproduct.addProduct(product);

            controlproduct.Save();


        }

        public void deleteProduct()
        {
            Console.WriteLine("Insert the name of the product you wish to delete from list");

            string productname = Console.ReadLine();

            controlproduct.deleteProductByName(productname);

            controlproduct.Save();
            
        }


        public void changeStock()
        {
            Console.WriteLine("Insert the name of the product whose stock you wish to change");

            string productname = Console.ReadLine();

            Console.WriteLine("Insert new stock quanitity");

            int newstock = Int32.Parse(Console.ReadLine());

            controlproduct.updateProductStockByName(productname,newstock);

            controlproduct.Save();
        }

        public void changePassword()
        {
            Console.WriteLine("Insert the new password : ");

            string newpassword = Console.ReadLine();

            controlperson.updateAdminPassword(person.Id, newpassword);

            Console.WriteLine("Password changed");

            controlperson.Save();
        }

       public void deleteClient()
       {
            Console.WriteLine("Insert name of the client you want to delete");

            string clientname = Console.ReadLine();

            controlperson.deletePersonByName(clientname);

            controlperson.Save();
       }
        
       public void displayBestSellingProduct()
       {

            int[] list = controlorderdetails.bestsellingproduct();



           for(int i =0;i < list.Length; i++)
            {

                if (list[i] != 0)
                {
                    Product p = controlproduct.returnProductById(i);

                    Console.WriteLine($"Product {p.getProductName()} was sold {list[i]} times");
                }
            }


       }
        
        public void displayStockAtRisk()
        {

            int[] list = controlproduct.stockAtRisk();

            for(int i = 0; i < list.Length; i++)
            {
                if(list[i] != 0)
                {
                    Product p = controlproduct.returnProductById(i);

                    Console.WriteLine($"Product {p.getProductName()} is available {list[i]} times");
                }
            }

        }

    }
}
