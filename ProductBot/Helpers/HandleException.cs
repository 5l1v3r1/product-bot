using ProductBot.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace ProductBot.Helpers
{
    class HandleException
    {
        private DatabaseConnection database;
        private Logger logger;

        public HandleException()
        {
            database = new DatabaseConnection();
            logger = new Logger();
        }

        public void ExceptionHandler(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (SqlException exception)
            {
                DatabaseHandleException(exception.Errors);
            }
            catch (SmtpException exception)
            {
                MailHandleException(exception);
            }
            catch (Exception exception)
            {
                AppHandleException(exception);

            }
        }

        public T ExceptionTypeHandler<T>(Func<T> func)
        {
            try
            {
               return (T)func.Invoke();
                
            }
            catch (SqlException exception)
            {
                DatabaseHandleException(exception.Errors);
            }
            catch (SmtpException exception)
            {
                MailHandleException(exception);
            }
            catch (Exception exception)
            {
                AppHandleException(exception);

            }
            return default(T);
            
        }
        public void DatabaseHandleException(SqlErrorCollection errors)
        {

            database.ConnectionClosed();

            StringBuilder log = new StringBuilder();

            foreach (SqlError error in errors)
            {
                log.AppendLine("Date:");
                log.Append(DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString());
                log.Append(Environment.NewLine);
                log.AppendLine("Error Line :");
                log.Append(error.LineNumber);
                log.Append(Environment.NewLine);
                log.AppendLine("Message :");
                log.Append(error.Message);
                log.Append(Environment.NewLine);
                log.AppendLine("No :");
                log.Append(error.Number);
                log.Append(Environment.NewLine);
                log.AppendLine("Procedure :");
                log.Append(error.Procedure);
                log.Append(Environment.NewLine);
                log.AppendLine("Source");
                log.Append(error.Source);
                log.Append(Environment.NewLine);
                log.AppendLine("Server");
                log.Append(error.Server);
                log.Append(Environment.NewLine);
                log.Append(Environment.NewLine);

                log.Append("----------------------------------");

            }

            logger.DatabaseErrorLog(log);


        }

        public void AppHandleException(Exception error)
        {

            StringBuilder log = new StringBuilder();

            log.AppendLine("Date:");
            log.Append(DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString());
            log.Append(Environment.NewLine);
            log.AppendLine("Error Line :");
            log.Append(error.StackTrace);
            log.Append(Environment.NewLine);
            log.AppendLine("Message :");
            log.Append(error.Message);
            log.Append(Environment.NewLine);
            log.Append(Environment.NewLine);

            log.Append("----------------------------------");

            logger.AppErrorLog(log);

        }

        public void MailHandleException(SmtpException exception)
        {

            StringBuilder log = new StringBuilder();

            log.AppendLine("Date:");
            log.Append(DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString());
            log.Append(Environment.NewLine);
            log.AppendLine("Error Line :");
            log.Append(exception.StackTrace);
            log.Append(Environment.NewLine);
            log.AppendLine("Message :");
            log.Append(exception.Message);
            log.Append(Environment.NewLine);
            log.Append(Environment.NewLine);

            log.Append("----------------------------------");

            logger.MailErrorLog(log);

        }
    }
}


