using FluentAssertions;
using ppedv.ProjectSelma.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ppedv.ProjectSelma.Data.EF.Tests
{
    public class EFContextTests
    {
        const string connectionString = @"Server=(localDB)\MSSQLLocalDB;Database=ProjectSelmaTESTDB;Trusted_Connection=true;AttachDbFileName=C:\temp\testDB.mdf";

        [Fact]
        public void EFContext_Can_Create_Context()
        {
            var context = new EFContext(connectionString);
            Assert.NotNull(context);
        }

        [Fact]
        public void EFContext_Can_Create_Database()
        {
            using (var context = new EFContext(connectionString))
            {
                if (context.Database.Exists())
                    context.Database.Delete();

                Assert.False(context.Database.Exists()); // Startwert: keine DB

                context.Database.Create();
                Assert.True(context.Database.Exists());
            }
        }

        [Fact]
        public void EFContext_Can_CRUD_Person()
        {
            Person p = new Person { FirstName = "Tom", LastName = "Ate", Age = 10, Balance = 100 };
            string newLastName = "Atinger";

            // Test: Create
            using (var context = new EFContext(connectionString))
            {
                context.Person.Add(p); // Insert
                context.SaveChanges();
            }
            // Check für Create
            using (var context = new EFContext(connectionString))
            {
                var loadedPerson = context.Person.Find(p.ID);
                Assert.NotNull(loadedPerson);
                Assert.Equal(loadedPerson.LastName, p.LastName); // Variante "schlecht"
                // Variante "richtig" wäre ein Vergleich auf alle Properties -> ObjectGraph

                // Update
                loadedPerson.LastName = newLastName;
                context.SaveChanges();
            }

            // Check für Update
            using (var context = new EFContext(connectionString))
            {
                var loadedPerson = context.Person.Find(p.ID);
                Assert.NotNull(loadedPerson);
                Assert.Equal(loadedPerson.LastName, newLastName);

                // Delete
                context.Person.Remove(loadedPerson);
                context.SaveChanges();
            }

            // Check für Delete
            using (var context = new EFContext(connectionString))
            {
                var loadedPerson = context.Person.Find(p.ID);
                Assert.Null(loadedPerson);
            }
        }


        [Fact]
        public void EFContext_Can_CRUD_Person_Fluent()
        {
            Person p = new Person { FirstName = "Tom", LastName = "Ate", Age = 10, Balance = 100 };
            string newLastName = "Atinger";

            // Test: Create
            using (var context = new EFContext(connectionString))
            {
                context.Person.Add(p); // Insert
                context.SaveChanges();
            }
            // Check für Create
            using (var context = new EFContext(connectionString))
            {
                var loadedPerson = context.Person.Find(p.ID);
                loadedPerson.Should().NotBeNull();       // Assert.NotNull(loadedPerson);
                loadedPerson.Should().BeEquivalentTo(p); // ObjectGraph-Vergleich

                // Update
                loadedPerson.LastName = newLastName;
                context.SaveChanges();
            }

            // Check für Update
            using (var context = new EFContext(connectionString))
            {
                var loadedPerson = context.Person.Find(p.ID);
                loadedPerson.Should().NotBeNull();
                loadedPerson.LastName.Should().Be(newLastName);

                // Delete
                context.Person.Remove(loadedPerson);
                context.SaveChanges();
            }

            // Check für Delete
            using (var context = new EFContext(connectionString))
            {
                var loadedPerson = context.Person.Find(p.ID);
                loadedPerson.Should().BeNull();
            }
        }
    }
}
