using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;

public partial class View_RecuperarContraseña : System.Web.UI.Page
{
    int CONSTANTE = 3;
    DataTable a = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        RecuperarContra rec = new RecuperarContra(Session["idioma"].ToString());
        rec.validar(Request.QueryString.Count, Request.QueryString[0]);
        ScriptManager.RegisterStartupScript(this, typeof( Page), "alerta", rec.get_script(), true);
        Session["user_id"] = rec.getSesion();
        a= rec.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        L_Titulo.Text = a.Rows[0]["texto"].ToString();
        L_Contrasena.Text = a.Rows[1]["texto"].ToString();
        L_Nueva_Contrasena.Text = a.Rows[2]["texto"].ToString();
        B_Cambiar.Text = a.Rows[3]["texto"].ToString();
    }

    protected void B_Cambiar_Click(object sender, EventArgs e)
    {        
        try
        {
            RecuperarContra rec = new RecuperarContra(Session["idioma"].ToString());
            rec.ValidarIgualdad(int.Parse(Session["user_id"].ToString()), Tb_Contraseña.Text, TB_Repetir.Text);
#pragma warning disable CS0618 // Type or member is obsolete
            this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('"+rec.getMensaje()+"');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        }
        catch (Exception ex)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('"+ex.Message+"')</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}