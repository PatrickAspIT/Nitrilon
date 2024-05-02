using Microsoft.Data.SqlClient;
using Nitrilon.Entities;

namespace Nitrilon.DataAccess
{
    public class EventRepository : Repository
    {

        public EventRepository() : base() { }
        

        //---------------------------------Event-----------------------------------------

        #region Event Methods
        /// <summary>
        /// DELETE: Delete an event from the database.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            try
            {
                string sql = $"DELETE FROM Events WHERE EventId = {id}";

                // Execute query:
                SqlDataReader reader = Execute(sql);

                // Close the connection when it is not needed anymore:
                CloseConnection();
            }
            catch (ArgumentException e)
            {
                throw new Exception(e.Message);
            }

            return;
        }

        /// <summary>
        /// GET: Get an event from the database.
        /// </summary>
        /// <returns></returns>
        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();

            try
            {
                string sql = "SELECT * FROM Events";
                                
                // Execute query:
                SqlDataReader reader = Execute(sql);

                // Retrieve data form the data reader:
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["EventId"]);
                    DateTime date = Convert.ToDateTime(reader["Date"]);
                    string name = Convert.ToString(reader["Name"]);
                    int attendees = Convert.ToInt32(reader["Attendees"]);
                    string description = Convert.ToString(reader["Description"]);

