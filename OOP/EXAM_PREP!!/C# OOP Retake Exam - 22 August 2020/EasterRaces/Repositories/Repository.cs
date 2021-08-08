using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories
{
  public abstract class Repository<T> : IRepository<T>
    {
        #region Implementation of IRepository<T>

        public ICollection<T> Models { get; private set; }

        public Repository()
        {
            Models = new List<T>();
        }


        public abstract T GetByName(string name);
        
        
        public IReadOnlyCollection<T> GetAll()
        {
            return (IReadOnlyCollection < T >) Models;
        }

        public void Add(T model)
        {
            Models.Add(model);
        }

        public bool Remove(T model)
        {
           return Models.Remove(model);
        }

        #endregion
    }
}
