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
            var villianId = Console.ReadLine();
            var connectionToDb = Config.ConnectionDatabase("MinionsDB");
            using (connectionToDb)
            {
                connectionToDb.Open();
                SqlCommand getOwner = new SqlCommand(DBQueries.GET_VILLIAN_BY_ID, connectionToDb);
                getOwner.Parameters.AddWithValue("@Id", villianId);
                var result = getOwner.ExecuteScalar();

                if(result == null)
                {
                    Console.WriteLine($"No villain with ID {villianId} exists in the database.");
                    return;
                }

                Console.WriteLine($"Villain: {result}");

                SqlCommand getMinions = new SqlCommand(DBQueries.GET_MINIONS_WITH_CURRENT_OWNER, connectionToDb);
                getMinions.Parameters.AddWithValue("@Id", villianId);

                SqlDataReader reader = getMinions.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");
                }
            }
        }

        public static void AddMinion()
        {
            Console.Write("You should add minion info(name, age, city): ");
            var minionInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var minionName = minionInfo[0];
            var minionAge = minionInfo[1];
            var minionTown = minionInfo[2];

            Console.Write("You should add villian name: ");
            var villianName = Console.ReadLine();

            using var connectionToDb = Config.ConnectionDatabase("MinionsDB");
            connectionToDb.Open();
            SqlTransaction transaction = connectionToDb.BeginTransaction();
            try
            {
                if(GetTown(connectionToDb, minionTown, transaction) == null)
                {
                    AddTown(connectionToDb, minionTown, transaction);
                }

                if (GetVillian(connectionToDb, villianName, transaction) == null)
                {
                    AddVillian(connectionToDb, villianName, transaction);
                }

                InsertMinion(connectionToDb, minionName, minionAge, minionTown, villianName, transaction);

                Console.WriteLine($"Successfully added {minionName} to be minion of {villianName}.");

                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            }


        }

        private static void InsertMinion(SqlConnection connectionToDb, string minionName, string minionAge, string minionTown, string villianName, SqlTransaction transaction)
        {
            var insertMinionCommand = new SqlCommand(DBQueries.ADD_Minion, connectionToDb, transaction);
            insertMinionCommand.Parameters.AddWithValue("@nam", minionName);
            insertMinionCommand.Parameters.AddWithValue("@age", minionAge);
            insertMinionCommand.Parameters.AddWithValue("@townId", (int)GetTown(connectionToDb, minionTown, transaction));

            insertMinionCommand.ExecuteNonQuery();

            AddMinionToTheVillian(connectionToDb, minionName,minionAge, minionTown, villianName, transaction);
        }

        private static void AddMinionToTheVillian(SqlConnection connectionToDb, string minionName, string minionAge, string minionTown, string villianName, SqlTransaction transaction)
        {
            var addMinionToVillianCommand = new SqlCommand(DBQueries.ADD_MINIONS_VILLAINS, connectionToDb, transaction);
            addMinionToVillianCommand.Parameters.AddWithValue("@villainId", (int)GetVillian(connectionToDb, villianName, transaction));
            addMinionToVillianCommand.Parameters.AddWithValue(@"minionId", (int)GetMinion(connectionToDb, minionName, minionTown,minionAge, transaction));
        }

        private static int GetMinion(SqlConnection connectionToDb, string minionName, string minionTown, string minionAge, SqlTransaction transaction)
        {
            var getMinionCommand = new SqlCommand(DBQueries.GET_MINION_BY_FULL_INFO, connectionToDb, transaction);
            getMinionCommand.Parameters.AddWithValue("@name", minionName);
            getMinionCommand.Parameters.AddWithValue("@age", minionAge);
            getMinionCommand.Parameters.AddWithValue("@townId", (int)GetTown(connectionToDb, minionTown, transaction));

            return (int)getMinionCommand.ExecuteScalar();
        }

        private static void AddVillian(SqlConnection connectionToDb, string villainName, SqlTransaction transaction)
        {
            var addVillianCommand = new SqlCommand(DBQueries.ADD_VILLAIN, connectionToDb, transaction);
            addVillianCommand.Parameters.AddWithValue("@villainName", villainName);

            addVillianCommand.ExecuteNonQuery();
            Console.WriteLine($"Villain {villainName} was added to the database.");
        }

        private static object GetVillian(SqlConnection connectionToDb, string villainName, SqlTransaction transaction)
        {
            SqlCommand getVillianCommand
               = new SqlCommand(DBQueries.GET_VILLAIN_BY_NAME, connectionToDb, transaction);
            getVillianCommand.Parameters.AddWithValue("@Name", villainName);

            var villian = getVillianCommand.ExecuteScalar();
           
            return villian;
        }

        private static void AddTown(SqlConnection connectionToDb, string minionTown, SqlTransaction transaction)
        {
            var addTownCommand = new SqlCommand(DBQueries.ADD_TOWN, connectionToDb, transaction);
            addTownCommand.Parameters.AddWithValue("@townName", minionTown);
            addTownCommand.ExecuteNonQuery();
            Console.WriteLine($"Town {minionTown} was added to the database.");
        }

        private static object GetTown(SqlConnection connectionToDb, string minionTown, SqlTransaction transaction)
        {
            SqlCommand getTownCommand
                = new SqlCommand(DBQueries.GET_TOWN_BY_NAME, connectionToDb, transaction);
            getTownCommand.Parameters.AddWithValue("@townName", minionTown);

            var city = getTownCommand.ExecuteScalar();

            return city;
        }
    }
}
