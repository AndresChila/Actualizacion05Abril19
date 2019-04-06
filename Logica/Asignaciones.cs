using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;
using Utilitarios;
using System.Collections;

namespace Logica
{
    public class Asignaciones
    {
        int kIdioma;
        DAOUsuario dAO = new DAOUsuario();
        DataTable comp = new DataTable();
        Hashtable compIdiomaa = new Hashtable();
        string msj1, msj2, msj3, msj4, msj5, msj6, msj7, msj8, msj9, msj10, msj11, msj12, msj13, msj14, msj15;
        public Asignaciones(string idioma)
        {
            mensajesTrad(idioma, 3);
            msj1= compIdiomaa["1"].ToString();
            msj2 = compIdiomaa["2"].ToString();
            msj3 = compIdiomaa["3"].ToString();
            msj4 = compIdiomaa["4"].ToString();
            msj5 = compIdiomaa["5"].ToString();
            msj6 = compIdiomaa["6"].ToString();
            msj7 = compIdiomaa["7"].ToString();
            msj8 = compIdiomaa["8"].ToString();
            msj9 = compIdiomaa["9"].ToString();
            msj10 = compIdiomaa["10"].ToString();
            msj11 = compIdiomaa["11"].ToString();
            msj12 = compIdiomaa["12"].ToString();
            msj13 = compIdiomaa["13"].ToString();
            msj14 = compIdiomaa["14"].ToString();
            msj15 = compIdiomaa["15"].ToString();
        }

        string mensaje;

        public string CantidadPendiente()
        {
            DAOUsuario dAO = new DAOUsuario();
            DataTable cantidadPendiente = new DataTable();
            cantidadPendiente = dAO.verPedido();
            return cantidadPendiente.Rows.Count.ToString();
        }

        public void ValidarPedidos(DataTable source,List<Asignacion> lista, string s, string idPed)
        {
            sede = s;
            int idped = int.Parse(idPed);
            if (source.Rows.Count <= 0)
            {
                mensaje = msj1;
                return;
            }
            else
            {
                for (int i = 0; i < source.Rows.Count; i++)
                {
                    this.Asignar(source.Rows[i]["referencia"].ToString(), Convert.ToDouble(source.Rows[i]["talla"].ToString()), int.Parse(source.Rows[i]["cantidad"].ToString()), source.Rows.Count - (i + 1), lista, sede,idped);
                }
            }
        }

        public void AgregarProductos(List<Producto> pguardar, string sede)
        {
            DAOUsuario d = new DAOUsuario();
            Asignacion asignacion = new Asignacion();
            
            Pedido pedido = new Pedido();
            int cont = 0;

            foreach (Producto p in pguardar)
            {
                DateTime fechaHoy = DateTime.Now;
                cont++;
                asignacion.Fecha = fechaHoy.ToString("d");
                asignacion.Estado = false;
                asignacion.Sede = sede;
                asignacion.Referencia = p.Referencia;
                asignacion.Talla = p.Talla;
                asignacion.Cantidad = int.Parse(p.Cantidad.ToString());
                if (cont == 1)
                {
                    d.crearAsignacion(asignacion);
                }
                DataTable id = new DataTable();
                id = d.verUltimoId2();
                if (id.Rows.Count > 0)
                {
                    foreach (DataRow ff in id.Rows)
                    {
                        pedido.Idpedido = Convert.ToInt32(ff["f_verultimoid2"]);
                    }
                    d.crearAsignaciones(asignacion, pedido.Idpedido);
                    d.editarCantidad(p.Idproducto, (asignacion.Cantidad + p.Entregado));
                    mensaje = msj2;
                }                
            }
        }
            



            
        

        string sede;

