using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Utilitarios
{
    [Serializable]
    [Table("asignacion", Schema = "tienda")]
    public class Asignacion1
    {
        private int idAsignacion;
        private string sede;
        private string fecha;
        private bool estado;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("idasignacion")]
        public int IdAsignacion { get => idAsignacion; set => idAsignacion = value; }
        [Column("sede")]
        public string Sede { get => sede; set => sede = value; }
        [Column("fecha")]
        public string Fecha { get => fecha; set => fecha = value; }
        [Column("estado")]
        public bool Estado { get => estado; set => estado = value; }
    } 
}
