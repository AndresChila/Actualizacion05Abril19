using Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using Utilitarios;

namespace Logica
{
    

    public class ValidacionesCrudAdmin
    {
        //String msj1, msj2, msj3, msj4, msj5, msj6, msj7, msj8, msj9;
        Hashtable compIdiomaa = new Hashtable();
        
        Usuario usuario = new Usuario();        

        string nombre, cedula, clave, direccion, telefono, correo, dseleccionado, dsexo;
        string nombree, cedulae, clavee, direccione, telefonoe, correoe, dseleccionadoe, dsexoe;
        string mensaje;
        string accion;

        public ValidacionesCrudAdmin(string idioma)
        {
            
            //msj1 = compIdiomaa["1"].ToString();
            //msj2 = compIdiomaa["2"].ToString();
            //msj3 = compIdiomaa["3"].ToString();
            //msj4 = compIdiomaa["4"].ToString();
            //msj5 = compIdiomaa["5"].ToString();
            //msj6 = compIdiomaa["6"].ToString();
            //msj7 = compIdiomaa["7"].ToString();
            //msj8 = compIdiomaa["8"].ToString();
            //msj9 = compIdiomaa["9"].ToString();
        }

        public ValidacionesCrudAdmin(string nombrea, string cedulaa, string correoa, string direcciona, string telefonoa, string dseleccionadoa, string dsexoa, string clave,
            string nombree, string cedulae, string correoe, string direccione, string telefonoe, string dseleccionadoe, string dsexoe, string clavee, string accion, string idioma)
        {
            compIdiomaa = mensajesTrad(idioma, 14);
            this.nombre = nombrea;
            this.cedula = cedulaa;
            this.direccion = direcciona;
            this.telefono = telefonoa;
            this.correo = correoa;
            this.dseleccionado = dseleccionadoa;
            this.dsexo = dsexoa;
            this.clave = clave;
            this.nombree = nombree;
            this.cedulae = cedulae;
            this.direccione = direccione;
            this.telefonoe = telefonoe;
            this.correoe = correoe;
            this.dseleccionadoe = dseleccionadoe;
            this.dsexoe = dsexoe;
            this.clavee = clavee;
            this.accion = accion;
            
            if (accion == "guardar")
            {
                mensaje = hacertodoagregar();
            }
            if (accion == "editar")
            {
                mensaje = hacertodoeditar();
            }

        }
        /// <summary>
        /// /Persistencia
        /// </summary>
        
        public List<Usuario> traerAdmins()
        {
            return new DAOPersistencia().traerUsuarios(1, 2);
        }

        public List<Sede> traerSedes()
        {
            return new DAOPersistencia().traerSedes();
        }

        public bool AgregarAdmin(Usuario usu)
        {
            return new DAOPersistencia().AgregarUsuario(usu);
        }

        public void ActualizarUsuario(Usuario su)
        {
            new DAOPersistencia().ActualizarUsuario(su);
        }

        public void EliminarUsuario(int id)
        {
            new DAOPersistencia().EliminarUsuario(id);
        }
        /// <returns>Persistencia</returns>
        public bool validarLlenoAgregar(string cedula, string nombre, string clave, string direccion, string telefono, string correo)
        {
            if (cedula == "" || nombre == "" || clave == "" || direccion == "" || telefono == "" || correo == "")
            {
                mensaje = compIdiomaa["1"].ToString();
                return false;
            }
            else
            {

                return true;
            }
        }

        public bool validarCaractNombre(string nombre)
        {
            bool resultadoNombre = Regex.IsMatch(nombre, @"^[a-zA-Z]+$");
            if (resultadoNombre == true || nombre.Contains(" "))
            {
                return true;
            }
            else
            {
                mensaje = compIdiomaa["2"].ToString();
                return false;
            }
        }

        public bool validarNumerosCed(string num)
        {
            try
            {
                if (int.Parse(cedula)< 999999999) {
                    double x = Convert.ToDouble(num);
                    return true;
                }
                else
                {
                    mensaje = compIdiomaa["3"].ToString();
                    return false;
                }
                
            }
            catch (Exception)
            {
                mensaje = compIdiomaa["2"].ToString(); ;
                return false;
            }
        }
        public bool validarNumerosTel(string num)
        {
            try
            {
                double x = Convert.ToDouble(num);
                return true;
            }
            catch (Exception)
            {
                mensaje = compIdiomaa["4"].ToString();
                return false;
            }
        }

        public bool validarAdmin(string sedeSeleccionada)
        {
            List<Usuario> lis = new List<Usuario>();
            foreach(Usuario s in lis)
            {
                if (s.Sede == sedeSeleccionada && s.RolId == 2)
                {
                    mensaje = compIdiomaa["6"].ToString();
                    return false;
                }
            }
            return true;
        }

