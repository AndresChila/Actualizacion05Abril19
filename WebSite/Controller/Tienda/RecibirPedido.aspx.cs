
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;

public partial class View_Tienda_RecibirPedido : System.Web.UI.Page
{
    int CONSTANTE = 19;
    Hashtable compIdioma = new Hashtable();

    DataTable paginar, paginar2, idAsignDT, listaDev;
    DAOUsuario dao = new DAOUsuario();
    Pedido pedidos = new Pedido();
    DataTable asig = new DataTable();
    DataTable asigs = new DataTable();
    
    string idref, referencia, talla, cantidad;
    protected void Page_Load(object sender, EventArgs e)
    {
        RecibirPedidos ped = new RecibirPedidos(Session["idioma"].ToString());
        paginar = Session["paginar"] as DataTable;
            paginar = null;
            paginar2 = Session["paginar2"] as DataTable;
            paginar2 = null;
            this.actualizarAsignaciones();

        compIdioma = ped.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        GV_Asignacion.HeaderRow.Cells[2].Text = compIdioma["GV_Asignacion_Column2"].ToString();
        
        L_Tabla.Text = compIdioma[L_Tabla.ID].ToString();
        L_Talla0.Text = compIdioma[L_Talla0.ID].ToString();
        L_Referencia0.Text = compIdioma[L_Referencia0.ID].ToString();
        L_Cantidad0.Text = compIdioma[L_Cantidad0.ID].ToString();
        B_AgregarInventario.Text = compIdioma[B_AgregarInventario.ID].ToString();
        L_Producto.Text = compIdioma[L_Producto.ID].ToString();
        L_Observaciones.Text = compIdioma[L_Observaciones.ID].ToString();
        B_Conflicto.Text = compIdioma[B_Conflicto.ID].ToString();
        L_Pedido.Text = compIdioma[L_Pedido.ID].ToString();
        L_Descripcion.Text = compIdioma[L_Descripcion.ID].ToString();

    }

    String idAsig
    {
        get { return Session["idAsig"] as String; }
        set { Session["idAsig"] = value; }
    }

    DataTable compara
    {
        get { return Session["paginar"] as DataTable; }
        set { Session["paginar"] = value; }
    }
    DataTable compara2
    {
        get { return Session["paginar2"] as DataTable; }
        set { Session["paginar2"] = value; }
    }

    protected void actualizarAsignaciones()
    {
        RecibirPedidos actu = new RecibirPedidos(Session["idioma"].ToString());

        GV_Asignacion.DataSource = actu.actualizarAsignaciones(Convert.ToString(Session["sede"])); 
        GV_Asignacion.DataBind();
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + actu.traerMensaje() + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete

    }

