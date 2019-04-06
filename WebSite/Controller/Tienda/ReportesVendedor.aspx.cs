using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;

public partial class View_Tienda_ReportesVendedor : System.Web.UI.Page
{
    
    Hashtable compIdioma = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        validarReportesVendedor val = new validarReportesVendedor(Session["idioma"].ToString());
        compIdioma = val.paraIdioma(Session["idioma"].ToString(), 20);
        L_Factura.Text = compIdioma["L_Factura"].ToString();
        L_NumVenta.Text = compIdioma[L_NumVenta.ID].ToString();
        B_Buscar.Text = compIdioma[B_Buscar.ID].ToString();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        validarReportesVendedor val = new validarReportesVendedor(Session["idioma"].ToString());
        val.validarTB(TB_Factura.Text);
        Session["idVenta"] = val.getSesion();
        Response.Redirect(val.getResponse());

#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + val.getMensaje() + "');</script>");
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos

    }

    
}