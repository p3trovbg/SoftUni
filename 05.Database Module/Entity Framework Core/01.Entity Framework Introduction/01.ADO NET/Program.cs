using System;
using System.Data.SqlClient;

namespace _01.ADO_NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using
                (
                SqlConnection conn = new SqlConnection("Server=localhost;User Id=sa;Password=Softuni!23;Database=SoftUni;"))
            {
                conn.Open();
            }

        }
    }
}
