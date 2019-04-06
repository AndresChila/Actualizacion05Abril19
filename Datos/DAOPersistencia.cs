using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Utilitarios;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DAOPersistencia
    {
        public List<Sede> traerSedes()
        {
            using (var db = new Mapeo())
            {
                return db.Sedes.Where(x => x.Estado == "true").ToList();
            }
        }

        public bool AgregarSede(Sede sede)
        {
            using (var db = new Mapeo())
            {
                int resultado = db.Sedes.Where(x => x.NombreSede == sede.NombreSede && x.Ciudad == sede.Ciudad).Count();
                if (resultado == 0)
                {
                    db.Sedes.Add(sede);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public void EliminarSede(int idSede)
        {
            using (var db = new Mapeo())
            {
                var entities = (from p in db.Sedes
                                where p.IdSede == idSede
                                select p).Single();
                entities.Estado = "false";
                db.Entry(entities).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<Usuario> traerUsuarios(int estado, int rol)
        {
            using (var db = new MapeoUsuarios())
            {
                return db.Usuarios.Where(x => x.Estado == estado && x.RolId == rol).ToList();
            }
        }

        public Usuario ExisteUsuario(Usuario usu)
        {
            try
            {
                using (var db = new MapeoUsuarios())
                    return db.Usuarios.First(t => t.Cedula == usu.Cedula);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool AgregarUsuario(Usuario usu)
        {
            using (var db = new MapeoUsuarios())
            {
                Usuario a = this.ExisteUsuario(usu);
                if (a == null)
                {
                    db.Usuarios.Add(usu);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    db.Entry(a).State = EntityState.Modified;
                    db.SaveChanges();
                    return false;
                }
            }
        }

        public int not_asignaciones()
        {
            using (var db = new MapeoPedido())
            {
                int resultado = db.Pedido.Where(x => x.Estado == false && x.Observacion == null).Count();
                return resultado;
            }
        }

        public int not_conflictos()
        {
            using (var db = new MapeoPedido())
            {
                int resultado = db.Pedido.Where(x => x.Estado == false && x.Observacion != null).Count();
                return resultado;
            }
        }

        public int not_pedido(string sede)
        {
            using (var db = new MapeoAsignacion())
            {
                int resultado = db.Asignacion.Where(x => x.Estado == false && x.Sede == sede).Count();
                return resultado;
            }            
        }

        public void AgregarAsignacion(Asignacion1 asignacion)
        {
            using(var db = new MapeoAsignacion())
            {
                db.Asignacion.Add(asignacion);
                db.SaveChanges();
            }
        }

        public void AgregarAsignaciones(Asignaciones asignaciones)
        {
            using(var db = new MapeoAsignaciones())
            {                
                db.Asignaciones.Add(asignaciones);
                db.SaveChanges();
            }
        }

        public void EditarCantidad(Producto producto)
        {
            using(var db = new MapeoProducto())
            {
                var entities = (from p in db.Productos
                                where p.Idproducto == producto.Idproducto
                                select p).Single();
                entities.Entregado = producto.Entregado;
                db.Entry(entities).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        private List<Asignacion1> VerAsignacion()
        {
            using(var db = new MapeoAsignacion())
            {
                return db.Asignacion.ToList();
            }            
        }


        public int VerUltimoIdAsignacion()
        {
            List<Asignacion1>  lista1 = this.VerAsignacion();
            Asignacion1 aa = lista1.Max();
            return aa.IdAsignacion;
        }

        public List<Pedido1> VerPedido(int id)
        {
            using (var db = new MapeoPedido())
            {
                return db.Pedido.Where(x => x.Estado == true && x.IdPedido == id).ToList();
            }
        }

        public List<Pedidos> VerPedidos(int id)
        {
            using(var db = new MapeoPedidos())
            {
                return db.Pedidos.Where(x => x.Idpedido == id).ToList();
            }
        }

        public List<Producto> ValidarAsignacion(string refe, double talla)
        {
            using(var db = new MapeoProducto())
            {
                return db.Productos.Where(x => x.Referencia == refe && x.Talla == talla).ToList();
            }
        }

        public List<Producto> VerProductos()
        {
            using(var db = new MapeoProducto())
            {
                return db.Productos.ToList();
            }
        }

        public List<Pedido1> VerPedido()
        {
            using(var db = new MapeoPedido())
            {
                return db.Pedido.Where(x => x.Estado == false).ToList();
            }
        }

        public void ActualizarPedido(int id)
        {
            using(var db = new MapeoPedido())
            {
                var entities = (from p in db.Pedido
                                where p.IdPedido == id
                                select p).Single();
                entities.Estado = true;
                db.Entry(entities).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            using (var db = new MapeoUsuarios())
            {
                var entities = (from p in db.Usuarios
                                where p.Cedula == usuario.Cedula
                                select p).Single();
                entities = usuario;
                db.Entry(entities).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<Usuario> ObtenerAdmins()
        {
            using(var db = new MapeoUsuarios())
            {
                return db.Usuarios.Where(x => x.RolId == 2 && x.Estado == 1).ToList();
            }
        }

        public void EliminarUsuario(int cedula)
        {
            using (var db = new MapeoUsuarios())
            {
                var entities = (from p in db.Usuarios
                                where p.Cedula == cedula
                                select p).Single();
                entities.Estado = 2;
                db.Entry(entities).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public Cliente ExisteCliente(int id)
        {
            try
            {
                using (var db = new MapeoCliente())
                    return db.Clientes.First(t => t.Cedula == id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool AgregarCliente()
        {

            return false;
        }

        public List<IdiomaT> ObtenerIdiomas()
        {
            using(var db = new MapeoIdioma())
            {
                return db.Idiomas.ToList();
            }
        }

        public List<Inventario> VerInventario(string sede)
        {
            string[] commandArgs = sede.ToString().Split(new char[] { '-' });
            string sede1 = commandArgs[0];
            using (var db = new MapeoInventario())
            {
                return db.Inventarios.Where(x => x.Sede == sede1 && x.Cantidad > 0).ToList();
            }
        }
    }
}
