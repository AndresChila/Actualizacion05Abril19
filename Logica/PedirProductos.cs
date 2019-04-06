using Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Logica
{
    public class PedirProductos
    {
        Hashtable compIdiomaa = new Hashtable();
        string msj1, msj2, msj3, msj4, msj5, msj6, msj7, msj8, msj9;
        public PedirProductos(string idioma)
        {
            mensajesTrad(idioma, 11);
            msj1 = compIdiomaa["1"].ToString();
            msj2 = compIdiomaa["2"].ToString();
            msj3 = compIdiomaa["3"].ToString();
            msj4 = compIdiomaa["4"].ToString();
            msj5 = compIdiomaa["5"].ToString();
            msj6 = compIdiomaa["6"].ToString();
            msj7 = compIdiomaa["7"].ToString();
            msj8 = compIdiomaa["8"].ToString();
            msj9 = compIdiomaa["9"].ToString();
        }
        Validaciones val = new Validaciones();
        List<Asignacion> aux = new List<Asignacion>();
        string mensaje;
        public void llenarLista(List<Asignacion> lproducto, string referencia, string talla, string cantidad)
        {
            lproducto = aux;
            if (val.validarVacio(cantidad) == true)
            {
                if (val.validarNumeros(cantidad) == true)
                {
                    Asignacion asignacion = new Asignacion();
                    asignacion.Referencia = referencia;
                    asignacion.Talla = Convert.ToDouble(talla);
                    asignacion.Cantidad = Convert.ToInt32(cantidad);

                    if (asignacion.Cantidad > 0)
                    {
                        if (lproducto == null)
                        {
                            lproducto = new List<Asignacion>();
                            lproducto.Add(asignacion);
                            aux = lproducto;

                            mensaje = msj1 + asignacion.Cantidad + ", " + asignacion.Referencia + ", " + asignacion.Talla + "";
                            return;
                        }
                        else
                        {
                            if (lproducto.Contains(asignacion))
                            {

                                mensaje = msj2;
                                return;
                            }
                            else
                            {
                                lproducto.Add(asignacion);

                                mensaje = msj3 + asignacion.Cantidad + asignacion.Referencia + asignacion.Talla + "";
                                return;
                            }
                        }
                    }
                    else
                    {
                        mensaje = msj4;
                        return;
                    }
                }
                else
                {
                    mensaje = msj5;
                    return;
                }
            }
            else
            {
                mensaje = msj6;
                return;
            }
        }

        public void ingresarBD(List<Asignacion> pedidos, string sede)
        {
            Pedido pedido = new Pedido();
            DAOUsuario dao = new DAOUsuario();
            DateTime fechaHoy = DateTime.Now;       
            if (pedidos != null)
            {
                pedido.Sede = Convert.ToString(sede);
                pedido.Fecha = fechaHoy.ToString("d");
                pedido.Estado = false;
                dao.crearPedido(pedido);
                DataTable id = new DataTable();
                id = dao.verUltimoId();
                if (id.Rows.Count > 0)
                {
                    foreach (DataRow row in id.Rows)
                    {
                        pedido.Idpedido = Convert.ToInt32(row["f_verultimoid"]);
                    }
                    foreach (Asignacion pedid in pedidos)
                    {
                        Asignacion temp = (Asignacion)pedid;
                        dao.crearPedidos(temp, pedido.Idpedido);
                    }
                }
                else
                {
                    mensaje = msj7;
                    return;
                }
                mensaje = msj8 + pedido.Idpedido + " ";
                return; 
            }
            else
            {
                mensaje = msj9;
                return;
            }
        }

        public List<Asignacion> Get_Lista()
        {
            return aux;
        }

        public string Get_mensaje()
        {
            return mensaje;
        }

        int kIdioma;
        public Hashtable paraIdioma(string idioma, int constante)
        {
            DataTable comp = new DataTable();
            DAOUsuario dAO = new DAOUsuario();
            Hashtable compIdioma = new Hashtable();
            DataTable idi = new DataTable();
            idi = dAO.traerIdioma();
            for (int i = 0; i < idi.Rows.Count; i++)
            {
                if (idi.Rows[i]["nombre"].ToString().ToLower() == idioma.ToLower())
                {
                    kIdioma = int.Parse(idi.Rows[i]["id"].ToString());
                }
            }
            comp = dAO.traerComponentes(kIdioma, constante);
            for (int i = 0; i < comp.Rows.Count; i++)
            {
                compIdioma.Add(comp.Rows[i]["control"].ToString(), comp.Rows[i]["texto"].ToString());
            }
            return compIdioma;
        }

       
        public void mensajesTrad(string idioma, int constante)
        {
            DAOUsuario dao = new DAOUsuario();
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
