
using _03._Raiding.Global;

namespace _03._Raiding.Models
{
  public  class Paladin : BaseHero
    {
        public Paladin(string name) : base(name)
        {
        }

        #region Overrides of BaseHero

        public override int Power => GlobalConstants.PaladinAndWarriorPower;

        #endregion

        #region Overrides of BaseHero

        public override string CastAbility()
        {
            return string.Format(GlobalConstants.StringOverrideDruidPaladin, GetType().Name, Name, Power);
        }

        #endregion
    }
}
