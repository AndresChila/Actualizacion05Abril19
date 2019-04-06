using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Descripción breve de Usuario
/// </summary>
namespace Utilitarios
{
    [MetadataType(typeof(Usuario))]
    public partial class ItemRequest
    { }

    [Serializable]
    [Table("usuario", Schema = "usuario")]
    public class Usuario
    {
        public Usuario()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        string nombre;
        string clave;
        string direccion;
        long telefono;
        string sexo;
        string sede;
        string correo;
        int estado;
        string session;
        int rolId;
        DateTime lastModified;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]        
        [Column("cedula")]
        public int Cedula { get; set; }
        [Column("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Column("clave")]
        public string Clave { get => clave; set => clave = value; }
        [Column("direccion")]
        public string Direccion { get => direccion; set => direccion = value; }
        [Column("telefono")]
        public long Telefono { get => telefono; set => telefono = value; }
        [Column("sexo")]
        public string Sexo { get => sexo; set => sexo = value; }
        [Column("sede")]
        public string Sede { get => sede; set => sede = value; }
        [Column("correo")]
        public string Correo { get => correo; set => correo = value; }
        [Column("estado")]
        public int Estado { get => estado; set => estado = value; }
        [Column("session")]
        public string Session { get => session; set => session = value; }
        [Column("rol_id")]
        public int RolId { get => rolId; set => rolId = value; }
        [Column("last_modified")]
        public DateTime LastModified { get => lastModified; set => lastModified = value; }

    }
}