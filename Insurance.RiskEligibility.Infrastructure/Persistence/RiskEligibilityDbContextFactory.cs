using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace Insurance.RiskEligibility.Infrastructure.Persistence
{
    public class RiskEligibilityDbContextFactory
          : IDesignTimeDbContextFactory<RiskEligibilityDbContext>
    {
        public RiskEligibilityDbContext CreateDbContext(string[] args)
        {
            // Load configuration
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<RiskEligibilityDbContext>();

            optionsBuilder.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"));

            return new RiskEligibilityDbContext(optionsBuilder.Options);
        }
    }
}
