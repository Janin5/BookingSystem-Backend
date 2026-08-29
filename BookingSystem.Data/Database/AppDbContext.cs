using BookingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Data.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public DbSet<Procedure> Procedures { get; set; }

    public DbSet<Salon> Salons { get; set; }

    public DbSet<SalonSchedule> SalonSchedules { get; set; }

    public DbSet<Stylist> Stylists { get; set; }

    public DbSet<StylistSchedule> StylistSchedules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Stylist)
            .WithMany(s => s.Appointments)
            .HasForeignKey(a => a.StylistId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Procedure)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.ProcedureId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Procedure>()
            .Property(p => p.Duration)
            .HasColumnType("time(0)");

        modelBuilder.Entity<Stylist>()
        .HasOne(s => s.Salon)
        .WithMany(sa => sa.Stylists)
        .HasForeignKey(s => s.SalonId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Stylist>()
       .HasMany(s => s.Procedures)
       .WithMany(p => p.Stylists)
       .UsingEntity<Dictionary<string, object>>(
       "ProcedureStylist",
       j => j.HasOne<Procedure>().WithMany().OnDelete(DeleteBehavior.NoAction),
       j => j.HasOne<Stylist>().WithMany().OnDelete(DeleteBehavior.NoAction)
);
    }
}
