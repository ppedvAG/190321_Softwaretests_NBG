using ppedv.ProjectSelma.Data.EF;
using ppedv.ProjectSelma.Domain;
using ppedv.ProjectSelma.Hardware.RoboRecruiter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ppedv.ProjectSelma.Logic.IntegrationTests
{
    public class CoreIntegrationTests
    {
        public CoreIntegrationTests()
        {
            // Setup
            var context = new EFContext(connectionString);
            if (context.Database.Exists()) // Immer eine frische DB
                context.Database.Delete();
            context.Database.Create();

            // Testdaten einfüllen:
            context.Person.Add(new Person { FirstName = "Tom", LastName = "Ate", Age = 10, Balance = 100 });
            context.Person.Add(new Person { FirstName = "Anna", LastName = "Nass", Age = 20, Balance = 2000 });
            context.Person.Add(new Person { FirstName = "Peter", LastName = "Silie", Age = 30, Balance = 30000 });
            context.Person.Add(new Person { FirstName = "Franz", LastName = "Ose", Age = 40, Balance = -487600 });
            context.Person.Add(new Person { FirstName = "Martha", LastName = "Pfahl", Age = 50, Balance = 55500 });

            context.SaveChanges();
            core = new Core(new EFRepository(context), new XingRecruiter3000());
        }
        const string connectionString = @"Server=(localDB)\MSSQLLocalDB;Database=ProjectSelmaTESTDB;Trusted_Connection=true;AttachDbFileName=C:\temp\testDB.mdf";
        private readonly Core core;



        [Fact]
        [Trait("Core_Integration", null)]
        public void Core_Can_GetPersonWithHighestBalance()
        {
            var result = core.GetPersonWithHighestBalance();
            Assert.Equal("Martha", result.FirstName);
        }

        [Fact]
        [Trait("Core_Integration", null)]
        public void Core_Can_RecruitFivePersons()
        {
            var result = core.RecruitFivePersons();
            Assert.Equal(5, result.Count());
        }

        [Fact]
        [Trait("Core_Integration", null)]
        public void Core_RecruitPersons_with_invalid_amount_throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => core.RecruitPersons(-5));
        }


        [Fact]
        [Trait("Core_Integration", null)]
        public void Core_ZGetAllPeople_Get_Exactly_5_People()
        {
            var result = core.GetAllPeople();
            Assert.Equal(5, result.Count());
        }
    }
}
