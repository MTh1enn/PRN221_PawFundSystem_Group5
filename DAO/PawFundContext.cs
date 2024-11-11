using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BusinessObjects.Models;

public partial class PawFundContext : DbContext
{
    public PawFundContext()
    {
    }

    public PawFundContext(DbContextOptions<PawFundContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdoptionRequest> AdoptionRequests { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<HealthCheck> HealthChecks { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<Shelter> Shelters { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VolunteerTask> VolunteerTasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local);Uid=sa;Pwd=12345;Database=PawFund;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdoptionRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Adoption__3214EC07F7257D54");

            entity.ToTable("AdoptionRequest");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AdoptionDate).HasColumnType("datetime");
            entity.Property(e => e.Comment).HasColumnType("text");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.ReviewDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Pet).WithMany(p => p.AdoptionRequests)
                .HasForeignKey(d => d.PetId)
                .HasConstraintName("FK__AdoptionR__PetId__27F8EE98");

            entity.HasOne(d => d.ReviewedByNavigation).WithMany(p => p.AdoptionRequestReviewedByNavigations)
                .HasForeignKey(d => d.ReviewedBy)
                .HasConstraintName("FK__AdoptionR__Revie__29E1370A");

            entity.HasOne(d => d.User).WithMany(p => p.AdoptionRequestUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__AdoptionR__UserI__28ED12D1");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Event__3214EC07449DA1C8");

            entity.ToTable("Event");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Events)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Event__UserId__1E6F845E");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Feedback__3214EC07D5DF5A63");

            entity.ToTable("Feedback");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.FeedbackAt).HasColumnType("datetime");

            entity.HasOne(d => d.Pet).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.PetId)
                .HasConstraintName("FK__Feedback__PetId__345EC57D");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Feedback__UserId__336AA144");
        });

        modelBuilder.Entity<HealthCheck>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HealthCh__3214EC07F16ED2EE");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CheckDate).HasColumnType("datetime");
            entity.Property(e => e.CheckType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.HealthStatus)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.HealthStatusDescription).HasColumnType("text");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.CheckedByNavigation).WithMany(p => p.HealthChecks)
                .HasForeignKey(d => d.CheckedBy)
                .HasConstraintName("FK__HealthChe__Check__2F9A1060");

            entity.HasOne(d => d.Pet).WithMany(p => p.HealthChecks)
                .HasForeignKey(d => d.PetId)
                .HasConstraintName("FK__HealthChe__PetId__2EA5EC27");
        });

        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pet__3214EC074FD54382");

            entity.ToTable("Pet");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Breed)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DeliveryStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.HealStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.PetStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RescueDate).HasColumnType("datetime");
            entity.Property(e => e.RescueLocation)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Owner).WithMany(p => p.Pets)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK__Pet__OwnerId__19AACF41");

            entity.HasOne(d => d.Shelter).WithMany(p => p.Pets)
                .HasForeignKey(d => d.ShelterId)
                .HasConstraintName("FK__Pet__ShelterId__1A9EF37A");
        });

        modelBuilder.Entity<Shelter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shelter__3214EC07C8B46B8B");

            entity.ToTable("Shelter");

            entity.HasIndex(e => e.ShelterCode, "UQ__Shelter__75626320BB85C986").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ShelterCode)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ManagedByNavigation).WithMany(p => p.Shelters)
                .HasForeignKey(d => d.ManagedBy)
                .HasConstraintName("FK__Shelter__Managed__13F1F5EB");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC0792C344FD");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__A9D10534E96FE6D0").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<VolunteerTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Voluntee__3214EC077FDC518E");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CompletedDate).HasColumnType("datetime");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.Priority)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TaskDescription).HasColumnType("text");

            entity.HasOne(d => d.AssignedByNavigation).WithMany(p => p.VolunteerTaskAssignedByNavigations)
                .HasForeignKey(d => d.AssignedBy)
                .HasConstraintName("FK__Volunteer__Assig__2334397B");

            entity.HasOne(d => d.AssignedToNavigation).WithMany(p => p.VolunteerTaskAssignedToNavigations)
                .HasForeignKey(d => d.AssignedTo)
                .HasConstraintName("FK__Volunteer__Assig__24285DB4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
