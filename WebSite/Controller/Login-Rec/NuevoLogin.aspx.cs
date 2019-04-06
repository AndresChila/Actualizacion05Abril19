using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;
using Datos;

public partial class View_NuevoLogin : System.Web.UI.Page
{ 
    int CONSTANTE = 2;
    
    DataTable comp = new DataTable();
    List<string> idi = new List<string>();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        Loguearse log = new Loguearse(Session["idioma"].ToString());
        comp = log.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        L_Login.Text = comp.Rows[0]["texto"].ToString();
        L_Cedula.Text = comp.Rows[1]["texto"].ToString();
        L_Contrasena.Text = comp.Rows[2]["texto"].ToString();
        LB_Recuperar.Text = comp.Rows[3]["texto"].ToString();
        B_Ingresar.Text = comp.Rows[4]["texto"].ToString();
        this.cerrarSesion();
    }

    protected void LB_Recuperar_Click(object sender, EventArgs e)
    {
        Response.Redirect("GenerarToken.aspx");
    }
    protected void B_Login_Click(object sender, EventArgs e)
    {
        Loguearse log = new Loguearse(Session["idioma"].ToString());
        UUsuario user = new UUsuario();
        CoreUser a = new CoreUser(Session["idioma"].ToString());
        bool ss;

        AjaxControlToolkit.NoBotState noBot;
        ss = NoBot1.IsValid(out noBot);
        L_NoEntra.Text = noBot.ToString();
        user = log.loguear(TB_Cedula.Text.ToString(), TB_Clave.Text.ToString(), true);
        Session["clave"] = user.Clave;
        Session["user_id"] = user.Usuario;
        Session["nombre_rol"] = user.Nombre_rol;
        Session["rol_id"] = user.Rol_id;
        Session["nombre"] = user.Nombre;
        Session["sede"] = user.Sede;
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", log.get_script(), true);

    }
 
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("GenerarToken.aspx");
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
    }

    protected void B_Volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Login-Rec/Idioma.aspx");
    }
}