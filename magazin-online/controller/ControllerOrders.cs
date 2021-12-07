using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace magazin_online
{
    public class ControllerOrders
    {

        private List<Order> orders;

       public ControllerOrders()
        {
            orders = new List<Order>();



            load();


        }

        public string displayOrders()
        {
            string text = "";
            for (int i = 0; i < orders.Count; i++)
            {
                text += orders[i].orderDetails() + "\n";
            }

            return text;
        }

        public int positionById(int id)
        {
            for(int i = 0; i < orders.Count; i++)
            {
                if(orders[i].Id == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public int nextid()
        {
            if(orders.Count == 0)
            {
                return 1;
            }
            else
            {
                return orders[orders.Count - 1].Id + 1;
            }
        }

        public Order order(int id)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].ClientId == id)
                {
                    return orders[i];
                }

            }
            return null;
        }

        public bool add(Order order)
        {
            int poz = positionById(order.Id);

            if (poz != -1)
            {
                Console.WriteLine("Order already saved in the list");
                return false;
            }
            else
            {
                orders.Add(order);
                Console.WriteLine("Order added to list");
                return true;
            }
        }

        public bool delete(int id)
        {
            int poz = positionById(id);

            if (poz == -1)
            {
                Console.WriteLine("Order is not in the list");
                return false;
            }
            else
            {
                orders.RemoveAt(poz);
                Console.WriteLine("Order deleted from list ");
                return true;
            }
        }

        public void updateDeliveryaddress(int id, string deliveryaddress)
        {
         
            foreach(Order order in orders)
            {
                if (order.Id == id)
                {
                    order.Deliveryaddress = deliveryaddress;
                }

            }
        }

       public void updateAmmount(int id,int newammount)
        {
            foreach(Order order in orders)
            {
                if (order.Id == id)
                {
                    order.Ammount = newammount; 
                }
            }
        }

     


        public void load()
        {
            StreamReader read = new StreamReader(@"C:\Users\Asus\Source\Repos\mockup-shop-online\magazin-online\resources\orders.txt");

            string line = "";

            while ((line = read.ReadLine()) != null)
            {
                string[] prop = line.Split(",");


                int id = Int32.Parse(prop[0]);
                string type = prop[1];
                int clientid = Int32.Parse(prop[2]);
                int ammount = Int32.Parse(prop[3]);
                string deliveryaddress = prop[4];


                Order order = new Order(id, type, clientid, ammount, deliveryaddress);

                orders.Add(order);

            }

            read.Close();
        }

        public string toSave()
        {

            string text = "";

            int i = 0;


            for (i = 0; i < orders.Count - 1; i++)
            {

                text += orders[i].toSave() + "\n";

            }

            text += orders[i].toSave();

            return text;
        }

        public void Save()
        {
            StreamWriter write = new StreamWriter(@"C:\Users\Asus\Source\Repos\mockup-shop-online\magazin-online\resources\orders.txt");

            write.Write(toSave());

            write.Close();
        }

        public List<Order> orderHistory(int clientid)
        {
            List<Order> historic = new List<Order>();

            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].ClientId == clientid)
                {
                    historic.Add(orders[i]);
                }
            }

            return historic;

        }
    }
}

