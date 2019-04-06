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
    public class Conflictos
    {
        string msj1, msj2, msj3, msj4, msj5, msj6, msj7, msj8;
        DAOUsuario dao = new DAOUsuario();
        DataTable data = new DataTable();
        DataTable datat = new DataTable();
        string obs;
        string mensaje;
        Hashtable compIdiomaa = new Hashtable();

        public Conflictos(string idioma)
        {
            mensajesTrad(idioma, 5);
            msj1 = compIdiomaa["1"].ToString();
            msj2 = compIdiomaa["2"].ToString();
            msj3 = compIdiomaa["3"].ToString();
            msj4 = compIdiomaa["4"].ToString();
            msj5 = compIdiomaa["5"].ToString();
            msj6 = compIdiomaa["6"].ToString();
            msj7 = compIdiomaa["7"].ToString();
            msj8 = compIdiomaa["8"].ToString();
        }
        
        public void llenarGV(int command)
        {            
           
            datat = dao.verPedido(Convert.ToInt32(command));
            data = dao.verPedidos(Convert.ToInt32(command));
            obs = dao.traerObservacion(Convert.ToInt32(command));
        }

        public void validarReasignar(DataTable source, string asig, string idped2)
        {
            int cont = 0, cantBodega= 0;
            for(int i =0; i< source.Rows.Count; i++)
            {
                cont++;
                DateTime fechaHoy = DateTime.Now;
                Asignacion a = new Asignacion();
                a.Referencia = Convert.ToString((source.Rows[i]["referencia"]).ToString());
                a.Talla = Convert.ToDouble((source.Rows[i]["talla"]).ToString());
                a.Cantidad = Convert.ToInt32((source.Rows[i]["cantidad"]).ToString());
                a.Fecha = fechaHoy.ToString("d");
                a.Estado = false;
                a.Sede = Convert.ToString(asig);

                DataTable r = dao.validarAsignacion(a.Referencia, a.Talla);
                if (r.Rows.Count == 1)
                {
                    if (cont == 1)
                    {
                        dao.crearAsignacion(a);
                    }
                    foreach (DataRow fi in r.Rows)
                    {
                        Producto producto = new Producto();
                        cantBodega = Convert.ToInt32(fi["cantidad"]);
                        producto.Entregado = Convert.ToInt32(fi["entregado"]);
                        producto.Idproducto = Convert.ToInt32(fi["idproducto"]);
                        cantBodega = cantBodega - producto.Entregado;

                        if (a.Cantidad < cantBodega)
                        {                            
                            dao.crearAsignaciones(a, this.idpedido2());
                            dao.editarCantidad(Convert.ToInt32(producto.Idproducto), (a.Cantidad + producto.Entregado));
                            dao.actualizarPedido(false, Convert.ToInt32(idped2));
                            mensaje = msj1 + a.Referencia + msj2 + a.Talla + msj3 + a.Cantidad + msj4;
                        }
                        else
                        {
                            mensaje = msj5 + a.Referencia + msj6 + a.Talla + msj7 + cantBodega + msj8;

                            return;
                        }
                    }

                }

            }
        }

        public int idpedido2()
        {
            DAOUsuario d = new DAOUsuario();
            DataTable id = new DataTable();
            id = d.verUltimoId2();
            if (id.Rows.Count > 0)
            {
                foreach (DataRow ff in id.Rows)
                {
                    return Convert.ToInt32(ff["f_verultimoid2"]);
                }
            }            
            return 0;
        }

        public string get_mensaje()
        {
            return mensaje;
        }

        public DataTable get_data()
        {
            return data;
        }

        public DataTable get_datat()
        {
            return datat;
        }

        public string get_obs()
        {
            return obs;
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

        
        public void mensajesTrad(string idiomaa, int constantea)
        {
            DataTable comp = new DataTable();
            DAOUsuario dAO = new DAOUsuario();
            DataTable idi = new DataTable();
            idi = dAO.traerIdioma();
            for (int i = 0; i < idi.Rows.Count; i++)
            {
                if (idi.Rows[i]["nombre"].ToString().ToLower() == idiomaa.ToLower())
                {
                    kIdioma = int.Parse(idi.Rows[i]["id"].ToString());
                }
            }
            comp = dAO.traerMensajes(kIdioma, constantea);
            for (int i = 0; i < comp.Rows.Count; i++)
            {
                compIdiomaa.Add(comp.Rows[i]["msj"].ToString(), comp.Rows[i]["texto"].ToString());
            }
        }
    }

}
