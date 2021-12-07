using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace magazin_online
{
    public class ControllerOrderDetails
    {

        private List<OrderDetails> orderdetails;
        
        

        public ControllerOrderDetails()
        {
            orderdetails = new List<OrderDetails>();
          

            load();
        }

        public string displayOrderDetails()
        {
            string text = "";
            for(int i = 0; i < orderdetails.Count; i++)
            {
                text += orderdetails[i].orderDetails() + "\n";
            }

            return text;
        }

        public int positionById(int id)
        {
            for(int i = 0; i < orderdetails.Count; i++)
            {
                if(orderdetails[i].Id == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public int nextid()
        {
            if (orderdetails.Count == 0)
            {
                return 1;
            }
            else
            {


                return orderdetails[orderdetails.Count - 1].Id + 1;
            }
        }

        public OrderDetails returnOrderDetails(int id)
        {
            for(int i = 0; i < orderdetails.Count;i++)
            {
                if(orderdetails[i].Id == id)
                {
                    return orderdetails[i];
                }
            }
            return null;
        }

        public bool addOrderDetails(OrderDetails orderdetail)
        {
            
                orderdetails.Add(orderdetail);
                Console.WriteLine("true");
                return true;
            
        }

        public bool deleteOrderDetails(int id)
        {
            int poz = positionById(id);

            if( poz == -1)
            {
                
                Console.WriteLine("false");
                return false;
            }
            else
            {
                orderdetails.RemoveAt(poz);
                Console.WriteLine("true");
                return true;

            }
        }


        public void updatePrice(int id, int newprice) 
        {
            foreach(OrderDetails orderdetail in orderdetails)
            {
                if(orderdetail.Id == id)
                {
                    orderdetail.Price = newprice;
                }
            }
        
        
        }

        public void updateQuantity(int id, int newquantity)
        {
            foreach(OrderDetails orderdetail in orderdetails)
            {
                if( orderdetail.Id == id)
                {
                    orderdetail.Quantity = newquantity;
                }
            }
        }

        public void load()
        {
            string line = "";

            StreamReader read = new StreamReader(@"C:\Users\Asus\source\repos\mockup-shop-online\magazin-online\resources\orderdetails.txt");

            while ((line = read.ReadLine()) != null)
            {
                string[] prop = line.Split(",");

                int id = Int32.Parse(prop[0]);
                int orderid = Int32.Parse(prop[1]);
                int productid = Int32.Parse(prop[2]);
                int price = Int32.Parse(prop[3]);
                int quantity = Int32.Parse(prop[4]);

                OrderDetails orderdetail = new OrderDetails(id, orderid,productid,price,quantity);

                orderdetails.Add(orderdetail); 
            }

            read.Close();

        }


        public string toSave()
        {
            string text = "";
            int i = 0;
            for(i =0;i<orderdetails.Count - 1; i++)
            {
                text += orderdetails[i].toSave() + "\n";
            }

            text += orderdetails[i].toSave();

            return text;
        }

        public void Save()
        {
            StreamWriter write = new StreamWriter(@"C:\Users\Asus\source\repos\mockup-shop-online\magazin-online\resources\orderdetails.txt");

            write.Write(toSave());

            write.Close();
        }

        //orderId
        //=>toate orderDetails care are orderId

        public List<OrderDetails> getOrderDetails(int id)
        {
            List<OrderDetails> details = new List<OrderDetails>();



            for(int i = 0; i < orderdetails.Count; i++)
            {
                if(orderdetails[i].Id == id)
                {


                    details.Add(orderdetails[i]);

                   
                     
                }
            }


            return details;
        }

        

        public List<OrderDetails> UpdatecQuanitity(int orderid, int newquanitity)
        {
            List<OrderDetails> details = new List<OrderDetails>();
            for (int i = 0; i < orderdetails.Count; i++)
            {
                if (orderdetails[i].Orderid == orderid)
                {


                    details[i].Quantity= newquanitity;



                }
            }


            return details;
        }

        public void ordersHistory(int orderid)
        {
            for (int i = 0; i < orderdetails.Count; i++)
            {
                if (orderdetails[i].Orderid == orderid)
                { 
                    Console.WriteLine(orderdetails[i].Orderid);
                }
            }
        }

        public int[] bestsellingproduct()
        {

            int[] list = new int[100];

            for(int i = 0; i < orderdetails.Count; i++)
            {

                list[orderdetails[i].Productid] += orderdetails[i].Quantity;
            }

            return list;
        }

       
    }
}
