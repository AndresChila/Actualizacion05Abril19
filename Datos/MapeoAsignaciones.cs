using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Datos
{
    class MapeoAsignaciones : DbContext
    {
        public DbSet<Asignaciones> Asignaciones { get; set; }
        public MapeoAsignaciones() : base("name = sedes1")
        {
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
