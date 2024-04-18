using Microsoft.Data.SqlClient;
using Nitrilon.Entities;

namespace Nitrilon.DataAccess
{
    public class Repository
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NitrilonDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        //---------------------------------Event-----------------------------------------

        /// <summary>
        /// DELETE: Delete an event from the database.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            try
            {
                string sql = $"DELETE FROM Events WHERE EventId = {id}";

                // 1: Make a sqlConnection object:
                SqlConnection connection = new SqlConnection(connectionString);

                // 2: Make a sqlCommand object:
                SqlCommand command = new SqlCommand(sql, connection);

                // 3: Open the connection:
                connection.Open();

                // 4: Execute the delete command:
                command.ExecuteNonQuery();

                // 5: Close the connection when it is not needed anymore:
                connection.Close();
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

                // 1: Make a sqlConnection object:
                SqlConnection connection = new SqlConnection(connectionString);

                // 2: Make a sqlCommand object:
                SqlCommand command = new SqlCommand(sql, connection);

                // 3: Open the connection:
                connection.Open();

                // 4: Execute query:
                SqlDataReader reader = command.ExecuteReader();

                // 5: Retrieve data form the data reader:
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["EventId"]);
                    DateTime date = Convert.ToDateTime(reader["Date"]);
                    string name = Convert.ToString(reader["Name"]);
                    int attendees = Convert.ToInt32(reader["Attendees"]);
                    string description = Convert.ToString(reader["Description"]);

                    Event e = new(id, date, name, attendees, description)
                    {
                        Id = id,
                        Date = date,
                        Name = name,
                        Attendees = attendees,
                        Description = description,
                    };

