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

            Assert.Equal(1, control.pozitie(3));




            
        }
        [Fact]
        public void testLoad()
        {
            control.load();

            Assert.Equal(2, control.detaliicomanda(2).getId());
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



            List<DetaliiComenzi> detaliiComenzi = c.getDetaliicomenzi(1);



            for(int i=0; i < detaliiComenzi.Count; i++)
            {
                output.WriteLine(detaliiComenzi[i].descriere());
            }



            

        }

    }
}
