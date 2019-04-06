using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using Datos;
using System.Web.UI.WebControls;
using Utilitarios.DataSet;
using Logica;

public partial class View_Tienda_VistaAbono : System.Web.UI.Page
{
    DataTable idVenta1;
    protected void Page_Load(object sender, EventArgs e)
    {
        idVenta1 = Session["idVenta1"] as System.Data.DataTable;
        try
        {
            DS_Abono ds = ObtenerInforme();
            CrystalReportSource1.ReportDocument.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = CrystalReportSource1;
        }
        catch (Exception)
        {
            throw;
        }

    }

    protected DS_Abono ObtenerInforme()
    {
        DS_Abono datos = new DS_Abono();
        VistaAbono vista = new VistaAbono(Session["idioma"].ToString());
        datos = vista.obtenerInforme();
        Session["idVenta1"] = null;
        return datos;
    }
}