namespace Nitrilon.Entities
{
    // Not used at the moment
    public class Rating
    {
        #region Fields
        private int id;
        private int ratingValue;
        private string description;
        #endregion

        #region Constraints
        public Rating(int id, int ratingValue, string description)
        {
            Id = id;
            RatingValue = ratingValue;
            Description = description;
        }
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public int RatingValue { get => ratingValue; set => ratingValue = value; }
        public string Description { get => description; set => description = value; }
        #endregion
    }
}