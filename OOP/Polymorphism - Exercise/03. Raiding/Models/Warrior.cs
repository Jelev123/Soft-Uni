using System;
using System.Collections.Generic;
using System.Text;
using _03._Raiding.Global;

namespace _03._Raiding.Models
{
   public class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        {
        }

        #region Overrides of BaseHero

        public override int Power => GlobalConstants.PaladinAndWarriorPower;

        #endregion

        #region Overrides of BaseHero

        public override string CastAbility()
        {
            return string.Format(GlobalConstants.StringOverrideRodueWarrior, GetType().Name, Name, Power);
        }

        #endregion
    }
}
