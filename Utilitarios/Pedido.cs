using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Pedido
/// </summary>
[Serializable]
[Table("pedido", Schema = "tienda")]
public class Pedido
{
    public Pedido()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    private int idpedido;
    private string sede;
    private string fecha;
    private bool estado;
    private string observacion;

    [Key]
    [Column("idpedido")]
    public int Idpedido { get => idpedido; set => idpedido = value; }
    [Column("sede")]
    public string Sede { get => sede; set => sede = value; }
    [Column("fecha")]
    public string Fecha { get => fecha; set => fecha = value; }
    [Column("estado")]
    public bool Estado { get => estado; set => estado = value; }
    [Column("observacion")]
    public string Observacion { get => observacion; set => observacion = value; }
}