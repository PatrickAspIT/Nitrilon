using Microsoft.Data.SqlClient;

namespace Nitrilon.DataAccess
{
    public class Repository
    {
        protected const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NitrilonDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        private SqlConnection connection;

        public Repository()
        {
            if (!CanConnect())
            {
                throw new Exception("Cannot connect to the database.");
            }
        }

        protected void CloseConnection()
        {
            if (connection != null && connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        protected SqlDataReader Execute(string sql)
        {
            if (sql is null)
            {
                throw new ArgumentNullException(nameof(sql));
            }

            // 1: Make a sqlConnection object:
            connection = new SqlConnection(connectionString);

            // 2: Make a sqlCommand object:
            SqlCommand command = new(sql, connection);

            // 3: Open the connection:
            connection.Open();

            // 4: Execute query:
            SqlDataReader reader = command.ExecuteReader();

            // 5: Return the data reader:
            return reader;
        }

        public bool CanConnect()
        {
            try
            {
                SqlConnection sqlConnection = new(connectionString);
                sqlConnection.Open();
                sqlConnection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }        
    }
}
