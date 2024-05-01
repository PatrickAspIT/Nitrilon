﻿using Microsoft.Data.SqlClient;
using Nitrilon.Entities;

namespace Nitrilon.DataAccess
{
    public class MemberRepository : Repository
    {

        public MemberRepository() : base() { }

        //---------------------------------Member----------------------------------------

        #region Member Methods
        /// <summary>
        /// GET: Get all members from the database.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<Member> GetAllMembers()
        {
            List<Member> members = new List<Member>();

            try
            {
                string sql = "SELECT * FROM Members";

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
                    int id = Convert.ToInt32(reader["MemberId"]);
                    string name = Convert.ToString(reader["Name"]);
                    string phoneNumber = Convert.ToString(reader["PhoneNumber"]);
                    string email = Convert.ToString(reader["Email"]);
                    DateTime date = Convert.ToDateTime(reader["Date"]);
                    int membershipId = Convert.ToInt32(reader["MembershipId"]);

                    try
                    {
                        Member e = new Member(id, name, phoneNumber, email, date, membershipId);
                        members.Add(e);
                    }
                    catch (ArgumentException Ex)
                    {
                        throw new Exception(Ex.Message);
                    };
                }

                // 6: Close the connection when it is not needed anymore:
                connection.Close();
            }
            catch (ArgumentException e)
            {
                throw new Exception(e.Message);
            }

            return members;
        }

        /// <summary>
        /// POST: Add a new member to the database.
        /// </summary>
        /// <param name="member"></param>
        /// <exception cref="Exception"></exception>
        public void AddMember(Member member)
        {
            try
            {
                string sql = $"INSERT INTO Members (Name, PhoneNumber, Email, Date, MembershipId) VALUES ('{member.Name}', '{member.PhoneNumber}', '{member.Email}', '{member.Date.ToString("yyyy-MM-dd")}', {member.MembershipId}); SELECT SCOPE_IDENTITY();";

                // 1: Make a sqlConnection object:
                SqlConnection connection = new SqlConnection(connectionString);

                // 2: Make a sqlCommand object:
                SqlCommand command = new SqlCommand(sql, connection);

                // 3: Open the connection:
                connection.Open();

                // 4: Execute the insert command:
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
        /// DELETE: Delete a member from the database.
        /// </summary>
        /// <param name="memberId"></param>
        /// <exception cref="Exception"></exception>
        public void DeleteMember(int memberId)
        {
            try
            {
                string sql = $"DELETE FROM Members WHERE MemberId = {memberId}";

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
        /// PUT: Update a member in the database.
        /// </summary>
        /// <param name="member"></param>
        /// <exception cref="Exception"></exception>
        public void UpdateMember(int memberId, Member member)
        {
            try
            {
                string sql = $"UPDATE Members SET Name = '{member.Name}', PhoneNumber = '{member.PhoneNumber}', Email = '{member.Email}', Date = '{member.Date.ToString("yyyy-MM-dd")}', MembershipId = {member.MembershipId} WHERE MemberId = {memberId}";

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
        #endregion

    }
}