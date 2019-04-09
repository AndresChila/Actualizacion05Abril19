using System;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;
using System.Collections;

public partial class View_Tienda_AgregarSed : System.Web.UI.Page
{
    string accion;
    Sede sedes = new Sede();
    List<Sede> sd = new List<Sede>();
    int CONSTANTE = 4;
    Hashtable compIdioma = new Hashtable();

    protected void Page_Load(object sender, EventArgs e)
    {
        AgregarSede0 a = new AgregarSede0(Session["idioma"].ToString());
        llenarGV_Sedes();
        
        compIdioma = a.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        L_Nombre_Sede.Text = compIdioma[L_Nombre_Sede.ID].ToString();
        L_Ciudad.Text = compIdioma[L_Ciudad.ID].ToString();
        L_Direccion.Text = compIdioma[L_Direccion.ID].ToString();
        B_Agregar_Sede.Text = compIdioma[B_Agregar_Sede.ID].ToString();
        L_AgregarSede.Text = compIdioma[L_AgregarSede.ID].ToString();
        L_VerEliminarSedes.Text = compIdioma[L_VerEliminarSedes.ID].ToString();
        try
        {
            GV_Sedes.HeaderRow.Cells[0].Text = compIdioma["GV_Sedes_Column0"].ToString();
            GV_Sedes.HeaderRow.Cells[1].Text = compIdioma["GV_Sedes_Column1"].ToString();
            GV_Sedes.HeaderRow.Cells[2].Text = compIdioma["GV_Sedes_Column2"].ToString();
            GV_Sedes.HeaderRow.Cells[3].Text = compIdioma["GV_Sedes_Column3"].ToString();
        }
        catch(Exception ex)
        {

        }
        
    }

    protected void B_AgregarSede_Click(object sender, EventArgs e)
    {
        accion = "agregar";
        bool resultadoSede = Regex.IsMatch(TB_Nombre_Sede.Text, @"^[a-zA-Z]+$");
        bool resultadoCiudad = Regex.IsMatch(TB_Ciudad.Text, @"^[a-zA-Z]+$");

        AgregarSede0 agr = new AgregarSede0(resultadoSede, resultadoCiudad, TB_Nombre_Sede.Text.ToString(), TB_Ciudad.Text.ToString(),
            TB_Direccion.Text.ToString(), accion, Session["idioma"].ToString());
        this.llenarGV_Sedes();
        string a = agr.traerMensaje();
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + a + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        TB_Ciudad.Text = "";
        TB_Direccion.Text = "";
        TB_Nombre_Sede.Text = "";

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }


    void llenarGV_Sedes()
    {
        //AgregarSede0 data = new AgregarSede0(Session["idioma"].ToString());
        AgregarSede0 data1 = new AgregarSede0();
        sd = data1.traerSedes();
        GV_Sedes.DataSource = sd;
        GV_Sedes.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        AgregarSede0 elimi = new AgregarSede0();
        elimi.eliminarSede(e.CommandName, int.Parse(e.CommandArgument.ToString()));
        llenarGV_Sedes();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void GV_Sedes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //AgregarSede0 a = new AgregarSede0(Session["idioma"].ToString());
        /*compIdioma = a.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        try
        {
            ((LinkButton)e.Row.FindControl("LB_Eliminar0")).Text = compIdioma["LB_Eliminar0"].ToString();
        }
        catch (Exception exe)
        {

        }*/
    }

    protected void GV_Sedes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Sedes.PageIndex = e.NewPageIndex;
        llenarGV_Sedes();
    }
}