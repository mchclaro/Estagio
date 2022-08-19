
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Address> Address { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentPayment> AppointmentPayments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Estimate> Estimates { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine("Creating models...");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            OnModelCreatingPartial(modelBuilder);
        }

         partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}