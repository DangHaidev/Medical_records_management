using System;
using System.Collections.Generic;
using Medical_record.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medical_record.Infrastructure.Persistence;

public partial class ApplicationDb : DbContext
{
    public ApplicationDb()
    {
    }

    public ApplicationDb(DbContextOptions<ApplicationDb> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<Report> Reports { get; set; }
    public virtual DbSet<PhieuKhamBenh> PhieuKhamBenhs { get; set; }
    public virtual DbSet<PhieuKhamBenhDetail> PhieuKhamBenhDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=haidang\\sqlexpress;Initial Catalog=QuanLyBenhNhan;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__D06765FEC75DCD3B");

            entity.ToTable("Appointment");

            entity.Property(e => e.AppointmentId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("appointmentId");
            entity.Property(e => e.AppointmentDate)
                .HasColumnType("datetime")
                .HasColumnName("appointmentDate");
            entity.Property(e => e.AppointmentType)
                .HasMaxLength(50)
                .HasColumnName("appointmentType");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("employeeId");
            entity.Property(e => e.PatientId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("patientId");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            entity.HasOne(d => d.Employee).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Appointme__emplo__5BE2A6F2");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Appointme__patie__5AEE82B9");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__C134C9C16ED1D79F");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("employeeId");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");
            entity.Property(e => e.Specialty)
                .HasMaxLength(100)
                .HasColumnName("specialty");
        });

        modelBuilder.Entity<MedicalRecord>(entity =>
        {
            entity.HasKey(e => e.RecordId).HasName("PK__MedicalR__D825195E92C503BF");

            entity.ToTable("MedicalRecord");

            entity.Property(e => e.RecordId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("recordId");
            entity.Property(e => e.AdmissionDate).HasColumnName("admissionDate");
            entity.Property(e => e.Department)
                .HasMaxLength(100)
                .HasColumnName("department");
            entity.Property(e => e.Diagnosis)
                .HasMaxLength(255)
                .HasColumnName("diagnosis");
            entity.Property(e => e.DischargeDate).HasColumnName("dischargeDate");
            entity.Property(e => e.PatientId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("patientId");
            entity.Property(e => e.Room)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("room");
            entity.Property(e => e.Treatment)
                .HasMaxLength(255)
                .HasColumnName("treatment");

            entity.HasOne(d => d.Patient).WithMany(p => p.MedicalRecords)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__MedicalRe__patie__5812160E");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patient__A17005ECE2EF97DC");

            entity.ToTable("Patient");

            entity.Property(e => e.PatientId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("patientId");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.BirthDate).HasColumnName("birthDate");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Photo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("photo");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.PrescriptionId).HasName("PK__Prescrip__7920FC245F59740F");

            entity.ToTable("Prescription");

            entity.Property(e => e.PrescriptionId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("prescriptionId");
            entity.Property(e => e.DatePrescribed).HasColumnName("datePrescribed");
            entity.Property(e => e.Dosage)
                .HasMaxLength(50)
                .HasColumnName("dosage");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("employeeId");
            entity.Property(e => e.Medication)
                .HasMaxLength(100)
                .HasColumnName("medication");
            entity.Property(e => e.RecordId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("recordId");

            entity.HasOne(d => d.Employee).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Prescript__emplo__5FB337D6");

            entity.HasOne(d => d.Record).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.RecordId)
                .HasConstraintName("FK__Prescript__recor__5EBF139D");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Report__1C9B4E2D14E3DF27");

            entity.ToTable("Report");

            entity.Property(e => e.ReportId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("reportId");
            entity.Property(e => e.Data)
                .HasColumnType("text")
                .HasColumnName("data");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("employeeId");
            entity.Property(e => e.GeneratedDate).HasColumnName("generatedDate");
            entity.Property(e => e.ReportType)
                .HasMaxLength(50)
                .HasColumnName("reportType");

            entity.HasOne(d => d.Employee).WithMany(p => p.Reports)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Report__employee__628FA481");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
