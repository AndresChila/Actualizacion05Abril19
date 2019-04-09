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


public partial class View_Tienda_CRUDProduc : System.Web.UI.Page
{
    String compara
    {
        get { return Session["compara"] as String; }
        set { Session["compara"] = value; }
    }
    String id
    {
        get { return Session["idproducto"] as String; }
        set { Session["idproducto"] = value; }
    }
    Hashtable compIdioma = new Hashtable();

    protected void Page_Load(object sender, EventArgs e)
    {
        ValidacionesCRUDProducto val = new ValidacionesCRUDProducto(Session["idioma"].ToString());
        compIdioma = val.paraIdioma(Session["idioma"].ToString(), 11);
        L_Referencia.Text = compIdioma[L_Referencia.ID].ToString();
        L_Referencia0.Text = compIdioma[L_Referencia0.ID].ToString();
        L_Precio.Text = compIdioma[L_Precio.ID].ToString();
        L_Precio0.Text = compIdioma[L_Precio0.ID].ToString();
        L_Cantidad.Text = compIdioma[L_Cantidad.ID].ToString();
        L_Talla.Text = compIdioma[L_Talla.ID].ToString();
        L_Cantidad0.Text = compIdioma[L_Cantidad0.ID].ToString();
        L_Talla0.Text = compIdioma[L_Talla0.ID].ToString();
        L_Editar.Text = compIdioma[L_Editar.ID].ToString();
        B_AgregarProducto.Text = compIdioma[B_AgregarProducto.ID].ToString();
        B_EditarProducto.Text = compIdioma[B_EditarProducto.ID].ToString();
        B_Cancelar.Text = compIdioma[B_Cancelar.ID].ToString();
        L_AgregarProducto.Text = compIdioma[L_AgregarProducto.ID].ToString();
        L_VerProductos.Text = compIdioma[L_VerProductos.ID].ToString();
        L_EditarProductos.Text = compIdioma[L_EditarProductos.ID].ToString();
        try
        {
            GV_Productos.HeaderRow.Cells[0].Text = compIdioma["GV_Productos_Column0"].ToString();
            GV_Productos.HeaderRow.Cells[1].Text = compIdioma["GV_Productos_Column1"].ToString();
            GV_Productos.HeaderRow.Cells[2].Text = compIdioma["GV_Productos_Column2"].ToString();
            GV_Productos.HeaderRow.Cells[3].Text = compIdioma["GV_Productos_Column3"].ToString();
            GV_Productos.HeaderRow.Cells[4].Text = compIdioma["GV_Productos_Column4"].ToString();
            GV_Productos.HeaderRow.Cells[5].Text = compIdioma["GV_Productos_Column5"].ToString();
        }
        catch(Exception ex)
        {

        }
    }

