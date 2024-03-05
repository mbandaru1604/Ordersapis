using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domain.Interfaces;
using DataAccess.EFCore.Interfaces;

namespace DataAccess.EFCore.Models
{
    public partial class MN_PSCContext : DbContext, IMMContext
    {
        public MN_PSCContext()
        {
        }

        public MN_PSCContext(DbContextOptions<MN_PSCContext> options)
            : base(options)
        {
        }

        public DbSet<BioDatum> BioData { get; set; } = null!;
        public DbSet<Caste> Castes { get; set; } = null!;
        public DbSet<Membership> Memberships { get; set; } = null!;
        public DbSet<ProfileImage> ProfileImages { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserMembership> UserMemberships { get; set; } = null!;

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("Data Source=DESKTOP-S0CALPR;Initial Catalog=MN_PSC;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BioDatum>(entity =>
            {
                //entity.HasKey(e => e.BioDataId);

                //entity.Property(e => e.BioDataId).ValueGeneratedNever();

                entity.Property(e => e.AdditionalInfo)
                    .HasMaxLength(200)
                    .HasColumnName("AdditionalINfo");

                //entity.Property(e => e.BirthLocation).HasMaxLength(50);

                //entity.Property(e => e.City).HasMaxLength(50);

                //entity.Property(e => e.Country).HasMaxLength(50);

                //entity.Property(e => e.CurrentAddress1).HasMaxLength(50);

                //entity.Property(e => e.CurrentAddress2).HasMaxLength(50);

                //entity.Property(e => e.District).HasMaxLength(50);

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                //entity.Property(e => e.Gothram).HasMaxLength(50);

                //entity.Property(e => e.Hobbies).HasMaxLength(100);

                //entity.Property(e => e.JobLocation).HasMaxLength(50);

                //entity.Property(e => e.Mandal).HasMaxLength(50);

                //entity.Property(e => e.MarriageType).HasMaxLength(20);

                //entity.Property(e => e.MoleIdentity).HasMaxLength(100);

                //entity.Property(e => e.MotherToungue).HasMaxLength(20);

                //entity.Property(e => e.Nakshatram).HasMaxLength(50);

                //entity.Property(e => e.Profession).HasMaxLength(50);

                //entity.Property(e => e.Qualification).HasMaxLength(50);

                //entity.Property(e => e.Religion).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BioData)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BioData__UserId__6B24EA82");
            });

            //modelBuilder.Entity<Caste>(entity =>
            //{
            //    entity.ToTable("Caste");

            //    entity.Property(e => e.CasteId).ValueGeneratedNever();

            //    entity.Property(e => e.Name).HasMaxLength(50);
            //});

            //modelBuilder.Entity<Membership>(entity =>
            //{
            //    entity.ToTable("Membership");

            //    entity.Property(e => e.MembershipId).ValueGeneratedNever();

            //    entity.Property(e => e.Name).HasMaxLength(50);
            //});

            //modelBuilder.Entity<ProfileImage>(entity =>
            //{
            //    entity.HasKey(e => e.ImageId);

            //    entity.Property(e => e.ImageId).ValueGeneratedNever();

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.ProfileImages)
            //        .HasForeignKey(d => d.UserId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK__ProfileIm__UserI__619B8048");
            //});

            //modelBuilder.Entity<Role>(entity =>
            //{
            //    entity.Property(e => e.RoleId).ValueGeneratedNever();

            //    entity.Property(e => e.RoleCode).HasMaxLength(10);

            //    entity.Property(e => e.RoleName).HasMaxLength(50);
            //});

            modelBuilder.Entity<User>(entity =>
            {
                //entity.Property(e => e.UserId).ValueGeneratedNever();

                //entity.Property(e => e.AlternateContact).HasMaxLength(15);

                //entity.Property(e => e.Contact).HasMaxLength(15);

                //entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                //entity.Property(e => e.Email).HasMaxLength(50);

                //entity.Property(e => e.FirstName).HasMaxLength(100);

                //entity.Property(e => e.Gender)
                //    .HasMaxLength(1)
                //    .IsUnicode(false)
                //    .IsFixedLength();

                //entity.Property(e => e.LastName).HasMaxLength(100);

                //entity.Property(e => e.MiddleName).HasMaxLength(50);

                //entity.Property(e => e. ).HasColumnType("datetime");

                //entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserRole",
                        l => l.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserRole__RoleId__7A672E12"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserRole__UserId__797309D9"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("UserRole");
                        });
            });

            modelBuilder.Entity<UserMembership>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.MembershipId })
                    .HasName("PK__UserMemb__9EA2B42BE919058E");

                entity.ToTable("UserMembership");

                entity.Property(e => e.Validity).HasColumnType("datetime");

                entity.HasOne(d => d.Membership)
                    .WithMany(p => p.UserMemberships)
                    .HasForeignKey(d => d.MembershipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserMembe__Membe__7F2BE32F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserMemberships)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserMembe__UserI__7E37BEF6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
