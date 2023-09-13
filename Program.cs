using System;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Poo
{
    public static class Program
    {
        static readonly string InsertQuery = "INSERT INTO [Usuario] (username, email, [password], isRandomPassword) VALUES(@username, @email,               @password,@isRandomPassword )";

        static readonly string updateQuery = "UPDATE [Usuario] SET [Username]=@username, [Email]=@email, [Password]=@password, [IsRandomPassword]=@isRandomPassword WHERE [Id]=@id";

        static readonly string deleteUserQuery = "DELETE [Usuario] WHERE [Id]=@id";


        public static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=BIManager;User ID=sa;Password=password123@";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            ListUsers(connection);

        }

        static void ListUsers(SqlConnection connection)
        {
            var users = connection.Query<Usuario>("SELECT * FROM [Usuario]");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id} - {user.Username} - {user.Email} - {user.Password} - {user.IsRandomPassword}");
            }
        }

        static void CreateUser(SqlConnection connection, Usuario user)
        {
            var affectedRows = connection.Execute(InsertQuery, user);
            Console.WriteLine($"Inserted {affectedRows} registers");
        }

        static void CreateManyUsers(SqlConnection connection, Usuario[] users)
        {
            var affectedRows = connection.Execute(InsertQuery, users);
            Console.WriteLine($"Inserted {affectedRows} registers");
        }

        static void UpdateUser(SqlConnection connection, int id, Usuario user)
        {
            var affectedRows = connection.Execute(updateQuery, new
            {
                user.Username,
                user.Email,
                user.Password,
                user.IsRandomPassword,
                id

            });
            Console.WriteLine($"Updated {affectedRows} registers.");
        }

        static void UpdateManyUsers(SqlConnection connection, int[] userIds, Usuario[] users)
        {
            var counter = 0;
            foreach (var user in users)
            {
                user.Id = userIds[counter];
                counter++;
            }
            var affectedRows = connection.Execute(updateQuery, users);
            Console.WriteLine($"Updated {affectedRows} registers.");
        }

        static void DeleteUser(SqlConnection connection, int id)
        {

            var rows = connection.Execute(deleteUserQuery, new { id });
            Console.WriteLine($"Deleted {rows} registers.");
        }

        static void DeleteManyUsers(SqlConnection connection, int[] userIds)
        {
            var affectedRows = connection.Execute(
                deleteUserQuery,
                userIds.Select(id => new { id = id }).ToArray()
                );
            Console.WriteLine($"Deleted {affectedRows} registers.");
        }
    }
}
