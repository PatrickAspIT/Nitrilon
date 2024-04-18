namespace Nitrilon.Entities
{
    public class Event
    {
        #region Fields
        public readonly DateTime EarliestPossibleEvent = new DateTime(2018, 01, 01);

        private int id;
        private DateTime date;
        private string name;
        private int attendees;
        private string description;
        #endregion


        #region Constructors
        public Event(int id, DateTime date, string name, int attendees, string description)
        {
            Id = id;
            Date = date;
            Name = name;
            Attendees = attendees;
            Description = description;
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
    }
}
