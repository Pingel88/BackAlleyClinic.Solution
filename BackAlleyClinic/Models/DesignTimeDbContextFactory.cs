using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BackAlleyClinic.Models
{
  public class BackAlleyClinicContextFactory : IDesignTimeDbContextFactory<BackAlleyClinicContext>
  {

    BackAlleyClinicContext IDesignTimeDbContextFactory<BackAlleyClinicContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

      var builder = new DbContextOptionsBuilder<BackAlleyClinicContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new BackAlleyClinicContext(builder.Options);
    }
  }
}
