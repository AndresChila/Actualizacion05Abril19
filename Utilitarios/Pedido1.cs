using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    [Serializable]
    [Table("pedido", Schema = "tienda")]
    public class Pedido1
    {
        public Pedido1()
        {

        }

        private int idPedido;
        private string sede;
        private string fecha;
        private bool estado;
        private string observacion;
        private ICollection<Pedidos> pedid;
        

        [Key]        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("idpedido")]
        public int IdPedido { get => idPedido; set => idPedido = value; }
        [Column("sede")]
        public string Sede { get => sede; set => sede = value; }
        [Column("fecha")]
        public string Fecha { get => fecha; set => fecha = value; }
        [Column("estado")]
        public bool Estado { get => estado; set => estado = value; }
        [Column("observacion")]
        public string Observacion { get => observacion; set => observacion = value; }
        [ForeignKey("Idpedidos")]
        public ICollection<Pedidos> Pedid { get => pedid; set => pedid = value; }
    }
}
