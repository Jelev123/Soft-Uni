using System.Linq;
using EasterRaces.Models.Cars.Contracts;

namespace EasterRaces.Repositories
{
    public class CarRepository : Repository<ICar>
    {
        #region Overrides of Repository<ICar>

        public override ICar GetByName(string name)
        {
            return Models.FirstOrDefault(x => x.Model == name);
        }

        #endregion
    }
}