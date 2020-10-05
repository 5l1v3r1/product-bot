using ProductBot.Entities;
using ProductBot.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ProductBot.DataAccessLayer
{
    class MailDal : DatabaseConnection
    {
        HandleException handle;

        public MailDal()
        {
            handle = new HandleException();
        }

        public int Save(Email mail)
        {
            return handle.ExceptionTypeHandler<int>(() =>
            {
                string query = "INSERT INTO dbo.e_mails(mail_address,price_percent) output INSERTED.id VALUES(@mail_address,@price_percent)";
                using (command = new SqlCommand(query, connection))
                {

                    command.Parameters.Add("@mail_address", SqlDbType.VarChar, 150).Value = mail.MailAddress;
                    command.Parameters.Add("@price_percent", SqlDbType.Int).Value = mail.PricePercent;

                    ConnectionControl();
                    int mailID = Convert.ToInt32(command.ExecuteScalar());
                    ConnectionControl();

                    return mailID;

                };
            });

            return 0;

        }
    }
}
