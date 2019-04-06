using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;

public partial class View_Tienda_PedirProductos : System.Web.UI.Page
{
    int CONSTANTE = 18;
    Hashtable compIdioma = new Hashtable();
    

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["pedidos"] = null;
        PedirProductos a = new PedirProductos(Session["idioma"].ToString());
        compIdioma = a.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        GV_Pedidos.HeaderRow.Cells[0].Text = compIdioma["GV_Pedidos_Column0"].ToString();
        GV_Pedidos.HeaderRow.Cells[1].Text = compIdioma["GV_Pedidos_Column1"].ToString();
        GV_Pedidos.HeaderRow.Cells[2].Text = compIdioma["GV_Pedidos_Column2"].ToString();
        L_Tabla.Text = compIdioma[L_Tabla.ID].ToString();
        L_Referencia0.Text = compIdioma[L_Referencia0.ID].ToString();
        L_Talla0.Text = compIdioma[L_Talla0.ID].ToString();
        L_Cantidad.Text = compIdioma[L_Cantidad.ID].ToString();
        L_Pedido.Text = compIdioma[L_Pedido.ID].ToString();
        B_Pedir.Text = compIdioma[B_Pedir.ID].ToString();
        B_Agregar.Text = compIdioma[B_Agregar.ID].ToString();
        //LB_Seleccionar
    }

    private List<Asignacion> pedidos
    {
        get { return Session["pedidos"] as List<Asignacion>; }
        set { Session["pedidos"] = value; }
    }

    
    protected void B_Agregar_Click(object sender, EventArgs e)
    {
        PedirProductos agre = new PedirProductos(Session["idioma"].ToString());
        agre.llenarLista(Session["pedidos"] as List<Asignacion>, L_Referencia.Text, L_Talla.Text, TB_Cantidad.Text);
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Revise los datos." + agre.Get_mensaje() + " ');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        Session["pedidos"] = agre.Get_Lista();
        GV_Ped.DataSource = Session["pedidos"] as List<Asignacion>;
        GV_Ped.DataBind();

        //GV_Ped.HeaderRow.Cells[0].Text = compIdioma["GV_Ped_Column0"].ToString();
        //GV_Ped.HeaderRow.Cells[1].Text = compIdioma["GV_Ped_Column1"].ToString();
        //GV_Ped.HeaderRow.Cells[2].Text = compIdioma["GV_Ped_Column2"].ToString();
    } 

    protected void GV_Pedir_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void B_Pedir_Click1(object sender, EventArgs e)
    {
        PedirProductos agre = new PedirProductos(Session["idioma"].ToString());
        agre.ingresarBD(Session["pedidos"] as List<Asignacion>, Session["sede"].ToString());
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Revise los datos." + agre.Get_mensaje() + " ');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        Session["pedidos"] = null;
        GV_Ped.DataBind();
    }

    protected void GV_Ped_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GV_Pedidos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        L_Referencia.Text = e.CommandName.ToString();
        L_Talla.Text = e.CommandArgument.ToString();
    }

    protected void GV_Pedidos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        PedirProductos a = new PedirProductos(Session["idioma"].ToString());
        compIdioma = a.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        try
        {
            ((LinkButton)e.Row.FindControl("LB_Seleccionar")).Text = compIdioma["LB_Seleccionar"].ToString();
        }
        catch (Exception exe)
        {

        }
    }
}