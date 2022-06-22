using System;
using System.Data.SqlClient;

namespace _1._2_ADO_NET___Exercise
{
    public class QueriesMethods
    {
        public static void GetVilliamsName()
        {
            var connectionToDb = Config.ConnectionDatabase("MinionsDB");
            using (connectionToDb)
            {
                connectionToDb.Open();
                SqlCommand getVillianNames = new SqlCommand(DBQueries.GET_VILLIAN_NAMES, connectionToDb);
                SqlDataReader reader = getVillianNames.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetString(0)} - {reader.GetInt32(1)}");
                    }
                }
            }
        }

        public static void GetMinionNamesAndOwner()
        {
            Console.Write("Please enter Id: ");
            var id = Console.ReadLine();
            var connectionToDb = Config.ConnectionDatabase("MinionsDB");
            using (connectionToDb)
            {
                connectionToDb.Open();
                var queryString = DBQueries.GET_VILLIAN_WITH_ID.Replace("@Id", id);
                SqlCommand getOwner = new SqlCommand(queryString, connectionToDb);
                var result = getOwner.ExecuteScalar();

                if(result == null)
                {
                    Console.WriteLine($"No villain with ID {id} exists in the database.");
                    return;
                }

                Console.WriteLine($"Villain: {result}");

                queryString = DBQueries.GET_MINIONS_WITH_CURRENT_OWNER.Replace("@Id", id);
                SqlCommand getMinions = new SqlCommand(queryString, connectionToDb);

                SqlDataReader reader = getMinions.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");
                }
            }
        }

        public static void AddMinion()
        {
            Console.Write("You should add minion info");
            var minionInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Console.Write("You should add villian name");
            var villianName = Console.ReadLine();


        }
    }
}
