using MusikalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MusikalAPI.Context
{
    public class MusikalContext : DbContext
    {
        public MusikalContext(DbContextOptions<MusikalContext> options) : base(options)
        {
        }

        //DbSet = Representa una tabla en la base de datos
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        //public DbSet<PasarelaPago> PasarelaPago { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuracion para Marca
            modelBuilder.Entity<Marca>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Marca>()
                .Property(m => m.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Marca>()
                .Property(m => m.PaisOrigen)
                .HasMaxLength(100);

            //Configuracion para Tipo
            modelBuilder.Entity<Tipo>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Tipo>()
                .Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            //Configuracion para Modelo
            modelBuilder.Entity<Modelo>()
                .HasKey(mo => mo.Id);

            modelBuilder.Entity<Modelo>()
                .Property(mo => mo.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Modelo>()
                .Property(mo => mo.Descripcion)
                .HasMaxLength(250);

            modelBuilder.Entity<Modelo>()
                .Property(mo => mo.Precio)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            modelBuilder.Entity<Modelo>()
               .Property(modelBuilder => modelBuilder.StockDisponible)
               .IsRequired();

            //Relaciones: Modelo - Marca y Modelo - Tipo
            modelBuilder.Entity<Modelo>()
                .HasOne(mo => mo.Marca)
                .WithMany()
                .HasForeignKey(mo => mo.IdMarca)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Modelo>()
                .HasOne(mo => mo.Tipo)
                .WithMany()
                .HasForeignKey(mo => mo.IdTipo)
                .OnDelete(DeleteBehavior.Restrict);

            //Configuracion para Cliente
            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Apellido)
                .HasMaxLength(100);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Email)
                .HasMaxLength(150);

            //Configuracion para Factura
            modelBuilder.Entity<Factura>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Factura>()
                .Property(f => f.FechaEmision)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("GETDATE()"); //Fecha por defecto la fecha actual

            modelBuilder.Entity<Factura>()
                .Property(f => f.MontoTotal)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            modelBuilder.Entity<Factura>()
                .Property(f => f.CodigoPagoUnico)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Factura>()
                .Property(f => f.Estado)
                .IsRequired()
                .HasMaxLength(50);

            //Relación: Factura - Cliente
            modelBuilder.Entity<Factura>()
                .HasOne(f => f.Cliente)
                .WithMany()
                .HasForeignKey(f => f.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

            //Pasarela de Pago
            /*
            modelBuilder.Entity<PasarelaPago>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<PasarelaPago>()
                .Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<PasarelaPago>()
                .Property(p => p.UrlBase)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<PasarelaPago>()
                .Property(p => p.ApiKey)
                .HasMaxLength(200);
            */

        } 
    }
}