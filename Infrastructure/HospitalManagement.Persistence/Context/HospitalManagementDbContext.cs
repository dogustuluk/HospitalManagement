﻿using HospitalManagement.Domain.Entities.Appointment;
using HospitalManagement.Domain.Entities.Common;
using HospitalManagement.Domain.Entities.Identity;
using HospitalManagement.Domain.Entities.Management;
using HospitalManagement.Domain.Entities.Medical;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Persistence.Context
{
    public class HospitalManagementDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public HospitalManagementDbContext(DbContextOptions options) : base(options)
        {
        }
        #region Appointment
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<VisitorAppointment> VisitorAppointments { get; set; }
        public DbSet<ExaminationAppointment> ExaminationAppointments { get; set; }
        #endregion

        #region Commerce

        #endregion

        #region Common
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AnyParam> AnyParams { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<DbParameter> DbParameters { get; set; }
        public DbSet<DbParameterType> DbParameterTypes { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Domain.Entities.Common.File> Files { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Status> Statuses { get; set; }
        #endregion

        #region HR

        #endregion

        #region Management
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ItemChange> ItemChanges { get; set; }
        public DbSet<OperationLog> OperationLogs { get; set; }
        public DbSet<PdfTemplate> PdfTemplates { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<ServiceLog> ServiceLogs { get; set; }
        #endregion

        #region Medical
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicineDetail> MedicineDetails { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<TreatmentPlan> TreatmentPlans { get; set; }
        #endregion

        #region Payment

        #endregion

        #region Users
        
        #endregion


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUser>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(a => a.Id)
                .ValueGeneratedOnAdd();
                
            });

            


            builder.Entity<City>()
                .HasKey(a => a.Id);
            builder.Entity<County>()
                .HasKey(a => a.Id);
            builder.Entity<County>()
                .HasOne(a => a.City) // County sınıfının bir City nesnesine sahip olduğunu belirt
                .WithMany(a => a.Countys) // City sınıfının birden fazla County nesnesine sahip olabileceğini belirt
                .HasForeignKey(a => a.CityId); // County sınıfının CityId özelliğinin foreign key olduğunu belirt

            builder.Entity<Room>()
                .HasKey(a => a.Id);
            


            builder.Entity<Medicine>()
                .HasKey(a => a.Id);
            builder.Entity<MedicineDetail>()
                .HasKey(a => a.Id);
            builder.Entity<Medicine>()
                .HasOne(a => a.MedicineDetail)
                .WithOne(a => a.Medicine)
                .HasForeignKey<Medicine>(a => a.MedicineDetailId);

            builder.Entity<MedicineDetail>()
                .HasOne(a => a.Medicine)
                .WithOne(a => a.MedicineDetail)
                .HasForeignKey<MedicineDetail>(a => a.MedicineId);


            builder.Entity<TreatmentPlan>()
                .HasKey(a => a.Id);
            builder.Entity<Prescription>()
                .HasKey(a => a.Id);
            builder.Entity<Prescription>()
                .HasOne(a => a.TreatmentPlan)
                .WithMany(a => a.Prescriptions)
                .HasForeignKey(a => a.Id);


            builder.Entity<Prescription>()
                .HasMany(p => p.Medicines) // Prescription sınıfının birden fazla Medicine nesnesine sahip olduğunu belirt
                .WithMany() // Medicine nesnesinin herhangi bir koleksiyon ile ilişkili olmadığını belirt (Medicine sınıfında belirtilen koleksiyon olmadığı için)
                .UsingEntity(j => j.ToTable("PrescriptionMedicines")); // İlişkiyi belirleyen ara tabloyu belirt (varsayılan olarak PrescriptionMedicines tablosunu kullanır)

            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker
                .Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}