using Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios.DataSet;

namespace Logica
{
    public class VistaAbono
    {
        DataTable idVenta1;
        String mensaje, msj1, msj2;
        Hashtable compIdiomaa = new Hashtable();
        string idioma;

        public VistaAbono(string idioma)
        {
            this.idioma = idioma;
            mensajesTrad(idioma, 19);
            msj1 = compIdiomaa["1"].ToString();
            msj2 = compIdiomaa["2"].ToString();
        }

        public VistaAbono(DataTable idVenta1)
        {
            this.idVenta1 = idVenta1;
        }
        
        public String pageLoad()
        {
            DAOUsuario dAO = new DAOUsuario();
            DataTable idd = new DataTable();
            idd = dAO.verUltimoId3();
            if (idd.Rows.Count > 0)
            {
                foreach (DataRow row in idd.Rows)
                {
                    if (idVenta1 == null)
                    {
                        idVenta1 = row["f_verultimoid4"] as System.Data.DataTable;
                    }
                }
            }
            else
            {
                mensaje = msj1;
            }

            return mensaje;
        }
                
        public string devuelveMensaje()
        {
            return mensaje;
        }

        public DS_Abono obtenerInforme()
        {
            DataRow fila, fila1;
            DataTable abonosInformacion = new DataTable();
            DS_Abono datos = new DS_Abono();

            abonosInformacion = datos.Tables["Venta"];
            DAOUsuario dao = new DAOUsuario();
            if (idVenta1 == null)
            {
                mensaje = msj2;
            }
            else
            {
                DataTable controles = new DataTable();
                DataTable intermedio = dao.verReporteAbonos(Convert.ToInt32(idVenta1));
                DataTable data = dao.verDescripcionAbono(Convert.ToInt32(idVenta1));
                Hashtable compIdioma = new Hashtable();
                controles = datos.Tables["Controles"];
                compIdioma =paraIdioma(idioma, 22);

                fila1 = controles.NewRow();
                fila1["ITO_Factura"] = compIdioma["ITO_Factura"].ToString();
                fila1["ITO_NombreCliente"] = compIdioma["ITO_NombreCliente"].ToString();
                fila1["ITO_NombreVendedor"] = compIdioma["ITO_NombreVendedor"].ToString();
                fila1["ITO_ApellidoCliente"] = compIdioma["ITO_ApellidoCliente"].ToString();
                fila1["ITO_Cedula"] = compIdioma["ITO_Cedula"].ToString();
                fila1["ITO_Fecha"] = compIdioma["ITO_Fecha"].ToString();
                fila1["ITO_Referencia"] = compIdioma["ITO_Referencia"].ToString();
                fila1["ITO_Talla"] = compIdioma["ITO_Talla"].ToString();
                fila1["ITO_ValorUni"] = compIdioma["ITO_ValorUni"].ToString();
                fila1["ITO_Valor"] = compIdioma["ITO_Valor"].ToString();
                fila1["ITO_Cantidad"] = compIdioma["ITO_Cantidad"].ToString();
                fila1["ITO_ValorTotal"] = compIdioma["ITO_ValorTotal"].ToString();
                controles.Rows.Add(fila1);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    fila = abonosInformacion.NewRow();
                    if (i == 0)
                    {
                        fila["nombre_c"] = intermedio.Rows[i]["nombre_c"].ToString();
                        fila["apellido_c"] = intermedio.Rows[i]["apellido_c"].ToString();
                        fila["id_cliente"] = Convert.ToInt32(intermedio.Rows[i]["id_cliente"].ToString());
                        fila["nombre_v"] = intermedio.Rows[i]["nombre_v"].ToString();
                        fila["fecha"] = DateTime.Parse(intermedio.Rows[i]["fecha"].ToString());
                        fila["valor_total"] = Convert.ToDouble(intermedio.Rows[i]["precio"].ToString());
                    }
                    fila["referencia"] = data.Rows[i]["ReferenciaProducto"].ToString();
                    fila["talla"] = Convert.ToDouble(data.Rows[i]["Talla"].ToString());
                    fila["cantidad"] = Convert.ToInt32(data.Rows[i]["Cantidad"].ToString());
                    fila["valor_uni"] = Convert.ToDouble(data.Rows[i]["Precio"].ToString());
                    fila["valor_uni_uni"] = Convert.ToDouble(data.Rows[i]["ValorTotal"].ToString());

                    abonosInformacion.Rows.Add(fila);
                }
            }
            idVenta1 = null;
            return datos;
        }

        int kIdiomaa;
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
                    kIdiomaa = int.Parse(idi.Rows[i]["id"].ToString());
                }
            }
            comp = dao.traerMensajes(kIdiomaa, constante);
            for (int i = 0; i < comp.Rows.Count; i++)
            {
                compIdiomaa.Add(comp.Rows[i]["msj"].ToString(), comp.Rows[i]["texto"].ToString());
            }
        }
        public Hashtable paraIdioma(string idioma, int constante)
        {
            int kIdioma = 0;
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
    }

}
