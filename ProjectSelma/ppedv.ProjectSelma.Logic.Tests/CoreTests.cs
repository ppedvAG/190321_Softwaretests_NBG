using Moq;
using ppedv.ProjectSelma.Domain;
using ppedv.ProjectSelma.Domain.Interfaces;
using ppedv.ProjectSelma.Logic.Driver;
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
        [Trait("Core_Unit",null)]
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
            var core = new Core(mock.Object,null); // "Treiber" wird nicht genutzt

            var result = core.GetAllPeople(); // Typische Businesslayer-Logik: Hol was aus der DB 
            Assert.Equal(5, result.Count());
        }

        [Fact]
        [Trait("Core_Unit", null)]
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
            var core = new Core(mock.Object,null); // "Treiber" wird nicht genutzt

            var result = core.GetPersonWithHighestBalance(); // Typische Businesslayer-Logik: Hol was aus der DB 
            Assert.Equal("Martha", result.FirstName);
        }

        [Fact]
        [Trait("Core_Unit", null)]
        public void Core_Can_RecruitFivePersons()
        {
            var driverMock = new Mock<IDevice>();
            driverMock.SetupSequence(x => x.RecruitPerson())
                      .Returns(() => new Person { FirstName = "Tom", LastName = "Ate", Age = 10, Balance = 100 })
                      .Returns(() => new Person { FirstName = "Anna", LastName = "Nass", Age = 20, Balance = 2000 })
                      .Returns(() => new Person { FirstName = "Peter", LastName = "Silie", Age = 30, Balance = 30000 })
                      .Returns(() => new Person { FirstName = "Franz", LastName = "Ose", Age = 40, Balance = -487600 })
                      .Returns(() => new Person { FirstName = "Martha", LastName = "Pfahl", Age = 50, Balance = 55500 });

            var core = new Core(null,driverMock.Object);

            var result = core.RecruitFivePersons();
            Assert.Equal(5, result.Count());
            driverMock.Verify(x => x.RecruitPerson(), Times.Exactly(5));
        }

        [Fact]
        [Trait("Core_Unit", null)]
        public void Core_RecruitPersons_with_invalid_amount_throws_ArgumentException()
        {
            var driverMock = new Mock<IDevice>();
            var core = new Core(null, driverMock.Object);
            Assert.Throws<ArgumentException>(() => core.RecruitPersons(-5));
            driverMock.Verify(x => x.RecruitPerson(), Times.Never); // Garantiert, dass diese Methode nicht aufgerufen wurde
        }
    }
}
