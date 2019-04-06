using System.Data.Entity;

namespace Datos
{
    class Mapeo: DbContext
    {
        public DbSet<Sede> Sedes { get; set; }              
        
        public Mapeo() : base("name = sedes1")
        {            
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {            
            base.OnModelCreating(builder);
        }
    }
}
