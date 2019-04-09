using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;

public partial class View_Tienda_MasterAdmin : System.Web.UI.MasterPage
{
    ValidarMasterAdmin val = new ValidarMasterAdmin();
    Hashtable compIdioma = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["user_id"] == null || Session["clave"] == null || Convert.ToInt32(Session["rol_id"]) != 2)
        {
            this.cerrarSesion();
            Response.Redirect("../Login-Rec/NuevoLogin.aspx");
        }
        else
        {
            Label_usuario.Text = Session["nombre"].ToString();
            Label_Sede.Text = Session["sede"].ToString();

        }

        compIdioma = val.paraIdioma(Session["idioma"].ToString(), 13);
        LB_Bodega.Text = compIdioma[LB_Bodega.ID].ToString();
        LB_PedirProductos.Text = compIdioma[LB_PedirProductos.ID].ToString();
        LB_RecibirPedidos.Text = compIdioma[LB_RecibirPedidos.ID].ToString();
        LB_Vendedor.Text= compIdioma[LB_Vendedor.ID].ToString();
        LB_VerPedidos.Text = compIdioma[LB_VerPedidos.ID].ToString(); ;
        B_CerrarSesion.Text = compIdioma[B_CerrarSesion.ID].ToString();
        L_Pedidos.Text = compIdioma[L_Pedidos.ID].ToString();
    }

    protected void LinkButton8_Click(object sender, EventArgs e)
    {

        Response.Redirect("PedirProductos.aspx");
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("VerPedidos.aspx");
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("RecibirPedido.aspx");

    }

    protected void LinkBodega_Click(object sender, EventArgs e)
    {
        Response.Redirect("Bodega.aspx");

    }

    protected void LinkVendedor_Click(object sender, EventArgs e)
    {
        Response.Redirect("CRUDVendedor.aspx");
    }

    protected void B_CerrarSesion_Click(object sender, EventArgs e)
    {
        this.cerrarSesion();
    }

    void cerrarSesion()
    {
        Session["clave"] = null;
        Session["user_id"] = null;
        Session["nombre_rol"] = null;
        Session["nombre"] = null;
        Session["sede"] = null;
        Session["rol_id"] = null;
        Response.Cache.SetNoStore();
        Response.Redirect("../Login-Rec/NuevoLogin.aspx");
    }

    void not_pedidos()
    {
        ValidarMasterAdmin val = new ValidarMasterAdmin();
        val.not_pedidos((Session["sede"]).ToString());
        P_Pedido.Visible = val.estado;
        L_Pedidos.Text = "¡Tiene "+val.get_cantidad()+" sin recibir!";
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("RecibirPedido.aspx");
    }
}
