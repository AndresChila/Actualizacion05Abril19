using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios.DataSet;

namespace Logica
{
    public class VerPedidos
    {
        DataTable pedidosInformacion = new DataTable();

        public VerPedidos(DataTable pedidosInformacion)
        {
            this.pedidosInformacion = pedidosInformacion;
        }

        public void obtenerInforme()
        {
            DataRow fila;
            DAOUsuario dao = new DAOUsuario();
            DataTable intermedio = dao.verPedido();
            //DS_Pedidos datos = new DS_Pedidos();

            for (int i = 0; i < intermedio.Rows.Count; i++)
            {
                fila = pedidosInformacion.NewRow();
                fila["idpedido"] = int.Parse(intermedio.Rows[i]["idpedido"].ToString());
                fila["sede"] = intermedio.Rows[i]["sede"].ToString();
                fila["fecha"] = DateTime.Parse(intermedio.Rows[i]["fecha"].ToString());
                fila["estado"] = Convert.ToString(intermedio.Rows[i]["estado"]);

                pedidosInformacion.Rows.Add(fila);
            }
        }
    }
}
