using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CustomerManagerADO.NET
{
    class SQLConnect
    {
        private SqlConnection con;

        public SQLConnect()
        {
            OpenConnection();
        }

        
        public SqlConnection OpenConnection()
        {
            Console.WriteLine("Getting connection......");

            var datasource = @"DESKTOP-9J9P6UP\SQLExpress";
            var database = "Customer";
            var username = "sa";
            var password = "parsnip";


            string connectionString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";User ID=" + username + ";Password=" + password;


            con = new SqlConnection(connectionString);

            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                con.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }


            return (con);

        }

        public void CloseConnection()
        {
            con.Close();
        }
        
    }
}
