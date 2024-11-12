
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace Estacionamiento.Models
{
    public class EstacionamientoContext : DbContext
    {
    
        public DbSet<Estacionamiento> estacionamientos { get; set; }
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Administrador> administradors { get; set; }    
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Ticket> ticket { get; set; }
        
        public DbSet<Vehiculo> vehiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-CUKE023\\MSSQLSERVER01, Initial Catalog = EstacionamientoDB;" + "Encrypt = ture;" + "TrustServerCertificate = true;" + "Integrated Security = ture");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasOne(cli => cli.Estacionamiento).WithMany(es => es.Clientes).HasForeignKey(cli => cli.EstacionamientoId);
            modelBuilder.Entity<Vehiculo>().HasOne(ve => ve.Estacionamiento).WithMany(es => es.Plaza).HasForeignKey(ve => ve.EstacionamientoId);
            modelBuilder.Entity<Ticket>().HasOne(tik => tik.Estacionamiento).WithMany(es => es.Tickets).HasForeignKey( tik => tik.EstacionamientoId);
            modelBuilder.Entity<Administrador>().HasOne(admin => admin.Estacionamiento).WithOne(es => es.Administrador).HasForeignKey<Administrador>(admin => admin.EstacionamientoId);


        }

    }
}
