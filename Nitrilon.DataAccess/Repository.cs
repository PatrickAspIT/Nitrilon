using Microsoft.Data.SqlClient;
using Nitrilon.Entities;

namespace Nitrilon.DataAccess
{
    public class Repository
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NitrilonDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";


        /// <summary>
        /// DELETE: Delete an event from the database.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
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

            return;
        }

        /// <summary>
        /// GET: Get an event from the database.
        /// </summary>
        /// <returns></returns>
        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();

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
            while(reader.Read())
            {
                int id = Convert.ToInt32(reader["EventId"]);
                DateTime date = Convert.ToDateTime(reader["Date"]);
                string name = Convert.ToString(reader["Name"]);
                int attendees = Convert.ToInt32(reader["Attendees"]);
                string description = Convert.ToString(reader["Description"]);

                Event e = new()
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

            return events;
        }

        public Event GetOne(int id)
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
            if(reader.Read())
            {
                int eventId = Convert.ToInt32(reader["EventId"]);
                DateTime date = Convert.ToDateTime(reader["Date"]);
                string name = Convert.ToString(reader["Name"]);
                int attendees = Convert.ToInt32(reader["Attendees"]);
                string description = Convert.ToString(reader["Description"]);

                Event e = new()
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

            return null;
        }

        /// <summary>
        /// PUT: Update an event in the database.
        /// </summary>
        /// <param name="eventToUpdate"></param>
        public void Update(Event eventToUpdate)
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
            //command.ExecuteNonQuery();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while(sqlDataReader.Read())
            {
                newId = (int)sqlDataReader.GetDecimal(0);
            }

            // 5: Close the connection when it is not needed anymore:
            connection.Close();

            return newId;
        }
    }
}
