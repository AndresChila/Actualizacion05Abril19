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
    [Table("asignaciones", Schema = "tienda")]
    public class Asignaciones : IEquatable<Asignaciones>
    {
        public Asignaciones()
        {

        }
        private int idAsignaciones;
        private int idAsignacion;
        private string referencia;
        private int cantidad;
        private double talla;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]        
        [Column("idasignaciones")]
        public int IdAsignaciones { get => idAsignaciones; set => idAsignaciones = value; }
        [Column("idasignacion")]
        public int IdAsignacion { get => idAsignacion; set => idAsignacion = value; }
        [Column("referencia")]
        public string Referencia { get => referencia; set => referencia = value; }
        [Column("cantidad")]
        public int Cantidad { get => cantidad; set => cantidad = value; }
        [Column("talla")]
        public double Talla { get => talla; set => talla = value; }

        bool IEquatable<Asignaciones>.Equals(Asignaciones other)
        {
            if (this.Referencia == other.Referencia && this.Talla == other.Talla &&
                this.Cantidad == other.Cantidad)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
