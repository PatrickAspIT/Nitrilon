namespace Nitrilon.Entities
{
    public class EventRating
    {
        #region Fields
        private int eventRatingId;
        private int eventId;
        private int ratingId;
        #endregion

        #region Properties
        public int EventRatingId
        {
            get => eventRatingId;
            set
            {
                if (eventRatingId != value)
                {
                    eventRatingId = value;
                }
            }
        }

        public int EventId
        {
            get => eventId;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("EventId must be greater than 0");
                }
                eventId = value;
            }
        }

        public int RatingId
        {
            get => ratingId;
            set
            {
                if (value < 0 || value > 5)
                {
                    throw new ArgumentException("RatingId can't be below 1 or greater than 5");
                }
                ratingId = value;
            }
        }
        #endregion
    }
}
