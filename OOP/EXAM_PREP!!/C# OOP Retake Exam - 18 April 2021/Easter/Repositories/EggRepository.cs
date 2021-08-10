using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
   public class EggRepository : IRepository<IEgg>
    {
       

        private readonly ICollection<IEgg> eggs;

        public EggRepository()
        {
            this.eggs = new List<IEgg>();
        }
        #region Implementation of IRepository<IEgg>

        public IReadOnlyCollection<IEgg> Models => (IReadOnlyCollection<IEgg>)this.eggs;
        public void Add(IEgg model)
        {
            this.eggs.Add(model);
        }

        public bool Remove(IEgg model)
        {
            return this.eggs.Remove(model);
        }

        public IEgg FindByName(string name)
        {
            return this.eggs.FirstOrDefault(n => n.Name == name);
        }

        #endregion
    }
}
