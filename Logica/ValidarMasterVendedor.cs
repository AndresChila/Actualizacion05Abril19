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
    public class ValidarMasterVendedor
    {
        public ValidarMasterVendedor()
        {

        }
        public string validarSessionNombreClaveRol(string nombre, string clave, string rol)
        {
            if(nombre == null || clave== null || rol == null)
            {
                return ("../Login-Rec/NuevoLogin.aspx");
            }
            return "CRUDCliente.aspx";
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
    }
}