    protected void GV_Asignacion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        RecibirPedidos ped = new RecibirPedidos(Session["idioma"].ToString());
        Session["paginar2"] = null;
        Session["idAsig"] = null;
        DataTable datosAsignaciones = new DataTable();
        datosAsignaciones = ped.rowcomand(e.CommandName, int.Parse(e.CommandArgument.ToString()));
        GV_Asignaciones.DataSource = datosAsignaciones;
        GV_Asignaciones.DataBind();
        try
        {
            GV_Asignaciones.HeaderRow.Cells[1].Text = compIdioma["GV_Asignaciones_Column1"].ToString();
            GV_Asignaciones.HeaderRow.Cells[2].Text = compIdioma["GV_Asignaciones_Column2"].ToString();
            GV_Asignaciones.HeaderRow.Cells[3].Text = compIdioma["GV_Asignaciones_Column3"].ToString();
            GV_Asignaciones.HeaderRow.Cells[4].Text = compIdioma["GV_Asignaciones_Column4"].ToString();
        }
        catch(Exception ex)
        {

        }
        compara2 = new DataTable();
        compara2 = datosAsignaciones;
        Session["paginar2"] = compara2;
        idAsig = Convert.ToString(e.CommandArgument);
        Session["idAsig"] = idAsig;
    
    }

    protected void GV_Asignacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        RecibirPedidos gv = new RecibirPedidos(Session["idioma"].ToString());
        GV_Asignacion.PageIndex = e.NewPageIndex;
        GV_Asignacion.DataSource = gv.actualizarAsignaciones(Convert.ToString(Session["sede"]));
        GV_Asignacion.DataBind();
    }

    protected void GV_Asignaciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Asignaciones.PageIndex = e.NewPageIndex;
        GV_Asignaciones.DataSource = (DataTable)Session["paginar2"];
        GV_Asignaciones.DataBind();
    }


    protected void B_AgregarInventario_Click(object sender, EventArgs e)
    {
        RecibirPedidos ped = new RecibirPedidos(Session["idioma"].ToString());
        ped.ingresarBD(Session["sourceEnviar"] as DataTable, Convert.ToInt32(Session["idAsig"]));
        Session["sourceEnviar"] = null;
        GV_Asignaciones.DataSource = null;
        GV_Asignacion.DataBind();
        GV_Asignaciones.DataBind();          
    }    

    protected void GV_Asignacion_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void B_Conflicto_Click(object sender, EventArgs e)
    {
        RecibirPedidos ped = new RecibirPedidos(Session["idioma"].ToString());
        ped.regresarP(Session["listaDevolver"] as List<Asignacion>, Session["sede"].ToString(), TB_Observación.Text);
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + ped.traerMensaje() + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        TB_Observación.Text = "";
        GV_Devolver.DataSource = null;
        GV_Devolver.DataBind();

    }

    protected void GV_Asignaciones_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        RecibirPedidos ped = new RecibirPedidos(Session["idioma"].ToString());
        ped.EliminaYAgrega(int.Parse(e.CommandArgument.ToString()), Session["listaDevolver"] as List<Asignacion>);
        Session["listaDevolver"] = ped.Get_Lista();
        GV_Devolver.DataSource = Session["listaDevolver"] as List<Asignacion>;
        GV_Devolver.DataBind();
        Session["sourceEnviar"] = ped.Get_source();
        GV_Asignaciones.DataSource = Session["sourceEditar"] as DataTable;
        GV_Asignaciones.DataBind();

        GV_Asignaciones.HeaderRow.Cells[1].Text = compIdioma["GV_Asignaciones_Column1"].ToString();
        GV_Asignaciones.HeaderRow.Cells[2].Text = compIdioma["GV_Asignaciones_Column2"].ToString();
        GV_Asignaciones.HeaderRow.Cells[3].Text = compIdioma["GV_Asignaciones_Column3"].ToString();
        GV_Asignaciones.HeaderRow.Cells[4].Text = compIdioma["GV_Asignaciones_Column4"].ToString();
        string[] commandArgs =e.CommandName.ToString().Split(new char[] { ',' });
        idref = commandArgs[0];
        referencia = commandArgs[1];
        talla = commandArgs[2];
        cantidad = commandArgs[3];
        GV_Devolver.HeaderRow.Cells[0].Text = compIdioma["GV_Devolver_Column0"].ToString();
        GV_Devolver.HeaderRow.Cells[1].Text = compIdioma["GV_Devolver_Column1"].ToString();
        GV_Devolver.HeaderRow.Cells[2].Text = compIdioma["GV_Devolver_Column2"].ToString();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        L_Nume.Text = idref;
        L_Referencia.Text = referencia;
        L_Talla.Text = talla;
        L_Cantidad.Text = cantidad;
    }

    protected void GV_Asignacion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        RecibirPedidos ped = new RecibirPedidos(Session["idioma"].ToString());
        compIdioma = ped.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        try
        {
            ((LinkButton)e.Row.FindControl("LB_SeleccionarA")).Text = compIdioma["LB_SeleccionarA"].ToString();
        }
        catch (Exception exe)
        {

        }
    }

    protected void GV_Asignaciones_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        RecibirPedidos ped = new RecibirPedidos(Session["idioma"].ToString());
        compIdioma = ped.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        try
        {
            ((LinkButton)e.Row.FindControl("LB_SeleccionarAs")).Text = compIdioma["LB_SeleccionarAs"].ToString();
        }
        catch (Exception exe)
        {

        }
    }
}
