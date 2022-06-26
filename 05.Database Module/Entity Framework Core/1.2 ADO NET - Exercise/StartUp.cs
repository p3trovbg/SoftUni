using System;
using System.Data.SqlClient;

namespace _1._2_ADO_NET___Exercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please write 1 if you want to create a database");
            Console.WriteLine("Please write 2 if you want to connect with a database");
            Console.WriteLine("Please write 3 if you want to get villian names");
            Console.WriteLine("Please write 4 if you want to get minions and them owner");
            Console.WriteLine("Please write 5 if you want to add minion to current villian");
            try
            {
                var input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.Write("Write name on database: ");
                        Config.CreateDatabase(Console.ReadLine());
                        break;
                    case 2:
                        Console.Write("Write name on database: ");
                        ConnectWithDatabase(Console.ReadLine());
                        break;
                    case 3:
                        QueriesMethods.GetVilliamsName();
                        break;
                    case 4:
                        QueriesMethods.GetMinionNamesAndOwner();
                        break;
                    case 5:
                        QueriesMethods.AddMinion();
                        break;
                    default:
                        break;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }




            static void ConnectWithDatabase(string databaseName)
            {
                var connectionToDb = Config.ConnectionDatabase(databaseName);
                using (connectionToDb)
                {
                    //CREATE TABLES
                    connectionToDb.Open();
                    SqlCommand createTablesCommand = new SqlCommand(DBQueries.CREATE_TABLES_MINIONS_DB, connectionToDb);
                    createTablesCommand.ExecuteNonQuery();

                    //INSERT DATA
                    SqlCommand insertIntoTablesCommand = new SqlCommand(DBQueries.INSERT_INTO_TABLES_MINIONS_DB, connectionToDb);
                    insertIntoTablesCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
