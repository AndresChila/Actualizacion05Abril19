using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Datos;
using Logica;

public partial class View_Tienda_MasterVendedor : System.Web.UI.MasterPage
{
    ValidarMasterVendedor val = new ValidarMasterVendedor();
    Hashtable compIdioma = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["nombre"] == null || Session["clave"] == null || Convert.ToInt32(Session["rol_id"]) != 3)
        {
            Response.Redirect("../Login-Rec/NuevoLogin.aspx");
        }
        else
        {
            Label_usuario.Text = Session["nombre"].ToString();
            Label_Sede.Text = Session["sede"].ToString();

        }

        compIdioma = val.paraIdioma(Session["idioma"].ToString(), 15);
        L_Vendedor.Text = compIdioma[L_Vendedor.ID].ToString();
        LB_Abonos.Text = compIdioma[LB_Abonos.ID].ToString();
        LB_AgregarCliente.Text= compIdioma[LB_AgregarCliente.ID].ToString();
        LB_Bodega.Text = compIdioma[LB_Bodega.ID].ToString();
        LB_MisVentas.Text = compIdioma[LB_MisVentas.ID].ToString();
        LB_NuevaVenta.Text= compIdioma[LB_NuevaVenta.ID].ToString();
        LB_VerFacturas.Text = compIdioma[LB_VerFacturas.ID].ToString();
        B_CerrarSesion.Text = compIdioma[B_CerrarSesion.ID].ToString();

    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("NuevaVenta.aspx");
    }

    protected void LinkBodega_Click(object sender, EventArgs e)
    {
        Response.Redirect("BodegaVendedor.aspx");
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("CRUDCliente.aspx");
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Redirect("VerVentas.aspx");
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReportesVendedor.aspx");
    }

    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Response.Redirect("NuevoAbono.aspx");
    }
    
    void cerrarSesion()
    {
        Session["clave"] = null;
        Session["user_id"] = null;
        Session["nombre_rol"] = null;
        Session["nombre"] = null;
        Session["sede"] = null;
        Session["rol_id"] = null;
        Response.Cache.SetNoStore();
        Response.Redirect("../Login-Rec/NuevoLogin.aspx");
    }

    protected void B_CerrarSesion_Click(object sender, EventArgs e)
    {
        this.cerrarSesion();
    }

    [WebMethod]
    [ScriptMethod]
    public static Slide[] GetImages()
    {
        List<Slide> slides = new List<Slide>();
        string path = HttpContext.Current.Server.MapPath("~/img/");
        if (path.EndsWith("\\"))
        {
            path = path.Remove(path.Length - 1);
        }
        Uri pathUri = new Uri(path, UriKind.Absolute);
        string[] files = Directory.GetFiles(path);
        foreach (string file in files)
        {
            Uri filePathUri = new Uri(file, UriKind.Absolute);
            slides.Add(new Slide
            {
                Name = Path.GetFileNameWithoutExtension(file),
                
                ImagePath = pathUri.MakeRelativeUri(filePathUri).ToString()
            });
        }
        return slides.ToArray();
    }
}
