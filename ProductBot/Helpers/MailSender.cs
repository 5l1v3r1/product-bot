using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace ProductBot.Helpers
{
    class MailSender
    {
        private HandleException handle;
        private MailMessage mail;
        private SmtpClient smtp;
        private Configuration config;
        private StringBuilder stringBuilder;
        public MailSender()
        {
            handle = new HandleException();
            mail = new MailMessage();
            smtp = new SmtpClient();
            config = new Configuration();
            SmtpConfig();
        }

        private void SmtpConfig()
        {
            smtp.Port = config.SmtpConfig<int>("port");
            smtp.Host = config.SmtpConfig<string>("host");
            smtp.EnableSsl = config.SmtpConfig<bool>("enable_sll");
            smtp.Credentials =
            new System.Net.NetworkCredential(config.MailConfig<string>("mail"), config.MailConfig<string>("password"));
        }

        public void Send(string email, string message, decimal newPrice, string name,string url)
        {
            handle.ExceptionHandler(() =>
            {

                mail.From = new MailAddress(config.MailConfig<string>("mail"));
                mail.To.Add(email);
                mail.Subject = "Ürün Fiyat Bilgilendirmesi";
                stringBuilder = new StringBuilder();
                stringBuilder.AppendLine(name);
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.AppendLine("Ürün URL: " + url);
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.AppendLine(message);
                stringBuilder.Append(Environment.NewLine);
             
                stringBuilder.Append("Ürünün Yeni Fiyatı: " + newPrice.ToString() + " TL");
                mail.Body = stringBuilder.ToString();

                smtp.Send(mail);

            });


        }
    }
}
