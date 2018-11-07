using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PeTest.Models
{
    public partial class TestpContext : DbContext
    {
        public TestpContext()
        {
        }

        public TestpContext(DbContextOptions<TestpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Catategory> Catategory { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Satus> Satus { get; set; }
        public virtual DbSet<Title> Title { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-DUKLKH8\\SQLEXPRESS;Initial Catalog=TestP;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catategory>(entity =>
            {
                entity.HasKey(e => e.CatId);

                entity.Property(e => e.CatId)
                    .HasColumnName("CatID")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.NameCat)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId);

                entity.Property(e => e.CustId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CustType)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.InitialCode)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CustTypeNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.CustType)
                    .HasConstraintName("FK_T_Customer_T_Type");

                entity.HasOne(d => d.InitialCodeNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.InitialCode)
                    .HasConstraintName("FK_T_Customer_T_Titel");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CatId)
                    .HasColumnName("CatID")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId)
                    .HasColumnName("statusID")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.UnitCode)
                    .HasColumnName("unitCode")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPerPrice).HasColumnName("unitPerPrice");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK_T_Product_T_Catategory");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_T_Product_T_Satus");

                entity.HasOne(d => d.UnitCodeNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.UnitCode)
                    .HasConstraintName("FK_T_Product_T_Unit");
            });

            modelBuilder.Entity<Satus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.Property(e => e.StatusId)
                    .HasColumnName("StatusID")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.HasKey(e => e.InitialCode);

                entity.Property(e => e.InitialCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.InitialName)
                    .HasColumnName("initialName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.HasKey(e => e.CustType);

                entity.Property(e => e.CustType)
                    .HasColumnName("custType")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.NameType).HasMaxLength(10);
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.HasKey(e => e.UnitCode);

                entity.Property(e => e.UnitCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.NameUnit)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
