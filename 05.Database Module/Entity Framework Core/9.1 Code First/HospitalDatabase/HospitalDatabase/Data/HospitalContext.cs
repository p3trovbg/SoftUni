namespace P01_HospitalDatabase.Data 
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;

    public class HospitalContext : DbContext
    {

        public HospitalContext()
        {
        }
        public HospitalContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PatientMedicament>(pm =>
            {
                pm.HasKey(x => new { x.PatientId, x.MedicamentId });
            });

            modelBuilder.Entity<Patient>(p =>
            {
                p.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(true);

                p.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(true);

                p.Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode(true);

                p.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Visitation>(v =>
            {
                v.Property(x => x.Comments)
                .HasMaxLength(250)
                .IsUnicode(true);
            });

            modelBuilder.Entity<Diagnose>(d =>
            {
                d.Property(x => x.Comments)
                .HasMaxLength(250)
                .IsUnicode(true);

                d.Property(x => x.Name)
                .HasMaxLength(50)
                .IsUnicode(true);
            });

            modelBuilder.Entity<Medicament>(m =>
            {
                m.Property(x => x.Name)
                .HasMaxLength(50)
                .IsUnicode(true);
            });
        }
    }
}
