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
    [Table("idioma", Schema = "traduccion")]
    public class IdiomaT
    {
        public IdiomaT()
        {

        }

        private int id;
        private string nombre;
        private string terminacion;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Column("terminacion")]
        public string Terminacion { get => terminacion; set => terminacion = value; }
    }
}
