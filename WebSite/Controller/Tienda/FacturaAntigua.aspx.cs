using Datos;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios.DataSet;

public partial class View_Tienda_FacturaAntigua : System.Web.UI.Page
{
    int idVenta;
    protected void Page_Load(object sender, EventArgs e)
    {
        idVenta = int.Parse(Session["idVenta"].ToString());
        VistaFactura vistaF = new VistaFactura(idVenta);
        vistaF.pageLoad();
        try
        {
            DS_FacturaNueva DS_Factura_ = ObtenerInforme();
            CrystalReportSource1.ReportDocument.SetDataSource(DS_Factura_);
            CrystalReportViewer1.ReportSource = CrystalReportSource1;
        }
        catch (Exception)
        {
            throw;
        }

        string a = vistaF.devuelveMensaje();
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + a + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
    }

    protected DS_FacturaNueva ObtenerInforme()
    {

        DS_FacturaNueva datos = new DS_FacturaNueva();
        VistaFactura vistaF = new VistaFactura(idVenta);
        datos = vistaF.obtenerInforme(Session["idioma"].ToString());
        //Session["idVenta"] = null;
        return datos;
    }
}