                    events.Add(e);
                }

                // 6: Close the connection when it is not needed anymore:
                connection.Close();
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
            try
            {
                string sql = $"SELECT * FROM Events WHERE EventId = {id}";

                // 1: Make a sqlConnection object:
                SqlConnection connection = new SqlConnection(connectionString);

                // 2: Make a sqlCommand object:
                SqlCommand command = new SqlCommand(sql, connection);

                // 3: Open the connection:
                connection.Open();

                // 4: Execute query:
                SqlDataReader reader = command.ExecuteReader();

                // 5: Retrieve data form the data reader:
                if (reader.Read())
                {
                    int eventId = Convert.ToInt32(reader["EventId"]);
                    DateTime date = Convert.ToDateTime(reader["Date"]);
                    string name = Convert.ToString(reader["Name"]);
                    int attendees = Convert.ToInt32(reader["Attendees"]);
                    string description = Convert.ToString(reader["Description"]);

                    Event e = new(eventId, date, name, attendees, description)
                    {
                        Id = eventId,
                        Date = date,
                        Name = name,
                        Attendees = attendees,
                        Description = description,
                    };

                    // 6: Close the connection when it is not needed anymore:
                    connection.Close();

                    return e;
                }
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

                // 1: Make a sqlConnection object:
                SqlConnection connection = new SqlConnection(connectionString);

                // 2: Make a sqlCommand object:
                SqlCommand command = new SqlCommand(sql, connection);

                // 3: Open the connection:
                connection.Open();

                // 4: Execute the update command:
                command.ExecuteNonQuery();

                // 5: Close the connection when it is not needed anymore:
                connection.Close();
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

                // 1: Make a sqlConnection object:
                SqlConnection connection = new SqlConnection(connectionString);

                // 2: Make a sqlCommand object:
                SqlCommand command = new SqlCommand(sql, connection);

                // 3: Open the connection:
                connection.Open();

                // 4: Execute the insert command and ge the newly created id for the row:
                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    newId = (int)sqlDataReader.GetDecimal(0);
                }

                // 5: Close the connection when it is not needed anymore:
                connection.Close();
            }
            catch (ArgumentException e)
            {
                throw new Exception(e.Message);
            }            

            return newId;
        }

        public string GetActiveOrFutureEvents()
        {
            List<Event> events = new List<Event>();
            string returnValues = "";

            try
            {
                DateTime date = DateTime.UtcNow;
                string sql = $"SELECT * FROM Events WHERE Date >= '{date.ToString("yyyy-MM-dd")}'";

                // 1: Make a sqlConnection object:
                SqlConnection connection = new SqlConnection(connectionString);

                // 2: Make a sqlCommand object:
                SqlCommand command = new SqlCommand(sql, connection);

                // 3: Open the connection:
                connection.Open();

                // 4: Execute query:
                SqlDataReader reader = command.ExecuteReader();

                // 5: Retrieve data form the data reader:
                if (reader.Read())
                {
                    int eventId = Convert.ToInt32(reader["EventId"]);
                    DateTime newDate = Convert.ToDateTime(reader["Date"]);
                    string name = Convert.ToString(reader["Name"]);
                    int attendees = Convert.ToInt32(reader["Attendees"]);
                    string description = Convert.ToString(reader["Description"]);

                    Event e = new(eventId, newDate, name, attendees, description)
                    {
                        Id = eventId,
                        Date = newDate,
                        Name = name,
                        Attendees = attendees,
                        Description = description,
                    };

                    events.Add(e);
                }

                // 6: Close the connection when it is not needed anymore:
                connection.Close();

                // Check what this does:
                for (int i = 0; i < events.Count; i++)
                {
                    returnValues += events[i].Id.ToString() + ": ";
                    returnValues += events[i].Name;
                    returnValues += " (" + events[i].Date.ToString("yyyy-MM-dd");
                    returnValues += ") | ";
                }
            }
            catch (ArgumentException e)
            {
                throw new Exception(e.Message);
            }

            return returnValues;
        }

        //---------------------------------EventRating-----------------------------------

        ///// <summary>
        ///// DELETE: Delete an EventRating from the database.
        ///// </summary>
        ///// <param name="id"></param>
        //public void DeleteEventRating(int id)
        //{
        //    string sql = $"DELETE FROM EventRatings WHERE EventRatingId = {id}";

        //    // 1: Make a sqlConnection object:
        //    SqlConnection connection = new SqlConnection(connectionString);

        //    // 2: Make a sqlCommand object:
        //    SqlCommand command = new SqlCommand(sql, connection);

        //    // 3: Open the connection:
        //    connection.Open();

        //    // 4: Execute the delete command:
        //    command.ExecuteNonQuery();

        //    // 5: Close the connection when it is not needed anymore:
        //    connection.Close();

        //    return;
        //}

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

                // 1: Make a sqlConnection object:
                SqlConnection connection = new SqlConnection(connectionString);

                // 2: Make a sqlCommand object:
                SqlCommand command = new SqlCommand(sql, connection);

                // 3: Open the connection:
                connection.Open();

                // 4: Execute query:
                SqlDataReader reader = command.ExecuteReader();

                // 5: Retrieve data form the data reader:
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

                // 6: Close the connection when it is not needed anymore:
                connection.Close();
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

                // 1: Make a sqlConnection object:
                SqlConnection connection = new SqlConnection(connectionString);

                // 2: Make a sqlCommand object:
                SqlCommand command = new SqlCommand(sql, connection);

                // 3: Open the connection:
                connection.Open();

                // 4: Execute query:
                SqlDataReader reader = command.ExecuteReader();

                // 5: Retrieve data form the data reader:
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

                    // 6: Close the connection when it is not needed anymore:
                    connection.Close();

                    return EventRating;
                }
            }
            catch (ArgumentException e)
            {
                throw new Exception(e.Message);
            }            

            return null;
        }

        ///// <summary>
        ///// PUT: Update an EventRating in the database.
        ///// </summary>
        ///// <param name="eventRatingToUpdate"></param>
        //public void UpdateEventRating(EventRating eventRatingToUpdate)
        //{
        //    string sql = $"UPDATE EventRatings SET EventId = {eventRatingToUpdate.EventId}, RatingId = {eventRatingToUpdate.RatingId} WHERE EventRatingId = {eventRatingToUpdate.EventRatingId}";

        //    // 1: Make a sqlConnection object:
        //    SqlConnection connection = new SqlConnection(connectionString);

        //    // 2: Make a sqlCommand object:
        //    SqlCommand command = new SqlCommand(sql, connection);

        //    // 3: Open the connection:
        //    connection.Open();

        //    // 4: Execute the update command:
        //    command.ExecuteNonQuery();

        //    // 5: Close the connection when it is not needed anymore:
        //    connection.Close();

        //    return;
        //}

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

                // 1: make a SqlConnection object:
                SqlConnection connection = new SqlConnection(connectionString);

                // 2: make a SqlCommand object:
                SqlCommand command = new SqlCommand(sql, connection);

                // 3. Open the connection:
                connection.Open();

                // 4. Execute the insert command and get the newly created id for the row:
                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    newId = (int)sqlDataReader.GetDecimal(0);
                }

                // 5. Close the connection when it is not needed anymore:
                connection.Close();
            }
            catch (ArgumentException e)
            {
                throw new Exception(e.Message);
            }            

            return newId;
        }

        void M()
        {
            Event e = new Event(1, DateTime.Now, "Mads", 1, null);
        }
    }
}
