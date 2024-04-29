namespace Nitrilon.Entities
{
    public class EventRatingData
    {
        #region Fields
        private int horribleRatingCount;
        private int badRatingCount;
        private int neutralRatingCount;
        private int goodRatingCount;
        private int fantasticRatingCount;
        #endregion

        #region Constructors
        public EventRatingData(int horribleRatingCount, int badRatingCount, int neutralRatingCount, int goodRatingCount, int fantasticRatingCount)
        {
            HorribleRatingCount = horribleRatingCount;
            BadRatingCount = badRatingCount;
            NeutralRatingCount = neutralRatingCount;
            GoodRatingCount = goodRatingCount;
            FantasticRatingCount = fantasticRatingCount;
        }
        #endregion

        #region Properties
        public int HorribleRatingCount { get => horribleRatingCount; set => horribleRatingCount = value; }
        public int BadRatingCount { get => badRatingCount; set => badRatingCount = value; }
        public int NeutralRatingCount { get => neutralRatingCount; set => neutralRatingCount = value; }
        public int GoodRatingCount { get => goodRatingCount; set => goodRatingCount = value; }
        public int FantasticRatingCount { get => fantasticRatingCount; set => fantasticRatingCount = value; }
        #endregion

        #region Methods
        public (double horribleRatingPercentage, double badRatingPercentage, double neutralRatingPercentage, double goodRatingPercentage, double fantasticRatingPercentage) GetPercentages()
        {
            (double, double, double, double, double) percentages = default;

            return percentages;
        }
        #endregion
    }
}
