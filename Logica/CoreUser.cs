using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Datos;
using System.Data;
using System.Collections;

namespace Logica
{
    public class CoreUser
    {
        DataTable comp = new DataTable();
        DAOUsuario dAO = new DAOUsuario();
        Hashtable compIdioma = new Hashtable();
        string msj1, msj2;

        public CoreUser(string idioma)
        {
            mensajesTrad(idioma, 6);
            msj1 = compIdioma["1"].ToString();
            msj2 = compIdioma["2"].ToString();
        }

        public UUsuario autenticar(UUsuario user)
        {
            DataTable data = new Datos.DAOUsuario().loggin(user);
            DAOUsuario guardarUsuario = new DAOUsuario();

            if (int.Parse(data.Rows[0]["cedula"].ToString()) > 0)
            {
                user.Clave = data.Rows[0]["clave"].ToString();
                user.Usuario = data.Rows[0]["cedula"].ToString();
                user.Nombre_rol = data.Rows[0]["rol_name"].ToString();
                user.Rol_id = int.Parse(data.Rows[0]["rol_id"].ToString());
                user.Nombre = data.Rows[0]["nombre"].ToString();
                user.Sede = data.Rows[0]["sede"].ToString();

                
                guardarUsuario.guardadoSession(user);

                user.Mensaje = msj1;

            }
            else
            {
                user.Mensaje = msj2;
            }
            return user;
        }

        int kIdioma;
        public void mensajesTrad(string idioma, int constante)
        {

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
                compIdioma.Add(comp.Rows[i]["msj"].ToString(), comp.Rows[i]["texto"].ToString());
            }
        }
    }
}
