using Datos;
using Utilitarios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data;
using System.Collections;

namespace Logica
{
    public class GenerarToken
    {
        DAOUsuario dao = new DAOUsuario();
        DataTable comp = new DataTable();
        Hashtable compIdioma = new Hashtable();
        string ltitulo, ldigite, lboton, msj1, msj2, msj3, msj4;
        int kIdioma;

        public GenerarToken(string idioma)
        {
            mensajesTrad(idioma, 7);
            msj1 = compIdioma["1"].ToString();
            msj2 = compIdioma["2"].ToString();
            msj3 = compIdioma["3"].ToString();
            msj4 = compIdioma["4"].ToString();
        }

        string mensaje = "";
        public void correoGenerar(string user)
        {
           
            System.Data.DataTable validez = dao.generarToken(int.Parse(user));
            if (int.Parse(validez.Rows[0]["cedula"].ToString()) > 0)
            {
                EUserToken token = new EUserToken();
                token.Id = int.Parse(validez.Rows[0]["cedula"].ToString());
                token.Nombre = validez.Rows[0]["clave"].ToString();
                //token.User_name = validez.Rows[0]["user_name"].ToString();
                token.Estado = int.Parse(validez.Rows[0]["estado"].ToString());
                token.Correo = validez.Rows[0]["correo"].ToString();
                token.Fecha = DateTime.Now.ToFileTimeUtc();

                String userToken = encriptar(JsonConvert.SerializeObject(token));
                dao.almacenarToken(userToken, token.Id);

                Correo correo = new Correo();

                String mensaje = msj1 + "http://localhost:65074/View/Login-Rec/RecuperarContraseña.aspx?" + userToken;
                correo.enviarCorreo(token.Correo, userToken, mensaje);

                mensaje = msj2;
                return;
            }
            else if (int.Parse(validez.Rows[0]["cedula"].ToString()) == -2)
            {
                mensaje = msj3;
                return;
            }
            else
            {
                mensaje = msj4;
                return;
            }


        }

        private string encriptar(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }

        public string Get_mensaje()
        {
            return mensaje;
        }
        public void paraIdioma(string idioma, int constante, string titulo, string user, string bton)
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
            comp = dao.traerComponentes(kIdioma, constante);

            for (int i = 0; i < comp.Rows.Count; i++)
            {
                if (comp.Rows[i]["control"].ToString() == titulo)
                {
                    ltitulo = comp.Rows[i]["texto"].ToString();
                }
                if (comp.Rows[i]["control"].ToString() == user)
                {
                    ldigite = comp.Rows[i]["texto"].ToString();
                }
                if (comp.Rows[i]["control"].ToString() == bton)
                {
                    lboton = comp.Rows[i]["texto"].ToString();
                }
            }
        }
        public string Get_LTitulo()
        {
            return ltitulo;
        }
        public string Get_LDigite()
        {
            return ldigite;
        }
        public string Get_LBoton()
        {
            return lboton;
        }

        public void mensajesTrad(string idioma, int constante)
        {

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
                compIdioma.Add(comp.Rows[i]["msj"].ToString(), comp.Rows[i]["texto"].ToString());
            }
        }
    }


}
