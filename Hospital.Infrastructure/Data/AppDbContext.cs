using Hospital.Core;
using Hospital.Core.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Data
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Appointment>().HasOne(x => x.Doctor).WithMany()
                .OnDelete(DeleteBehavior.Restrict); ;
            builder.Entity<Appointment>().HasOne(x => x.Patient).WithMany()
                .OnDelete(DeleteBehavior.Restrict); ;

            builder.Entity<PatientReport>().HasOne(x => x.Patient).WithMany()
                .OnDelete(DeleteBehavior.Restrict); ;
            builder.Entity<PatientReport>().HasOne(x => x.Doctor).WithMany()
                .OnDelete(DeleteBehavior.Restrict); ;
            //builder.Entity<AppUser>().HasOne(x => x.Department).WithMany();
        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<HospitalInfo> HospitalInfo { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicineReport> MedicineReports { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<TestPrice> TestPrices { get; set; }
        public DbSet<PrescribedMedicine> PrescribedMedicines { get; set; }
    }
}
