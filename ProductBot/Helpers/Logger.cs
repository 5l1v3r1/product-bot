using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Text;

namespace ProductBot.Helpers
{
    class Logger
    {
        private String CurrentDirectory
        {
            get;
            set;
        }

        private String AppFileName
        {
            get;
            set;
        }

        private String SQLFileName
        {
            get;
            set;
        }

        private String MailFileName { get; set; }
        private String MailFilePath { get; set; }

        private String AppFilePath
        {
            get;
            set;
        }

        private String SQLFilePath
        {
            get;
            set;
        }

        private FileStream FileStreamer
        {
            get;
            set;
        }

        private StreamWriter FileWriter
        {
            get;
            set;
        }
        public Logger()
        {

            try
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\logs");
                CurrentDirectory = Directory.GetCurrentDirectory();
                AppFileName = "/logs/App.log";
                SQLFileName = "/logs/SQL.log";
                MailFileName = "logs/Mail.log";
                AppFilePath = CurrentDirectory + AppFileName;
                SQLFilePath = CurrentDirectory + SQLFileName;
                MailFileName = CurrentDirectory + MailFileName;

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }


        }

        public void DatabaseErrorLog(StringBuilder log)
        {
            try
            {

                if (!File.Exists(SQLFilePath))
                {

                    using (FileWriter = File.CreateText(SQLFilePath))
                    {
                        FileWriter.WriteLine(log);
                        FileWriter.Flush();
                    }
                }
                else
                {
                    using (FileWriter = File.AppendText(SQLFilePath))
                    {

                        FileWriter.WriteLine(log);
                        FileWriter.Flush();
                    };
                }


            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {

                FileWriter.Close();
            }

        }


        public void AppErrorLog(StringBuilder log)
        {
            try
            {
                if (!File.Exists(AppFilePath))
                {

                    using (FileWriter = File.CreateText(AppFilePath))
                    {
                        FileWriter.WriteLine(log);
                        FileWriter.Flush();
                    }
                }
                else
                {
                    using (FileWriter = File.AppendText(AppFilePath))
                    {

                        FileWriter.WriteLine(log);
                        FileWriter.Flush();
                    };
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {

                FileWriter.Close();
            }

        }

        public void MailErrorLog(StringBuilder log)
        {
            try
            {
                if (!File.Exists(MailFilePath))
                {

                    using (FileWriter = File.CreateText(MailFilePath))
                    {
                        FileWriter.WriteLine(log);
                        FileWriter.Flush();
                    }
                }
                else
                {
                    using (FileWriter = File.AppendText(MailFilePath))
                    {

                        FileWriter.WriteLine(log);
                        FileWriter.Flush();
                    };
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {

                FileWriter.Close();
            }

        }


    }
}