        public bool validaralgocedula()
        {
            if (usuario.Cedula <= 0 )
            {
                mensaje = compIdiomaa["7"].ToString();
                return false;
            }
            return true;
        }

        public string hacertodoagregar()
        {
            if (validarLlenoAgregar(cedula, nombre, clave, direccion, telefono, correo))
            {
                if (validarCaractNombre(nombre))
                {
                    if (validarNumerosTel(telefono))
                    {
                        if (validarNumerosCed(cedula))
                        {
                            if (validarAdmin(dseleccionado))
                            {
                                usuario.Cedula = Convert.ToInt32(cedula);
                                if (validaralgocedula())
                                {
                                    usuario.Nombre = nombre;
                                    usuario.Clave = clave;
                                    usuario.Direccion = direccion;
                                    usuario.Telefono = long.Parse(telefono);
                                    if (usuario.Telefono <= 0)
                                    {
                                        mensaje = compIdiomaa["8"].ToString();
                                        return mensaje;
                                    }
                                    usuario.Sexo = dsexo;
                                    usuario.Sede = dseleccionado;
                                    usuario.Correo = correo;
                                    usuario.Estado = 1;
                                    usuario.Session = "hola";
                                    usuario.RolId = 2;
                                    usuario.LastModified = DateTime.Now;

                                    if(AgregarAdmin(usuario) == true)
                                    {
                                        return mensaje = compIdiomaa["10"].ToString(); ;
                                    }
                                    else
                                    {
                                        return mensaje = compIdiomaa["5"].ToString();
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
            return mensaje;
        }

        public string devuelvemensaje()
        {
            return mensaje;
        }

        bool validarLlenoEditar()
        {
            if (cedulae == "" || nombree == "" || clavee == "" || direccione == "" || telefonoe == "" || correoe == "")
            {
                mensaje = compIdiomaa["9"].ToString();
                return false;
            }
            else
            {
                return true;
            }
        }
        public string hacertodoeditar()
        {
            if (validarLlenoEditar())
            {
                if (validarCaractNombre(nombree))
                {
                    if (validarNumerosTel(telefonoe))
                    {
                        Usuario usuario2 = new Usuario();

                        usuario2.Cedula = int.Parse(cedulae);
                        usuario2.Nombre = nombree;
                        usuario2.Clave = clavee;
                        usuario2.Direccion = direccione;
                        usuario2.Telefono = Convert.ToInt64(telefonoe);
                        usuario2.Sexo = dsexoe;
                        usuario2.Sede = dseleccionadoe;
                        usuario2.Correo = correoe;
                        usuario2.Estado = 1;
                        usuario2.Session = "";
                        usuario2.RolId = 2;
                        usuario2.LastModified = DateTime.Now;

                        this.ActualizarUsuario(usuario2);
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
            return mensaje;
        }
        public Usuario paracomandogrid(string comando, string argumento) 
        {
            Usuario iusuari = new Usuario();
            if(comando == "Editar")
            {
                iusuari = traerEditar(Convert.ToInt32(argumento));
                return iusuari;
            }
            if(comando == "Eliminar")
            {
                eliminarUsuario(argumento);
            }
            return iusuari;
        }
        List<Usuario> traeEditar = new List<Usuario>();
        
        public Usuario traerEditar(int a)
        {
            traeEditar = this.traerAdmins();
            Usuario usuar = new Usuario();
            foreach(Usuario u in traeEditar)
            {
                if(a == u.Cedula)
                {
                    usuar.Cedula = u.Cedula;
                    usuar.Nombre = u.Nombre;
                    usuar.Clave = u.Clave;
                    usuar.Sexo = u.Sexo;
                    usuar.Direccion = u.Direccion;
                    usuar.Telefono = u.Telefono;
                    usuar.Correo = u.Correo;
                }
            }           
            return usuar;
        }

        void eliminarUsuario(string a)
        {
            this.EliminarUsuario(Convert.ToInt32(a));
        }

        public List<string> llenarDDLs()
        {
            List<Sede> listaSedes = new List<Sede>();
            listaSedes = this.traerSedes();
            List<string> sedes = new List<string>();
            
            foreach(Sede s in listaSedes)
            {
                sedes.Add(s.NombreSede + "-" + s.Ciudad);
            }            
            return sedes;
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

        //int kIdiomaa;
        public Hashtable mensajesTrad(string idioma, int constante)
        {
            DataTable comp = new DataTable();
            DataTable idi = new DataTable();
            DAOUsuario dao = new DAOUsuario();
            Hashtable a = new Hashtable();
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
                a.Add(comp.Rows[i]["msj"].ToString(), comp.Rows[i]["texto"].ToString());
            }
            return a;
        }
    }
}
