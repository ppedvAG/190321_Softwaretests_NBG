using ppedv.ProjectSelma.Domain;
using ppedv.ProjectSelma.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace ppedv.ProjectSelma.Logic
{
    public class Core
    {
        public Core(IRepository repository)
        {
            this.repository = repository;
        }

        private readonly IRepository repository;// EF oder Azure oder .xml ....

        public IEnumerable<Person> GetAllPeople()
        {
            return repository.GetAll<Person>();
        }
    }
}
