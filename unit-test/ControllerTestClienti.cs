using magazin_online;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace unit_test
{
    public class ControllerTestClienti
    {

        private ControllerPerson control;

        private readonly ITestOutputHelper output;


        public ControllerTestClienti(ITestOutputHelper output)
        {

            control = new ControllerPerson();

            this.output = output;


        }
        [Fact]
        public void testPozitie()
        {

            Assert.Equal(0, control.pozitie(1));
        }
        [Fact]
        public void testPozitie2()
        {
            Assert.Equal(0, control.pozitie(1));
        }
        [Fact]
        public void testPozitie3()
        {
            Person a = new Person(1, "email", "parola", "nume", "adresa", "tara", 21382101,false); //0
            Person b = new Person(2, "email1", "parola2", "nume2", "adresa2", "tara2", 213821011,false); //1
            Person c = new Person(3, "email3", "parola3", "nume3", "adresa3", "tara3", 2138210121,false); //2
            Person d = new Person(4, "email4", "parola4", "nume4", "adresa4", "tara4", 398382101,false); //3
            Person e = new Person(5, "email5", "parola5", "nume5", "adresa5", "tara5", 993821014,false); //4
            Person f = new Person(6, "email6", "parola6", "nume6", "adresa6", "tara6", 2138210123,false); //5

            control.add(a);
            control.add(b);
            control.add(c);
            control.add(d);
            control.add(e);
            control.add(f);

            

            control.delete(1);

            Assert.Equal(1, control.pozitie(1));


        }
        [Fact]
        public void testUpdate()
        {
            control.load();

            

            control.updateNume(2,"numenou");

            Assert.Equal("numenou", control.client(2).getNume());
        }

        [Fact]
        public void testUpdateEmail()
        {
            control.load();
            
            control.updateEmail(2,"emailupdate");

            Assert.Equal("emailupdate", control.client(2).getEmail());
        }

        [Fact]

        public void testUpdateParola()
        {
            control.load();

            control.updateParola(2,"updateparola");

            Assert.Equal("updateparola", control.client(2).getParola());
        }

        [Fact]
        public void testUpdateAdresa()
        {
            control.load();

            control.updateAdresa(2,"updateadresa");

            Assert.Equal("updateadresa", control.client(2).getAdresa());
        }

        [Fact]
        public void testUpdateTelefon()
        {
            control.load();

            control.updateNrTelefon(2, 3213819);

            Assert.Equal(3213819, control.client(2).getNrtelefon());
        }
        [Fact]
        public void testDeletedupanume()
        {
            control.load();
            control.deletedupanume("numee");

            Assert.Equal(1, control.pozitie(3));
        }

        [Fact]
        public void testload()
        {
            control.load();

            Assert.Equal("numee", control.client(2).getNume());
        }
        [Fact]
        public void testSave()
        {
            control.load();

            

            control.Save();

            control.load();

            output.WriteLine(control.toSave());

            
        }


    }
}
