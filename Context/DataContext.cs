using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Initial Values

            #endregion Initial Values

            #region Configuration Models

            modelBuilder.Entity<Usuario>(usuario =>
            {
                usuario.ToTable("Usuario");
                usuario.HasKey(prop => prop.UsuarioId);
                usuario.Property(prop => prop.Nombre).IsRequired().HasMaxLength(150);
                usuario.Property(prop => prop.Correo).IsRequired();
                usuario.Property(prop => prop.Edad).IsRequired();
                //usuario.HasData(usuarioInit); //Si queremos inicializar usuarios al comienzo de la app descomentar esta linea.
            });

            #endregion Configuration Models
        }
    }
}
