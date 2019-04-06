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

public partial class View_Tienda_Bodega : System.Web.UI.Page
{
    int CONSTANTE = 6;
    Hashtable compIdioma = new Hashtable();

    protected void Page_Load(object sender, EventArgs e)
    {
        llenarGridView();
        BodegaIdi a = new BodegaIdi();
        compIdioma = a.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        GV_Inventario.HeaderRow.Cells[1].Text = compIdioma["GV_Inventario_Column1"].ToString();
        GV_Inventario.HeaderRow.Cells[2].Text = compIdioma["GV_Inventario_Column2"].ToString();
        GV_Inventario.HeaderRow.Cells[3].Text = compIdioma["GV_Inventario_Column3"].ToString();
        L_Inventario.Text = compIdioma[L_Inventario.ID].ToString();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    void llenarGridView()
    {
        LlenarGridViews llenar = new LlenarGridViews();
        DataTable gri = new DataTable();
        
        GV_Inventario.DataSource = llenar.llenarGridViewBodega(Convert.ToString(Session["sede"]));
        GV_Inventario.DataBind();
    }

    protected void GV_Inventario_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Inventario.PageIndex = e.NewPageIndex;
        llenarGridView();
        GV_Inventario.HeaderRow.Cells[1].Text = compIdioma["GV_Inventario_Column1"].ToString();
        GV_Inventario.HeaderRow.Cells[2].Text = compIdioma["GV_Inventario_Column2"].ToString();
        GV_Inventario.HeaderRow.Cells[3].Text = compIdioma["GV_Inventario_Column3"].ToString();
    }
}