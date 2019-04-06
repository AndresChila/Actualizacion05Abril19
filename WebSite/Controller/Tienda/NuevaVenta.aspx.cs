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

public partial class View_Tienda_NuevaVenta : System.Web.UI.Page
{

    Cliente cliente = new Cliente();
    DataTable cli = new DataTable();
    Producto producto = new Producto();
    DataTable cli2 = new DataTable();
    DataTable cli3 = new DataTable();
    bool pbNV;
    int CONSTANTE = 16;
    Hashtable compIdioma = new Hashtable();
    
    
    
    private List<Producto> listaVenta
    {
        get { return Session["l"] as List<Producto>; }
        set { Session["l"] = value; }
    }

    private string valorVenta
    {
        get { return Session["valorVenta"] as string; }
        set { Session["valorVenta"] = value; }
    }

    private string idCliente
    {
        get { return Session["idCliente"] as string; }
        set { Session["idCliente"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        MisVentas a = new MisVentas(Session["idioma"].ToString());
        //if (!IsPostBack)
        //{
        llenarGridView();
            //Session["lis"] = null;
        //}
        compIdioma = a.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        
        GV_Productos.HeaderRow.Cells[3].Text = compIdioma["GV_Productos_Column3"].ToString();
        B_BuscarCliente.Text = compIdioma[B_BuscarCliente.ID].ToString();
        L_Referencia.Text = compIdioma[L_Referencia.ID].ToString();
        L_Talla.Text = compIdioma[L_Talla.ID].ToString();
        L_Cantidad.Text = compIdioma[L_Cantidad.ID].ToString();
        L_Cliente.Text = compIdioma[L_Cliente.ID].ToString();
        L_BuscarCliente.Text = compIdioma[L_BuscarCliente.ID].ToString();
        L_Productos.Text = compIdioma[L_Productos.ID].ToString();
        B_Seleccionar.Text = compIdioma[B_Seleccionar.ID].ToString();
        B_Facturar.Text = compIdioma[B_Facturar.ID].ToString();
        B_Abono.Text = compIdioma[B_Abono.ID].ToString();
        B_Cancelar.Text = compIdioma[B_Cancelar.ID].ToString();
        ((Button)GV_Productos.HeaderRow.FindControl("B_BuscarProducto")).Text = compIdioma["B_BuscarProducto"].ToString();
        
    }
    /////////////////////////////////////////////////////////////////////////////////////////arreglado
    public void llenarGridView()
    {
        LlenarGridViews llenara = new LlenarGridViews();
        
        GV_Productos.DataSource = llenara.llenarGridViewVenta(Session["sede"].ToString(), pbNV); 
        GV_Productos.DataBind();
    }
    

    protected void GV_Productos_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
    {

    }
    

    protected void B_BuscarCliente_Click(object sender, EventArgs e)
    {
        DataTable cliente = new DataTable();
        BuscarCliente clnte = new BuscarCliente(Session["idioma"].ToString());
        Cliente datosCliente = new Cliente();
        
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('"+ clnte.buscarVacio(TB_BuscarCliente.Text) + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete


        datosCliente = clnte.Get_cliente();
            
        TB_Nombre.Text = datosCliente.Nombre;
        TB_Apellido.Text = datosCliente.Apellido;
        B_Seleccionar.Enabled = true;
            
        Session["idCliente"] = TB_BuscarCliente.Text;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
    }


    protected void B_Seleccionar_Click(object sender, EventArgs e)
    {
        MisVentas a = new MisVentas(Session["idioma"].ToString());
        AgregarProductos agregar = new AgregarProductos(Session["idioma"].ToString());
        llenarVenta(agregar.AnalizarGridView(TB_Cantidad.Text, LTalla.Text, LRef.Text, Session["sede"].ToString(), (List<Producto>)Session["lis"]));
        string msg = agregar.get_mensaje();
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + msg + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        actualizarGV_Venta();
        TB_Cantidad.Text = "";
        try
        {
            compIdioma = a.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
            GV_Venta.HeaderRow.Cells[0].Text = compIdioma["GV_Venta_Column0"].ToString();
            GV_Venta.HeaderRow.Cells[1].Text = compIdioma["GV_Venta_Column1"].ToString();
            GV_Venta.HeaderRow.Cells[2].Text = compIdioma["GV_Venta_Column2"].ToString();
            GV_Venta.HeaderRow.Cells[3].Text = compIdioma["GV_Venta_Column3"].ToString();
            GV_Venta.HeaderRow.Cells[4].Text = compIdioma["GV_Venta_Column4"].ToString();
            GV_Venta.HeaderRow.Cells[5].Text = compIdioma["GV_Venta_Column5"].ToString();
            ((Label)GV_Venta.FooterRow.FindControl("L_TotalVenta")).Text = compIdioma["L_TotalVenta"].ToString();
        }
        catch(Exception ex)
        {

        }
    }

    void llenarVenta(List<Producto> listaVV)
    {
        MisVentas a = new MisVentas(Session["idioma"].ToString());
        Session["lis"] = listaVV;
        AgregarProductos tot = new AgregarProductos(Session["idioma"].ToString());
        double precioTotal = 0;
        List<Producto> listaV = new List<Producto>();
        listaV = (Session["lis"] as List<Producto>);
        precioTotal = tot.sumarTotal(listaV);
        Session["valorVenta"] = Convert.ToString(precioTotal);
    }

    void actualizarGV_Venta()
    {
        List<Producto> listaV = new List<Producto>();
        listaV = (Session["lis"] as List<Producto>);
        GV_Venta.DataSource = listaV;
        GV_Venta.DataBind();
        AgregarProductos p = new AgregarProductos(Session["idioma"].ToString());
        try
        {
            ((TextBox)GV_Venta.FooterRow.FindControl("TB_TotalVenta")).Text = p.valorVenta(Session["valorVenta"].ToString());
        }
        catch(Exception e)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('No hay productos para añadir a la grid venta');</script>");
#pragma warning restore CS0618 // Type or member is obsolete 
        }
    }


     void irAFactura2()
    {
        Session["lis"] = null;
        Response.Redirect("../Tienda/VistaAbono.aspx");
    }

    protected void B_Facturar_Click(object sender, EventArgs e)
    {

        Venta venta = new Venta();
        DateTime fechaHoy = DateTime.Now;
        AgregarProductos fact = new AgregarProductos(Session["idioma"].ToString());
        venta.Idcliente = int.Parse(Session["idCliente"].ToString());
        venta.Idvendedor = int.Parse(Session["user_id"].ToString());
        venta.Producto = (Session["lis"] as List<Producto>);
        venta.Fecha = fechaHoy.ToString("d");        
        venta.Sede = Session["sede"].ToString();
        fact.validarValorVenta(Convert.ToString(Session["valorVenta"]), venta);
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", fact.get_script(), true);
        actualizarInventario();
        reiniciar();        
    }



    void actualizarInventario()
    {
        AgregarProductos actInvt = new AgregarProductos(Session["idioma"].ToString());
        actInvt.paraInvent(Session["lis"] as List<Producto>, Session["sede"].ToString());
        Session["idVenta"] = actInvt.getUltimito();
    }

     protected void GV_Productos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Productos.PageIndex = e.NewPageIndex;
        this.llenarGridView();
    }
    

    protected void GV_Venta_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        List<Producto> pventa = new List<Producto>();
        pventa = (Session["lis"] as List<Producto>);
        AgregarProductos borr = new AgregarProductos(Session["idioma"].ToString());
        Session["lis"] = borr.BorrarDelGrid(e.CommandName.ToString(), pventa, e.CommandArgument.ToString());
        actualizarGV_Venta();
                   
    }