                    Event e = new Event(id, date, name, attendees, description);
                    events.Add(e);
                }

                // Close the connection when it is not needed anymore:
                CloseConnection();
            }
            catch (ArgumentException e)
            {
                throw new Exception(e.Message);
            }

            return events;
        }

        /// <summary>
        /// GET: Get an event from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Event GetOne(int id)
        {
            Event oneEvent = null;

            try
            {
                string sql = $"SELECT * FROM Events WHERE EventId = {id}";

                // Execute query:
                SqlDataReader reader = Execute(sql);

                // 5: Retrieve data form the data reader:
                if (reader.Read())
                {
                    int eventId = Convert.ToInt32(reader["EventId"]);
                    DateTime date = Convert.ToDateTime(reader["Date"]);
                    string name = Convert.ToString(reader["Name"]);
                    int attendees = Convert.ToInt32(reader["Attendees"]);
                    string description = Convert.ToString(reader["Description"]);

                    oneEvent = new Event(eventId, date, name, attendees, description);
                }

                // Close the connection when it is not needed anymore:
                CloseConnection();

                return oneEvent;
            }
            catch (ArgumentException e)
            {
                throw new Exception(e.Message);
            }

            return null;
        }

        /// <summary>
        /// PUT: Update an event in the database.
        /// </summary>
        /// <param name="eventToUpdate"></param>
        public void Update(Event eventToUpdate)
        {
            try
            {
                string sql = $"UPDATE Events SET Date = '{eventToUpdate.Date.ToString("yyyy-MM-dd")}', Name = '{eventToUpdate.Name}', Attendees = {eventToUpdate.Attendees}, Description = '{eventToUpdate.Description}' WHERE EventId = {eventToUpdate.Id}";

                // Execute query:
                SqlDataReader reader = Execute(sql);

                // Close the connection when it is not needed anymore:
                CloseConnection();
            }
            catch (ArgumentException e)
            {
                throw new Exception(e.Message);
            }

            return;
        }

        /// <summary>
        /// POST: Save new event to the database.
        /// </summary>
        /// <param name="newEvent"></param>
        /// <returns></returns>
        public int Save(Event newEvent)
        {
            int newId = 0;

            try
            {
                // TODO: handle attendees when the event is not yet over.
                // Don't forget to format the date as 'yy-MM-dd'.
                string sql = $"INSERT INTO Events (Date, Name, Attendees, Description) VALUES ('{newEvent.Date.ToString("yyyy-MM-dd")}', '{newEvent.Name}', {newEvent.Attendees}, '{newEvent.Description}'); SELECT SCOPE_IDENTITY();";

                // Execute the insert command and get the newly created id for the row:
                SqlDataReader sqlDataReader = Execute(sql);

                while (sqlDataReader.Read())
                {
                    newId = (int)sqlDataReader.GetDecimal(0);
                }

                // Close the connection when it is not needed anymore:
                CloseConnection();
            }
            catch (ArgumentException e)
            {
                throw new Exception(e.Message);
            }

            return newId;
        }

        /// <summary>
        /// GET: Get all active or future events from the database.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<Event> GetActiveOrFutureEvents()
        {
            List<Event> events = new List<Event>();

            try
            {
                DateTime date = DateTime.UtcNow;
                string sql = $"SELECT * FROM Events WHERE Date >= '{date.ToString("yyyy-MM-dd")}'";

                // 4: Execute query:
                SqlDataReader reader = Execute(sql);

                // 5: Retrieve data form the data reader:
                while (reader.Read())
                {
                    int eventId = Convert.ToInt32(reader["EventId"]);
                    DateTime newDate = Convert.ToDateTime(reader["Date"]);
                    string name = Convert.ToString(reader["Name"]);
                    int attendees = Convert.ToInt32(reader["Attendees"]);
                    string description = Convert.ToString(reader["Description"]);

                    Event e = new Event(eventId, newDate, name, attendees, description);
                    events.Add(e);
                }

                // Close the connection when it is not needed anymore:
                CloseConnection();
            }
            catch (ArgumentException e)
            {
                throw new Exception(e.Message);
            }

            return events;
        }

        /// <summary>
        /// GET: Get amount of ratings for an event.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public EventRatingData GetEventRatingDataBy(int eventId)
        {
            int horribleRatingCount = 0;
            int badRatingCount = 0;
            int neutralRatingCount = 0;
            int goodRatingCount = 0;
            int fantasticRatingCount = 0;
            EventRatingData eventRatingData = default;

            try
            {
                string sql = $"EXEC CountAllowedRatingsForEvent @EventId = {eventId}";

                // Execute query:
                SqlDataReader reader = Execute(sql);

                // Retrieve data form the data reader:
                if (reader.Read())
                {
                    horribleRatingCount = Convert.ToInt32(reader["RatingId1Count"]);
                    badRatingCount = Convert.ToInt32(reader["RatingId2Count"]);
                    neutralRatingCount = Convert.ToInt32(reader["RatingId3Count"]);
                    goodRatingCount = Convert.ToInt32(reader["RatingId4Count"]);
                    fantasticRatingCount = Convert.ToInt32(reader["RatingId5Count"]);
                    eventRatingData = new(horribleRatingCount, badRatingCount, neutralRatingCount, goodRatingCount, fantasticRatingCount);
                }

                // Close the connection when it is not needed anymore:
                CloseConnection();
            }
            catch (ArgumentException e)
            {
                throw new Exception(e.Message);
            }

            return eventRatingData;
        }
        #endregion

        //---------------------------------EventRating-----------------------------------

        #region EventRating Methods
        /// <summary>
        /// GET: Get all EventRatings from the database.
        /// </summary>
        /// <returns></returns>
        public List<EventRating> GetAllEventRatings()
        {
            List<EventRating> eventRatings = new List<EventRating>();

            try
            {
                string sql = "SELECT * FROM EventRatings";

                // Execute query:
                SqlDataReader reader = Execute(sql);

                // Retrieve data form the data reader:
                while (reader.Read())
                {
                    int eventRatingId = Convert.ToInt32(reader["EventRatingId"]);
                    int eventId = Convert.ToInt32(reader["EventId"]);
                    int ratingId = Convert.ToInt32(reader["RatingId"]);

                    EventRating EventRating = new()
                    {
                        EventRatingId = eventRatingId,
                        EventId = eventId,
                        RatingId = ratingId,
                    };

                    eventRatings.Add(EventRating);
                }

                // Close the connection when it is not needed anymore:
                CloseConnection();
            }
            catch (ArgumentException e)
            {
                throw new Exception(e.Message);
            }

            return eventRatings;
        }

        /// <summary>
        /// GET: Get an EventRating from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EventRating GetOneEventRating(int id)
        {
            try
            {
                string sql = $"SELECT * FROM EventRatings WHERE EventRatingId = {id}";

                // Execute query:
                SqlDataReader reader = Execute(sql);

                // Retrieve data form the data reader:
                if (reader.Read())
                {
                    int eventRatingId = Convert.ToInt32(reader["EventRatingId"]);
                    int eventId = Convert.ToInt32(reader["EventId"]);
                    int ratingId = Convert.ToInt32(reader["RatingId"]);

                    EventRating EventRating = new()
                    {
                        EventRatingId = eventRatingId,
                        EventId = eventId,
                        RatingId = ratingId,
                    };

                    // Close the connection when it is not needed anymore:
                    CloseConnection();

                    return EventRating;
                }
            }
            catch (ArgumentException e)
            {
                throw new Exception(e.Message);
            }

            return null;
        }

        /// <summary>
        /// POST: Save new EventRating to the database.
        /// </summary>
        /// <param name="newEventRating"></param>
        /// <returns></returns>
        public int SaveEventRating(int eventId, int ratingId)
        {
            int newId = 0;
            if (eventId <= 0)
            {
                return -1;
            }

            try
            {
                // TODO: handle attendees when the event is not yet over.
                // Don't forget to format a date as 'yyyy-MM-dd'
                string sql = $"INSERT INTO EventRatings (EventId, RatingId) VALUES ({eventId},{ratingId});";

                // Execute the insert command and get the newly created id for the row:
                SqlDataReader sqlDataReader = Execute(sql);

                while (sqlDataReader.Read())
                {
                    newId = (int)sqlDataReader.GetDecimal(0);
                }

                // Close the connection when it is not needed anymore:
                CloseConnection();
            }
            catch (ArgumentException e)
            {
                throw new Exception(e.Message);
            }

            return newId;
        }
        #endregion

    }
}
