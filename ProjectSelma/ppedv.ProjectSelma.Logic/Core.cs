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
        public Core(IRepository repository, IDevice device)
        {
            this.repository = repository;
            this.device = device;
        }

        private readonly IRepository repository;// EF oder Azure oder .xml ....
        private readonly IDevice device;

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
            return RecruitPersons(5);
        }

        public IEnumerable<Person> RecruitPersons(int amount)
        {
            if (amount < 0)
                throw new ArgumentException();
            List<Person> persons = new List<Person>();
            for (int i = 0; i < amount; i++)
            {
                persons.Add(device.RecruitPerson()); 
            }
            return persons;
        }

        public int SaveRecruitedPeopleInDB(IEnumerable<Person> people)
        {
            int savedPersons = 0;
            foreach (var item in people)
            {
                try
                {
                    repository.Add(item);
                    savedPersons++;
                }
                catch (Exception){ }
            }
            return savedPersons;
        }
    }
}
