using Datos;
using Newtonsoft.Json;
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
    public class NuevosAbonos
    {
        DAOUsuario dAO = new DAOUsuario();
        string mensaje, precioDeuda, pagoActual, idAbono, msj1, msj2, msj3, msj4, msj5;
        DataTable vntaS, datosAbono;
        List<Producto> refresh;
        Hashtable compIdiomaa = new Hashtable();

        public NuevosAbonos(string idioma)
        {
            mensajesTrad(idioma, 10);
            msj1 = compIdiomaa["1"].ToString();
            msj2 = compIdiomaa["2"].ToString();
            msj3 = compIdiomaa["3"].ToString();
            msj4 = compIdiomaa["4"].ToString();
            msj5 = compIdiomaa["5"].ToString();
        }
        public NuevosAbonos(DataTable vntaS, string precioDeuda, string pagoActual, string idAbono)
        {
            this.vntaS = vntaS;
            this.precioDeuda = precioDeuda;
            this.pagoActual = pagoActual;
            this.idAbono = idAbono;
        }

        public string nuevaVenta()
        {
            if (vntaS != null)
            {
                Producto individual = new Producto();
                datosAbono = new DataTable();
                datosAbono = (vntaS as DataTable);

                foreach (DataRow row in datosAbono.Rows)
                {
                    Venta venta = new Venta();
                    venta.Idcliente = Convert.ToInt32(row["idcliente"]);
                    venta.Producto = JsonConvert.DeserializeObject<List<Producto>>(Convert.ToString(row["descripcion"]));
                    refresh = venta.Producto as List<Producto>;
                    venta.Idvendedor = Convert.ToInt32(row["idvendedor"]);
                    venta.Fecha = row["fecha"].ToString();
                    venta.Precio = Convert.ToDouble(row["precio"]);
                    venta.Sede = Convert.ToString(row["sede"]);
                  
                    dAO.crearVenta(venta, JsonConvert.SerializeObject(venta.Producto));
                    mensaje = msj1;
                    //this.actualizarInventario();
                }

                
            }
            return mensaje;
        }

        public string traerMensaje()
        {
            return mensaje;
        }

        public string agregarProducto()
        {
            if (validarLlenoAbono() == true)
            {
                double a, b;
                a = Convert.ToDouble(precioDeuda);
                b = Convert.ToDouble(pagoActual);
                if (idAbono == null)
                {
                    mensaje = msj2;
                }
                else
                {
                    if (a < b)
                    {
                        mensaje = msj3;
                    }
                    else if (b <= a)
                    {
                        DAOUsuario dAO = new DAOUsuario();
                        dAO.actualizarAbono(Convert.ToInt32(idAbono), a - b);
                        mensaje = msj5 + (a - b);
                        //this.llenarGV_Abonos();
                        if ((a - b) == 0)
                        {
                            this.nuevaVenta();
                        }
                        pagoActual=null;
                        precioDeuda=null;
                        idAbono = null;
                    }
                }
            }
            else
            {
                mensaje = msj4;
            }
            return mensaje;
        }

        public void seleccionarAbono(string comandName, int comandArgument)
        {
            if (comandName.Equals("Select"))
            {
                DAOUsuario dAO = new DAOUsuario();
                precioDeuda = Convert.ToString(dAO.traePrecioAbono(Convert.ToInt32(comandArgument)));
               idAbono = Convert.ToString(comandArgument);
            }
        }

        bool validarLlenoAbono()
        {
            if (precioDeuda == "" || pagoActual == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string Get_preciodeuda()
        {
            return precioDeuda;
        }
        public void actuInvent(List<Producto> listaVenta, string sede)
        {
            DAOUsuario dAO = new DAOUsuario();
            foreach (Producto p in listaVenta)
            {
                dAO.actualizarInventario(p, sede);
            }
        }
        public DataTable llevarDataTable(string sede)
        {
            DataTable tabla = new DataTable();
            tabla = dAO.traerAbonos(sede);
            return tabla;
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

        
        public void mensajesTrad(string idiomaa, int constante)
        {
            DataTable comp = new DataTable();
            DataTable idi = new DataTable();
            idi = dAO.traerIdioma();
            for (int i = 0; i < idi.Rows.Count; i++)
            {
                if (idi.Rows[i]["nombre"].ToString().ToLower() == idiomaa.ToLower())
                {
                    kIdioma = int.Parse(idi.Rows[i]["id"].ToString());
                }
            }
            comp = dAO.traerMensajes(kIdioma, constante);
            for (int i = 0; i < comp.Rows.Count; i++)
            {
                compIdiomaa.Add(comp.Rows[i]["msj"].ToString(), comp.Rows[i]["texto"].ToString());
            }
        }
    }
}
