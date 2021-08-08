using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories
{
    public class DriverRepository : Repository<IDriver>
    {
        #region Overrides of Repository<IDriver>

        public override IDriver GetByName(string name)
        {
            return Models.FirstOrDefault(x => x.Name == name);
        }

        #endregion
    }
}