using ppedv.ProjectSelma.Domain;
using System;
using System.Data.Entity;

namespace ppedv.ProjectSelma.Data.EF
{
    public class EFContext : DbContext
    {
        public EFContext() : this(@"Server=(localDB)\MSSQLLocalDB;Database=ProjectSelma;Trusted_Connection=true;AttachDbFileName=C:\temp\produktivDB.mdf") {}
        public EFContext(string connectionString) : base(connectionString){}

        public DbSet<Person> Person { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Company> Company { get; set; }

    }
}
