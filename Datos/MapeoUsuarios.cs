using Utilitarios;
using System.Data.Entity;

namespace Datos
{
    class MapeoUsuarios : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public MapeoUsuarios () : base("name = sedes1")
        {
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);           
        }
    }
}