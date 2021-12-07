using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace magazin_online
{
    //-->view produsele
    //-->add cos
    //-->edit cos
    //-->remove cos
    //trimite comamnda
    class ViewClient
    {

        private Person person;
        private ControllerProduct controlproduct;
        private ControllerOrders controlorder;
        private ControllerOrderDetails controlorderdetails;
        private ControllerPerson controlperson;

        private Order order;
        

        public ViewClient(Person person)
        {

            this.person = person;
            controlproduct = new ControllerProduct();
            controlorder = new ControllerOrders();
            controlorderdetails = new ControllerOrderDetails();
            controlperson = new ControllerPerson();

            order = new Order(controlorder.nextid(),"", person.Id, 0,"");


        

        }

        public void menu()
        {
            Console.WriteLine("===================Menu Client================");
            Console.WriteLine($"Bun venit, {person.Name}");
            Console.WriteLine("Press 1 to see the list of products");
            Console.WriteLine("Press 2 to add products to cart");
            Console.WriteLine("Press 3 to see the producst in cart ");
            Console.WriteLine("Press 4 to delete a product from the cart");
            Console.WriteLine("Press 5 to edit products from cart");
            Console.WriteLine("Press 6 to finish the order");
            Console.WriteLine("Press 7 to see the orders history");
            Console.WriteLine("Press 8 to see the last placed order");
            Console.WriteLine("Press 9 to see orders order");
            //Console.WriteLine("Apasati tasta 0 pentru a edita profilul dumneaovastra");
           



        }
                
        public void play()
        {
            
            bool running = true;
            while (running == true) {

                menu();
                int alegere = Int32.Parse(Console.ReadLine());

                switch (alegere)
                {
                    case 1:
                        controlproduct.productsDisplay();
                        break;
                    case 2:
                        addCart();
                        break;
                    case 3:
                        displayCart();
                        break;

                    case 4:
                        deleteProductFromCart();
                        break;
                    case 5:
                        editCart();
                        break;
                    case 6:
                        finishOrder();
                        break;
                    case 7:
                        ordersHistory();
                        break;
                    case 8:
                        lastOrder();
                        break;
                    case 9:
                        ordersOrder();
                        break;
                    case 0:
                        
                        break;
                         
                }


            }

        }

        //public void meniuUpdateprofil()
        //{
        //    Console.WriteLine("===================Meniu Update Client================");
        //    Console.WriteLine($"Bun venit, {person.Name}");
        //    Console.WriteLine("Apasati tasta 1 pentru a edita numele");
        //    Console.WriteLine("Apasati tasta 2 pentru a edita email-ul");
        //    Console.WriteLine("Apasati tasta 3 pentru a edita parola");
        //    Console.WriteLine("Apasati tasta 4 pentru a edita adresa");
        //    Console.WriteLine("Apasati tasta 5 pentru a edita tara");
        //    Console.WriteLine("Apasati tasta 6 pentru a edita numarul de telefon");
        //}


        
        public void addCart()
        {

            Console.WriteLine("Insert product name you wish to add to cart");

            string desiredproduct = Console.ReadLine();

            

            


            Product product = controlproduct.returnProductByName(desiredproduct);



            if( product != null)
            {

                Console.WriteLine("Insert quanitity of product : ");

                int desiredquantity = Int32.Parse(Console.ReadLine());

                //exista cantiatatea dorita

                if( product.getProductStock() >= desiredquantity)
                {
                    //adauga in cos

                    OrderDetails neworder = new OrderDetails(controlorderdetails.nextid(), order.Id, product.getProductId(), desiredquantity * (int)product.getProductPrice(), desiredquantity);



                    controlorderdetails.addOrderDetails(neworder);

                    //update  produse


                    controlproduct.updateProductStock(controlproduct.returnProductByName(desiredproduct).getProductId(), product.getProductStock() - desiredquantity);


                    Console.WriteLine("Product added to cart ");

                    

                }
                 
            }
            else
            {

            }


    }

        public void displayCart()
        {

            List<OrderDetails> orderdetails = controlorderdetails.getOrderDetails(order.Id);

            for (int i = 0; i < orderdetails.Count; i++)
            {
                string text = "Product ID : " + orderdetails[i].Productid + "\n";

                text += "Product name : " + controlproduct.returnProductById(orderdetails[i].Productid).getProductName() + "\n";

                text += "Quantity :  " + orderdetails[i].Quantity + "\n";

                text += "Price : " + orderdetails[i].Price + "\n";

                Console.WriteLine(text);
            }
                

        }

        public void deleteProductFromCart()
        {
            Console.WriteLine("Insert name of the product you want to remove from cart");

            string productname = Console.ReadLine();

            Product product = controlproduct.returnProductByName(productname);

            List<OrderDetails> orderdetails = controlorderdetails.getOrderDetails(order.Id);

            for(int i = 0; i < orderdetails.Count; i++)
            {
                if (controlproduct.returnProductById(orderdetails[i].Productid).getProductName().Equals(productname))
                {
                    controlorderdetails.deleteOrderDetails(orderdetails[i].Id);
                   
                }
                else
                {
                    Console.WriteLine("Produsul not in cart");
                }
            }
            
           
        }

        public void editCart()
        {
            Console.WriteLine("Insert product name of which quanitity you wish to modify ");

            string modifyproductquanitity = Console.ReadLine();

            Product product = controlproduct.returnProductByName(modifyproductquanitity);



            List<OrderDetails> orderdetails = controlorderdetails.getOrderDetails(order.Id);

            for(int i = 0; i < orderdetails.Count; i++)
            {
                if (controlproduct.returnProductById(orderdetails[i].Productid).getProductName().Equals(modifyproductquanitity))


                {
                    Console.WriteLine($"There are {orderdetails[i].Quantity} products of this type in the cart");

                    Console.WriteLine("Insert new quanitity : ");

                    int newquanitity = Int32.Parse(Console.ReadLine());

                    if (newquanitity > 0)
                    {
                        int oldquanitity = orderdetails[i].Quantity;

                   


                        controlproduct.updateProductStockByName(modifyproductquanitity, (product.getProductStock()+oldquanitity)- newquanitity);


                        orderdetails[i].Quantity = newquanitity;


                        orderdetails[i].Price = newquanitity * (int)product.getProductPrice();



                       
                        Console.WriteLine("Cart edited");
                    }
                    else if (newquanitity == 0)
                    {
                        controlorderdetails.deleteOrderDetails(orderdetails[i].Id);
                        Console.WriteLine("Product removed from cart");
                    }
                    else
                    {
                        Console.WriteLine("Product is not in the cart");
                    }
                }
            }
        }

        public void finishOrder()
        {
            Console.WriteLine("Are you sure you want to finish the order? yes/no");

            string sure = Console.ReadLine();

            if (sure == "yes")
            {
                Console.WriteLine("This is your order : ");
                displayCart();

                Console.WriteLine("You wish to place this order? yes/no");

                string yesorno = Console.ReadLine();

                if (yesorno == "yes")
                {
                    controlorderdetails.toSave();
                    Console.WriteLine($"The order will be delivered at  {order.Deliveryaddress}");
                    controlorderdetails.deleteOrderDetails(order.Id);
                }
                else
                {
                    Console.WriteLine("Redirected to main menu");
                    menu();
                }

            }
            else if( sure == "nu")
            {
                Console.WriteLine("Redirected to main menu");
                menu();
            }
            else
            {

                Console.WriteLine("Redirected to main menu");
                menu();
            }

        }

        public void ordersHistory()
        {
            List<OrderDetails> orderhistory = controlorderdetails.getOrderDetails(order.ClientId);

            
            for(int i = 0; i < orderhistory.Count; i++)
            {
                
                Console.WriteLine(orderhistory[i].orderDetails());
            }
        }

        public void lastOrder()
        {

            List<OrderDetails> ordershistory = controlorderdetails.getOrderDetails(order.ClientId);

           

             Console.WriteLine(ordershistory[ordershistory.Count-1].orderDetails());
            

        }

        public void ordersOrder()
        {

            List<OrderDetails> ordershistory = controlorderdetails.getOrderDetails(order.ClientId); 


            for(int i = 0; i < ordershistory.Count-1; i++)
            {
                for(int j = i+1; j < ordershistory.Count; j++)
                {
                    if(ordershistory[i].Price > ordershistory[j].Price)
                    {
                        OrderDetails aux = ordershistory[i];
                        ordershistory[i] = ordershistory[j];
                        ordershistory[j] = aux;
                    }

                }

            }



            foreach(OrderDetails orderdetails in ordershistory)
            {
                Console.WriteLine(orderdetails.orderDetails());
            }
          

        }

        //public void editProfile()
        //{
        //    meniuUpdateprofil();

        //    Console.WriteLine("Alegeti ce doriti sa modificati din profil ");

        //    int alegere = Int32.Parse(Console.ReadLine());

        //    switch (alegere)
        //    {
        //        case 1:
        //            Console.WriteLine("Introduceti un numele nou : ");
        //            string numenou = Console.ReadLine();
        //            controlclienti.updateNume(clienti.getId(),numenou);
        //            controlclienti.Save();
        //            break;
        //        case 2:
        //            Console.WriteLine("Introduceti emailul nou : ");
        //            string emailnou = Console.ReadLine();
        //            controlclienti.updateEmail(clienti.getId(),emailnou);
        //            controlclienti.Save();
        //            break;

        //        case 3:
        //            Console.WriteLine("Introduceti parola noua : ");
        //            string parolanoua = Console.ReadLine();
        //            controlclienti.updateParola(clienti.getId(),parolanoua);
        //            controlclienti.Save();
        //            break;
        //        case 4:
        //            Console.WriteLine("Introduceti o adresa noua : ");
        //            string adresanoua = Console.ReadLine();
        //            controlclienti.updateAdresa(clienti.getId(),adresanoua);
        //            controlclienti.Save();
        //            break;
        //        case 5:
        //            Console.WriteLine(" Introduceti numele tarii : ");
        //            string taranoua = Console.ReadLine();
        //            controlclienti.updateTara(clienti.getId(),taranoua);
        //            controlclienti.Save();
        //            break;
        //        case 6:
        //            Console.WriteLine("introduceti numarul de telefon:");
        //            int telefonnou = Int32.Parse(Console.ReadLine());
        //            controlclienti.updateNrTelefon(clienti.getId(),telefonnou);
        //            controlclienti.Save();
        //            break;
        //    }
        //}


    }
   
}
