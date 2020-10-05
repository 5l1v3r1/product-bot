using ProductBot.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ProductBot.DataAccessLayer
{
    internal class StatisticDal : DatabaseConnection
    {
        HandleException handle;

        public StatisticDal()
        {
            handle = new HandleException();
        }

        public void Show()
        {
            handle.ExceptionHandler(() =>
            {
                using (command = new SqlCommand("Select * From [user]", connection))
                {

                    ConnectionControl();

                    using (reader = command.ExecuteReader())
                    {
                        reader.Read();

                        Console.WriteLine(reader[0]);
                        Console.WriteLine(reader[1]);
                        Console.WriteLine(reader[2]);
                    }

                };
            });

        }

    }
}
