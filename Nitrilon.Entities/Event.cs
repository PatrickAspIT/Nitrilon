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
        private List<Rating> ratings;
        #endregion

        #region Constructors
        public Event(int id, DateTime date, string name, int attendees, string description, List<Rating> ratings)
        {
            Id = id;
            Date = date;
            Name = name;
            Attendees = attendees;
            Description = description;
            this.ratings = ratings ?? throw new ArgumentNullException(nameof(ratings));
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
        #endregion

        #region Methods
        public void Add(Rating rating)
        {
            if (rating == null)
            {
                throw new ArgumentNullException(nameof(rating));
            }
            ratings.Add(rating);
        }

        public double GetRatingAverage()
        {
            if (ratings == null)
            {
                throw new ArgumentNullException(nameof(ratings));
            }

            double sum = 0;
            foreach (Rating rating in ratings)
            {
                sum += rating.RatingValue;
            }

            return sum / ratings.Count;
        }
        #endregion
    }
}
