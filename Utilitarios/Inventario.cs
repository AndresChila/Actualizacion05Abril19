using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Inventario
/// </summary>
[Serializable]
[Table("inventario", Schema = "tienda")]
public class Inventario
{
    public Inventario()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    private int idInventario;
    private string referencia;
    private double talla;
    private int cantidad;
    private string sede;


    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("idproducto")]
    public int IdInventario { get => idInventario; set => idInventario = value; }
    [Column("referencia")]
    public string Referencia { get => referencia; set => referencia = value; }
    [Column("talla")]
    public double Talla { get => talla; set => talla = value; }
    [Column("cantidad")]
    public int Cantidad { get => cantidad; set => cantidad = value; }
    [Column("sede")]
    public string Sede { get => sede; set => sede = value; }
}