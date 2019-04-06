using Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ValidacionesCRUDProducto
    {
        DAOUsuario dao = new DAOUsuario();
        String msj1, msj2, msj3, msj4, msj5, msj6, msj7, msj8;
        Hashtable compIdiomaa = new Hashtable();

        public ValidacionesCRUDProducto(string idioma)
        {
            mensajesTrad(idioma, 16);
            msj1 = compIdiomaa["1"].ToString();
            msj2 = compIdiomaa["2"].ToString();
            msj3 = compIdiomaa["3"].ToString();
            msj4 = compIdiomaa["4"].ToString();
            msj5 = compIdiomaa["5"].ToString();
            msj6 = compIdiomaa["6"].ToString();
            msj7 = compIdiomaa["7"].ToString();
            msj8 = compIdiomaa["8"].ToString();
        }
        string mensaje = "Datos correctos. Puede ingresar";
        bool validarLlenoAgregar(string refp, string precio, string cantidad)
        {
            if (refp == "" || precio == "" || cantidad == "")
            {
                mensaje = "Por favor llene todos los campos";
                return false;
            }
            else
            {
                return true;
            }
        }
        bool validarLlenoEditar(string refp, string precio, string cantidad)
        {
            if (refp == "" || precio == "" || cantidad == "")
            {
                return false;
            }
            else
            {
                mensaje = "Por favor llene todos los campos.";
                return true;
            }
        }

        public bool validarNumeros(string num)
        {
            try
            {
                double x = Convert.ToDouble(num);
                return true;
            }
            catch (Exception)
            {
                mensaje = "Ingrese un dato númerico válido";
                return false;
            }
        }

        public void AgregarProducto(string refp, string precio, string cantidad, string talla)
        {
            if (validarLlenoAgregar(refp, precio, cantidad) == true)
            {
                if (validarNumeros(cantidad) == true)
                {
                    if (validarNumeros(precio) == true)
                    {
                        DAOUsuario dAO = new DAOUsuario();
                        Producto producto = new Producto();
                        Producto producto2 = new Producto();
                        producto.Referencia = refp;
                        producto.Cantidad = Convert.ToInt64(cantidad);
                        producto.Precio = Convert.ToDouble(precio);
                        producto.Talla = Convert.ToDouble(talla);
                        if (producto.Precio <= 0 || producto.Cantidad <= 0)
                        {
                            mensaje = "Ingrese un valor mayor a 0.";
                            return;
                        }
                        producto2.Referencia = refp;
                        producto2.Precio = Convert.ToDouble(precio);
                        producto2.Talla = Convert.ToDouble(talla);
                        List<string> referencias = dAO.ReferenciasProducto();
                        List<Producto> referencias2 = new List<Producto>();
                        referencias2 = dAO.pruebaaa();
                        if (referencias2.Contains(producto2))
                        {
                            mensaje = "Este producto ya esta registrado. Si desea añadir mas elementos de este producto, dirijase a la seccion de actualizar un producto.";
                        }
                        else
                        {                           
                            dAO.crearProducto(producto);
                            mensaje = "Producto ingresado exitosamente";
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                }
            }
            else
            {
            }
        }

        public string devuelvemensaje()
        {
            return mensaje;
        }
        Producto producto = new Producto();
        public void RowCommand(string name, string argument, int r)
        {
            DAOUsuario dAO = new DAOUsuario();                        
            if(name.Equals("Delete"))
            {
                int id = Convert.ToInt32(argument);
                dAO.eliminarProducto(id);
                this.SetProducto(0);
            }
            if (name.Equals("Editar"))
            {
                this.SetProducto(Convert.ToInt32(argument));
            }
        }

        public void SetProducto(int r)
        {
            DAOUsuario dAO = new DAOUsuario();            
            int refe = r;
            DataTable productos = dAO.verProductosEditar(refe);
            if (productos != null && r > 0)
            {
                foreach (DataRow row in productos.Rows)
                {
                    producto.Referencia = Convert.ToString(row["referenciaproducto"]);
                    producto.Cantidad = Convert.ToInt64(row["cantidad"]);
                    producto.Talla = Convert.ToDouble(row["talla"]);
                    producto.Precio = Convert.ToDouble(row["precio"]);
                }
            }
            else
            {
                producto.Referencia = "";
                producto.Cantidad = 0;
                producto.Talla = 0;
                producto.Precio = 0;
            }              
        }

        public Producto GetProducto()
        {
            return producto;
        }

        public void EditarProducto(string refp, string precio, string cantidad, string talla, string id, string com)
        {
            if (validarLlenoAgregar(refp, precio, cantidad) == true)
            {
                if (validarNumeros(cantidad) == true)
                {
                    if (validarNumeros(precio) == true)
                    {
                        DAOUsuario dAO = new DAOUsuario();
                        Producto producto = new Producto();
                        Producto producto2 = new Producto();
                        producto.Referencia = refp;
                        producto.Cantidad = Convert.ToInt64(cantidad);
                        producto.Precio = Convert.ToDouble(precio);
                        producto.Talla = Convert.ToDouble(talla);
                        producto.Idproducto = Convert.ToInt32(id);
                        if (producto.Precio <= 0 || producto.Cantidad <= 0)
                        {
                            mensaje = "Ingrese un valor mayor a cero";
                            return;
                        }
                        string comp = com;
                        
                        if (Convert.ToInt32(producto.Cantidad) < Convert.ToInt32(comp))
                        {
                            mensaje = "El numero de elementos de esta referencia debe ser mayor o igual a los ya existente.";
                            return;
                        }
                        else
                        {
                            dAO.editarProducto(producto);
                            mensaje = "Producto editado exitosamente.";
                            return;
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                }
            }
            else
            {
            }            
        }
        int kIdioma;
        public Hashtable paraIdioma(string idioma, int constante)
        {
            DataTable comp = new DataTable();
            Hashtable compIdioma = new Hashtable();
            DataTable idi = new DataTable();
            idi = dao.traerIdioma();
            for (int i = 0; i < idi.Rows.Count; i++)
            {
                if (idi.Rows[i]["nombre"].ToString().ToLower() == idioma.ToLower())
                {
                    kIdioma = int.Parse(idi.Rows[i]["id"].ToString());
                }
            }
            comp = dao.traerComponentes(kIdioma, constante);
            for (int i = 0; i < comp.Rows.Count; i++)
            {
                compIdioma.Add(comp.Rows[i]["control"].ToString(), comp.Rows[i]["texto"].ToString());
            }
            return compIdioma;
        }

        //int kIdiomaa;
        public void mensajesTrad(string idioma, int constante)
        {
            DataTable comp = new DataTable();
            DataTable idi = new DataTable();
            idi = dao.traerIdioma();
            for (int i = 0; i < idi.Rows.Count; i++)
            {
                if (idi.Rows[i]["nombre"].ToString().ToLower() == idioma.ToLower())
                {
                    kIdioma = int.Parse(idi.Rows[i]["id"].ToString());
                }
            }
            comp = dao.traerMensajes(kIdioma, constante);
            for (int i = 0; i < comp.Rows.Count; i++)
            {
                compIdiomaa.Add(comp.Rows[i]["msj"].ToString(), comp.Rows[i]["texto"].ToString());
            }
        }
    }
}
///////////////////arreglado
