using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// Descripción breve de Sede
/// </summary>
[Serializable]
[Table("sedes", Schema = "tienda")]
public class Sede
{
    
    public Sede()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    private int idSede;
    private string nombreSede;
    private string ciudad;
    private string direccion;
    private string estado;


    [Key]
    [Column("idsede")]
    public int IdSede { get => idSede; set => idSede = value; }
    [Column("nombresede")]
    public string NombreSede { get => nombreSede; set => nombreSede = value; }
    [Column("ciudad")]
    public string Ciudad { get => ciudad; set => ciudad = value; }
    [Column("direccion")]
    public string Direccion { get => direccion; set => direccion = value; }
    [Column("estado")]
    public string Estado { get => estado; set => estado = value; }
}