using Core.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace Core.models
    {
        public class DatabaseContext : DbContext
        {
            public DbSet<GebruikerDTO> gebruikers { get; set; }

            public DbSet<ItemDTO> items { get; set; }


            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Data Source=(LocalDb)\\MSSQLLocalDB");
            }
        }
    }
