using System.Security.Cryptography.X509Certificates;
using _03._Raiding.Global;

namespace _03._Raiding
{
    public class Druid :BaseHero
    {
        public Druid(string name) : base(name)
        {

        }

        #region Overrides of BaseHero

        public override int Power => GlobalConstants.RogueAndDruidPower;

        #endregion

        #region Overrides of BaseHero

        public override string CastAbility()
        {
            return string.Format(GlobalConstants.StringOverrideDruidPaladin, GetType().Name, Name, Power);
        }

        #endregion
    }
}