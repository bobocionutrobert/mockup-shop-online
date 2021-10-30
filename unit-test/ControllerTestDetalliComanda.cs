using System;
using System.Collections.Generic;
using System.Text;
using magazin_online;
using Xunit;
using Xunit.Abstractions;

namespace unit_test
{
    public class ControllerTestDetalliComanda
    {

        private ControllerDetaliiComenzi control;

        private readonly ITestOutputHelper output;

        public ControllerTestDetalliComanda(ITestOutputHelper output)
        {
            control = new ControllerDetaliiComenzi();

            this.output = output;
        }

        [Fact]

        public void testAfisare()
        {



        }
      
        [Fact]
        public void testPozitie()
        {

            DetaliiComenzi a = new DetaliiComenzi(1,200,300,1000,1);
            DetaliiComenzi b = new DetaliiComenzi(2, 300, 400, 2000, 2);
            DetaliiComenzi c = new DetaliiComenzi(3, 400, 500, 3000, 2);

            control.add(a);
            control.add(b);
            control.add(c);

            control.delete(1);

            Assert.Equal(2, control.pozitie(3));




            
        }
        [Fact]
        public void testLoad()
        {
            control.load();

            output.WriteLine(control.afisare());
        }
        [Fact]
        public void testSave()
        {
            control.load();
            DetaliiComenzi a = new DetaliiComenzi(99,999,9999,1999,1);
            control.add(a);

            control.Save();
            control.load();

            output.WriteLine(control.toSave());
        }

        [Fact]

        public void testDetaliiComenzi()
        {
            control.load();

            ControllerDetaliiComenzi c = new ControllerDetaliiComenzi();



            List<DetaliiComenzi> detalii = control.getDetaliicomenzi(1);

            for(int i = 0; i < detalii.Count; i++)
            {
                Assert.Equal(1, detalii[i].getId());
                output.WriteLine(detalii[i].getId().ToString());
            }
            

            /*for(int i=0; i < detaliiComenzi.Count; i++)
            {
                output.WriteLine(detaliiComenzi[i].descriere());
            }
            */


            

        }
        [Fact]
        public void testDetaliiComenzi2()
        {

            control.load();

            ControllerDetaliiComenzi c = new ControllerDetaliiComenzi();



            List<DetaliiComenzi> detalii = control.getDetaliicomenzi(2); // id comanda = 2

            for (int i = 0; i < detalii.Count; i++)
            {
                
                Assert.Equal(1, detalii[i].getId()); // comanda 2, id client =1

                Assert.Equal(3231, detalii[i].getIdprodus()); // comanda 2, id produs = 3231

                Assert.Equal(4221, detalii[i].getPret()); //comanda 2, pret total 4211


                
            }
        }
        [Fact]
        public void testcelmaivandutprodus()
        {



            //Preconditie   cream  mai multe order details cu produse si le daugam in controll
            //
            DetaliiComenzi a = new DetaliiComenzi(1, 1, 1, 100, 3);
            DetaliiComenzi b = new DetaliiComenzi(2, 2, 1, 100, 2);
            DetaliiComenzi c = new DetaliiComenzi(3, 4, 2, 70, 2);
            DetaliiComenzi d = new DetaliiComenzi(4, 10, 3, 80, 3);
            DetaliiComenzi e = new DetaliiComenzi(5, 4, 2, 20, 7);

            control.add(a);
            control.add(b);
            control.add(c);
            control.add(d);
            control.add(e);
            int[] list = control.celmaivandutprouds();



            Assert.Equal(list[2], 9);
        }


    }
}
