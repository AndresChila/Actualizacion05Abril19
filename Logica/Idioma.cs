using Datos;
using System.Collections.Generic;
using System.Data;
using Utilitarios;

namespace Logica
{

    public class Idioma
    {
        
        List<string> idiomas = new List<string>();
        DataTable tabla = new DataTable();
        public Idioma()
        {

        }

        List<IdiomaT> ObtenerIdiomas()
        {
            return new DAOPersistencia().ObtenerIdiomas();
        }

        public List<string> llenarDDL()
        {
            List<IdiomaT> l = this.ObtenerIdiomas();
            foreach( IdiomaT t in l)
            {
                idiomas.Add(t.Nombre);
            }
            return idiomas;
        }
    }
}
