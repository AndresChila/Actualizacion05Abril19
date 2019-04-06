using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using System.Collections;
using Utilitarios;

namespace Logica
{

    public class ValidacionesCrudCliente
    {
        DAOUsuario dao = new DAOUsuario();
        Cliente cliente = new Cliente();
        DataTable cli = new DataTable();
        Hashtable compIdiomaa = new Hashtable();
        string nombre, cedula, apellido, direccion, telefono, sexo;
        string nombree, cedulae, apellidoe, direccione, telefonoe, sexoe;
        string mensaje;
        string accion;
        bool resultadoNombre, resultadoApellido;
        string msj1, msj3, msj2, msj4, msj5, msj6, msj7, msj8, msj9, msj10, msj11, msj12;

        public ValidacionesCrudCliente(string idioma)
        {
            mensajesTrad(idioma, 15);
            msj1 = compIdiomaa["1"].ToString();
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
        }

        
        public ValidacionesCrudCliente(string nombrea, string cedulaa, string apellidoa, string direcciona, string telefonoa, string sexoa,
            string nombree, string cedulae, string apellidoe, string direccione, string telefonoe, string sexoe, string accion, bool resultadoNombre, bool resultadoApellido)
        {
            this.nombre = nombrea;
            this.cedula = cedulaa;
            this.direccion = direcciona;
            this.telefono = telefonoa;
            this.apellido = apellidoa;
            this.sexo = sexoa;
            this.nombree = nombree;
            this.cedulae = cedulae;
            this.direccione = direccione;
            this.telefonoe = telefonoe;
            this.apellidoe = apellidoe;
            this.sexoe = sexoe;
            this.accion = accion;
            this.resultadoNombre = resultadoNombre;
            this.resultadoApellido = resultadoApellido;

            if (accion == "guardar")
            {
                hacertodoagregar();
            }
            if (accion == "editar")
            {
                hacertodoeditar();
            }
        }

        bool validarLlenoEditar()
        {
            if (cedulae == "" || nombree == "" || apellidoe == "" || direccione == "" || telefonoe == "")
            {
                mensaje = msj1;
                return false;
            }
            else
            {
                return true;
            }
        }

        bool validarLlenoAgregar(string cedula, string nombre, string apellido, string direccion, string telefono)
        {
            if (cedula == "" || nombre == "" || apellido == "" || direccion == "" || telefono == "")
            {
                mensaje = msj2;
                return false;
            }
            else
            {
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
                mensaje = msj3;
                return false;
            }
        }

        public string hacertodoagregar()
        {
            if (validarLlenoAgregar(cedula, nombre, apellido, direccion, telefono) == true)
            {
                if (validarExistente(cedula))
                {
                    if (validarNumeros(cedula) == true)
                    {
                        if (resultadoNombre == true)
                        {
                            if (resultadoApellido == true)
                            {
                                if (validarNumeros(telefono) == true)
                                {
                                    cliente.Cedula = Convert.ToInt32(cedula);
                                    cliente.Nombre = nombre;
                                    cliente.Apellido = apellido;
                                    cliente.Direccion = direccion;
                                    cliente.Telefono = Convert.ToInt64(telefono);
                                    cliente.Sexo = sexo;
                                    if (cliente.Cedula <= 0 || cliente.Telefono <= 0)
                                    {
                                        mensaje = msj4;
                                    }

                                    dao.CrearCliente(cliente);
                                    mensaje = msj5;

                                    cedula = "";
                                    nombre = "";
                                    apellido = "";
                                    direccion = "";
                                    telefono = "";

                                }
                                else
                                {
                                    mensaje = msj6;
                                }
                            }
                            else
                            {
                                mensaje = msj7;
                            }
                        }
                        else
                        {
                            mensaje = msj8;
                        }
                    }
                    else
                    {
                        mensaje = msj9;
                    }
                }
                else
                {
                    mensaje = msj10;
                }
            }
            else
            {
                mensaje = msj11;
            }
            return mensaje;
        }

        public string devuelvemensaje()
        {
            return mensaje;
        }

        public string hacertodoeditar()
        {
            if (validarLlenoEditar() == true)
            {
                if (validarNumeros(cedulae) == true)
                {
                    if (resultadoNombre == true)
                    {
                        if (resultadoApellido == true)
                        {
                            if (validarNumeros(telefonoe) == true)
                            {
                                Cliente cliente2 = new Cliente();

                                cliente2.Cedula = int.Parse(cedulae);

                                cliente2.Nombre = nombree;
                                cliente2.Apellido = apellidoe;
                                cliente2.Direccion = direccione;
                                cliente2.Telefono = Convert.ToInt64(telefonoe);
                                cliente2.Sexo = sexoe;
                                if (cliente2.Cedula <= 0 || cliente2.Telefono <= 0)
                                {
                                    mensaje = msj12;
                                }
                                dao.actualizarCliente(cliente2);

                                cedulae = "";
                                nombree = "";
                                apellidoe = "";
                                direccione = "";
                                telefonoe = "";
                            }
                            else
                            {
                                mensaje = msj6;
                            }
                        }
                        else
                        {
                            mensaje = msj7;
                        }
                    }
                    else
                    {
                        mensaje = msj8;
                    }
                }
                else
                {
                    mensaje = msj9;
                }
            }
            else
            {
                mensaje = msj11;
            }
            return mensaje;
        }

        Cliente clientico = new Cliente();
        public void RowCommand(string name, string argument)
        {
            DAOUsuario dAO = new DAOUsuario();
            if (name.Equals("Eliminar"))
            {
                int id = Convert.ToInt32(argument);
                dao.eliminarCliente(id);
                this.SetCliente(0);
            }
            if (name.Equals("Editar"))
            {
                this.SetCliente(Convert.ToInt32(argument));

            }
        }

        public void SetCliente(int r)
        {
            DAOUsuario dAO = new DAOUsuario();
            int id = r;
            DataTable clientes = dAO.verClientesEditar(id);
            if (clientes != null && r > 0)
            {
                foreach (DataRow row in clientes.Rows)
                {
                    clientico.Cedula = Convert.ToInt32(row["cedula"]);
                    clientico.Nombre = Convert.ToString(row["nombre"]);
                    clientico.Apellido = Convert.ToString(row["apellido"]);
                    clientico.Direccion = Convert.ToString(row["direccion"]);
                    clientico.Telefono = Convert.ToInt64(row["telefono"]);
                    clientico.Sexo = Convert.ToString(row["sexo"]);
                }
            }
            else
            {
                clientico.Cedula = 0;
                clientico.Nombre = "";
                clientico.Apellido = "";
                clientico.Direccion = "";
                clientico.Telefono = 0;
                clientico.Sexo = "";
            }
        }

        public Cliente Get_Clientico()
        {
            return clientico;
        }

        public bool validarExistente(string cedula)
        {
            try
            {
                Cliente usu = new DAOPersistencia().ExisteCliente(Convert.ToInt32(cedula));
                if(usu == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(Exception ex)
            {
                return true;
            }
            
        }
        public DataTable paraGrilla()
        {
            DataTable tabla = new DataTable();
            tabla = dao.traerClientes();
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

        
        public void mensajesTrad(string idioma, int constante)
        {
            DataTable comp = new DataTable();
            DataTable idi = new DataTable();
            DAOUsuario dAO = new DAOUsuario();
            idi = dAO.traerIdioma();
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
