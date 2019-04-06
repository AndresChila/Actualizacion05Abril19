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

public partial class Controller_Tienda_VerVentas : System.Web.UI.Page
{
    DataTable sdata, suser_id;
    int flag = 0;
    
    Hashtable compIdioma = new Hashtable();

    protected void Page_Load(object sender, EventArgs e)
    {
        MisVentas v = new MisVentas(Session["idioma"].ToString());
        sdata = Session["data"] as DataTable;
        suser_id = Session["user_id"] as DataTable;

        compIdioma = v.paraIdioma(Session["idioma"].ToString(), 21);
        L_Ventas.Text = compIdioma[L_Ventas.ID].ToString();
        L_Entre.Text = compIdioma[L_Entre.ID].ToString();
        L_Filtrar.Text = compIdioma[L_Filtrar.ID].ToString();
        L_Y.Text = compIdioma[L_Y.ID].ToString();
        L_Tabla.Text = compIdioma[L_Tabla.ID].ToString();
        B_Ir.Text = compIdioma["B_Ir"].ToString();
        B_Buscar.Text = compIdioma[B_Buscar.ID].ToString();
        //GV_Ventas.HeaderRow.Cells[0].Text = compIdioma["GV_Ventas_Column0"].ToString();
        //GV_Ventas.HeaderRow.Cells[1].Text = compIdioma["GV_Ventas_Column1"].ToString();
        //GV_Ventas.HeaderRow.Cells[2].Text = compIdioma["GV_Ventas_Column2"].ToString();
    }

    protected void B_Ir_Click(object sender, EventArgs e)
    {
        MisVentas filtrar = new MisVentas(DDL_Filtrar.SelectedValue, Convert.ToString(TB_Fecha1.Text), Convert.ToString(TB_Fecha2.Text), sdata, suser_id);
        this.ponerIn(filtrar.Get_Estado());
        this.llenarGV_Ventas();
        B_Ir.Enabled = filtrar.Get_Estado2();
    }

    public void ponerIn(bool est)
    {
        L_Entre.Visible = est;
        L_Y.Visible = est;
        TB_Fecha1.Visible = est;
        TB_Fecha2.Visible = est;
        B_Buscar.Visible = est;
    }

    void llenarGV_Ventas()
    {
        MisVentas a = new MisVentas(Session["idioma"].ToString());
        DataTable data = a.Get_GV_Ventas();
        GV_Ventas.DataSource = data;
        GV_Ventas.DataBind();
        //GV_Ventas.HeaderRow.Cells[0].Text = compIdioma["GV_Ventas_Column0"].ToString();
        //GV_Ventas.HeaderRow.Cells[1].Text = compIdioma["GV_Ventas_Column1"].ToString();
        //GV_Ventas.HeaderRow.Cells[2].Text = compIdioma["GV_Ventas_Column2"].ToString();
    }

    protected void B_Buscar_Click(object sender, EventArgs e)
    {
        MisVentas venta = new MisVentas(DDL_Filtrar.SelectedValue, Convert.ToString(TB_Fecha1.Text), Convert.ToString(TB_Fecha2.Text), sdata, suser_id);
        string a = venta.traerMensaje();
        B_Ir.Enabled = venta.Get_Estado2();
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + a + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        GV_Ventas.HeaderRow.Cells[0].Text = compIdioma["GV_Ventas_Column0"].ToString();
        GV_Ventas.HeaderRow.Cells[1].Text = compIdioma["GV_Ventas_Column1"].ToString();
        GV_Ventas.HeaderRow.Cells[2].Text = compIdioma["GV_Ventas_Column2"].ToString();
    }

    protected void GV_Ventas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Ventas.PageIndex = e.NewPageIndex;
        this.llenarGV_Ventas();
        GV_Ventas.HeaderRow.Cells[0].Text = compIdioma["GV_Ventas_Column0"].ToString();
        GV_Ventas.HeaderRow.Cells[1].Text = compIdioma["GV_Ventas_Column1"].ToString();
        GV_Ventas.HeaderRow.Cells[2].Text = compIdioma["GV_Ventas_Column2"].ToString();
    }

    
}