    protected void B_AgregarProducto_Click(object sender, EventArgs e)
    {
        ValidacionesCRUDProducto val = new ValidacionesCRUDProducto(Session["idioma"].ToString());
        val.AgregarProducto(TB_ReferenciaProducto.Text, TB_Precio.Text, TB_Cantidad.Text, DDL_Tallas.SelectedValue);
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + val.devuelvemensaje() + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        GV_Productos.DataBind();
        GV_Productos.HeaderRow.Cells[0].Text = compIdioma["GV_Productos_Column0"].ToString();
        GV_Productos.HeaderRow.Cells[1].Text = compIdioma["GV_Productos_Column1"].ToString();
        GV_Productos.HeaderRow.Cells[2].Text = compIdioma["GV_Productos_Column2"].ToString();
        GV_Productos.HeaderRow.Cells[3].Text = compIdioma["GV_Productos_Column3"].ToString();
        GV_Productos.HeaderRow.Cells[4].Text = compIdioma["GV_Productos_Column4"].ToString();
        GV_Productos.HeaderRow.Cells[5].Text = compIdioma["GV_Productos_Column5"].ToString();
        this.reiniciar();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GV_Productos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            TabContainer1.ActiveTabIndex = 2; TabContainer1.ActiveTabIndex = 2;
        }
        Session["idproducto"] = null;
        ValidacionesCRUDProducto validaciones = new ValidacionesCRUDProducto(Session["idioma"].ToString());
        validaciones.RowCommand(e.CommandName, e.CommandArgument.ToString(), Convert.ToInt32(e.CommandArgument));
        Session["idproducto"] = Convert.ToString(e.CommandArgument);
        Seleccionar_Producto(validaciones.GetProducto());
    }

    void Seleccionar_Producto(Producto producto)
    {        
        
        Session["compara"] = Convert.ToString(producto.Cantidad);
        TB_EditarReferencia.Text = producto.Referencia;
        TB_EditarCantidad.Text = Convert.ToString(producto.Cantidad);
        TB_EditarPrecio.Text = Convert.ToString(producto.Precio);
        try
        {
            string t = producto.Talla.ToString();
            string[] commandArgs = t.ToString().Split(new char[] { ',' });
            string t1 = commandArgs[0] + "." + commandArgs[1];
            DDL_EditarTallas.SelectedValue = t1;
        }
        catch (Exception e)
        {
            string x = producto.Talla.ToString();
            DDL_EditarTallas.SelectedValue = x;
        }        
        B_EditarProducto.Enabled = true;
        B_Cancelar.Enabled = true;
    }

    protected void B_EditarProducto_Click(object sender, EventArgs e)
    {
        ValidacionesCRUDProducto val = new ValidacionesCRUDProducto(Session["idioma"].ToString());
        val.EditarProducto(TB_EditarReferencia.Text, TB_EditarPrecio.Text, TB_EditarCantidad.Text, DDL_EditarTallas.SelectedValue, Convert.ToString(Session["idproducto"]), Convert.ToString(Session["compara"]));
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + val.devuelvemensaje() + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        GV_Productos.DataBind();
        GV_Productos.HeaderRow.Cells[0].Text = compIdioma["GV_Productos_Column0"].ToString();
        GV_Productos.HeaderRow.Cells[1].Text = compIdioma["GV_Productos_Column1"].ToString();
        GV_Productos.HeaderRow.Cells[2].Text = compIdioma["GV_Productos_Column2"].ToString();
        GV_Productos.HeaderRow.Cells[3].Text = compIdioma["GV_Productos_Column3"].ToString();
        GV_Productos.HeaderRow.Cells[4].Text = compIdioma["GV_Productos_Column4"].ToString();
        GV_Productos.HeaderRow.Cells[5].Text = compIdioma["GV_Productos_Column5"].ToString();
        TB_EditarReferencia.Text = "";
        TB_EditarCantidad.Text = "";
        TB_EditarPrecio.Text = "";
        DDL_EditarTallas.SelectedIndex = 0;
        B_EditarProducto.Enabled = false;
        B_Cancelar.Enabled = false;
        Session["compara"] = null;
    }

    protected void B_Cancelar_Click(object sender, EventArgs e)
    {
        TB_EditarReferencia.Text = "";
        TB_EditarReferencia.Text = "";
        TB_EditarPrecio.Text = "";
        DDL_EditarTallas.SelectedIndex = 0;
        B_EditarProducto.Enabled = false;
        B_Cancelar.Enabled = false;
    }

    protected void DL_ReferenciaProducto_SelectedIndexChanged(object sender, EventArgs e)
    {
        B_EditarProducto.Enabled = false;
        B_Cancelar.Enabled = false;
    }

    void reiniciar()
    {
        TB_ReferenciaProducto.Text = "";
        TB_Precio.Text = "";
        TB_Cantidad.Text = "";
        DDL_Tallas.SelectedIndex = 0;
    }

    protected void TB_EditarPrecio_TextChanged(object sender, EventArgs e)
    {

    }

    protected void GV_Productos_PageIndexChanged(object sender, EventArgs e)
    {
        GV_Productos.DataBind();
        GV_Productos.HeaderRow.Cells[0].Text = compIdioma["GV_Productos_Column0"].ToString();
        GV_Productos.HeaderRow.Cells[1].Text = compIdioma["GV_Productos_Column1"].ToString();
        GV_Productos.HeaderRow.Cells[2].Text = compIdioma["GV_Productos_Column2"].ToString();
        GV_Productos.HeaderRow.Cells[3].Text = compIdioma["GV_Productos_Column3"].ToString();
        GV_Productos.HeaderRow.Cells[4].Text = compIdioma["GV_Productos_Column4"].ToString();
        GV_Productos.HeaderRow.Cells[5].Text = compIdioma["GV_Productos_Column5"].ToString();
    }

    protected void GV_Productos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Productos.PageIndex = e.NewPageIndex;
        GV_Productos.DataBind();
        GV_Productos.HeaderRow.Cells[0].Text = compIdioma["GV_Productos_Column0"].ToString();
        GV_Productos.HeaderRow.Cells[1].Text = compIdioma["GV_Productos_Column1"].ToString();
        GV_Productos.HeaderRow.Cells[2].Text = compIdioma["GV_Productos_Column2"].ToString();
        GV_Productos.HeaderRow.Cells[3].Text = compIdioma["GV_Productos_Column3"].ToString();
        GV_Productos.HeaderRow.Cells[4].Text = compIdioma["GV_Productos_Column4"].ToString();
        GV_Productos.HeaderRow.Cells[5].Text = compIdioma["GV_Productos_Column5"].ToString();
    }

    protected void GV_Productos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ValidacionesCRUDProducto val = new ValidacionesCRUDProducto(Session["idioma"].ToString());
        compIdioma = val.paraIdioma(Session["idioma"].ToString(), 11);
        try
        {
            ((LinkButton)e.Row.FindControl("LB_Seleccionar")).Text = compIdioma["LB_Seleccionar"].ToString();
            ((LinkButton)e.Row.FindControl("LB_Eliminar")).Text = compIdioma["LB_Eliminar"].ToString();
        }
        catch (Exception exe)
        {

        }
    }
}