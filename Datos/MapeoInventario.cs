using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class MapeoInventario :DbContext
    {
        public DbSet<Inventario> Inventarios { get; set; }
        public MapeoInventario() :base("name = sedes1")
        {
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
