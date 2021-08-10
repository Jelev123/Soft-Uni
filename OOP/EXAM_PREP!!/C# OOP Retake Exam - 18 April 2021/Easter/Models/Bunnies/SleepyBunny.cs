namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int BunyEnergy = 50;
        private const int DecreaseEnergy=5;

        public SleepyBunny(string name) : base(name, BunyEnergy)
        {
           
        }

       

        #region Overrides of Bunny

        public override void Work()
        {
            base.Work();
            this.Energy -= DecreaseEnergy;

        }

        #endregion
    }
}