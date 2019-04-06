using System;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using Logica;

public partial class View_Tienda_CRUDClient : System.Web.UI.Page
{
    int CONSTANTE = 10;
    Cliente cliente = new Cliente();
    DataTable cli = new DataTable();
    Hashtable compIdioma = new Hashtable();
    string accion;

    protected void Page_Load(object sender, EventArgs e)
    {
        ValidacionesCrudCliente valCli = new ValidacionesCrudCliente(Session["idioma"].ToString());
        cli = valCli.paraGrilla();
        GV_Clientes.DataSource = cli;
        GV_Clientes.DataBind();
        compIdioma = valCli.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        L_Cedula.Text = compIdioma[L_Cedula.ID].ToString();
        L_Cedula0.Text = compIdioma[L_Cedula0.ID].ToString();
        L_Nombre.Text = compIdioma[L_Nombre.ID].ToString();
        L_Nombre0.Text = compIdioma[L_Nombre0.ID].ToString();
        L_Apellido.Text = compIdioma[L_Apellido.ID].ToString();
        L_Apellido0.Text = compIdioma[L_Apellido0.ID].ToString();
        L_Direccion.Text = compIdioma[L_Direccion.ID].ToString();
        L_Direccion0.Text = compIdioma[L_Direccion0.ID].ToString();
        L_Telefono.Text = compIdioma[L_Telefono.ID].ToString();
        L_Telefono0.Text = compIdioma[L_Telefono0.ID].ToString();
        L_Sexo.Text = compIdioma[L_Sexo.ID].ToString();
        L_Sexo0.Text = compIdioma[L_Sexo0.ID].ToString();
        L_Editar.Text = compIdioma[L_Editar.ID].ToString();
        B_Actualizar.Text = compIdioma[B_Actualizar.ID].ToString();
        B_Agregar.Text = compIdioma[B_Agregar.ID].ToString();
        DDL_Sexo.Items.Add(compIdioma["DDL_Sexo_Item0"].ToString());
        DDL_Sexo.Items.Add(compIdioma["DDL_Sexo_Item1"].ToString());
        DDL_Sexo0.Items.Add(compIdioma["DDL_Sexo0_Item0"].ToString());
        DDL_Sexo0.Items.Add(compIdioma["DDL_Sexo0_Item1"].ToString());
        GV_Clientes.HeaderRow.Cells[0].Text = compIdioma["GV_Clientes_Column0"].ToString();
        GV_Clientes.HeaderRow.Cells[1].Text = compIdioma["GV_Clientes_Column1"].ToString();
        GV_Clientes.HeaderRow.Cells[2].Text = compIdioma["GV_Clientes_Column2"].ToString();
        GV_Clientes.HeaderRow.Cells[3].Text = compIdioma["GV_Clientes_Column3"].ToString();
        GV_Clientes.HeaderRow.Cells[4].Text = compIdioma["GV_Clientes_Column4"].ToString();
        GV_Clientes.HeaderRow.Cells[5].Text = compIdioma["GV_Clientes_Column5"].ToString();
        GV_Clientes.HeaderRow.Cells[6].Text = compIdioma["GV_Clientes_Column6"].ToString();
        GV_Clientes.HeaderRow.Cells[7].Text = compIdioma["GV_Clientes_Column7"].ToString();

    }

    protected void B_Agregar_Click(object sender, EventArgs e)
    {
        ValidacionesCrudCliente valCli = new ValidacionesCrudCliente(Session["idioma"].ToString());
        bool resultadoNombre = Regex.IsMatch(TB_Nombre.Text, @"^[a-zA-Z]+$");
        bool resultadoApellido = Regex.IsMatch(TB_Apellido.Text, @"^[a-zA-Z]+$");
        accion = "guardar";
        ValidacionesCrudCliente val = new ValidacionesCrudCliente(TB_Nombre.Text.ToString(), TB_Cedula.Text.ToString(), TB_Apellido.Text.ToString(), TB_Direccion.Text.ToString(),
                                                                  TB_Telefono.Text.ToString(), DDL_Sexo.SelectedValue.ToString(), TB_Nombre0.ToString(), TB_Cedula0.ToString(),
                                                                  TB_Apellido0.ToString(), TB_Direccion0.ToString(), TB_Telefono0.ToString(), DDL_Sexo0.SelectedValue.ToString(),
                                                                 accion, resultadoNombre, resultadoApellido);

#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + val.devuelvemensaje() + " ');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        cli = valCli.paraGrilla();
        GV_Clientes.DataSource = cli;
        GV_Clientes.DataBind();
        GV_Clientes.HeaderRow.Cells[0].Text = compIdioma["GV_Clientes_Column0"].ToString();
        GV_Clientes.HeaderRow.Cells[1].Text = compIdioma["GV_Clientes_Column1"].ToString();
        GV_Clientes.HeaderRow.Cells[2].Text = compIdioma["GV_Clientes_Column2"].ToString();
        GV_Clientes.HeaderRow.Cells[3].Text = compIdioma["GV_Clientes_Column3"].ToString();
        GV_Clientes.HeaderRow.Cells[4].Text = compIdioma["GV_Clientes_Column4"].ToString();
        GV_Clientes.HeaderRow.Cells[5].Text = compIdioma["GV_Clientes_Column5"].ToString();
        GV_Clientes.HeaderRow.Cells[6].Text = compIdioma["GV_Clientes_Column6"].ToString();
        GV_Clientes.HeaderRow.Cells[7].Text = compIdioma["GV_Clientes_Column7"].ToString();
    }

