using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easter.Models.Bunnies.Contracts;

namespace Easter.Repositories.Contracts
{
   public class BunnyRepository : IRepository<IBunny>
   {
     

       private readonly ICollection<IBunny> modelsBunnies;

       public BunnyRepository()
       {
           this.modelsBunnies = new List<IBunny>();
       }

       public IReadOnlyCollection<IBunny> Models => (IReadOnlyCollection<IBunny>) this.modelsBunnies;
        public void Add(IBunny model)
        {
            this.modelsBunnies.Add(model);
        }

        public bool Remove(IBunny model)
        {
            return this.modelsBunnies.Remove(model);
        }

        public IBunny FindByName(string name)
        {
            return this.modelsBunnies.FirstOrDefault(n => n.Name == name);
        }
   }
}
