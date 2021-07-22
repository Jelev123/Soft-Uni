
using _03._Raiding.Global;

namespace _03._Raiding.Models
{
  public  class Rogue : BaseHero
    {
        public Rogue(string name) : base(name)
        {
        }

        #region Overrides of BaseHero

        public override int Power => GlobalConstants.RogueAndDruidPower;

        #endregion

        #region Overrides of BaseHero

        public override string CastAbility()
        {
            return string.Format(GlobalConstants.StringOverrideRodueWarrior, GetType().Name, Name, Power);
        }

        #endregion
    }
}
