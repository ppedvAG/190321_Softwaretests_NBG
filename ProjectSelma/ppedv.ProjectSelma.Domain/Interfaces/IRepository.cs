using System;
using System.Collections.Generic;
using System.Text;

namespace ppedv.ProjectSelma.Domain.Interfaces
{
    public interface IRepository
    {
        IEnumerable<T> GetAll<T>() where T : Entity;
        T GetByID<T>(int ID) where T : Entity;
        void Add<T>(T item) where T : Entity;
        void Update<T>(T item) where T : Entity;
        void Delete<T>(T item) where T : Entity;
        void Save();
    }
}
