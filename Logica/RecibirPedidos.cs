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
    public class RecibirPedidos
    {
        string mensaje, idAsig;
        DataTable datosAsignacion, compara, compara2, paginar, paginar2, idAsignDT;
        Validaciones val = new Validaciones();
        DAOUsuario dAO = new DAOUsuario();
        Hashtable compIdiomaa = new Hashtable();
        string msj1, msj2, msj3, msj4, msj5, msj6, msj7, msj8, msj9;

        public RecibirPedidos(string idioma)
        {
            mensajesTrad(idioma, 12);
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

        public RecibirPedidos(DataTable datosAsignacion, DataTable paginar, DataTable paginar2, DataTable idAsignDT, string idAsig)
        {
            this.datosAsignacion = datosAsignacion;
            this.paginar = paginar;
            this.paginar2 = paginar2;
            this.idAsignDT = idAsignDT;
            this.idAsig = idAsig;
        }

        public DataTable actualizarAsignaciones(string sede)
        {
            DAOUsuario dAO = new DAOUsuario();
            DataTable datosAsignacion = new DataTable();
            datosAsignacion = dAO.verAsignacion(sede); ;

            if (datosAsignacion.Rows.Count == 0)
            {
                mensaje = msj1;
                return null;
            }
            else
            {
                mensaje = msj2 + datosAsignacion.Rows.Count + msj3;
                return datosAsignacion;
            }
        }

        public string traerMensaje()
        {
            return mensaje;
        }

        public void seleccionarSede(string comandName, int comandArgument)
        {
            if (comandName == ("Select"))
            {

                paginar2 = null;
                idAsignDT = null;
                DataTable datosAsignaciones = dAO.verAsignaciones(Convert.ToInt32(comandArgument));
                if (paginar2 == null)
                {
                    compara2 = new DataTable();
                    compara2 = datosAsignaciones;
                    paginar2 = compara2;
                }
                if (idAsignDT == null)
                {
                    idAsig = Convert.ToString(comandArgument);
                    idAsignDT.Equals(idAsig);
                }

            }
        }

        public string agregarInventario()
        {
            /*
            if (FilasGV == 0)
            {
                mensaje = "No hay productos pendientes para asignar al inventario.";
            }
            else
            {
                List<Inventario> listaDevolucion;
                foreach (GridViewRow fila in GV_Asignaciones.Rows)
                {
                    Inventario inventario = new Inventario();
                    bool dev;
                    inventario.Referencia = Convert.ToString(((Label)fila.Cells[1].FindControl("L_Referencia")).Text);
                    inventario.Talla = Convert.ToDouble(((Label)fila.Cells[2].FindControl("L_Talla")).Text);
                    inventario.Cantidad = Convert.ToInt32(((Label)fila.Cells[3].FindControl("L_Cantidad")).Text);
                    dev = Convert.ToBoolean(((CheckBox)fila.Cells[4].FindControl("CB_Recibido")).Checked);
                    if (inventario.Referencia != null)
                    {
                        inventario.Sede = Convert.ToString(Session["sede"]);
                        if (dev == true)
                        {
                            da.crearInventario(inventario);
                        }
                        else if (dev == false)
                        {
                            if (Session["listaDev"] == null)
                            {
                                listaDevolucion = new List<Inventario>();
                                listaDevolucion.Add(inventario);
                                Session["listaDev"] = listaDevolucion;
                            }
                            else
                            {
                                listaDevolucion = (Session["listaDev"] as List<Inventario>);
                                listaDevolucion.Add(inventario);
                                Session["listaDev"] = listaDevolucion;
                            }
                        }
                        mensaje= "Se han añadido los productos al inventario.";
                    }
                    else
                    {
                        mensaje = "No hay productos pendientes para agregar al inventario de la sede.";
                    }

                }
            }*/
            return mensaje;
        }
        public DataTable verAsignaciones(int commando)
        {
            DataTable tabla = new DataTable();
            tabla = dAO.verAsignaciones(commando);
            return tabla;
        }

        DataTable a = new DataTable();
        List<Asignacion> aux = new List<Asignacion>();
        public void EliminaYAgrega(int command, List<Asignacion> lista)
        {
            a = dAO.verAsignacionesDetalle(command);
            this.llenarLista(a, lista);
            dAO.eliminarAsignacionesDetalle(command);
        }

        public void llenarLista(DataTable data, List<Asignacion> lista)
        {
            lista = aux;
            Asignacion devolver = new Asignacion();
            devolver.Referencia = data.Rows[0]["referencia"].ToString();
            devolver.Talla = double.Parse(data.Rows[0]["talla"].ToString());
            devolver.Cantidad = int.Parse(data.Rows[0]["cantidad"].ToString());
            if (lista == null)
            {
                lista = new List<Asignacion>();
                lista.Add(devolver);
                aux = lista;
            }
            else
            {
                lista.Add(devolver);
                aux = lista;
            }
        }

        public void ingresarBD(DataTable asignaciones, int idAsig)
        {
            DAOUsuario da = new DAOUsuario();
            int idAsignacion = idAsig; 

            da.actualizarAsignacion(true, idAsignacion);

            if (asignaciones.Rows.Count == 0)
            {
                mensaje = msj4;
                return;
            }
            else
            {
                for (int i = 0; i < asignaciones.Rows.Count; i++)
                {
                    Inventario inventario = new Inventario();

                    inventario.Referencia = Convert.ToString((asignaciones.Rows[1]["L_Referencia"]).ToString());
                    inventario.Talla = Convert.ToDouble((asignaciones.Rows[2]["L_Talla"]).ToString());
                    inventario.Cantidad = Convert.ToInt32((asignaciones.Rows[3]["L_Cantidad"]).ToString());
                    da.crearInventario(inventario);
                }
                mensaje = msj5+asignaciones.Rows.Count+msj6;
                return;
            }
        }  

        public void regresarP(List<Asignacion> l, string sede, string observacion)
        {
            
            Pedido devolver = new Pedido();
            DateTime fechaHoy = DateTime.Now;
            if (val.validarVacio(observacion) == false)
            {
                mensaje = msj7;
                return;
            }
            else
            {
                devolver.Sede = sede;
                devolver.Fecha = fechaHoy.ToString("d");
                devolver.Estado = false;
                dAO.crearPedido(devolver, observacion);
                DataTable id = new DataTable();
                id = dAO.verUltimoId();
                if (id.Rows.Count > 0)
                {
                    foreach (DataRow rowe in id.Rows)
                    {
                        devolver.Idpedido = Convert.ToInt32(rowe["f_verultimoid"]);
                    }
                    foreach (Asignacion a in l)
                    {
                        Asignacion temp = new Asignacion();
                        temp.Referencia = Convert.ToString(a.Referencia);
                        temp.Talla = Convert.ToDouble(a.Talla);
                        temp.Cantidad = Convert.ToInt32(a.Cantidad);
                        dAO.crearPedidos(temp, devolver.Idpedido);
                        
                    }
                    mensaje = msj8 + a.Rows.Count + msj9;
                    return;
                }
            }
        }


        public List<Asignacion> Get_Lista()
        {
            return aux;
        }

        public DataTable Get_source()
        {
            return a;
        }

        public DataTable llenarDataTable(int argumento)
        {
            DataTable tabla = new DataTable();
            tabla = dAO.verAsignaciones(argumento);
            return tabla;
        }

        public DataTable rowcomand(string comando, int argumento)
        {
            DataTable datosAsignaciones = new DataTable();
            if (comando.Equals("Select"))
            {
                datosAsignaciones = llenarDataTable(argumento);
                return datosAsignaciones;
            }
            return datosAsignaciones;
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
            DataTable comp = new DataTable();
            DataTable idi = new DataTable();
            idi = dAO.traerIdioma();
            for (int i = 0; i < idi.Rows.Count; i++)
            {
                if (idi.Rows[i]["nombre"].ToString().ToLower() == idioma.ToLower())
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
