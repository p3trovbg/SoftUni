using System;
using System.Data.SqlClient;

namespace _01.ADO_NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=localhost;User Id=sa;Password=Softuni!23;Database=SoftUni;";
            try
            {
                using
               (
               SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Successfull login!");


                    //Employee count command
                    string query = @"SELECT COUNT(*)
                                       FROM Employees";
                    var command = new SqlCommand(query, connection);
                    var count = command.ExecuteScalar();
                    Console.WriteLine($"Online people: {count}");


                    //Employees information
                    string input = String.Empty;
                    while (input != "Close")
                    {
                        Console.WriteLine("Input your command");
                        input = Console.ReadLine();
                        //Here, we can invoke this command many times.
                        if (input == "Give me all employees")
                        {
                            ReadAllEmployees(connection, out query, out command);
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Wrong username or password!");
                Console.WriteLine(ex.Number);
            }

        }

        private static void ReadAllEmployees(SqlConnection connection, out string query, out SqlCommand command)
        {
            query = @"SELECT 
                                FirstName, 
                                LastName,
                                JobTitle
                                FROM Employees";

            command = new SqlCommand(query, connection);
            var reader = command.ExecuteReader();
            var idx = 1;
            while (reader.Read())
            {
                string firstName = (string)reader.GetString(0);
                string lastName = (string)reader.GetString(1);
                string jobTitle = (string)reader.GetString(2);
                Console.WriteLine("===============================================");
                Console.WriteLine($"{idx++}.{firstName} {lastName} -> Job name: {jobTitle}");
            }

            reader.Close();
        }
    }
}
