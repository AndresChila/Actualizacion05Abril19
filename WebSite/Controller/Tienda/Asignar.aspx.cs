using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Logica;

public partial class View_Tienda_Asigna : System.Web.UI.Page
{
    DataTable a = new DataTable();
    int CONSTANTE = 5;
    Hashtable compIdioma = new Hashtable();

    protected void Page_Load(object sender, EventArgs e)
    {
        Asignaciones pen = new Asignaciones(Session["idioma"].ToString());
        GV_Asignacion_Final.DataBind();
        L_Cantidad_Pendiente.Text = Convert.ToString(pen.CantidadPendiente());
        compIdioma = pen.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        GV_Productos_Bodega.HeaderRow.Cells[0].Text = compIdioma["GV_Productos_Bodega_Column0"].ToString();
        GV_Pendientes.HeaderRow.Cells[2].Text = compIdioma["GV_Pendientes_Column2"].ToString();
        GV_Productos_Bodega.HeaderRow.Cells[1].Text = compIdioma["GV_Productos_Bodega_Column1"].ToString();
        GV_Asignar_Sin_Pedido.HeaderRow.Cells[2].Text = compIdioma["GV_Asignar_Sin_Pedido_Column2"].ToString();
        GV_Productos_Bodega.HeaderRow.Cells[2].Text = compIdioma["GV_Productos_Bodega_Column2"].ToString();
        L_Asignacion_Sin_Pedido.Text = compIdioma[L_Asignacion_Sin_Pedido.ID].ToString();
        GV_Pendientes.HeaderRow.Cells[3].Text = compIdioma["GV_Pendientes_Column3"].ToString();
        GV_Productos_Bodega.HeaderRow.Cells[3].Text = compIdioma["GV_Productos_Bodega_Column3"].ToString();
        L_Productos_Bodega.Text = compIdioma[L_Productos_Bodega.ID].ToString();
        GV_Productos_Bodega.HeaderRow.Cells[4].Text = compIdioma["GV_Productos_Bodega_Column4"].ToString();
        L_Cantidad.Text = compIdioma[L_Cantidad.ID].ToString();
        L_Asignaciones_Pendientes.Text = compIdioma[L_Asignaciones_Pendientes.ID].ToString();
        GV_Asignar_Sin_Pedido.HeaderRow.Cells[0].Text = compIdioma["GV_Asignar_Sin_Pedido_Column0"].ToString();
        L_Detalle_Pedido.Text = compIdioma[L_Detalle_Pedido.ID].ToString();
        L_Referencia1.Text = compIdioma[L_Referencia1.ID].ToString();
        GV_Pendientes.HeaderRow.Cells[0].Text = compIdioma["GV_Pendientes_Column0"].ToString();
        GV_Pendientes.HeaderRow.Cells[1].Text = compIdioma["GV_Pendientes_Column1"].ToString();
        B_Validar.Text = compIdioma[B_Validar.ID].ToString();
        GV_Asignar_Sin_Pedido.HeaderRow.Cells[1].Text = compIdioma["GV_Asignar_Sin_Pedido_Column1"].ToString();
        B_Asignar1.Text = compIdioma[B_Asignar1.ID].ToString();
        L_Talla1.Text = compIdioma[L_Talla1.ID].ToString();
        B_Agregar.Text = compIdioma[B_Agregar.ID].ToString();
        L_Sede.Text = compIdioma[L_Sede.ID].ToString();
        B_Asignar.Text = compIdioma[B_Asignar.ID].ToString();

    }

    String compara
    {
        get { return Session["compara"] as String; }
        set { Session["compara"] = value; }
    }
    String idPed
    {
        get { return Session["idPed"] as String; }
        set { Session["idPed"] = value; }
    }
    List<Asignacion> listaAsignacion
    {
        get { return Session["asignacionl"] as List<Asignacion>; }
        set { Session["asignacionl"] = value; }
    }
    List<Asignacion> listaAsignacion2
    {
        get { return Session["asignacion2"] as List<Asignacion>; }
        set { Session["asignacion2"] = value; }
    }

    List<Asignacion> listaAsignacion3
    {
        get { return Session["asignacion3"] as List<Asignacion>; }
        set { Session["asignacion3"] = value; }
    }

    protected void B_Asignar_Click(object sender, EventArgs e)
    {
        Asignaciones agregar = new Asignaciones(Session["idioma"].ToString());
        agregar.AgregarProductos(Session["asignacion3"] as List<Producto>, DL_Sedes.SelectedItem.ToString());
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + agregar.Devuelve_Mensaje() + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        Session["asignacion3"] = null;
        Session["entregado"] = null;
        Session["asignacion2"] = null;
        Session["idproducto"] = null;
        Session["idPed"] = null;
        Session["compara"] = null;
        Session["source"] = null;
    }

