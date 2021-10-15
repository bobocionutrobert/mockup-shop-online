using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using magazin_online;


namespace unit_tests
{
    public class ControllerTest
    {
        private ControllerProduse control;

        private readonly ITestOutputHelper output;


        public ControllerTest(ITestOutputHelper output)
        {

            control = new ControllerProduse();

            this.output = output;


        }



        [Fact]
        public void testPozitie()
        {



            Assert.Equal(-1, control.pozitie(1));

            output.WriteLine("a");





        }
        [Fact]
        public void testPozitie1()
        {



            Assert.Equal(0, control.pozitie(1));

            output.WriteLine("a");





        }

        [Fact]
        public void testAdd()
        {
            //Preconditie
            Produs a = new Produs(10, "ciorap",4.99,10);

            //ACTIUNE
            control.add(a);


            //Rezultat
            Assert.Equal(true, control.produs("ciorap") != null);
        }


        [Fact]
        public void testAdd2()
        {

            for (int i = 0; i < 100; i++)
            {
                Produs a = new Produs(10, "ciorap", 4.99, 10);

                control.add(a);

                Assert.Equal(false, control.produs("ciorap"+i) != null);
            }



        }

        [Fact]

        public void testUpdateStoc()
        {
            control.updateStoc(1, 2);

            Assert.Equal(2, control.produs("tricou").getStoc());
        }

        [Fact]

        public void testUpdateStoc1()
        {
            control.updateStoc(2, 20);
            control.updateStoc(2, 10);

            Assert.Equal(10, control.produs("pantalon").getStoc());
        }
        [Fact]
        public void testUpdateStoc2()
        {
            control.updateStoc(2, 20-10);
           

            Assert.Equal(10, control.produs("pantalon").getStoc());
        }
        [Fact]
        public void testload()
        {
            control.load();

            Assert.Equal("tricou", control.produs("tricou").getNume());


        }
        [Fact]
        public void testToSave()
        {

            control.load();

            control.updatePret(1, 100);

            control.Save();



            control.load();

            Assert.Equal(100, control.produs("tricou").getPret());



            output.WriteLine(control.toSave());


        }
        [Fact]

        public void testprodusdupaid()
        {
            control.load();

            output.WriteLine(control.produsdupaid(1).getNume());

            
        }
    }
}
