using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class ValidarMasterSuperAdmin
    {
        public ValidarMasterSuperAdmin()
        {

        }
        public bool a;
        public int cantA, cantC;

        public void always_visible_panel()
        {
            int x, x1;
            x = new DAOPersistencia().not_asignaciones();
            x1 = new DAOPersistencia().not_conflictos();
            if(x == 0)
            {
                a = false;
                cantA = x;
                cantC = x1;
            }
            else
            {
                a = true;
                cantA = x;
                cantC = x1;
            }
        }

        public bool estado()
        {
            return this.a;
        }

        public int get_cantidad_asignaciones()
        {
            return cantA;
        }

        public int get_cantidad_conflictos()
        {
            return cantC;
        }
    }
}
