using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ProductBot.DataAccessLayer
{
    class DatabaseConnection
    {
        protected SqlConnection connection { get; set; }
        protected SqlCommand command { get; set; }
        protected SqlDataReader reader { get; set; }

        private Configuration config;

        public DatabaseConnection()
        {
            config = new Configuration();

            connection = new SqlConnection(config.DatabaseConfig<string>("connection_string"));
            /*            connection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=sahibinden;Trusted_Connection=True;");
            */
        }

        public void ConnectionControl()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            else
            {
                connection.Close();
            }
        }

        public void ConnectionClosed()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
