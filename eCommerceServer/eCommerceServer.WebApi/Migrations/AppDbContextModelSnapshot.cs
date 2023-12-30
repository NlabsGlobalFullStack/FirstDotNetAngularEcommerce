﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eCommerceServer.WebApi.Context;

#nullable disable

namespace eCommerceServer.WebApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eCommerceServer.WebApi.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c8243b08-cce0-4c8b-974c-8d567dd0052a"),
                            Email = "turkmvc@gmail.com",
                            FirstName = "Cuma",
                            IsAdmin = true,
                            LastName = "KÖSE",
                            Password = "String123",
                            UserName = "turkmvc"
                        });
                });

            modelBuilder.Entity("eCommerceServer.WebApi.Entities.Basket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("eCommerceServer.WebApi.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("eCommerceServer.WebApi.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CoverImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e1e4c7df-2a3c-4b38-9e1e-e269880315d8"),
                            CoverImageUrl = "apple.png",
                            CreatedDate = new DateTime(2023, 12, 31, 1, 1, 44, 701, DateTimeKind.Local).AddTicks(1437),
                            Description = "",
                            Name = "Elma",
                            Price = 20m,
                            Slug = "elma",
                            UserId = new Guid("c8243b08-cce0-4c8b-974c-8d567dd0052a")
                        },
                        new
                        {
                            Id = new Guid("3027f70c-1e4f-4cad-844e-c8b10e4b1d7e"),
                            CoverImageUrl = "pear.png",
                            CreatedDate = new DateTime(2023, 12, 31, 1, 1, 44, 701, DateTimeKind.Local).AddTicks(1457),
                            Description = "",
                            Name = "Armut",
                            Price = 30m,
                            Slug = "armut",
                            UserId = new Guid("c8243b08-cce0-4c8b-974c-8d567dd0052a")
                        },
                        new
                        {
                            Id = new Guid("70c97b8b-18c1-472c-83c3-c72c61ba61fc"),
                            CoverImageUrl = "watermelon.png",
                            CreatedDate = new DateTime(2023, 12, 31, 1, 1, 44, 701, DateTimeKind.Local).AddTicks(1461),
                            Description = "",
                            Name = "Karpuz",
                            Price = 120m,
                            Slug = "karpuz",
                            UserId = new Guid("c8243b08-cce0-4c8b-974c-8d567dd0052a")
                        },
                        new
                        {
                            Id = new Guid("95028995-63d8-43c1-82e4-8a61e8fe72fb"),
                            CoverImageUrl = "banana.png",
                            CreatedDate = new DateTime(2023, 12, 31, 1, 1, 44, 701, DateTimeKind.Local).AddTicks(1464),
                            Description = "",
                            Name = "Muz",
                            Price = 50m,
                            Slug = "muz",
                            UserId = new Guid("c8243b08-cce0-4c8b-974c-8d567dd0052a")
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
