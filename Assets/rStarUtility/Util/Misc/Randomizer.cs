namespace rStarUtility.Util
{
    public interface Randomizer
    {
    #region Public Variables

        public bool IsTrigger { get; }

    #endregion

    #region Public Methods

        public void SetChance(int chance);

    #endregion
    }

    public class RandomizerRuntime : Randomizer
    {
    #region Public Variables

        public bool IsTrigger
        {
            get
            {
                return chance switch
                {
                    0 => false , >= 100 => true , _ => chance >= RandomUtilities.GetRandomValue(1 , 99)
                };
            }
        }

    #endregion

    #region Private Variables

        private int chance;

    #endregion

    #region Public Methods

        public void SetChance(int chance)
        {
            this.chance = chance;
        }

    #endregion
    }
}