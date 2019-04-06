using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;
using System.Collections;

public partial class View_Tienda_NuevoAbono : System.Web.UI.Page
{
    DataTable vntaS,refresh;
    Hashtable compIdioma = new Hashtable();
    string precioDeuda, pagoActual;
    protected void Page_Load(object sender, EventArgs e)
    {
        NuevosAbonos n = new NuevosAbonos(Session["idioma"].ToString());
        llenarGV_Abonos();
        compIdioma = n.paraIdioma(Session["idioma"].ToString(), 17);
        L_Abonos.Text = compIdioma[L_Abonos.ID].ToString();
        L_Deuda.Text = compIdioma[L_Deuda.ID].ToString();
        L_Valor.Text = compIdioma[L_Valor.ID].ToString();
        B_Pagar.Text = compIdioma[B_Pagar.ID].ToString();
        try
        {
            GV_AbonosPendientes.HeaderRow.Cells[1].Text = compIdioma["GV_AbonosPendientes_Column1"].ToString();
            GV_AbonosPendientes.HeaderRow.Cells[2].Text = compIdioma["GV_AbonosPendientes_Column2"].ToString();
            GV_AbonosPendientes.HeaderRow.Cells[3].Text = compIdioma["GV_AbonosPendientes_Column3"].ToString();
        }
        catch(Exception ex)
        {

        }
    }

    public List<Producto> listaVenta
    {
        get { return Session["refresh"] as List<Producto>; }
        set { Session["refresh"] = value; }
    }

    private DataTable datosAbono
    {
        get { return Session["venta"] as DataTable; }
        set { Session["venta"] = value; }
    }

    private string idAbono
    {
        get { return Session["idAbono"] as string; }
        set { Session["idAbono"] = value; }
    }

    protected void GV_AbonosPendientes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        NuevosAbonos select = new NuevosAbonos(null, null, null, null);
        select.seleccionarAbono(e.CommandName, int.Parse(e.CommandArgument.ToString()));
        TB_PrecioDeuda.Text = select.Get_preciodeuda();
        Session["idAbono"] = Convert.ToString(e.CommandArgument);

    }

    void llenarGV_Abonos()  
    {
        DataTable abo = new DataTable();
        NuevosAbonos a = new NuevosAbonos(Session["idioma"].ToString());
        abo = a.llevarDataTable(Session["sede"].ToString());
        string aa = Convert.ToString(Session["sede"]);
        Session["venta"] = abo;
        GV_AbonosPendientes.DataSource = abo;
        GV_AbonosPendientes.DataBind();
    }

    void nuevaVenta()
    {
        vntaS = Session["venta"] as DataTable;
        NuevosAbonos newAbono = new NuevosAbonos(vntaS, TB_PrecioDeuda.Text.ToString(), TB_PagoActual.Text.ToString(), idAbono);
        this.actualizarInventario();
        string a = newAbono.traerMensaje();
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + a + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        Response.Redirect("../Tienda/VistaFactura.aspx");
    }

    void actualizarInventario()
    {
        listaVenta = new List<Producto>();
        listaVenta = (Session["refresh"] as List<Producto>);
        NuevosAbonos a = new NuevosAbonos(null, null, null, null);
        a.actuInvent(listaVenta, Session["sede"].ToString());


    }

    protected void B_AgregarProducto_Click(object sender, EventArgs e)
    {
        /*idAbono = Convert.ToString(Session["idAbono"]);
        NuevosAbonos newAbono = new NuevosAbonos(vntaS, precioDeuda, pagoActual, idAbono);
        this.llenarGV_Abonos();
        string a = newAbono.traerMensaje();
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + a + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete*/
        nuevaVenta();

    }

    protected void GV_AbonosPendientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_AbonosPendientes.PageIndex = e.NewPageIndex;
        this.llenarGV_Abonos();
    }

    protected void GV_AbonosPendientes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        NuevosAbonos n = new NuevosAbonos(Session["idioma"].ToString());
        compIdioma = n.paraIdioma(Session["idioma"].ToString(), 17);
        try
        {
            ((LinkButton)e.Row.FindControl("LB_Seleccionar")).Text = compIdioma["LB_Seleccionar"].ToString();
        }
        catch (Exception exe)
        {

        }
    }
}