using Moq;
using ppedv.ProjectSelma.Domain;
using ppedv.ProjectSelma.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ppedv.ProjectSelma.Logic.Tests
{
    public class CoreTests
    {
        [Fact]
        public void Core_GetAllPeople_Get_Exactly_5_People()
        {
            var mock = new Mock<IRepository>();
            // Konfiguration
            mock.Setup(x => x.GetAll<Person>())
                .Returns(() =>
                {
                    return new Person[]
                    {
                        new Person{FirstName="Tom",LastName="Ate",Age=10,Balance=100},
                        new Person{FirstName="Anna",LastName="Nass",Age=20,Balance=2000},
                        new Person{FirstName="Peter",LastName="Silie",Age=30,Balance=30000},
                        new Person{FirstName="Franz",LastName="Ose",Age=40,Balance=-487600},
                        new Person{FirstName="Martha",LastName="Pfahl",Age=50,Balance=55500},
                    };
                });
            var core = new Core(mock.Object); 

            var result = core.GetAllPeople(); // Typische Businesslayer-Logik: Hol was aus der DB 
            Assert.Equal(5, result.Count());
        }

        [Fact]
        public void Core_Can_GetPersonWithHighestBalance()
        {
            var mock = new Mock<IRepository>();
            // Konfiguration
            mock.Setup(x => x.GetAll<Person>())
                .Returns(() =>
                {
                    return new Person[]
                    {
                        new Person{FirstName="Tom",LastName="Ate",Age=10,Balance=100},
                        new Person{FirstName="Anna",LastName="Nass",Age=20,Balance=2000},
                        new Person{FirstName="Peter",LastName="Silie",Age=30,Balance=30000},
                        new Person{FirstName="Franz",LastName="Ose",Age=40,Balance=-487600},
                        new Person{FirstName="Martha",LastName="Pfahl",Age=50,Balance=55500},
                    };
                });
            var core = new Core(mock.Object);

            var result = core.GetPersonWithHighestBalance(); // Typische Businesslayer-Logik: Hol was aus der DB 
            Assert.Equal("Martha", result.FirstName);
        }

        [Fact]
        public void Core_Can_RecruitFivePersons()
        {
            var mock = new Mock<IRepository>();
            var core = new Core(mock.Object);

            var result = core.RecruitFivePersons();
            Assert.Equal(5, result.Count());
        }
    }
}
