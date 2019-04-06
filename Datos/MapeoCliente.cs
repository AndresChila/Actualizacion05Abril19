using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class MapeoCliente : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public MapeoCliente() : base("name = sedes1")
        {
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
    
}
