using System;
using System.Collections.Generic;
using System.Data;
using Datos;
using System.Collections;

namespace Logica
{
    public class AgregarSede0
    {
        DAOUsuario dao = new DAOUsuario();
        Sede sedes = new Sede();
        DataTable sd = new DataTable();
        Hashtable compIdiomaa = new Hashtable();
        int kIdioma;
        string nombresede, ciudad, direccion, accion, mensaje;
        bool resultadoSede, resultadoCiudad;
        string msj1, msj2, msj3, msj4, msj5;
        string idioma;

        public AgregarSede0()
        {

        }

        public AgregarSede0(string idioma)
        {
            this.idioma = idioma;
            mensajesTrad(idioma, 2);
            msj1 = compIdiomaa["1"].ToString();
            msj2 = compIdiomaa["2"].ToString();
            msj3 = compIdiomaa["3"].ToString();
            msj4 = compIdiomaa["4"].ToString();
            msj5 = compIdiomaa["5"].ToString();
        }
        public AgregarSede0(bool resultadoSede, bool resultadoCiudad, string nombresede, string ciudad, string direccion, string accion, string idioma)
        {
            this.idioma = idioma;
            mensajesTrad(idioma, 2);
            msj1 = compIdiomaa["1"].ToString();
            msj2 = compIdiomaa["2"].ToString();
            msj3 = compIdiomaa["3"].ToString();
            msj4 = compIdiomaa["4"].ToString();
            msj5 = compIdiomaa["5"].ToString();
            this.nombresede = nombresede;
            this.ciudad = ciudad;
            this.direccion = direccion;
            this.resultadoCiudad = resultadoCiudad;
            this.resultadoSede = resultadoSede;
            this.accion = accion;
            
            if (accion == "agregar")
            {
                mensaje = hacertodoagregar();
            }
        }
/// <summary>
/// Persistencia
/// </summary>
        public List<Sede> traerSedes()
        {
            return new DAOPersistencia().traerSedes();
        }

        public bool agregar(Sede sede)
        {
            return new DAOPersistencia().AgregarSede(sede);
        }

        public void eliminarSede(int id)
        {
            new DAOPersistencia().EliminarSede(id);
        }

/// <returns>Persistencia</returns>


        public string hacertodoagregar() { 
            if (validarLlenoSede() == true)
            {
                if (resultadoSede == true)
                {
                    if (resultadoCiudad == true)
                    {
                        Sede sede = new Sede();
                        DAOUsuario dAO = new DAOUsuario();

                        sede.NombreSede = nombresede;
                        sede.Ciudad = ciudad;
                        sede.Direccion = direccion;
                        sede.Estado = "true";
                        bool exit = this.agregar(sede);
                        ciudad = "";
                        nombresede = "";
                        direccion = "";
                        if (exit == true)
                        {
                           mensaje = msj1;
                            return mensaje;
                        }
                        else
                        {
                            dAO.editarAgregarSedeNuevamente(sede.NombreSede, sede.Ciudad);
                            mensaje = msj2;
                            return mensaje;
                        };                                            
                    }
                    else
                    {
                       return mensaje =msj3;
                    }
                }
                else
                {
                    return mensaje = msj4;
                }
            }
            else
            {
                return mensaje = msj5;
            }            
        }

        bool validarLlenoSede()
        {
            if (nombresede == "" || ciudad == "" || direccion == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string traerMensaje()
        {
            return mensaje;
        }

        public void eliminarSede(string comandName, int comandArgument)
        {
            if (comandName==("Delete"))
            {
                new DAOPersistencia().EliminarSede(Convert.ToInt32(comandArgument));                 
                
            }
        }

        
        public Hashtable paraIdioma(string idioma, int constante)
        {
            DataTable comp = new DataTable();
            DAOUsuario dAO = new DAOUsuario();
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

        
        public void mensajesTrad(string idiomaa, int constantea)
        {
            DataTable comp = new DataTable();
            DAOUsuario dAO = new DAOUsuario();
            DataTable idi = new DataTable();
            idi = dAO.traerIdioma();
            for (int i = 0; i < idi.Rows.Count; i++)
            {
                if (idi.Rows[i]["nombre"].ToString().ToLower() == idioma.ToLower())
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
