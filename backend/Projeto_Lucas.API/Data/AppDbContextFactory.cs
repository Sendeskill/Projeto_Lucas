using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Projeto_Lucas.API.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var path = Directory.GetCurrentDirectory();
            Console.WriteLine($"[DEBUG] CurrentDirectory: {path}");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json")
                .Build();

            var fullConfig = File.ReadAllText("appsettings.json");
            Console.WriteLine($"[DEBUG] Conteúdo bruto do appsettings.json:\n{fullConfig}");

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine($"[DEBUG] Connection string interpretada: {connectionString}");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
