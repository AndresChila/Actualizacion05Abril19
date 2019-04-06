using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class Validaciones
    {
        public Validaciones()
        {

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
                return false;
            }
        }

        public bool validarVacio(string a)
        {
            if(a == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool validarNull(string a)
        {
            if (a == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string validarRol(int rol)
        {
            if (rol == 1)
            {
                return("../Tienda/AgregarSede.aspx");
            }

            if (rol == 2)
            {
                return ("../Tienda/CRUDVendedor.aspx");
            }

            if (rol == 3)
            {
                return ("../Tienda/CRUDCliente.aspx");
            }
            return "../Login-Rec/NuevoLogin.aspx";
        }
    }
}
