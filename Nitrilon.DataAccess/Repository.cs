using Microsoft.Data.SqlClient;
using Nitrilon.Entities;

namespace Nitrilon.DataAccess
{
    public class Repository
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NitrilonDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        // DELETE: Delete an event from the database.
        public void Delete(int id)
        {
            string sql = $"DELETE FROM Events WHERE EventId = {id}";

            // 1: Make a sqlConnection object:
            SqlConnection connection = new SqlConnection(connectionString);

            // 2: Make a sqlCommand object:
            SqlCommand command = new SqlCommand(sql, connection);

            // TODO: try catchify this:
            // 3: Open the connection:
            connection.Open();

            // 4: Execute the delete command:
            command.ExecuteNonQuery();

            // 5: Close the connection when it is not needed anymore:
            connection.Close();

            return;
        }

        // GET: Get all events from the database.
        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();

            string sql = "SELECT * FROM Events";

            // 1: Make a sqlConnection object:
            SqlConnection connection = new SqlConnection(connectionString);

            // 2: Make a sqlCommand object:
            SqlCommand command = new SqlCommand(sql, connection);

            // TODO: try catchify this:
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

        // POST: Save new event to the database.
        public int Save(Event newEvent)
        {
            // TODO: handle attendees when the event is not yet over.
            // Don't forget to format the date as 'yy-MM-dd'.
            string sql = $"INSERT INTO Events (Date, Name, Attendees, Description) VALUES ('{newEvent.Date.ToString("yyyy-MM-dd")}', '{newEvent.Name}', {newEvent.Attendees}, '{newEvent.Description}')";

            // 1: Make a sqlConnection object:
            SqlConnection connection = new SqlConnection(connectionString);

            // 2: Make a sqlCommand object:
            SqlCommand command = new SqlCommand(sql, connection);
            
            // TODO: try catchify this:
            // 3: Open the connection:
            connection.Open();

            // TODO: figure out how to get the new id created in the table.
            // 4: Execute the insert command:
            command.ExecuteNonQuery();

            // 5: Close the connection when it is not needed anymore:
            connection.Close();

            return -1;
        }
    }
}
