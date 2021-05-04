using Microsoft.EntityFrameworkCore;
using SD.Core.Entities.Movies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SD.Persistence.Repositories.DBContexts
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext() { }

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
            //Timeout für das Erreichen des Servers
            Database.SetCommandTimeout(60);
        }


        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<MediumType> MediumTypes { get; set; }

        //Konfiguration vom DB-Context -> Migration im Repository implementieren
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var currentDirectory = Directory.GetCurrentDirectory();

#if DEBUG
            if (currentDirectory.IndexOf("bin") > -1)
            {
                currentDirectory = currentDirectory.Substring(0, currentDirectory.IndexOf("bin"));
            }
#endif


        }

        //Fluent - API and Seed Method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
