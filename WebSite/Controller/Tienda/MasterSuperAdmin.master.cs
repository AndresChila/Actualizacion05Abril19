using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;

public partial class View_Tienda_MasterTienda : System.Web.UI.MasterPage
{
    SuperAdmin s = new SuperAdmin();
    Hashtable compIdioma = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] == null || Session["clave"] == null || Convert.ToInt32(Session["rol_id"]) != 1)
        {
            this.cerrarSesion();
            Response.Redirect("../Login-Rec/NuevoLogin.aspx");
        }
        else
        {
            Label_Usuario.Text = Session["nombre"].ToString();
            L_Sede.Text = Session["sede"].ToString();
        }

        compIdioma = s.paraIdioma(Session["idioma"].ToString(), 14);
        LB_AgregarSede.Text = compIdioma[LB_AgregarSede.ID].ToString();
        LB_Asignar.Text = compIdioma[LB_Asignar.ID].ToString();
        LB_Conflictos.Text = compIdioma[LB_Conflictos.ID].ToString();
        //LB_CRUDAdmin.Text = compIdioma[LB_CRUDAdmin.ID].ToString();
        LB_CRUDProducto.Text = compIdioma[LB_CRUDProducto.ID].ToString();
        B_CerrarSesion.Text = compIdioma[B_CerrarSesion.ID].ToString();
        LB_Idioma.Text = compIdioma[LB_Idioma.ID].ToString();

        this.panel_validacion();
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("AgregarSede.aspx");
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Response.Redirect("CRUDProducto.aspx");
    }

    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddIdioma.aspx");
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("CRUDAdmin.aspx");
    }

    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        Response.Redirect("SuperVentasReportes.aspx");
    }

    protected void B_CerrarSesion_Click(object sender, EventArgs e)
    {
        this.cerrarSesion();
    }


    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Response.Redirect("Conflictos.aspx");
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
    

    protected void IR_Conflictos_Click(object sender, EventArgs e)
    {
        Response.Redirect("Conflictos.aspx");
    }

    protected void IR_Asignaciones_Click(object sender, EventArgs e)
    {
        Response.Redirect("Asignar.aspx");
    }

    void panel_validacion()
    {
        ValidarMasterSuperAdmin validar = new ValidarMasterSuperAdmin();
        validar.always_visible_panel();
        Panel1.Visible = validar.estado();
        not_conflictos(validar.cantC);
        not_asignaciones(validar.cantA);
    }

    void not_conflictos(int c)
    {
        L_c.Text = c.ToString();
    }

    void not_asignaciones(int a)
    {
        L_c1.Text = a.ToString();
    }
}
