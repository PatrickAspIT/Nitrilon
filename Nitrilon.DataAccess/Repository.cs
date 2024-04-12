using Microsoft.Data.SqlClient;
using Nitrilon.Entities;

namespace Nitrilon.DataAccess
{
    public class Repository
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NitrilonDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        // Save new event to the database.
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

        // Get all events from the database.
        public List<Event> GetAllEvents()
        {
            return new List<Event>();
        }
    }
}
