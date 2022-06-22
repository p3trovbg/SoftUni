using System;
using System.Data.SqlClient;

namespace _1._2_ADO_NET___Exercise
{
    public class Config
    {
        public const string ConnectionMasterDB =
            "Server=localhost;Database=master;User=sa;Password=Softuni!23;Trusted_Connection=False;MultipleActiveResultSets=true;Encrypt=false";


        public static void CreateDatabase(string databaseName)
        {
            try
            {
                SqlConnection connectionToMaster = new SqlConnection(ConnectionMasterDB);

                using(connectionToMaster)
                {
                    connectionToMaster.Open();
                    SqlCommand createMinionsDB = new SqlCommand($"CREATE DATABASE {databaseName}", connectionToMaster);
                    createMinionsDB.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static SqlConnection ConnectionDatabase(string databaseName)
        {
            string connectionString =
            @$"Server=localhost;
               Database={databaseName};
               User=sa;
               Password=Softuni!23;
               Trusted_Connection=False;
               MultipleActiveResultSets=true;
               Encrypt=false";

            try
            {
                SqlConnection connectionToDb = new SqlConnection(connectionString);
                return connectionToDb;        
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