        public DataTable Row_Command(string name, string argument)
        {
            DataTable detalle = new DataTable();
            if (name.Equals("Select"))
            {
                
                DataTable ped = new DataTable();
                ped = dAO.verPedido(Convert.ToInt32(argument));

                detalle = dAO.verPedidos(Convert.ToInt32(argument));
                this.set_sede( Convert.ToString(ped.Rows[0][1]));
                return detalle;
            }
            else
            {
                return detalle;
            }

        }
        List<Asignacion> aux = new List<Asignacion>();
        int entregado, idProducto;
        bool estado;
        public void Asignar(string refp, double talla, int cantidad, int count, List<Asignacion> lista, string sede, int idped)
        {
            DAOUsuario d = new DAOUsuario();

            Producto producto = new Producto();
            Pedido pedido = new Pedido();
            int cantBodega = 0;
            lista = aux;
            Asignacion asignacion = new Asignacion();            
            asignacion.Referencia = refp;
            asignacion.Talla = talla;
            asignacion.Cantidad = cantidad;
            DataTable r = d.validarAsignacion(asignacion.Referencia, asignacion.Talla);
            if (r.Rows.Count == 1)
            {
                foreach (DataRow ro in r.Rows)
                {
                    cantBodega = Convert.ToInt32(ro["cantidad"]);
                    producto.Entregado = Convert.ToInt32(ro["entregado"]);
                    entregado = producto.Entregado;
                    producto.Idproducto = Convert.ToInt32(ro["idproducto"]);
                    idProducto = producto.Idproducto;
                    cantBodega = cantBodega - producto.Entregado;
                }
                if (asignacion.Cantidad < cantBodega)
                {                    
                    if ((cantBodega - asignacion.Cantidad) >= 5)
                    {
                        DateTime fechaHoy = DateTime.Now;
                        asignacion.IdProducto = producto.Idproducto;
                        asignacion.Fecha = fechaHoy.ToString("d");
                        asignacion.Estado = false;
                        asignacion.Sede = Convert.ToString(sede);
                        if (lista == null)
                        {
                            lista = new List<Asignacion>();
                            lista.Add(asignacion);
                            aux = lista;
                        }
                        else
                        {
                            lista.Add(asignacion);
                            aux = lista;
                        }
                        estado = true;
                    }
                    else
                    {
                        estado = false;
                        mensaje = msj3 + asignacion.Referencia + msj4 + asignacion.Talla + ".";
                        return;
                    }
                }
                else
                {
                    estado = false;
                    mensaje = msj5;
                    return;
                }
            }
            else
            {
                estado = false;
                mensaje = msj6;
                return;
            }

            
        }
        int idpedido;
        public void ingresarBD(List<Asignacion> lista, int idPed, int entr)
        {
            DAOUsuario d = new DAOUsuario();
            List<Asignacion> listaAsignacion2 = new List<Asignacion>();
            listaAsignacion2 = lista;
            
            entregado = entr;
            int cont = 0;
            if (listaAsignacion2.Count > 0)
            {
                foreach (Asignacion a in listaAsignacion2)
                {
                    cont++;
                    if (cont == 1)
                    {
                        d.crearAsignacion(a);
                    }
                    DataTable id = new DataTable();
                    id = d.verUltimoId2();
                    if (id.Rows.Count > 0)
                    {
                        foreach (DataRow ff in id.Rows)
                        {
                            idpedido = Convert.ToInt32(ff["f_verultimoid2"]);
                        }
                        d.crearAsignaciones(a, Convert.ToInt32(idpedido));
                        d.editarCantidad(Convert.ToInt32(a.IdProducto), (a.Cantidad + Convert.ToInt32(entregado)));
                        d.actualizarPedido(true, Convert.ToInt32(idPed));
                        mensaje = msj7;
                        return;
                    }
                }
            }
            else
            {
                mensaje =msj8;
                return;
            }
        }
        List<Producto> aux1 = new List<Producto>();
        Validaciones val = new Validaciones();
        public string listaEnviar(List<Producto> lproducto, string referencia, string talla, string cantidad)
        {
            DAOUsuario dao = new DAOUsuario();
            
            int cantBodega = 0;
            if (val.validarVacio(referencia) == true && val.validarVacio(talla) && val.validarVacio(cantidad) == true)
            {
                if (val.validarNumeros(cantidad) == true)
                {
                    Producto p = new Producto();
                    p.Referencia = referencia;
                    p.Talla = Convert.ToDouble(talla);
                    p.Cantidad = Convert.ToInt64(cantidad);
                    DataTable r = dao.validarAsignacion(p.Referencia, p.Talla);
                    if (r.Rows.Count == 1)
                    {
                        foreach (DataRow row in r.Rows)
                        {
                            cantBodega = Convert.ToInt32(row["cantidad"]);
                            p.Entregado = Convert.ToInt32(row["entregado"]);
                            p.Idproducto = Convert.ToInt32(row["idproducto"]);
                            cantBodega = cantBodega - p.Entregado;

                        }
                    }
                    else
                    {

                    }
                    if (p.Cantidad < cantBodega)
                    {
                        if ((cantBodega - p.Cantidad) >= 5)
                        {
                            if (lproducto == null)
                            {
                                lproducto = new List<Producto>();
                                lproducto.Add(p);
                                aux1 = lproducto;
                            }
                            else
                            {
                                lproducto.Add(p);
                                aux1 = lproducto;
                            }
                            return msj9 + p.Referencia + msj10 + p.Talla + msj11 + p.Cantidad + ".";
                        }
                        else
                        {
                            return msj12;
                        }
                    }
                    else
                    {
                        return msj13;
                    }

                }
                else
                {
                    return msj14;
                }
            }
            else
            {
                return msj15;
            }            
            
        }

