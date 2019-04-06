using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;


namespace Datos
{
    public class MapeoAsignacion: DbContext 
    {
        public DbSet<Asignacion1> Asignacion { get; set; }
        public MapeoAsignacion() : base("name = sedes1")
        {
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
