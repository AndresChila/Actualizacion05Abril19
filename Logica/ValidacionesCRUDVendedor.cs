using Datos;
using System;
using System.Collections;
using Utilitarios;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logica
{
    public class ValidacionesCRUDVendedor
    {
        DAOUsuario dao = new DAOUsuario();
        Usuario usuario = new Usuario();
        DataTable usu = new DataTable();
        DataTable sedess = new DataTable();
        string cedula, nombre, direccion, telefono, correo, clave, sexo, sede, rol;
        string cedula0, nombre0, direccion0, telefono0, correo0, clave0, sexo0, sede0, rol0;
        string mensaje, msj1, msj2, msj3, msj4, msj5, msj6, msj7, msj8;
        Hashtable compIdiomaa = new Hashtable();

        public ValidacionesCRUDVendedor()
        {

        }

        public ValidacionesCRUDVendedor(string idioma)
        {
            mensajesTrad(idioma, 17);
            msj1 = compIdiomaa["1"].ToString();
            msj2 = compIdiomaa["2"].ToString();
            msj3 = compIdiomaa["3"].ToString();
            msj4 = compIdiomaa["4"].ToString();
            msj5 = compIdiomaa["5"].ToString();
            msj6 = compIdiomaa["6"].ToString();
            msj7 = compIdiomaa["7"].ToString();
            msj8 = compIdiomaa["8"].ToString();
        }
        
        public ValidacionesCRUDVendedor(string cedula, string nombre, string clave, string direccion, string telefono, string correo,
                                        string sexo, string sede, string rol, string cedula0, string nombre0, string clave0, string direccion0, 
                                        string telefono0, string correo0, string sexo0, string sede0, string rol0)
        {
            //Constructor
            this.cedula = cedula;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.correo = correo;
            this.sexo = sexo;
            this.sede = sede;
            this.rol = rol;
            this.clave = clave;
            this.cedula0 = cedula0;
            this.nombre0 = nombre0;
            this.direccion0 = direccion0;
            this.telefono0 = telefono0;
            this.correo0 = correo0;
            this.sexo0 = sexo0;
            this.sede0 = sede0;
            this.rol0 = rol0;
            this.clave0 = clave0;
        }
        bool validarLlenoAgregar()
        {
            if (cedula == "" || nombre == "" || clave == "" || direccion == "" || telefono == "" || correo == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool validarNumerosCed(string num)
        {
            try
            {
                if (int.Parse(cedula) < 999999999)
                {
                    double x = Convert.ToDouble(num);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool validarNumerosTel(string num)
        {
            try
            {
                if (Convert.ToInt64(num) >9999999)
                {
                    double x = Convert.ToDouble(num);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool validarCedula()
        {
            DataTable cedulatabla = new DataTable();

            cedulatabla = dao.traerUsuarios();
            for (int i = 0; i < cedulatabla.Rows.Count; i++)
            {
                if (cedulatabla.Rows[i]["cedula"].ToString() == cedula)
                {
                    return false;
                }
            }
            return true;
        }

        public string hacerTodoAgregar()
        {
            bool resultadoNombre = Regex.IsMatch(nombre, @"^[a-zA-Z]+$");
            if (validarIngresadoAgregar())
            {
                if (validarLlenoAgregar() == true)
                {
                    if (resultadoNombre == true)
                    {
                        if (validarNumerosCed(cedula) == true)
                        {
                            if (validarNumerosTel(telefono) == true)
                            {
                                if (validarCedula() == true)
                                {

                                    usuario.Cedula = int.Parse(cedula);
                                    if (usuario.Cedula <= 0)
                                    {
                                        mensaje = msj1;
                                        return mensaje;
                                    }
                                    usuario.Nombre = nombre;
                                    usuario.Clave = clave;
                                    usuario.Direccion = direccion;
                                    usuario.Telefono = Convert.ToInt64(telefono);
                                    if (usuario.Telefono <= 0)
                                    {
                                        mensaje = msj2;
                                        return mensaje;
                                    }
                                    usuario.Sexo = sexo;

                                    usuario.Sede = sede;
                                    usuario.Correo = correo;
                                    usuario.Estado = 1;
                                    usuario.Session = "hola";
                                    usuario.RolId = int.Parse(rol);
                                    usuario.LastModified = DateTime.Now;

                                    dao.CrearUsuario(usuario);
                                }
                                else
                                {
                                    dao.agregarUsuarioNuevamente(cedula);
                                    usu = dao.traerUsuarios2(sede);
                                    mensaje = msj3;
                                    return mensaje;
                                }
                            }
                            else
                            {
                                mensaje = msj4;
                                return mensaje;
                            }
                        }
                        else
                        {
                            mensaje = msj5;
                            return mensaje;
                        }
                    }
                    else
                    {
                        mensaje = msj6;
                        return mensaje;
                    }
                }
                else
                {
                    mensaje = msj7;
                    return mensaje;
                }
            }
            else
            {
                mensaje = msj8;
                return mensaje;
            }
            return mensaje;
        }

        public Usuario llenarCampos(DataTable usu, string cedula)
        {
            for(int i=0; i< usu.Rows.Count; i++)
            {
                if(usu.Rows[i]["cedula"].ToString() == cedula)
                {
                    usuario.Cedula = int.Parse(usu.Rows[i]["cedula"].ToString());
                    usuario.Nombre = usu.Rows[i]["nombre"].ToString();
                    usuario.Clave = usu.Rows[i]["clave"].ToString();
                    usuario.Direccion = usu.Rows[i]["direccion"].ToString();
                    usuario.Telefono = long.Parse(usu.Rows[i]["telefono"].ToString());
                    usuario.Correo = usu.Rows[i]["correo"].ToString();
                    usuario.RolId = int.Parse(usu.Rows[i]["rol_id"].ToString());
                }
            }
            return usuario;
        }
        bool validarLlenoEditar()
        {
            if (cedula0 == "" || nombre0 == "" || clave0 == "" || direccion0 == "" || telefono0 == "" || correo0 == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string hacerTodoEditar()
        {
            bool resultadoNombre = Regex.IsMatch(nombre0, @"^[a-zA-Z]+$");
            if (validarIngresadoEditar())
            {
                if (validarLlenoEditar() == true)
                {
                    if (resultadoNombre == true)
                    {
                        if (validarNumerosTel(telefono0) == true)
                        {
                            Usuario usuario2 = new Usuario();

                            usuario2.Cedula = int.Parse(cedula0);
                            usuario2.Nombre = nombre0;
                            usuario2.Clave = clave0;
                            usuario2.Direccion = direccion0;
                            usuario2.Estado = 1;
                            usuario2.Telefono = Convert.ToInt64(telefono0);
                            usuario2.Sexo = sexo0;
                            usuario2.Sede = sede0;
                            usuario2.Correo = correo0;
                            usuario2.Session = "hola";
                            usuario2.RolId = int.Parse(rol0);
                            usuario2.LastModified = DateTime.Now;

                            dao.actualizarUsuario(usuario2);
                        }
                        else
                        {
                            mensaje = msj5;
                            return mensaje;
                        }
                    }
                    else
                    {
                        mensaje = msj6;
                        return mensaje;
                    }
                }
                else
                {
                    mensaje = msj7;
                    return mensaje;
                }
            }
            else
            {
                mensaje = msj8;
                return mensaje;
            }
            return mensaje;
        }
        public bool validarIngresadoAgregar()
        {
            DataTable cedulatabla = new DataTable();

            cedulatabla = dao.traerUsuarios();
            for (int i = 0; i < cedulatabla.Rows.Count; i++)
            {
                if (cedulatabla.Rows[i]["cedula"].ToString() == cedula && cedulatabla.Rows[i]["estado"].ToString() == "2")
                {
                    return false;
                }
            }
            return true;
        }
        public bool validarIngresadoEditar()
        {
            DataTable cedulatabla = new DataTable();

            cedulatabla = dao.traerUsuarios();
            for (int i = 0; i < cedulatabla.Rows.Count; i++)
            {
                if (cedulatabla.Rows[i]["cedula"].ToString() == cedula && cedulatabla.Rows[i]["estado"].ToString() == "2")
                {
                    return false;
                }
            }
            return true;
        }
        public DataTable llenarGrilla(string sesion)
        {
            DataTable tabla = new DataTable();
            tabla = dao.traerUsuarios2(sesion);
            return tabla;
        }
        public DataTable TraerSedes()
        {
            DataTable tabla = new DataTable();
            tabla = dao.traerSedes();
            return tabla;
        }
        public void EliminarUsu(string select)
        {
            dao.eliminarUsuario(select);
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