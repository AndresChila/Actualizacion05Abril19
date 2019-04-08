using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

public partial class View_Tienda_AddIdioma : System.Web.UI.Page
{
    List<string> compAct = new List<string>();
    List<string> compViejo= new List<string>();
    List<string> listaVista = new List<string>();
    AddIdioma add;
    Hashtable compIdioma = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        add = new AddIdioma(Session["idioma"].ToString());
        B_Comprobar.Enabled = true;
        compIdioma = add.paraIdioma(Session["idioma"].ToString(), 25);
        L_Titulo.Text = compIdioma[L_Titulo.ID].ToString();
        L_Nombre.Text = compIdioma[L_Nombre.ID].ToString();
        L_Terminacion.Text = compIdioma[L_Terminacion.ID].ToString();
        L_Traducir.Text = compIdioma[L_Traducir.ID].ToString();
        L_Actual.Text = compIdioma[L_Actual.ID].ToString();
        L_Traduccion.Text = compIdioma[L_Traduccion.ID].ToString();
        B_Guardar.Text = compIdioma[B_Guardar.ID].ToString();
        L_Actualizar.Text = compIdioma[L_Actualizar.ID].ToString();
        Label6.Text = compIdioma[Label6.ID].ToString();
        Label7.Text = compIdioma[Label7.ID].ToString();
        B_Actualizar.Text = compIdioma[B_Actualizar.ID].ToString();
        Button1.Text = compIdioma[Button1.ID].ToString();
        L_VistaT.Text = compIdioma[L_VistaT.ID].ToString();
        L_VistaA.Text = compIdioma[L_VistaA.ID].ToString();

    }

    protected void B_Comprobar_Click(object sender, EventArgs e)
    {
        add = new AddIdioma(Session["idioma"].ToString());
        add.ValidarExistente(TB_Nombre.Text.ToString(), TB_Terminacion.Text.ToString());
        compAct = add.getListaAct();
        DDL_Actual.DataSource = compAct;
        DDL_Actual.DataBind();
        compViejo = add.getListaParaAct();
        DDL_Viejos.DataSource = compViejo;
        DDL_Viejos.DataBind();
        B_Guardar.Enabled = true;
        Panel1.Visible = true;
    }

    protected void B_Guardar_Click(object sender, EventArgs e)
    {
        add = new AddIdioma(Session["idioma"].ToString());
        add.ValidarExistente(TB_Nombre.Text.ToString(), TB_Terminacion.Text.ToString());
        add.ActualizarIdioma(DDL_Actual.SelectedItem.ToString(), TB_Traduccion.Text.ToString());
        DDL_Actual.Items.Remove(DDL_Actual.SelectedItem.ToString());
        DDL_Actual.Items.Clear();
        compAct = add.getListaAct();        
        DDL_Actual.DataSource = compAct;
        DDL_Actual.DataBind();
        TB_Traduccion.Text = "";
        DDL_Viejos.Items.Clear();
        compViejo = add.getListaParaAct();
        DDL_Viejos.DataSource = compViejo;
        DDL_Viejos.DataBind();
    }

    protected void B_Actualizar_Click(object sender, EventArgs e)
    {
        add = new AddIdioma(Session["idioma"].ToString());
        add.ValidarExistente(TB_Nombre.Text.ToString(), TB_Terminacion.Text.ToString());
        add.ActualizarIdioma(DDL_Viejos.SelectedItem.ToString(), TB_Actualizar.Text.ToString());
        DDL_Actual.Items.Remove(DDL_Actual.SelectedItem.ToString());
        DDL_Actual.Items.Clear();
        compAct = add.getListaAct();
        DDL_Actual.DataSource = compAct;
        DDL_Actual.DataBind();
        TB_Actualizar.Text = "";
        DDL_Viejos.Items.Clear();
        compViejo = add.getListaParaAct();
        DDL_Viejos.DataSource = compViejo;
        DDL_Viejos.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        add = new AddIdioma(Session["idioma"].ToString());
        add.ValidarExistente(TB_Nombre.Text.ToString(), TB_Terminacion.Text.ToString());
        add.BorrarALV();
        TB_Nombre.Text = "";
        TB_Terminacion.Text = "";
        TB_Actualizar.Text = "";
        TB_Traduccion.Text = "";
        DDL_Actual.Items.Clear();
        DDL_Actual.DataSource = null;
        DDL_Actual.DataBind();
        DDL_Viejos.Items.Clear();
        DDL_Viejos.DataSource = null;
        DDL_Viejos.DataBind();
    }
}