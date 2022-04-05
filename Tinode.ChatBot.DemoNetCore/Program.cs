using CommandLine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Pbx;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinode.ChatBot.DemoNetCore
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var chat = new Chat(args);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
              .ConfigureLogging(loggingBuilder =>
              {
                  var configuration = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json")
                   .Build();
                  Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Error()
               .Enrich.FromLogContext()
               .WriteTo.File(@"logs//applog.log", rollingInterval: RollingInterval.Day)
               .CreateLogger();
                  //var logger = new LoggerConfiguration()
                  //    .ReadFrom.Configuration(configuration)
                  //    .CreateLogger();
                  //loggingBuilder.AddSerilog(logger, dispose: true);
              })
                .ConfigureServices((hostContext, services) =>
                {
                    //services.RegisterServices();
                    //services.RegisterBgTaskSyncNews();
                    ////services.RegisterBgTaskSyncNewsAudio();
                    //services.RegisterLogging(hostContext);
                });
    }
}