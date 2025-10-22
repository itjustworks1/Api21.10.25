using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Api21._10._25.DB;

public partial class Api211025Context : DbContext
{
    public Api211025Context()
    {
    }

    public Api211025Context(DbContextOptions<Api211025Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<ApplicationType> ApplicationTypes { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<GroupApplicationContact> GroupApplicationContacts { get; set; }

    public virtual DbSet<PersonalVisitor> PersonalVisitors { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("userid=student;password=student;server=192.168.200.13;database=Api21.10.25", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.39-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Application");

            entity.HasIndex(e => e.ApplicationTypeId, "FK_Application_Application_Type");

            entity.HasIndex(e => e.DepartmentId, "FK_Application_Department_Id");

            entity.HasIndex(e => e.EmployeeId, "FK_Application_Employee_Id");

            entity.HasIndex(e => e.StatusId, "FK_Application_Status");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ApplicantEmail).HasMaxLength(255);
            entity.Property(e => e.ApplicationTypeId).HasColumnType("int(11)");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DepartmentId).HasColumnType("int(11)");
            entity.Property(e => e.EmployeeId).HasColumnType("int(11)");
            entity.Property(e => e.Purpose).HasMaxLength(255);
            entity.Property(e => e.RejectionReason).HasMaxLength(255);
            entity.Property(e => e.StatusId).HasColumnType("int(11)");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.ApplicationType).WithMany(p => p.Applications)
                .HasForeignKey(d => d.ApplicationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_Application_Type");

            entity.HasOne(d => d.Department).WithMany(p => p.Applications)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_Department_Id");

            entity.HasOne(d => d.Employee).WithMany(p => p.Applications)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_Employee_Id");

            entity.HasOne(d => d.Status).WithMany(p => p.Applications)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Application_Status");
        });

        modelBuilder.Entity<ApplicationType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ApplicationType");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Value).HasMaxLength(255);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Department");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.DepartmentId, "FK_Employee_department_id");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.DepartmentId).HasColumnType("int(11)");
            entity.Property(e => e.FullName).HasMaxLength(255);

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Department_Id2");
        });

        modelBuilder.Entity<GroupApplicationContact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("GroupApplicationContact");

            entity.HasIndex(e => e.ApplicationId, "FK_GroupApplicationContact_Application_Id");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ApplicationId).HasColumnType("int(11)");
            entity.Property(e => e.ContactEmail).HasMaxLength(255);
            entity.Property(e => e.ContactName).HasMaxLength(255);
            entity.Property(e => e.ContactPhone).HasMaxLength(255);
            entity.Property(e => e.Organization).HasMaxLength(255);

            entity.HasOne(d => d.Application).WithMany(p => p.GroupApplicationContacts)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupApplicationContact_Application_Id");
        });

        modelBuilder.Entity<PersonalVisitor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("PersonalVisitor");

            entity.HasIndex(e => e.ApplicationId, "FK_PersonalVisitor_Application_Id");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ApplicationId).HasColumnType("int(11)");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.MiddleName).HasMaxLength(255);
            entity.Property(e => e.Organization).HasMaxLength(255);
            entity.Property(e => e.PassportNumber).HasMaxLength(6);
            entity.Property(e => e.PassportSeries).HasMaxLength(4);
            entity.Property(e => e.Phone).HasMaxLength(255);

            entity.HasOne(d => d.Application).WithMany(p => p.PersonalVisitors)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonalVisitor_Application_Id");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Status");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Value).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
