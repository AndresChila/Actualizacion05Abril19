using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;
using Utilitarios.DataSet;

public partial class View_Tienda_VistaFactura : System.Web.UI.Page
{
    int idVenta;
    DataTable aid = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        DAOUsuario dao = new DAOUsuario();

        aid = dao.verUltimoId3();
        idVenta = int.Parse(aid.Rows[0]["f_verultimoid3"].ToString());

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
        Session["idVenta"] = null;
        return datos;
    }
}