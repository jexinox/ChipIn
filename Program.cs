using ChipIn.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson.Serialization;

// ��� ��� ����� ������ web(back-end) ������, �� ������ ����� ������ :)
namespace ChipIn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BsonClassMap.RegisterClassMap<User>(user =>
            {
                user.MapIdProperty(user => user.Id);
                user.MapCreator(user => new User(user.Id));
            });

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
