using ppedv.ProjectSelma.Domain;
using ppedv.ProjectSelma.Domain.Interfaces;
using ppedv.ProjectSelma.Logic.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.ProjectSelma.Logic
{
    public class Core
    {
        public Core(IRepository repository)
        {
            this.repository = repository;
            driver = new RoboRecruiterDriver();
        }

        private readonly IRepository repository;// EF oder Azure oder .xml ....
        private readonly RoboRecruiterDriver driver;

        public IEnumerable<Person> GetAllPeople()
        {
            return repository.GetAll<Person>();
        }

        public Person GetPersonWithHighestBalance()
        {
            return repository.GetAll<Person>()
                             .OrderByDescending(x => x.Balance)
                             .FirstOrDefault();
        }

        public IEnumerable<Person> RecruitFivePersons()
        {
            return driver.RecruitPersons(5);
        }
    }
}
