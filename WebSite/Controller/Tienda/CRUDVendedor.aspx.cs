using System;
using System.Collections;
using System.Data;
using Logica;
using Utilitarios;

public partial class View_Tienda_CRUDVendedo : System.Web.UI.Page
{
    Usuario usuario = new Usuario();
    DataTable usu = new DataTable();
    DataTable sedess = new DataTable();
    Hashtable compIdioma = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        ValidacionesCRUDVendedor val = new ValidacionesCRUDVendedor(Session["idioma"].ToString());
        string aaa = Session["sede"].ToString();
        usu = val.llenarGrilla(Session["sede"].ToString());
        GV_Usuarios.DataSource = usu;
        GV_Usuarios.DataBind();
        sedess = val.TraerSedes();

        compIdioma = val.paraIdioma(Session["idioma"].ToString(), 12);
        L_Cedula.Text = compIdioma[L_Cedula.ID].ToString();
        L_Nombre.Text = compIdioma[L_Nombre.ID].ToString();
        L_Clave.Text = compIdioma[L_Clave.ID].ToString();
        L_Direccion.Text = compIdioma[L_Direccion.ID].ToString();
        L_Telefono.Text = compIdioma[L_Telefono.ID].ToString();
        L_Sexo.Text = compIdioma[L_Sexo.ID].ToString();
        L_Correo.Text = compIdioma[L_Correo.ID].ToString();


        L_Cedula0.Text = compIdioma[L_Cedula0.ID].ToString();
        L_Nombre0.Text = compIdioma[L_Nombre0.ID].ToString();
        L_Clave0.Text = compIdioma[L_Clave0.ID].ToString();
        L_Direccion0.Text = compIdioma[L_Direccion0.ID].ToString();
        L_Telefono0.Text = compIdioma[L_Telefono0.ID].ToString();
        L_Sexo0.Text = compIdioma[L_Sexo0.ID].ToString();
        L_Correo0.Text = compIdioma[L_Correo0.ID].ToString();


        B_Agregar.Text = compIdioma[B_Agregar.ID].ToString();
        B_Actualizar.Text = compIdioma[B_Actualizar.ID].ToString();
        DDL_Sexo.Items.Add(compIdioma["DDL_Sexo_Item0"].ToString());
        DDL_Sexo.Items.Add(compIdioma["DDL_Sexo_Item1"].ToString());
        DDL_Sexo0.Items.Add(compIdioma["DDL_Sexo0_Item0"].ToString());
        DDL_Sexo0.Items.Add(compIdioma["DDL_Sexo0_Item1"].ToString());


    }

    protected void B_Agregar_Click(object sender, EventArgs e)
    {
        ValidacionesCRUDVendedor val = new ValidacionesCRUDVendedor(TB_Cedula.Text, TB_Nombre.Text, TB_Clave.Text, TB_Direccion.Text, TB_Telefono.Text,
                                                                     TB_Correo.Text, DDL_Sexo0.SelectedValue.ToString(), Session["sede"].ToString(), "3",
                                                                     null, null, null, null, null,
                                                                     null, null, null, null);

        string a = val.hacerTodoAgregar();

        string aaa = Session["sede"].ToString();
        usu = val.llenarGrilla(Session["sede"].ToString());

        GV_Usuarios.DataSource = usu;
        GV_Usuarios.DataBind();

        TB_Cedula.Text = "";
        TB_Nombre.Text = "";
        TB_Clave.Text = "";
        TB_Direccion.Text = "";
        TB_Telefono.Text = "";
        TB_Correo.Text = "";

#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + a + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete

    }

    protected void B_Seleccionar_Click(object sender, EventArgs e)
    {



    }

    protected void B_Actualizar_Click(object sender, EventArgs e)
    {

        ValidacionesCRUDVendedor val = new ValidacionesCRUDVendedor(null, null, null, null, null,
                                                                     null, null, null, null,
                                                                     TB_Cedula0.Text, TB_Nombre0.Text, TB_Clave0.Text, TB_Direccion0.Text, TB_Telefono0.Text,
                                                                     TB_Correo0.Text, DDL_Sexo.SelectedValue.ToString(), Session["sede"].ToString(), "3");
        string a = val.hacerTodoEditar();
        usu = val.llenarGrilla(Session["sede"].ToString());
        GV_Usuarios.DataSource = usu;
        GV_Usuarios.DataBind();
        //GV_Usuarios.HeaderRow.Cells[0].Text = compIdioma["GV_Usuarios_Column0"].ToString();
        //GV_Usuarios.HeaderRow.Cells[1].Text = compIdioma["GV_Usuarios_Column1"].ToString();
        //GV_Usuarios.HeaderRow.Cells[2].Text = compIdioma["GV_Usuarios_Column2"].ToString();
        //GV_Usuarios.HeaderRow.Cells[3].Text = compIdioma["GV_Usuarios_Column3"].ToString();
        //GV_Usuarios.HeaderRow.Cells[4].Text = compIdioma["GV_Usuarios_Column4"].ToString();
        //GV_Usuarios.HeaderRow.Cells[5].Text = compIdioma["GV_Usuarios_Column5"].ToString();
        //GV_Usuarios.HeaderRow.Cells[6].Text = compIdioma["GV_Usuarios_Column6"].ToString();
        //GV_Usuarios.HeaderRow.Cells[7].Text = compIdioma["GV_Usuarios_Column7"].ToString();
        //GV_Usuarios.HeaderRow.Cells[8].Text = compIdioma["GV_Usuarios_Column8"].ToString();

#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + a + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
    }

    protected void B_Eliminar_Click(object sender, EventArgs e)
    {


    }

    protected void GV_Usuarios_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        Session["idvendedor"] = e.CommandArgument;
        if (e.CommandName.Equals("Select"))
        {

            ValidacionesCRUDVendedor val = new ValidacionesCRUDVendedor();
            //usu = val.llenarGrilla(Session["sede"].ToString());
            Usuario usuario = val.llenarCampos(usu, Session["idvendedor"].ToString());
            TabContainer1.ActiveTabIndex = 2;
            TB_Cedula0.Text = usuario.Cedula.ToString();
            TB_Nombre0.Text = usuario.Nombre;
            TB_Clave0.Text = usuario.Clave;
            TB_Direccion0.Text = usuario.Direccion;
            TB_Telefono0.Text = usuario.Telefono.ToString();
            TB_Correo0.Text = usuario.Correo;
        }
        if (e.CommandName.Equals("Eliminar"))
        {
            ValidacionesCRUDVendedor val = new ValidacionesCRUDVendedor(Session["idioma"].ToString());

            Usuario usuario3 = new Usuario();
            val.EliminarUsu(Session["idvendedor"].ToString());

            usu = val.llenarGrilla(Session["sede"].ToString());
            GV_Usuarios.DataSource = usu;
            GV_Usuarios.DataBind();
        }
    }
}