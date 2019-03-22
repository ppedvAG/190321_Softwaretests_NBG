using System;

namespace ppedv.ProjectSelma.Domain
{
    public class Person : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public decimal Balance { get; set; }
    }
}
