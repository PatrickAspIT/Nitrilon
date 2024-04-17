namespace Nitrilon.Entities
{
    public class EventRating
    {
        private int eventRatingId;
        private int eventId;
        private int ratingId;

        public int EventRatingId
        {
            get { return eventRatingId }
            set { eventRatingId = value }
        } 

        public int EventId
        {
            get { return eventId }
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
            get { return ratingId }
            set
            {
                if (value < 0 || value > 5)
                {
                    throw new ArgumentException("RatingId can't be below 1 or greater than 5");
                }
                ratingId = value;
            }
        }

    }
}
