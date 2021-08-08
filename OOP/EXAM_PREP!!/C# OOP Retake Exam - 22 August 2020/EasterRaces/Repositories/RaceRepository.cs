using System.Linq;
using EasterRaces.Models.Races.Contracts;

namespace EasterRaces.Repositories
{
    public class RaceRepository : Repository<IRace>
    {
        #region Overrides of Repository<IRace>

        public override IRace GetByName(string name)
        {
            return Models.FirstOrDefault(x => x.Name == name);
        }

        #endregion
    }
}