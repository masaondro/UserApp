using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCRUD.Infrastructure.DataAccess.Interfaces;

namespace UserCRUD.Infrastructure.DataAccess
{
    public class UserCRUDDbContextConfiguration : IDbContextOptionsConfigurator<UserCRUDDbContext>
    {
        private const string PostgesConnectionStringName = "PostgresBoardDb";

        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;
        public UserCRUDDbContextConfiguration(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _configuration = configuration;
            _loggerFactory = loggerFactory;
        }

        public void Configure(DbContextOptionsBuilder<UserCRUDDbContext> options)
        {
            var connectionString = _configuration.GetConnectionString(PostgesConnectionStringName);
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    $"Не найдена строка подключения с именем '{PostgesConnectionStringName}'");
            }
            options.UseNpgsql(connectionString);
            options.UseLoggerFactory(_loggerFactory);
        }
    }
}
