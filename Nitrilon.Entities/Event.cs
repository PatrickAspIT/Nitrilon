namespace Nitrilon.Entities
{
    public class Event
    {
        #region Fields and constants
        public readonly DateTime EarliestPossibleEvent = new DateTime(2018, 01, 01);

        private int id;
        private DateTime date;
        private string name;
        private int attendees;
        private string description;
        private EventRatingData ratings;
        #endregion

        public Event(int id, DateTime date, string name, int attendees, string description)
        {
            Id = id;
            Date = date;
            Name = name;
            Attendees = attendees;
            Description = description;
        }

        #region Constructors
        public Event(int id, DateTime date, string name, int attendees, string description, EventRatingData ratings)
            : this(id, date, name, attendees, description)
        {
            Ratings = ratings;
        }
        #endregion

        #region Properties
        public int Id
        {
            get => id; // get { return id; }
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value);
                if (id != value)
                {
                    id = value;
                }
            }
        }

        public DateTime Date
        {
            get => date; // get { return date; }
            set
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(value, EarliestPossibleEvent);
                if (date != value)
                {
                    date = value;
                }
            }
        }

        public string Name
        {
            get => name; // get { return name; } 
            set
            {
                ArgumentOutOfRangeException.ThrowIfNullOrWhiteSpace(value);
                if (name != value)
                {
                    name = value;
                }
            }
        }

        public int Attendees
        {
            get => attendees; // get { return attendees; } 
            set
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(value, -1);
                if (attendees != value)
                {
                    attendees = value;
                }
            }
        }

        public string Description
        {
            get => description; // get { return description; } 
            set
            {
                if (description != value)
                {
                    description = value;
                }
            }
        }

        public EventRatingData Ratings { get => ratings; set => ratings = value; }
        #endregion

        #region Methods
        ///// <summary>
        ///// Adds a rating to this event.
        ///// </summary>
        ///// <param name="rating">The rating to add to this event.</param>
        ///// <exception cref="ArgumentNullException">Thrown when the provided rating is null.</exception>
        //public void Add(Rating rating)
        //{
        //    if (rating == null)
        //    {
        //        throw new ArgumentNullException(nameof(rating));
        //    }
        //    ratings.Add(rating);
        //}

        ///// <summary>
        ///// Gets the average value of the ratings for this event.
        ///// </summary>
        ///// <returns>The average rating value. When there are no ratings for this event, the value -1.0 is returned.</returns>
        //public double GetRatingAverage()
        //{
        //    if (ratings.Count == 0)
        //    {
        //        double average = 0.0;
        //        int sum = 0;
        //        foreach (Rating rating in ratings)
        //        {
        //            sum += rating.RatingValue;
        //        }
        //        average = (double)sum / (double)ratings.Count;
        //        return average;
        //    }
        //    else
        //    {
        //        return -1.0;
        //    }
        //}
        #endregion
    }
}
