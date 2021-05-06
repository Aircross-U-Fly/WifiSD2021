﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SD.Persistence.Repositories.DBContexts;

namespace SD.Persistence.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    [Migration("20210506194106_SD.Persistence")]
    partial class SDPersistence
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SD.Core.Entities.Movies.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sience Fiction"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Comedy"
                        });
                });

            modelBuilder.Entity("SD.Core.Entities.Movies.MediumType", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Code");

                    b.ToTable("MediumType");

                    b.HasData(
                        new
                        {
                            Code = "BR",
                            Name = "Blue Ray"
                        },
                        new
                        {
                            Code = "BR4K",
                            Name = "Blue Ray 4K"
                        },
                        new
                        {
                            Code = "BR3D",
                            Name = "Blue Ray 3D"
                        },
                        new
                        {
                            Code = "BRHDR",
                            Name = "Blue Ray HD"
                        },
                        new
                        {
                            Code = "DVD",
                            Name = "Digital Versitale Disc"
                        },
                        new
                        {
                            Code = "ST",
                            Name = "Streaming"
                        });
                });

            modelBuilder.Entity("SD.Core.Entities.Movies.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("MediumTypeCode")
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("MediumTypeCode");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_Movies_Name");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("64f024f6-f145-417b-afbd-5cb2f4967911"),
                            GenreId = 1,
                            MediumTypeCode = "DVD",
                            Name = "Rambo",
                            Price = 4.99m,
                            ReleaseDate = new DateTime(1985, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("af6301d0-f9d5-461b-b675-d247a78f9904"),
                            GenreId = 3,
                            MediumTypeCode = "BR3D",
                            Name = "Star Trek - Beyond",
                            Price = 6.34m,
                            ReleaseDate = new DateTime(2016, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("9443e96b-41b3-42c9-9aa7-6ce5c5f92c00"),
                            GenreId = 3,
                            MediumTypeCode = "BR",
                            Name = "Star Wars - Episode IV",
                            Price = 9.99m,
                            ReleaseDate = new DateTime(1987, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("7fb72af0-bbe0-4e43-97bc-aa4f10390ede"),
                            GenreId = 2,
                            MediumTypeCode = "ST",
                            Name = "The Ring",
                            Price = 4.50m,
                            ReleaseDate = new DateTime(2005, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SD.Core.Entities.Movies.Movie", b =>
                {
                    b.HasOne("SD.Core.Entities.Movies.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SD.Core.Entities.Movies.MediumType", "MediumType")
                        .WithMany("Movies")
                        .HasForeignKey("MediumTypeCode")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Genre");

                    b.Navigation("MediumType");
                });

            modelBuilder.Entity("SD.Core.Entities.Movies.Genre", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("SD.Core.Entities.Movies.MediumType", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}