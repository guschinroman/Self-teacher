using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ServiceTeacher.Service.Helpers.DataContext
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SelfTeacher.Service.Helpers.DataAccess.DataContext>
    {
        public SelfTeacher.Service.Helpers.DataAccess.DataContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<SelfTeacher.Service.Helpers.DataAccess.DataContext>();
            var connectionString = configuration.GetSection("connectionString").GetValue<string>("TeacherDB");
            builder.UseSqlServer(connectionString);
            return new SelfTeacher.Service.Helpers.DataAccess.DataContext(builder.Options);
        }
    }
}
