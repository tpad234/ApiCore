using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
   
        public class DatabaseContext : DbContext
    {

        protected readonly IConfiguration Configuration;


        public DatabaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

      
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("WebApiDatabase");
            options.UseSqlServer(connectionString);
        }

        public DbSet<Gebruiker> gebruikers { get; set; }


        public DbSet<Item> items { get; set; }


        }

}
