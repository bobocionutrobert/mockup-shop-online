using magazin_online;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace unit_test
{
    public class ControllerTestPerson
    {

        private ControllerPerson control;

        

        private readonly ITestOutputHelper output;


        public ControllerTestPerson(ITestOutputHelper output)
        {

            control = new ControllerPerson();

            this.output = output;


        }
        [Fact]
        public void testPozitie()
        {
            control.load();

            Assert.Equal(0, control.positionById(1));
        }
        [Fact]
        public void testPozitie2()
        {

            control.load();

            Assert.Equal(2, control.positionByName("Admin"));
        }


        [Fact]
        public void testPozitie3()
        {
            


        }
        [Fact]
        public void testUpdateName()
        {
            control.load();



            control.updatePersonName(1, "newname");

            Assert.Equal("newname", control.returnPersonbyId(1).Name);
        }

        [Fact]
        public void testUpdateEmail()
        {
            control.load();

            control.updatePersonEmail(1, "newemail");

            Assert.Equal("newemail", control.returnPersonbyId(1).Email);
            
        }

        [Fact]

        public void testUpdateAddress()
        {
            control.load();

            control.updatePersonAddress(1, "newaddress");

            Assert.Equal("newaddress", control.returnPersonbyId(1).Address);
        }

        [Fact]
        public void testUpdatePhone()
        {
            control.load();

            control.updatePersonPhoneNumber(1,929128);

            Assert.Equal(929128, control.returnPersonbyId(1).Phone);
        }

        [Fact]
        public void testUpdatePasswordClient()
        {
            control.load();

            control.updateClientPassword(1, "newpassword");

            
        }
        [Fact]
        public void testDeletebyName()
        {
            control.load();
            control.deletePersonByName("Admin");

            Assert.Equal(2, control.positionById(3));
        }

        [Fact]
        public void testload()
        {
            control.load();

            Assert.Equal("Admin", control.returnPersonByName("Admin").Name);
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
