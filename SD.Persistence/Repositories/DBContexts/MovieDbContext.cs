using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
            var configurationBuilder = new ConfigurationBuilder()
                                           .SetBasePath(currentDirectory)
                                           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


            var configuration = configurationBuilder.Build();
            var connectionString = configuration.GetConnectionString(nameof(MovieDbContext));
            var commandTimeOut = 90;

            optionsBuilder.UseSqlServer(connectionString, opt => opt.CommandTimeout(commandTimeOut));

        }

        //Fluent - API and Seed Method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                //entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(64);
                entity.HasIndex(p => p.Name).HasDatabaseName("IX_Movies_Name");
                entity.Property(p => p.ReleaseDate).HasColumnType("date");
                entity.Property(p => p.Price).HasPrecision(18, 2);
            });

            modelBuilder.Entity<MediumType>(entity => entity.HasKey(p => p.Code));

            // FK-Constraints
            modelBuilder.Entity<Movie>()
                        .HasOne(m => m.MediumType)
                        .WithMany(m => m.Movies)
                        .HasForeignKey(m => m.MediumTypeCode)
                        .OnDelete(DeleteBehavior.Cascade); //Löschweitergabe unterbunden

            //modelBuilder.Entity<MediumType>()
            //            .HasMany(m => m.Movies)
            //            .WithOne(m => m.MediumType)
            //            .HasForeignKey(m => m.MediumTypeCode)
            //            .OnDelete(DeleteBehavior.Cascade); //Löschweitergabe unterbunden

            modelBuilder.Entity<Genre>()
                        .HasMany(g => g.Movies)            // Ein Genre kann in beliebig vielen Movie Datensätzen verwendet werden
                        .WithOne(g => g.Genre)             // Jedes Genre existiert nur einmal und für ein Movie kann nur ein Genre definiert werden
                        .HasForeignKey(g => g.GenreId)     // Fremdschlüssel PK => FK
                        .OnDelete(DeleteBehavior.Cascade); // Löschweitergabe unterbinden


            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Horror" },
                new Genre { Id = 3, Name = "Sience Fiction" },
                new Genre { Id = 4, Name = "Comedy" }
                );

            modelBuilder.Entity<MediumType>().HasData(
                new MediumType { Code = MediumTypeEnum.BR.ToString(), Name = "Blue Ray" },
                new MediumType { Code = MediumTypeEnum.BR4K.ToString(), Name = "Blue Ray 4K" },
                new MediumType { Code = MediumTypeEnum.BR3D.ToString(), Name = "Blue Ray 3D" },
                new MediumType { Code = MediumTypeEnum.BRHDR.ToString(), Name = "Blue Ray HD" },
                new MediumType { Code = MediumTypeEnum.DVD.ToString(), Name = "Digital Versitale Disc" },
                new MediumType { Code = MediumTypeEnum.ST.ToString(), Name = "Streaming" }
                );

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = new Guid("64F024F6-F145-417B-AFBD-5CB2F4967911"),
                    GenreId = 1,
                    MediumTypeCode = MediumTypeEnum.DVD.ToString(),
                    Name = "Rambo",
                    Price = 4.99M,
                    ReleaseDate = new DateTime(1985, 04, 13),
                },
                new Movie
                {
                    Id = new Guid("AF6301D0-F9D5-461B-B675-D247A78F9904"),
                    GenreId = 3,
                    MediumTypeCode = MediumTypeEnum.BR3D.ToString(),
                    Name = "Star Trek - Beyond",
                    Price = 6.34M,
                    ReleaseDate = new DateTime(2016, 05, 30),
                },
                new Movie
                {
                    Id = new Guid("9443E96B-41B3-42C9-9AA7-6CE5C5F92C00"),
                    GenreId = 3,
                    MediumTypeCode = MediumTypeEnum.BR.ToString(),
                    Name = "Star Wars - Episode IV",
                    Price = 9.99M,
                    ReleaseDate = new DateTime(1987, 4, 13),
                },
                new Movie
                {
                    Id = new Guid("7FB72AF0-BBE0-4E43-97BC-AA4F10390EDE"),
                    GenreId = 2,
                    MediumTypeCode = MediumTypeEnum.ST.ToString(),
                    Name = "The Ring",
                    Price = 4.50M,
                    ReleaseDate = new DateTime(2005, 11, 15),
                }
            );
        }
    }
}
