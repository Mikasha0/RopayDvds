using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RopayDvd.Models
{
    public partial class RopayDatabaseContext : DbContext
    {
        public RopayDatabaseContext()
        {
        }

        public RopayDatabaseContext(DbContextOptions<RopayDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<CastMember> CastMembers { get; set; }
        public virtual DbSet<DvdCategory> DvdCategories { get; set; }
        public virtual DbSet<DvdCopy> DvdCopies { get; set; }
        public virtual DbSet<DvdTitle> DvdTitles { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<LoanType> LoanTypes { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MembershipCategory> MembershipCategories { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<RopayUser> RopayUsers { get; set; }
        public virtual DbSet<Studio> Studios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=RopayConString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.ActorNumber)
                    .HasName("PK__Actor__B04B6DF7DC166E15");

                entity.ToTable("Actor");

                entity.Property(e => e.ActorNumber).HasColumnName("actorNumber");

                entity.Property(e => e.ActorFirstName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("actorFirstName");

                entity.Property(e => e.ActorLastName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("actorLastName");
            });

            modelBuilder.Entity<CastMember>(entity =>
            {
                entity.HasKey(e => new { e.DvdNumber, e.ActorNumber })
                    .HasName("PK__CastMemb__56673B555D853E3F");

                entity.ToTable("CastMember");

                entity.Property(e => e.DvdNumber).HasColumnName("dvdNumber");

                entity.Property(e => e.ActorNumber).HasColumnName("actorNumber");

                entity.HasOne(d => d.ActorNumberNavigation)
                    .WithMany(p => p.CastMembers)
                    .HasForeignKey(d => d.ActorNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CastMembe__actor__6FE99F9F");

                entity.HasOne(d => d.DvdNumberNavigation)
                    .WithMany(p => p.CastMembers)
                    .HasForeignKey(d => d.DvdNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CastMembe__dvdNu__6EF57B66");
            });

            modelBuilder.Entity<DvdCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryNumber)
                    .HasName("PK__DvdCateg__D15A43E55A3D5947");

                entity.ToTable("DvdCategory");

                entity.Property(e => e.CategoryNumber).HasColumnName("categoryNumber");

                entity.Property(e => e.AgeRestricted).HasColumnName("ageRestricted");

                entity.Property(e => e.CategoryDescription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("categoryDescription");
            });

            modelBuilder.Entity<DvdCopy>(entity =>
            {
                entity.HasKey(e => e.CopyNumber)
                    .HasName("PK__DvdCopy__E0C391566FD0C7C5");

                entity.ToTable("DvdCopy");

                entity.Property(e => e.CopyNumber).HasColumnName("copyNumber");

                entity.Property(e => e.DatePurchased)
                    .HasColumnType("date")
                    .HasColumnName("datePurchased")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DvdNumber).HasColumnName("dvdNumber");

                entity.HasOne(d => d.DvdNumberNavigation)
                    .WithMany(p => p.DvdCopies)
                    .HasForeignKey(d => d.DvdNumber)
                    .HasConstraintName("FK__DvdCopy__dvdNumb__72C60C4A");
            });

            modelBuilder.Entity<DvdTitle>(entity =>
            {
                entity.HasKey(e => e.DvdNumber)
                    .HasName("PK__DvdTitle__3D638D8A2AFD1DE3");

                entity.ToTable("DvdTitle");

                entity.HasIndex(e => e.DvdTite, "UQ__DvdTitle__F1150D977870CBFC")
                    .IsUnique();

                entity.Property(e => e.DvdNumber).HasColumnName("dvdNumber");

                entity.Property(e => e.CategoryNumber).HasColumnName("categoryNumber");

                entity.Property(e => e.DateReleased)
                    .HasColumnType("date")
                    .HasColumnName("dateReleased")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DvdTite)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("dvdTite");

                entity.Property(e => e.PenaltyCharge)
                    .HasColumnType("money")
                    .HasColumnName("penaltyCharge");

                entity.Property(e => e.ProducerNumber).HasColumnName("producerNumber");

                entity.Property(e => e.StandardCharge)
                    .HasColumnType("money")
                    .HasColumnName("standardCharge");

                entity.Property(e => e.StudioNumber).HasColumnName("studioNumber");

                entity.HasOne(d => d.CategoryNumberNavigation)
                    .WithMany(p => p.DvdTitles)
                    .HasForeignKey(d => d.CategoryNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DvdTitle__catego__6754599E");

                entity.HasOne(d => d.ProducerNumberNavigation)
                    .WithMany(p => p.DvdTitles)
                    .HasForeignKey(d => d.ProducerNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DvdTitle__produc__693CA210");

                entity.HasOne(d => d.StudioNumberNavigation)
                    .WithMany(p => p.DvdTitles)
                    .HasForeignKey(d => d.StudioNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DvdTitle__studio__68487DD7");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasKey(e => e.LoanNumber)
                    .HasName("PK__Loan__88C9C1736CBFFFED");

                entity.ToTable("Loan");

                entity.Property(e => e.LoanNumber).HasColumnName("loanNumber");

                entity.Property(e => e.CopyNumber).HasColumnName("copyNumber");

                entity.Property(e => e.DateDue)
                    .HasColumnType("date")
                    .HasColumnName("dateDue");

                entity.Property(e => e.DateOut)
                    .HasColumnType("date")
                    .HasColumnName("dateOut")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateReturned)
                    .HasColumnType("date")
                    .HasColumnName("dateReturned");

                entity.Property(e => e.LoanTypeNumber).HasColumnName("loanTypeNumber");

                entity.Property(e => e.MemberNumber).HasColumnName("memberNumber");

                entity.HasOne(d => d.CopyNumberNavigation)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.CopyNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Loan__copyNumber__02084FDA");

                entity.HasOne(d => d.LoanTypeNumberNavigation)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.LoanTypeNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Loan__loanTypeNu__01142BA1");

                entity.HasOne(d => d.MemberNumberNavigation)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.MemberNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Loan__memberNumb__02FC7413");
            });

            modelBuilder.Entity<LoanType>(entity =>
            {
                entity.HasKey(e => e.LoanTypeNumber)
                    .HasName("PK__LoanType__1B55E2CC6B2A21E8");

                entity.ToTable("LoanType");

                entity.HasIndex(e => e.LoanTypeName, "UQ__LoanType__700AFF1DD7E75F2F")
                    .IsUnique();

                entity.Property(e => e.LoanTypeNumber).HasColumnName("loanTypeNumber");

                entity.Property(e => e.LoanDuration)
                    .HasColumnName("loanDuration")
                    .HasDefaultValueSql("((7))");

                entity.Property(e => e.LoanTypeName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("loanTypeName");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.MemberNumber)
                    .HasName("PK__Member__21717F66E7F035EC");

                entity.ToTable("Member");

                entity.Property(e => e.MemberNumber).HasColumnName("memberNumber");

                entity.Property(e => e.MemberAddress)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("memberAddress");

                entity.Property(e => e.MemberDateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("memberDateOfBirth");

                entity.Property(e => e.MemberFirstName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("memberFirstName");

                entity.Property(e => e.MemberLastName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("memberLastName");

                entity.Property(e => e.MembershipCategoryNumber).HasColumnName("membershipCategoryNumber");

                entity.HasOne(d => d.MembershipCategoryNumberNavigation)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.MembershipCategoryNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Member__membersh__7E37BEF6");
            });

            modelBuilder.Entity<MembershipCategory>(entity =>
            {
                entity.HasKey(e => e.MembershipCategoryNumber)
                    .HasName("PK__Membersh__B084C28C828A4DF0");

                entity.ToTable("MembershipCategory");

                entity.Property(e => e.MembershipCategoryNumber).HasColumnName("membershipCategoryNumber");

                entity.Property(e => e.MembershipCategoryDescription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("membershipCategoryDescription");

                entity.Property(e => e.MembershipCategoryTotalLoans)
                    .HasColumnName("membershipCategoryTotalLoans")
                    .HasDefaultValueSql("((5))");
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.HasKey(e => e.ProducerNumber)
                    .HasName("PK__Producer__B26CD52DC9F33FDE");

                entity.ToTable("Producer");

                entity.Property(e => e.ProducerNumber).HasColumnName("producerNumber");

                entity.Property(e => e.ProducerName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("producerName");
            });

            modelBuilder.Entity<RopayUser>(entity =>
            {
                entity.HasKey(e => e.UserNumber)
                    .HasName("PK__RopayUse__72938793039D9E6E");

                entity.ToTable("RopayUser");

                entity.HasIndex(e => e.UserName, "UQ__RopayUse__66DCF95CCCB581B2")
                    .IsUnique();

                entity.Property(e => e.UserNumber).HasColumnName("userNumber");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("userName");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("userPassword");

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("userType");
            });

            modelBuilder.Entity<Studio>(entity =>
            {
                entity.HasKey(e => e.StudioNumber)
                    .HasName("PK__Studio__9A154E441511067F");

                entity.ToTable("Studio");

                entity.Property(e => e.StudioNumber).HasColumnName("studioNumber");

                entity.Property(e => e.StudioName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("studioName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
