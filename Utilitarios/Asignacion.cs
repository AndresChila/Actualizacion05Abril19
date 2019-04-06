using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Asignacion
/// </summary>
[Serializable]
[Table ("asignacion", Schema ="tienda")]
public class Asignacion: IEquatable<Asignacion>
{
    public Asignacion()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    private int idAsignacion;
    private int idAsignaciones;
    private int idProducto;
    private string referencia;
    private int cantidad;
    private double talla;
    private string sede;
    private string fecha;
    private bool estado;

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]   
    [Column("idasignacion")]
    public int IdAsignacion { get => idAsignacion; set => idAsignacion = value; }
    [Column("idasignaciones")]
    public int IdAsignaciones { get => idAsignaciones; set => idAsignaciones = value; }    
    public int IdProducto { get => idProducto; set => idProducto = value; }
    [Column("referencia")]
    public string Referencia { get => referencia; set => referencia = value; }
    [Column("cantidad")]
    public int Cantidad { get => cantidad; set => cantidad = value; }
    [Column("talla")]
    public double Talla { get => talla; set => talla = value; }
    [Column("sede")]
    public string Sede { get => sede; set => sede = value; }
    [Column("fecha")]
    public string Fecha { get => fecha; set => fecha = value; }
    [Column("estado")]
    public bool Estado { get => estado; set => estado = value; }
    

    bool IEquatable<Asignacion>.Equals(Asignacion other)
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