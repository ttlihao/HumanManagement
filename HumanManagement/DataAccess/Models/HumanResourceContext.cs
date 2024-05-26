using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HumanManagement.DataAccess.Models;

public partial class HumanResourceContext : DbContext
{
    public HumanResourceContext()
    {
    }

    public HumanResourceContext(DbContextOptions<HumanResourceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersClaim> UsersClaims { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-0S9BEQ8\\MSSQLSERVER01;Initial Catalog=HumanResource;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.HasKey(e => e.Aid).HasName("PK__Attachme__C69007C82405BC51");

            entity.Property(e => e.Aid).HasColumnName("AID");
            entity.Property(e => e.FilePath).HasMaxLength(255);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Attachments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Attachmen__UserI__5535A963");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A6213F6A0");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(255);
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tokens__3214EC27367C2032");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.RefreshToken).HasMaxLength(255);
            entity.Property(e => e.TokenString).HasMaxLength(255);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Tokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Tokens__UserID__5812160E");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC7915B583");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.DaysOffLimit).HasDefaultValueSql("((14))");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Username).HasMaxLength(255);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleID__4F7CD00D");
        });

        modelBuilder.Entity<UsersClaim>(entity =>
        {
            entity.HasKey(e => e.UserClaimId).HasName("PK__UsersCla__E22E298489550204");

            entity.ToTable("UsersClaim");

            entity.Property(e => e.UserClaimId).HasColumnName("UserClaimID");
            entity.Property(e => e.ClaimValue).HasMaxLength(255);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.UsersClaims)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UsersClai__UserI__52593CB8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
