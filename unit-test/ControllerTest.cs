//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xunit;
//using Xunit.Abstractions;
//using magazin_online;


//namespace unit_tests
//{
//    public class ControllerTest
//    {
//        private ControllerProduse control;

//        private readonly ITestOutputHelper output;


//        public ControllerTest(ITestOutputHelper output)
//        {

//            control = new ControllerProduse();

//            this.output = output;


//        }



//        [Fact]
//        public void testPozitie()
//        {

//            control.load();

//            Assert.Equal(0, control.pozitie(1));

            





//        }
//        [Fact]
//        public void testPozitie1()
//        {


//            control.load();

//            Assert.Equal(1, control.pozitie(2));

//            output.WriteLine("a");





//        }

//        [Fact]
//        public void testAdd()
//        {
//            //Preconditie
//            Product a = new Product(10, "telefon",4.99,10);

//            //ACTIUNE
//            control.add(a);


//            //Rezultat
//            Assert.Equal(true, control.produs("telefon") != null);
//        }


//        [Fact]
//        public void testAdd2()
//        {

//            for (int i = 0; i < 100; i++)
//            {
//                Product a = new Product(10, "telefon", 4.99, 10);

//                control.add(a);

//                Assert.Equal(false, control.produs("telefon"+i) != null);
//            }



//        }

//        [Fact]

//        public void testUpdateStoc()
//        {
//            control.updateStoc(1, 2);

//            Assert.Equal(2, control.produs("tricou").getStoc());
//        }

//        [Fact]

//        public void testUpdateStoc1()
//        {
//            control.updateStoc(2, 20);
            

//            Assert.Equal(20,control.produs("pantof").getStoc());
//        }
//        [Fact]
//        public void testUpdateStoc2()
//        {
//            control.updateStoc(1, 50);
           

//            Assert.Equal(50, control.produs("tricou").getStoc());
//        }
//        [Fact]
//        public void testload()
//        {
//            control.load();

//            Assert.Equal("tricou", control.produs("tricou").getNume());


//        }
//        [Fact]
//        public void testToSave()
//        {

//            control.load();

//            control.updatePret(1, 100);

//            control.Save();



//            control.load();

//            Assert.Equal(100, control.produs("tricou").getPret());



//            output.WriteLine(control.toSave());


//        }
//        [Fact]

//        public void testprodusdupaid()
//        {
//            control.load();
//            //tricou,pantof,geaca,bluza,produs,testprodus
//            //output.WriteLine(control.produsdupaid(6).getNume());
//            Assert.Equal("tricou", control.produsdupaid(1).getNume());
//            Assert.Equal("pantof", control.produsdupaid(2).getNume());
//            Assert.Equal("geaca", control.produsdupaid(3).getNume());
//            Assert.Equal("bluza", control.produsdupaid(4).getNume());
//            Assert.Equal("produs", control.produsdupaid(5).getNume());
//            Assert.Equal("testprodus", control.produsdupaid(6).getNume());

            
//        }

//        [Fact]

//        public void testprodusdupanume()
//        {
//            control.load();

//            Assert.Equal("tricou", control.produs("tricou").getNume());
//        }
//        [Fact]
//        public void testpozitieduapnume()
//        {
//            control.load();

//            Assert.Equal(0, control.pozitiedupanume("tricou"));
//        }
//        [Fact]
//        public void updatestocdupanume()
//        {
//            control.load();

//            control.updateStocdupanume("tricou", 20);

//            Assert.Equal(20, control.produs("tricou").getStoc());

//        }
//    }
//}
