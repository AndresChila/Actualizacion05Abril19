using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class BuscarCliente
    {
        string msj1, msj2, msj3;
        Cliente cli = new Cliente();
        DataTable cliente = new DataTable();
        DAOUsuario dao = new DAOUsuario();
        DataTable comp = new DataTable();
        Hashtable compIdioma = new Hashtable();

        public BuscarCliente(string idioma)
        {
            mensajesTrad(idioma, 4);
            msj1 = compIdioma["1"].ToString();
            msj2 = compIdioma["2"].ToString();
            msj3 = compIdioma["3"].ToString();
        }
        public string buscarVacio(string cedula)
        {
            if (cedula == "")
            {
                return msj1;
            }
            else
            {
                try
                {
                    cliente = dao.buscarCliente(Convert.ToInt32(cedula));
                    this.BuscarDatosCliente(cedula, cliente.Rows.Count);
                }
                catch (Exception exc)
                {
                    
                }
                if (cliente.Rows.Count > 0)
                {
                    return msj2;
                }
            }
            return msj3;
        }
        public void BuscarDatosCliente(string cedula, int filas)
        {
            if (filas > 0)
            {
                DataTable datos = new DataTable();
                datos = dao.buscarCliente(Convert.ToInt32(cedula));
                Cliente clien = new Cliente();
                clien.Nombre = datos.Rows[0]["nombre"].ToString();
                clien.Apellido = datos.Rows[0]["apellido"].ToString();
                clien.Cedula = int.Parse(cedula);
                cli = clien;
            }
            else
            {
                Cliente clien = new Cliente();
                clien.Nombre = "No se";
                clien.Apellido = "encontró";
                clien.Cedula = int.Parse(cedula);
                cli = clien;
            }
        }

        public Cliente Get_cliente()
        {
            return cli;
        }

        int kIdioma;
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