    protected void GV_Asignaciones_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GV_Pedido_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GV_Pedido_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Asignaciones row = new Asignaciones(Session["idioma"].ToString());
        Session["idPed"] = Convert.ToString(e.CommandArgument);
        GV_Pedidos.DataSource = row.Row_Command(e.CommandName.ToString(), e.CommandArgument.ToString());
        GV_Pedidos.DataBind();
        Session["source"] = row.Row_Command(e.CommandName.ToString(), e.CommandArgument.ToString());
        Session["sedePedido"] = row.Get_Sede();
        GV_Pedidos.HeaderRow.Cells[0].Text = compIdioma["GV_Pedidos_Column0"].ToString();
        GV_Pedidos.HeaderRow.Cells[1].Text = compIdioma["GV_Pedidos_Column1"].ToString();
        GV_Pedidos.HeaderRow.Cells[2].Text = compIdioma["GV_Pedidos_Column2"].ToString();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Asignaciones validar = new Asignaciones(Session["idioma"].ToString());
        string ff = Convert.ToString(Session["sedePedido"]);
        DataTable ss = Session["source"] as DataTable;
        validar.ValidarPedidos(ss, Session["asignacion2"] as List<Asignacion>, Session["sedePedido"].ToString(), Convert.ToString(Session["idPed"]));
        Session["entregado"] = validar.GetEntregado();
        Session["asignacion2"] = validar.GetPedidos();
        Session["idproducto"] = validar.GetId();
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + validar.Devuelve_Mensaje() + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        B_Asignar1.Enabled = validar.GeT_Estado();
        B_Validar.Enabled = !validar.GeT_Estado();
        GV_Pendientes.DataBind();
        GV_Pedidos.DataBind();
        GV_Productos_Bodega.DataBind();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button2_Click1(object sender, EventArgs e)
    {
        Asignaciones ingresar = new Asignaciones(Session["idioma"].ToString());
        ingresar.ingresarBD(Session["asignacion2"] as List<Asignacion>, Convert.ToInt32(Session["idPed"]), Convert.ToInt32(Session["entregado"]));
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + ingresar.Devuelve_Mensaje() + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete    
        GV_Pendientes.DataBind();
        GV_Pedidos.DataBind();
        GV_Productos_Bodega.DataBind();
    }

    protected void GV_AsignarSinPedido_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        L_Referencia.Text = e.CommandName.ToString();
        L_Talla.Text = e.CommandArgument.ToString();
    }

    protected void B_Agregar_Click(object sender, EventArgs e)
    {
        Asignaciones agregar = new Asignaciones(Session["idioma"].ToString());
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + agregar.listaEnviar(Session["asignacion3"] as List<Producto>, L_Referencia.Text, L_Talla.Text, TB_Cantidad.Text) + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete    
        Session["asignacion3"] = agregar.GetAsignacionSinPedido();
        GV_Asignacion_Final.DataSource = Session["asignacion3"] as List<Producto>;
        GV_Asignacion_Final.DataBind();
        GV_Asignacion_Final.HeaderRow.Cells[1].Text = compIdioma["GV_Asignacion_Final_Column1"].ToString();
        GV_Asignacion_Final.HeaderRow.Cells[3].Text = compIdioma["GV_Asignacion_Final_Column3"].ToString();
        GV_Asignacion_Final.HeaderRow.Cells[0].Text = compIdioma["GV_Asignacion_Final_Column0"].ToString();
        GV_Asignacion_Final.HeaderRow.Cells[2].Text = compIdioma["GV_Asignacion_Final_Column2"].ToString();
    }

    protected void GV_Pendientes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Asignaciones pen = new Asignaciones(Session["idioma"].ToString());
        compIdioma = pen.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        try
        {
            ((LinkButton)e.Row.FindControl("LB_Seleccionar_AP")).Text = compIdioma["LB_Seleccionar_AP"].ToString();
        }
        catch (Exception exe)
        {

        }
    }

    protected void GV_Asignar_Sin_Pedido_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Asignaciones pen = new Asignaciones(Session["idioma"].ToString());
        compIdioma = pen.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        try
        {
            ((LinkButton)e.Row.FindControl("LB_Seleccionar_ASP")).Text = compIdioma["LB_Seleccionar_ASP"].ToString();
        }
        catch (Exception exe)
        {

        }
    }

    protected void GV_Asignacion_Final_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Asignaciones pen = new Asignaciones(Session["idioma"].ToString());
        compIdioma = pen.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        try
        {
            ((LinkButton)e.Row.FindControl("LB_Seleccionar_AF")).Text = compIdioma["LB_Seleccionar_AF"].ToString();
        }
        catch (Exception exe)
        {

        }
    }
}