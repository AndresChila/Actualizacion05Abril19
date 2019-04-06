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
    public class RecuperarContra
    {
        string mensaje, response, msj1, msj2, msj3, msj4;
        int sesion;
        DAOUsuario user = new DAOUsuario();
        int kIdioma;
        Hashtable compIdiomaa = new Hashtable();

        public RecuperarContra(string idioma)
        {
            mensajesTrad(idioma, 13);
            msj1 = compIdiomaa["1"].ToString();
            msj2 = compIdiomaa["2"].ToString();
            msj3 = compIdiomaa["3"].ToString();
            msj4 = compIdiomaa["4"].ToString();
        }

        public void validar(int qryCount, string qrystring)
        {
            if (qryCount > 0)
            {
                DataTable info = user.obtenerUsusarioToken(qrystring);

                if (int.Parse(info.Rows[0][0].ToString()) == -1)
                {
                    mensaje = msj1;
                    response = "../View/Login-Rec/RecuperarContraseña.aspx";
                }
                else if (int.Parse(info.Rows[0][0].ToString()) == -1)
                {
                    mensaje = msj2;
                    response = "../View/Login-Rec/RecuperarContraseña.aspx";
                }
                else
                    sesion = int.Parse(info.Rows[0][0].ToString());
            }
            else
            {
                response = "../View/Login-Rec/NuevoLogin.aspx";
            }
        }
       
        public int getSesion()
        {
            return sesion;
        }

        public string getMensaje()
        {
            return mensaje;
        }
        public string get_script()
        {
            string c = "alert('" + mensaje + "');window.location.href = '" + response + "'; ";
            return c;
        }
         public void ValidarIgualdad(int userId, string userClave, string userRepClave)
        {

            if (userRepClave == userClave)
            {
                user.actualziarContrasena(userId.ToString(), userClave);
                mensaje = msj3;
            }
            else
            {
                mensaje = msj4;
            }
        }

        public DataTable paraIdioma(string idioma, int constante)
        {
            DataTable comp = new DataTable();

            DataTable idi = new DataTable();
            idi = user.traerIdioma();
            for (int i = 0; i < idi.Rows.Count; i++)
            {
                if (idi.Rows[i]["nombre"].ToString().ToLower() == idioma.ToLower())
                {
                    kIdioma = int.Parse(idi.Rows[i]["id"].ToString());
                }
            }
            comp = user.traerComponentes(kIdioma, constante);
            return comp;
        }

        
        public void mensajesTrad(string idioma, int constante)
        {
            DataTable comp = new DataTable();
            DataTable idi = new DataTable();
            idi = user.traerIdioma();
            for (int i = 0; i < idi.Rows.Count; i++)
            {
                if (idi.Rows[i]["nombre"].ToString().ToLower() == idioma.ToLower())
                {
                    kIdioma = int.Parse(idi.Rows[i]["id"].ToString());
                }
            }
            comp = user.traerMensajes(kIdioma, constante);
            for (int i = 0; i < comp.Rows.Count; i++)
            {
                compIdiomaa.Add(comp.Rows[i]["msj"].ToString(), comp.Rows[i]["texto"].ToString());
            }
        }
    }
}