    void pintarEditar(Cliente cliente)
    {
        TB_Cedula0.Text = cliente.Cedula.ToString();
        TB_Nombre0.Text = cliente.Nombre;
        TB_Apellido0.Text = cliente.Apellido;
        TB_Direccion0.Text = cliente.Direccion;
        TB_Telefono0.Text = cliente.Telefono.ToString();
    }

    protected void B_Actualizar_Click(object sender, EventArgs e)
    {
        ValidacionesCrudCliente valCli = new ValidacionesCrudCliente(Session["idioma"].ToString());
        accion = "editar";
        bool resultadoNombre = Regex.IsMatch(TB_Nombre0.Text, @"^[a-zA-Z]+$");
        bool resultadoApellido = Regex.IsMatch(TB_Apellido0.Text, @"^[a-zA-Z]+$");
        ValidacionesCrudCliente val = new ValidacionesCrudCliente(TB_Nombre.Text.ToString(), TB_Cedula.Text.ToString(), TB_Apellido.Text.ToString(), TB_Direccion.Text.ToString(),
                                                                  TB_Telefono.Text.ToString(), DDL_Sexo.SelectedValue.ToString(), TB_Nombre0.Text.ToString(), TB_Cedula0.Text.ToString(),
                                                                  TB_Apellido0.Text.ToString(), TB_Direccion0.Text.ToString(), TB_Telefono0.Text.ToString(), DDL_Sexo0.SelectedValue.ToString(),
                                                                  accion, resultadoNombre, resultadoApellido);
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + val.devuelvemensaje() + " ');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        cli = valCli.paraGrilla();
        GV_Clientes.DataSource = cli;
        GV_Clientes.DataBind();
        GV_Clientes.HeaderRow.Cells[0].Text = compIdioma["GV_Clientes_Column0"].ToString();
        GV_Clientes.HeaderRow.Cells[1].Text = compIdioma["GV_Clientes_Column1"].ToString();
        GV_Clientes.HeaderRow.Cells[2].Text = compIdioma["GV_Clientes_Column2"].ToString();
        GV_Clientes.HeaderRow.Cells[3].Text = compIdioma["GV_Clientes_Column3"].ToString();
        GV_Clientes.HeaderRow.Cells[4].Text = compIdioma["GV_Clientes_Column4"].ToString();
        GV_Clientes.HeaderRow.Cells[5].Text = compIdioma["GV_Clientes_Column5"].ToString();
        GV_Clientes.HeaderRow.Cells[6].Text = compIdioma["GV_Clientes_Column6"].ToString();
        GV_Clientes.HeaderRow.Cells[7].Text = compIdioma["GV_Clientes_Column7"].ToString();
    }

    protected void GV_Clientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ValidacionesCrudCliente valCli = new ValidacionesCrudCliente(Session["idioma"].ToString());
        GV_Clientes.PageIndex = e.NewPageIndex;
        cli = valCli.paraGrilla();
        GV_Clientes.DataSource = cli;
        GV_Clientes.DataBind();
        GV_Clientes.HeaderRow.Cells[0].Text = compIdioma["GV_Clientes_Column0"].ToString();
        GV_Clientes.HeaderRow.Cells[1].Text = compIdioma["GV_Clientes_Column1"].ToString();
        GV_Clientes.HeaderRow.Cells[2].Text = compIdioma["GV_Clientes_Column2"].ToString();
        GV_Clientes.HeaderRow.Cells[3].Text = compIdioma["GV_Clientes_Column3"].ToString();
        GV_Clientes.HeaderRow.Cells[4].Text = compIdioma["GV_Clientes_Column4"].ToString();
        GV_Clientes.HeaderRow.Cells[5].Text = compIdioma["GV_Clientes_Column5"].ToString();
        GV_Clientes.HeaderRow.Cells[6].Text = compIdioma["GV_Clientes_Column6"].ToString();
        GV_Clientes.HeaderRow.Cells[7].Text = compIdioma["GV_Clientes_Column7"].ToString();
    }

    protected void GV_Clientes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ValidacionesCrudCliente valCli = new ValidacionesCrudCliente(Session["idioma"].ToString());
        ValidacionesCrudCliente val = new ValidacionesCrudCliente(Session["idioma"].ToString());
        val.RowCommand(e.CommandName.ToString(), e.CommandArgument.ToString());
        cli = valCli.paraGrilla();
        GV_Clientes.DataSource = cli;
        GV_Clientes.DataBind();
        pintarEditar(val.Get_Clientico());
        DDL_Sexo0.Enabled = true;
    }

    protected void GV_Clientes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        ValidacionesCrudCliente valCli = new ValidacionesCrudCliente(Session["idioma"].ToString());
        compIdioma = valCli.paraIdioma(Session["idioma"].ToString(), CONSTANTE);
        try
        {
            ((LinkButton)e.Row.FindControl("LB_Seleccionar")).Text = compIdioma["LB_Seleccionar"].ToString();
            ((LinkButton)e.Row.FindControl("LB_Eliminar")).Text = compIdioma["LB_Eliminar"].ToString();
        }
        catch (Exception exe)
        {

        }
    }
}