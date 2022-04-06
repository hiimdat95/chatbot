using Ioc;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Tinode.ChatBot.DemoNetCore
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //var services = new ServiceCollection();
            //var serviceprovider = services.BuildServiceProvider();
            //using (var scope = serviceprovider.CreateScope())
            //{
            //    //  Lấy Service trong một pham vi
            //    var repository = scope.ServiceProvider.GetService<IBaseRepository>();
            //    var unitOfWork = scope.ServiceProvider.GetService<IUnitOfWork>();

            //    var chat = new Chat(args, repository, unitOfWork);
            //}
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
              .ConfigureLogging(loggingBuilder =>
              {
                  Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Error()
               .Enrich.FromLogContext()
               .WriteTo.File(@"logs//applog.log", rollingInterval: RollingInterval.Day)
               .CreateLogger();
              })
                .ConfigureServices((hostContext, services) =>
                {
                    services.RegisterServices();
                    var chat = new Chat(args, services);
                });
    }
}