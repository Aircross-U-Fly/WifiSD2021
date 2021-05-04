using Microsoft.EntityFrameworkCore;
using SD.Core.Entities.Movies;
using System;
using System.Collections.Generic;
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
        }

        //Fluent - API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