        public bool GeT_Estado()
        {
            return estado;
        }

        public List<Asignacion> GetPedidos()
        {
            return aux;
        }

        public List<Producto> GetAsignacionSinPedido()
        {
            return aux1;
        }

        public int GetEntregado()
        {
            return entregado;
        }

        public int GetId()
        {
            return idProducto;
        }
        public void set_sede(string a)
        {
            sede = a;
        }
        public string Get_Sede()
        {
            return sede;
        }

        public string Devuelve_Mensaje()
        {
            return mensaje;
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
                return false;
            }
        }
        //string gvProdBogcolumn0, gvProdBogcolumn1, gvProdBogcolumn2, gvProdBogcolumn3, gvProdBogcolumn4, gvPendColum0, gvPendColum1, gvPendColum2, gvPendColum3, gvAsigSinPedColumn0, 
        //    gvAsigSinPedColumn1, gvAsigSinPedColumn2, lAsignSinPed, lProdBod, lCantidad, lAsigPend, lDetallePed, lRef1, bValid, bAsig1, bAsignar1, lTalla1, bAgregar, lSede, bAsignar,
        //    gvAsigFinColumn0, gvAsigFinColumn1, gvAsigFinColumn2, gvAsigFinColumn3;
        //, string gvProdBogcolumn0, string gvProdBogcolumn1, string gvProdBogcolumn2, string gvProdBogcolumn3, 
            //string gvProdBogcolumn4, string gvPendColum0, string gvPendColum1, string gvPendColum2, string gvPendColum3, string gvAsigSinPedColumn0, string gvAsigSinPedColumn1, 
            //string gvAsigSinPedColumn2, string lAsignSinPed, string lProdBod, string lCantidad, string lAsigPend,string lDetallePed, string lRef1, string bValid, string bAsig1, 
            //string bAsignar1, string lTalla1, string bAgregar, string lSede, string gvAsigFinColumn0, string gvAsigFinColumn1, string gvAsigFinColumn2, 
            //string gvAsigFinColumn3
        public Hashtable paraIdioma(string idioma, int constante)
        {
            Hashtable compIdioma = new Hashtable();
            if (idioma == "Español")
            {
                kIdioma = 1;
            }
            else if (idioma == "English")
            {
                kIdioma = 2;
            }
            comp = dAO.traerComponentes(kIdioma, constante);
            for (int i = 0; i < comp.Rows.Count; i++)
            {
                compIdioma.Add(comp.Rows[i]["control"].ToString(), comp.Rows[i]["texto"].ToString());
            }
            return compIdioma;
        }

        int kIdiomaa;
        public void mensajesTrad(string idioma, int constante)
        {

            if (idioma == "Español")
            {
                kIdiomaa = 1;
            }
            else if (idioma == "English")
            {
                kIdiomaa = 2;
            }
            comp = dAO.traerMensajes(kIdiomaa, constante);
            for (int i = 0; i < comp.Rows.Count; i++)
            {
                compIdiomaa.Add(comp.Rows[i]["msj"].ToString(), comp.Rows[i]["texto"].ToString());
            }
        }
    }
}