    protected void GV_Venta_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GV_Venta_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    void reiniciar()
    {
        Session["lis"] = null;
        llenarGridView();
        actualizarGV_Venta();
        TB_Nombre.Text = "";
        TB_Apellido.Text = "";
        L_InfoCliente.Text = "";
        TB_BuscarCliente.Text = "";
    }

    protected void B_Abono_Click(object sender, EventArgs e)
    {
        AgregarProductos abono = new AgregarProductos(Session["idioma"].ToString());
        Abono venta = new Abono();
        DateTime fechaHoy = DateTime.Now;
        venta.Idcliente = Convert.ToInt32(Session["idCliente"]);
        venta.Idvendedor = Convert.ToInt32(Session["user_id"]);
        venta.Producto = (Session["lis"] as List<Producto>);
        venta.Fecha = fechaHoy.ToString("d");
        venta.Precio = Convert.ToDouble(Session["valorVenta"]);
        venta.Sede = Convert.ToString(Session["sede"]);
        string msj2 = abono.crearAbono(Convert.ToInt32(Session["idCliente"]), venta);
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + msj2 + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        actualizarInventario();
        reiniciar();
        this.irAFactura2();
    }

    protected void B_BuscarProducto_Click(object sender, EventArgs e)
    {
        AgregarProductos boton = new AgregarProductos(Session["idioma"].ToString());        
        GV_Productos.DataSource = boton.actualizar(((TextBox)GV_Productos.HeaderRow.FindControl("TB_BuscarReferencia")).Text, ((TextBox)GV_Productos.HeaderRow.FindControl("TB_BuscarTalla")).Text, Convert.ToString(Session["sede"]), pbNV); ;
        GV_Productos.DataBind();        
    }

    protected void GV_VentaPedido_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void B_Cancelar_Click(object sender, EventArgs e)
    {
        this.reiniciar();
    }

    protected void GV_VentaPedido_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        AgregarProductos ag = new AgregarProductos(Session["idioma"].ToString());
        List<Producto> prod = new List<Producto>();
        string[] argumentos = e.CommandArgument.ToString().Split(new char[] { ',' });
        string referencia = argumentos[0];
        string talla = argumentos[1];

        producto.Referencia = referencia;
        producto.Talla = double.Parse(talla);
        pintarSeleccionado(producto);
        
    }

    protected void TB_Cantidad_TextChanged(object sender, EventArgs e)
    {
        
    }
    public void pintarSeleccionado(Producto p)
    {
        LRef.Text = p.Referencia;
        LTalla.Text = p.Talla.ToString();
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    protected void GV_Productos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        MisVentas a = new MisVentas(Session["idioma"].ToString());
        compIdioma = a.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        try
            {
                ((LinkButton)e.Row.FindControl("LB_Seleccionar")).Text = compIdioma["LB_Seleccionar"].ToString();
        }
            catch(Exception exe)
            {

            }
    }

    protected void GV_Venta_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        MisVentas a = new MisVentas(Session["idioma"].ToString());
        compIdioma = a.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        try
        {
            ((LinkButton)e.Row.FindControl("LB_Eliminar")).Text = compIdioma["LB_Eliminar"].ToString();
        }catch(Exception exe)
        {

        }
    }
}