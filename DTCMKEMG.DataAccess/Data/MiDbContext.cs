using System;
using System.Collections.Generic;
using DTCMKEMG.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DTCMKEMG.DataAccess.Data;

public partial class MiDbContext : DbContext
{
    public MiDbContext()
    {
    }

    public MiDbContext(DbContextOptions<MiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PetBrand> PetBrands { get; set; }

    public virtual DbSet<PetSupply> PetSupplies { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DANIELA\\SQL2022;Database=petstore;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PetBrand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PetBrand__3214EC07A6DC2505");

            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PetSupply>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PetSuppl__3214EC07BB335219");

            entity.Property(e => e.CustomerPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ItemName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.PetBrand).WithMany(p => p.PetSupplies)
                .HasForeignKey(d => d.PetBrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PetSuppli__PetBr__6477ECF3");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07BE7E501B");

            entity.Property(e => e.AccessLevel)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07B0CF7DFF");

            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleId__5FB337D6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
