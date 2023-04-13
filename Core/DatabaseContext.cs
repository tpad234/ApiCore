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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Item>()
        //        .HasOne(i => i.Verzoeken)
        //        .WithOne(v => v.Item)
        //         .HasForeignKey<Item>(i => i.VerzoekenId)
        //         .OnDelete(DeleteBehavior.Restrict);

        //    modelBuilder.Entity<Item>()
        //      .HasOne(i => i.Eigenaar)
        //      .WithMany(v => v.Items)
        //       .OnDelete(DeleteBehavior.Restrict);

        //    modelBuilder.Entity<Verzoeken>()
        //       .HasOne(i => i.Item)
        //       .WithOne(v => v.Verzoeken)
        //         .HasForeignKey<Verzoeken>(i => i.ItemId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("WebApiDatabase");
            options.UseSqlServer(connectionString);
        }

        public DbSet<Gebruiker> gebruikers { get; set; }


        public DbSet<Item> items { get; set; }

       // public DbSet<Verzoeken> verzoeken { get;set; }


    }

}
