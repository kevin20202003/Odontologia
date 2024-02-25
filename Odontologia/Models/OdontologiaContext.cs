using Microsoft.EntityFrameworkCore;
using Odontologia.Models.Entidades;

namespace Odontologia.Models
{
    public class OdontologiaContext : DbContext
    {
        public OdontologiaContext()
        {
        }
        public OdontologiaContext(DbContextOptions<OdontologiaContext> options) : base(options)
        {

        }

        public DbSet<Contacto> Contactos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Contacto>().HasIndex(c => c.nombre).IsUnique();
        }
    }
}
