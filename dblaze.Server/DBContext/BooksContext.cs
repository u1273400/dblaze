using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dblaze.Shared.DBContext
{
    public partial class BooksContext : DbContext
    {
        public virtual DbSet<Basket> Basket { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<OrderLine> OrderLine { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Database=App_Data\books.mdf;Integrated Security=True");
                optionsBuilder.UseSqlite(@"Data Source=books.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Basket>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.BookId)
                    .HasColumnName("BookID")
                    .HasColumnType("nchar(3)");

                entity.Property(e => e.Title).HasColumnType("nchar(20)");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.BookId)
                    .HasColumnName("BookID")
                    .HasColumnType("nchar(3)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Author).HasColumnType("nchar(20)");

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("ImageURL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Title).HasColumnType("nchar(20)");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.CategoryName).HasColumnType("nchar(20)");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Address).HasColumnType("nchar(50)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Phone).HasColumnType("nchar(15)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.HasKey(e => e.LineNum);

                entity.Property(e => e.BookId).HasColumnType("nchar(3)");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.Property(e => e.CardNo).HasMaxLength(12);

                entity.Property(e => e.CardType).HasColumnType("nchar(10)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.SecurityNo).HasMaxLength(3);
            });
        }
    }
}
