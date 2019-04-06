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

public partial class Controller_Tienda_Conflictos : System.Web.UI.Page
{
    int CONSTANTE = 8;
    Hashtable compIdioma = new Hashtable();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Conflictos llenar = new Conflictos(Session["idioma"].ToString());
        compIdioma = llenar.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        L_Conflictos.Text = compIdioma[L_Conflictos.ID].ToString();
        GV_Pedido.HeaderRow.Cells[0].Text = compIdioma["GV_Pedido_Column0"].ToString();
        GV_Pedido.HeaderRow.Cells[1].Text = compIdioma["GV_Pedido_Column1"].ToString();
        GV_Pedido.HeaderRow.Cells[2].Text = compIdioma["GV_Pedido_Column2"].ToString();
        GV_Pedido.HeaderRow.Cells[3].Text = compIdioma["GV_Pedido_Column3"].ToString();
        
        L_Observaciones.Text = compIdioma[L_Observaciones.ID].ToString();
        B_Reasignar.Text = compIdioma[B_Reasignar.ID].ToString();
    }
    
    protected void B_Reasignar_Click(object sender, EventArgs e)
    {
        Conflictos llenar = new Conflictos(Session["idioma"].ToString());
        llenar.validarReasignar(Session["datasource"] as DataTable, Convert.ToString(Session["asig"]), Convert.ToString(Session["idPed2"]));
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + llenar.get_mensaje() + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        GV_Pedido.DataBind();
        GV_Pedidos.DataBind();
    }

    protected void GV_Pedido_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Conflictos llenar = new Conflictos(Session["idioma"].ToString());
        llenar.llenarGV(int.Parse(e.CommandArgument.ToString()));
        TB_Observacion.Text = llenar.get_obs();
        Session["idPed2"] = e.CommandArgument;
        Session["asig"] = llenar.get_datat().Rows[0]["sede"];
        Session["datasource"] = llenar.get_data();
        GV_Pedidos.DataSource = Session["datasource"] as DataTable;
        GV_Pedidos.DataBind();
        //GV_Pedidos.HeaderRow.Cells[0].Text = compIdioma["GV_Pedidos_Column0"].ToString();
        //GV_Pedidos.HeaderRow.Cells[1].Text = compIdioma["GV_Pedidos_Column1"].ToString();
        //GV_Pedidos.HeaderRow.Cells[2].Text = compIdioma["GV_Pedidos_Column2"].ToString();
    }

    

    protected void GV_Pedido_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GV_Pedido_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Conflictos llenar = new Conflictos(Session["idioma"].ToString());
        compIdioma = llenar.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        try
        {
            ((LinkButton)e.Row.FindControl("LB_Seleccionar")).Text = compIdioma["LB_Seleccionar"].ToString();
        }
        catch (Exception exe)
        {

        }
    }
}