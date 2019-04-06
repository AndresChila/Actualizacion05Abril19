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

public partial class View_Tienda_BodegaVendedor : System.Web.UI.Page
{
    int CONSTANTE = 7;
    Hashtable compIdioma = new Hashtable();

    protected void Page_Load(object sender, EventArgs e)
    {
        llenarGridView();
        BodegaVendedor a = new BodegaVendedor();
        compIdioma = a.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        GV_Bodega_Vendedor.HeaderRow.Cells[1].Text = compIdioma["GV_Bodega_Vendedor_Column1"].ToString();
        GV_Bodega_Vendedor.HeaderRow.Cells[2].Text = compIdioma["GV_Bodega_Vendedor_Column2"].ToString();
        GV_Bodega_Vendedor.HeaderRow.Cells[3].Text = compIdioma["GV_Bodega_Vendedor_Column3"].ToString();
        L_Inventario.Text = compIdioma[L_Inventario.ID].ToString();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    void llenarGridView()
    {
        LlenarGridViews llenar = new LlenarGridViews();   
        GV_Bodega_Vendedor.DataSource = llenar.llenarGridViewBodega(Session["sede"].ToString());
        GV_Bodega_Vendedor.DataBind();
    }

    protected void GV_Inventario_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Bodega_Vendedor.PageIndex = e.NewPageIndex;
        llenarGridView();
        GV_Bodega_Vendedor.HeaderRow.Cells[1].Text = compIdioma["GV_Bodega_Vendedor_Column1"].ToString();
        GV_Bodega_Vendedor.HeaderRow.Cells[2].Text = compIdioma["GV_Bodega_Vendedor_Column2"].ToString();
        GV_Bodega_Vendedor.HeaderRow.Cells[3].Text = compIdioma["GV_Bodega_Vendedor_Column3"].ToString();
    }    
}