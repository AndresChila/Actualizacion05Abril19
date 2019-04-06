using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Cliente
/// </summary>
[Serializable]
[Table("sedes", Schema = "tienda")]
public class Cliente
{
    public Cliente()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    int cedula;
    string nombre;
    string apellido;
    string direccion;
    long telefono;
    string sexo;
    int estado;

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("cedula")]
    public int Cedula { get => cedula; set => cedula = value; }
    [Column("nombre")]
    public string Nombre { get => nombre; set => nombre = value; }
    [Column("apellido")]
    public string Apellido { get => apellido; set => apellido = value; }
    [Column("direccion")]
    public string Direccion { get => direccion; set => direccion = value; }
    [Column("telefono")]
    public long Telefono { get => telefono; set => telefono = value; }
    [Column("sexo")]
    public string Sexo { get => sexo; set => sexo = value; }
    [Column("estado")]
    public int Estado { get => estado; set => estado = value; }
}