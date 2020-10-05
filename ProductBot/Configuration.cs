using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Binder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Collections;
using System.Dynamic;

namespace ProductBot
{
    public class Configuration
    {
        private IConfigurationBuilder builder;
        private IConfiguration configuration;

    
        public Configuration()
        {
            builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            configuration = builder.Build();
        }

        public T SmtpConfig<T>(string key)
        {
            var config = new Hashtable();

            config.Add("port", configuration.GetValue<int>("smtp:port"));
            config.Add("enable_sll", configuration.GetValue<bool>("smtp:enable_sll"));
            config.Add("host", configuration.GetValue<string>("smtp:host"));
            
            return (T) config[key];
            
        }


        public T MailConfig<T>(string key)
        {
            var config = new Hashtable();

            config.Add("mail", configuration.GetValue<string>("sender_mail:mail"));
            config.Add("password", configuration.GetValue<string>("sender_mail:password"));

            return (T) config[key];

        }

        public T DatabaseConfig<T>(string key)
        {
            var config = new Hashtable();

            config.Add("connection_string", configuration.GetValue<string>("database:connection_string"));

            return (T)config[key];

        }

    }
}
