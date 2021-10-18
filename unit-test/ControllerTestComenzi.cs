using magazin_online;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace unit_test
{
    public class ControllerTestComenzi
    {

        private ControllerComenzi control;

        private readonly ITestOutputHelper output;


        public ControllerTestComenzi(ITestOutputHelper output)
        {

            control = new ControllerComenzi();

            this.output = output;


        }

        [Fact]
        public void testPozitie()
        {

            control.load();

            Assert.Equal(0, control.pozitie(2));

            output.WriteLine("a");


        }

        [Fact]
        public void testload()
        {
            control.load();

            Assert.Equal(10, control.comanda(1).getId());
        }
        [Fact]

        public void testistoric()
        {

           
            List<Comenzi> list = control.istoriccomenzi(1);


            output.WriteLine(list.Count.ToString());

            for(int i=0;i< list.Count; i++)
            {
                output.WriteLine(list[i].descriere());
            }

        }
    }
}
