﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dblaze.Shared.DBContext;

namespace dblaze.Server.Migrations
{
    [DbContext(typeof(BooksContext))]
    [Migration("20181125060554_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("dblaze.Shared.DBContext.Basket", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ItemID");

                    b.Property<string>("BookId")
                        .HasColumnName("BookID")
                        .HasColumnType("nchar(3)");

                    b.Property<string>("Title")
                        .HasColumnType("nchar(20)");

                    b.HasKey("ItemId");

                    b.ToTable("Basket");
                });

            modelBuilder.Entity("dblaze.Shared.DBContext.Book", b =>
                {
                    b.Property<string>("BookId")
                        .HasColumnName("BookID")
                        .HasColumnType("nchar(3)");

                    b.Property<string>("Author")
                        .HasColumnType("nchar(20)");

                    b.Property<int?>("CategoryId");

                    b.Property<string>("ImageUrl")
                        .HasColumnName("ImageURL")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<decimal?>("Price")
                        .HasColumnType("money");

                    b.Property<string>("Title")
                        .HasColumnType("nchar(20)");

                    b.HasKey("BookId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("dblaze.Shared.DBContext.Category", b =>
                {
                    b.Property<int>("CategoryId");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nchar(20)");

                    b.Property<string>("Description");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("dblaze.Shared.DBContext.Customers", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("Address")
                        .HasColumnType("nchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nchar(10)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nchar(10)");

                    b.Property<string>("Phone")
                        .HasColumnType("nchar(15)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("UserId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("dblaze.Shared.DBContext.OrderLine", b =>
                {
                    b.Property<short>("LineNum")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BookId")
                        .HasColumnType("nchar(3)");

                    b.Property<int?>("OrderId");

                    b.Property<int?>("Quantity");

                    b.HasKey("LineNum");

                    b.ToTable("OrderLine");
                });

            modelBuilder.Entity("dblaze.Shared.DBContext.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CardNo")
                        .HasMaxLength(12);

                    b.Property<string>("CardType")
                        .HasColumnType("nchar(10)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("SecurityNo")
                        .HasMaxLength(3);

                    b.Property<decimal?>("TotalCost");

                    b.Property<Guid?>("UserId");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
