using ppedv.ProjectSelma.Domain;
using ppedv.ProjectSelma.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.ProjectSelma.Data.EF
{
    public class EFRepository : IRepository
    {
        public EFRepository(EFContext context)
        {
            this.context = context;
        }
        private readonly EFContext context;

        public void Add<T>(T item) where T : Entity
        {
            context.Set<T>().Add(item);
        }

        public void Delete<T>(T item) where T : Entity
        {
            context.Set<T>().Remove(item);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return context.Set<T>().ToList();
        }

        public T GetByID<T>(int ID) where T : Entity
        {
            // return context.Set<T>().Find(ID); // Cache !!
            return context.Set<T>().FirstOrDefault(x => x.ID == ID);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update<T>(T item) where T : Entity
        {
            var loadedItem = context.Set<T>().FirstOrDefault(x => x.ID == item.ID);
            if(loadedItem != null)
                context.Entry(loadedItem).CurrentValues.SetValues(item);
        }
    }
}
