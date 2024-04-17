namespace Nitrilon.Entities
{
    public class Event
    {
        private int id;
        private DateTime date;
        private string name;
        private int attendees;
        private string description;        

        public int Id 
        {
            get { return id } 
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Id must be greater than 0");
                }
                id = value;
            }
        } 

        public DateTime Date
        {
            get { return date } 
            set
            {
                if (String.IsNullOrWhiteSpace(value.ToString()))
                {
                    throw new ArgumentException("Date must be set correctly");
                }
                date = value;
            }
        }

        public string Name
        {
            get { return name } 
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name can't be empty");
                }
                name = value;
            }
        }

        public int Attendees
        {
            get { return attendees } 
            set
            {
                if (value < -1)
                {
                    throw new ArgumentException("Attendees can't be negative");
                }
                attendees = value;
            }
        }

        public string Description
        {
            get { return description; }
            set {  description = value; }
        }
        
    }
}
