using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Tienda_CRUDAdmi : System.Web.UI.Page
{
    Usuario usuario = new Usuario();
    List<Usuario> usu = new List<Usuario>();
    List<Sede> sedess = new List<Sede>();
    DataTable admins = new DataTable();
    string accion;
    Hashtable compIdioma = new Hashtable();
    int CONSTANTE = 9;

    protected void Page_Load(object sender, EventArgs e)
    {
        ValidacionesCrudAdmin llenarGV = new ValidacionesCrudAdmin(Session["idioma"].ToString());
        usu = llenarGV.traerAdmins();
        GV_Productos.DataSource = usu;
        GV_Productos.DataBind();
        ValidacionesCrudAdmin lleanar = new ValidacionesCrudAdmin(Session["idioma"].ToString());
        DDL_Sedes.DataSource = lleanar.llenarDDLs();
        DDL_Sedes0.DataSource = lleanar.llenarDDLs();
        DDL_Sedes.DataBind();
        DDL_Sedes0.DataBind();

        compIdioma = llenarGV.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        L_Cedula.Text = compIdioma[L_Cedula.ID].ToString();
        L_Cedula0.Text = compIdioma[L_Cedula0.ID].ToString();
        L_Telefono.Text = compIdioma[L_Telefono.ID].ToString();
        L_Telefono0.Text = compIdioma[L_Telefono0.ID].ToString();
        L_Sexo0.Text = compIdioma[L_Sexo0.ID].ToString();
        L_Sexo.Text = compIdioma[L_Sexo.ID].ToString();
        L_Correo.Text = compIdioma[L_Correo.ID].ToString();
        L_Correo0.Text = compIdioma[L_Correo0.ID].ToString();
        L_Nombre.Text = compIdioma[L_Nombre.ID].ToString();
        L_Nombre0.Text = compIdioma[L_Nombre0.ID].ToString();
        L_Clave.Text = compIdioma[L_Clave.ID].ToString();
        L_Clave0.Text = compIdioma[L_Clave0.ID].ToString();
        L_Direccion.Text = compIdioma[L_Direccion.ID].ToString();
        L_Direccion0.Text = compIdioma[L_Direccion0.ID].ToString();
        L_Sede.Text = compIdioma[L_Sede.ID].ToString();
        L_Sede0.Text = compIdioma[L_Sede0.ID].ToString();
        B_Agregar.Text = compIdioma[B_Agregar.ID].ToString();
        B_Cancelar.Text = compIdioma[B_Cancelar.ID].ToString();
        B_Cancelar0.Text = compIdioma[B_Cancelar0.ID].ToString();
        B_Actualizar.Text = compIdioma[B_Actualizar.ID].ToString();
        L_AgregarAdmin.Text = compIdioma[L_AgregarAdmin.ID].ToString();
        L_VerAdmins.Text = compIdioma[L_VerAdmins.ID].ToString();
        L_EditarAdmins.Text = compIdioma[L_EditarAdmins.ID].ToString();
        
        try
        {
            L_GVAdmin.Text = compIdioma[L_GVAdmin.ID].ToString();
            GV_Productos.HeaderRow.Cells[0].Text = compIdioma["GV_Productos_Column0"].ToString();
            GV_Productos.HeaderRow.Cells[1].Text = compIdioma["GV_Productos_Column1"].ToString();
            GV_Productos.HeaderRow.Cells[2].Text = compIdioma["GV_Productos_Column2"].ToString();
            GV_Productos.HeaderRow.Cells[3].Text = compIdioma["GV_Productos_Column3"].ToString();
            GV_Productos.HeaderRow.Cells[4].Text = compIdioma["GV_Productos_Column4"].ToString();
            GV_Productos.HeaderRow.Cells[5].Text = compIdioma["GV_Productos_Column5"].ToString();
            GV_Productos.HeaderRow.Cells[6].Text = compIdioma["GV_Productos_Column6"].ToString();
        }
        catch(Exception ex)
        {

        }
        DDL_Sexo.Items.Add(compIdioma["DDL_Sexo_Item0"].ToString());
        DDL_Sexo0.Items.Add(compIdioma["DDL_Sexo_Item0"].ToString());
        DDL_Sexo.Items.Add(compIdioma["DDL_Sexo_Item1"].ToString());
        DDL_Sexo0.Items.Add(compIdioma["DDL_Sexo_Item1"].ToString());



    }



    protected void B_Agregar_Click(object sender, EventArgs e)
    {

        accion = "guardar";
        ValidacionesCrudAdmin val = new ValidacionesCrudAdmin(TB_Nombre.Text.ToString(), TB_Cedula.Text.ToString(), TB_Correo.Text.ToString(), TB_Direccion.Text.ToString(),
                                                                  TB_Telefono.Text.ToString(), DDL_Sedes.SelectedValue.ToString(), DDL_Sexo.SelectedValue.ToString(), TB_Clave.Text.ToString(),
                                                                  TB_Nombre0.ToString(), TB_Cedula0.ToString(), TB_Correo0.ToString(), TB_Direccion0.ToString(),
                                                                  TB_Telefono0.ToString(), DDL_Sedes0.SelectedValue, DDL_Sexo0.SelectedValue, TB_Clave0.Text.ToString(), accion, Session["idioma"].ToString());
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + val.devuelvemensaje() + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        this.limpiar();
        this.llenarGV_Usuarios();

        //dao.agregarUsuarioNuevamente(TB_Cedula.Text);
        usu = val.traerAdmins();
        GV_Productos.DataSource = usu;
        GV_Productos.DataBind();
        try
        {
            GV_Productos.HeaderRow.Cells[0].Text = compIdioma["GV_Productos_Column0"].ToString();
            GV_Productos.HeaderRow.Cells[1].Text = compIdioma["GV_Productos_Column1"].ToString();
            GV_Productos.HeaderRow.Cells[2].Text = compIdioma["GV_Productos_Column2"].ToString();
            GV_Productos.HeaderRow.Cells[3].Text = compIdioma["GV_Productos_Column3"].ToString();
            GV_Productos.HeaderRow.Cells[4].Text = compIdioma["GV_Productos_Column4"].ToString();
            GV_Productos.HeaderRow.Cells[5].Text = compIdioma["GV_Productos_Column5"].ToString();
            GV_Productos.HeaderRow.Cells[6].Text = compIdioma["GV_Productos_Column6"].ToString();
        }
        catch (Exception ez)
        {

        }
    }

    protected void B_Actualizar_Click(object sender, EventArgs e)
    {
        accion = "editar";
        ValidacionesCrudAdmin val = new ValidacionesCrudAdmin(TB_Nombre.Text.ToString(), TB_Cedula.Text.ToString(), TB_Correo.Text.ToString(), TB_Direccion.Text.ToString(),
                                                              TB_Telefono.Text.ToString(), DDL_Sedes.SelectedValue.ToString(), DDL_Sexo.SelectedValue.ToString(), TB_Clave.Text.ToString(),
                                                              TB_Nombre0.Text.ToString(), TB_Cedula0.Text.ToString(), TB_Correo0.Text.ToString(), TB_Direccion0.Text.ToString(),
                                                              TB_Telefono0.Text.ToString(), DDL_Sedes0.SelectedValue, DDL_Sexo0.SelectedValue, TB_Clave0.Text.ToString(), accion, Session["idioma"].ToString());
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + val.devuelvemensaje() + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete

        this.llenarGV_Usuarios();
        this.limpiarEditar();
    }

    void estadoEditar(bool x)
    {
        PanelEditar.Enabled = x;
        TB_Nombre0.Enabled = x;
        TB_Clave0.Enabled = x;
        TB_Direccion0.Enabled = x;
        TB_Telefono0.Enabled = x;
        TB_Correo0.Enabled = x;
        DDL_Sexo0.Enabled = x;
        B_Actualizar.Enabled = x;
        B_Cancelar0.Enabled = x;
    }

    void limpiarEditar()
    {
        TB_Cedula0.Text = "";
        TB_Nombre0.Text = "";
        TB_Clave0.Text = "";
        TB_Direccion0.Text = "";
        TB_Telefono0.Text = "";
        TB_Correo0.Text = "";
    }

    void limpiar()
    {
        TB_Cedula.Text = "";
        TB_Nombre.Text = "";
        TB_Clave.Text = "";
        TB_Direccion.Text = "";
        TB_Telefono.Text = "";
        TB_Correo.Text = "";
    }

    protected void GV_Productos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Productos.PageIndex = e.NewPageIndex;
        this.llenarGV_Usuarios();
    }

    protected void GV_Productos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ValidacionesCrudAdmin val = new ValidacionesCrudAdmin(TB_Nombre.Text.ToString(), TB_Cedula.Text.ToString(), TB_Correo.Text.ToString(), TB_Direccion.Text.ToString(),
                                                             TB_Telefono.Text.ToString(), DDL_Sedes.SelectedValue.ToString(), DDL_Sexo.SelectedValue.ToString(), TB_Clave.Text.ToString(),
                                                             TB_Nombre0.Text.ToString(), TB_Cedula0.Text.ToString(), TB_Correo0.Text.ToString(), TB_Direccion0.Text.ToString(),
                                                             TB_Telefono0.Text.ToString(), DDL_Sedes0.SelectedValue, DDL_Sexo0.SelectedValue, TB_Clave0.Text.ToString(), accion, Session["idioma"].ToString());
        Usuario u = new Usuario();
        u = val.paracomandogrid(e.CommandName, e.CommandArgument.ToString());
        traerEditar(u);
        this.estadoEditar(true);
        this.llenarGV_Usuarios();
    }

    void llenarGV_Usuarios()
    {
        ValidacionesCrudAdmin llenarGV = new ValidacionesCrudAdmin(Session["idioma"].ToString());
        usu = llenarGV.traerAdmins();
        GV_Productos.DataSource = usu;
        GV_Productos.DataBind();
        try
        {
            GV_Productos.HeaderRow.Cells[0].Text = compIdioma["GV_Productos_Column0"].ToString();
            GV_Productos.HeaderRow.Cells[1].Text = compIdioma["GV_Productos_Column1"].ToString();
            GV_Productos.HeaderRow.Cells[2].Text = compIdioma["GV_Productos_Column2"].ToString();
            GV_Productos.HeaderRow.Cells[3].Text = compIdioma["GV_Productos_Column3"].ToString();
            GV_Productos.HeaderRow.Cells[4].Text = compIdioma["GV_Productos_Column4"].ToString();
            GV_Productos.HeaderRow.Cells[5].Text = compIdioma["GV_Productos_Column5"].ToString();
            GV_Productos.HeaderRow.Cells[6].Text = compIdioma["GV_Productos_Column6"].ToString();
        }
        catch(Exception es)
        {

        }
    }

    protected void B_Cancelar_Click(object sender, EventArgs e)
    {
        this.limpiarEditar();
        this.estadoEditar(false);
    }

    protected void B_Cancelar1_Click(object sender, EventArgs e)
    {
        this.limpiarEditar();
    }

    public void traerEditar(Usuario u)
    {

        TB_Cedula0.Text = u.Cedula.ToString();
        TB_Nombre0.Text = u.Nombre;
        TB_Clave0.Text = u.Clave;
        TB_Direccion0.Text = u.Direccion;
        DDL_Sexo0.SelectedValue = u.Sexo;
        TB_Telefono0.Text = u.Telefono.ToString();
        TB_Correo0.Text = u.Correo;
    }


    protected void GV_Productos_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void TB_Cedula_TextChanged(object sender, EventArgs e)
    {

    }

    protected void GV_Productos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ValidacionesCrudAdmin llenarGV = new ValidacionesCrudAdmin(Session["idioma"].ToString());
        compIdioma = llenarGV.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        try
        {
            ((LinkButton)e.Row.FindControl("LB_Eliminar")).Text = compIdioma["LB_Eliminar"].ToString();
            ((LinkButton)e.Row.FindControl("LB_Editar")).Text = compIdioma["LB_Editar"].ToString();
        }
        catch (Exception exe)
        {

        }
    }
}