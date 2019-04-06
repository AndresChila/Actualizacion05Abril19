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
    [Table("pedidos", Schema = "tienda")]
    public class Pedidos
    {
        public Pedidos()
        {

        }

        private int idpedidos;
        private string referencia;
        private double talla;
        private int cantidad;
        private int idpedido;
        private Pedido1 pedidoss;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("idpedidos")]
        public int Idpedidos { get => idpedidos; set => idpedidos = value; }
        [Column("referencia")]
        public string Referencia { get => referencia; set => referencia = value; }
        [Column("talla")]
        public double Talla { get => talla; set => talla = value; }
        [Column("cantidad")]
        public int Cantidad { get => cantidad; set => cantidad = value; }        
        public Pedido1 Pedidoss { get => pedidoss; set => pedidoss = value; }
        [Column("idpedido")]
        public int Idpedido { get => idpedido; set => idpedido = value; }
        
    }
}
