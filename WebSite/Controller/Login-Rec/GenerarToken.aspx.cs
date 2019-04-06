using Newtonsoft.Json;
using System;
using Logica;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class View_GenerarToken : System.Web.UI.Page
{
    int CONSTANTE = 1;
    
        DataTable compo = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        GenerarToken idioma = new GenerarToken(Session["idioma"].ToString());
        string ltitulo = L_Recuperar_Clave.ID;
        string ldigite = L_User_Name.ID;
        string lboton = B_Recuperar.ID;
        idioma.paraIdioma(Session["idioma"].ToString(), CONSTANTE, ltitulo, ldigite, lboton);
        L_Recuperar_Clave.Text = idioma.Get_LTitulo();
        L_User_Name.Text = idioma.Get_LDigite();
        B_Recuperar.Text = idioma.Get_LBoton();
    }

    protected void B_Recuperar_Click(object sender, EventArgs e)
    {
        GenerarToken tok = new GenerarToken(Session["idioma"].ToString());
        try
        {
            tok.correoGenerar(TB_User_Name.Text);
#pragma warning disable CS0618 // Type or member is obsolete
            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + tok.Get_mensaje() + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        }
        catch (Exception wejee)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + wejee.Message+ "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
        }


    }

 
}