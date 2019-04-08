<%@ Page Title="" Language="C#" MasterPageFile="~/View/Tienda/MasterSuperAdmin.master" AutoEventWireup="true" CodeFile="~/Controller/Tienda/AddIdioma.aspx.cs" Inherits="View_Tienda_AddIdioma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style14 {
        height: 29px;
        text-align: center;
    }
    .auto-style15 {
        font-size: large;
    }
        .auto-style16 {
            width: 304px;
            height: 28px;
        }
        .auto-style17 {
            width: 100%;
            height: 85px;
        }
        .auto-style18 {
            height: 28px;
            text-align: center;
        }
        .auto-style19 {
            height: 28px;
        }
        .auto-style20 {
            text-align: center;
        }
        .auto-style21 {
            width: 301px;
        }
        .auto-style22 {
            width: 306px;
        }
        .auto-style23 {
            font-weight: bold;
        }
        .auto-style24 {
            background-color: #0000CC;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BorderColor="#0066FF" BorderStyle="Double" Height="93px">
        <table class="auto-style17">
            <tr>
                <td class="auto-style18" colspan="2"><strong>
                    <asp:Label ID="L_Titulo" runat="server" CssClass="auto-style15" Text="Crear idioma"></asp:Label>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style16">
                    <asp:Label ID="L_Nombre" runat="server" Text="Nombre idioma: "></asp:Label>
                    &nbsp;<asp:TextBox ID="TB_Nombre" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style19">
                    <asp:Label ID="L_Terminacion" runat="server" Text="Terminacion: "></asp:Label>
                    <asp:TextBox ID="TB_Terminacion" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style14" colspan="2">
                    <asp:Button ID="B_Comprobar" runat="server" Text="Comprobar" OnClick="B_Comprobar_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:Panel ID="Panel2" runat="server" BorderColor="#0066FF" BorderStyle="Double" Height="99px">
        <table class="auto-style1">
            <tr>
                <td class="auto-style20" colspan="3"><strong>
                    <asp:Label ID="L_Traducir" runat="server" CssClass="auto-style15" Text="Traducir"></asp:Label>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style21">
                    <asp:Label ID="L_VistaT" runat="server"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DDL_VistaT" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style21">
                    <asp:Label ID="L_Actual" runat="server" Text="Actual: "></asp:Label>
                    <br />
                    <asp:DropDownList ID="DDL_Actual" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="L_Traduccion" runat="server" Text="Traduccion: "></asp:Label>
                    <br />
                    <asp:TextBox ID="TB_Traduccion" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style20" colspan="3">
                    <asp:Button ID="B_Guardar" runat="server" Enabled="False" OnClick="B_Guardar_Click" Text="Guardar" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:Panel ID="Panel3" runat="server" BorderColor="#0066FF" BorderStyle="Double">
        <table class="auto-style1">
            <tr>
                <td class="auto-style20" colspan="3">
                    <strong>
                    <asp:Label ID="L_Actualizar" runat="server" CssClass="auto-style24" Text="Actualizar"></asp:Label>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style22">
                    <asp:Label ID="L_VistaA" runat="server"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DDL_VistaA" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style22">
                    <asp:Label ID="Label6" runat="server" Text="Actual: "></asp:Label>
                    <br />
                    <asp:DropDownList ID="DDL_Viejos" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Actualizacion"></asp:Label>
                    <br />
                    <asp:TextBox ID="TB_Actualizar" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style20" colspan="3">
                    <asp:Button ID="B_Actualizar" runat="server" OnClick="B_Actualizar_Click" Text="Actualizar" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:Panel ID="Panel4" runat="server" BorderColor="#0066FF" BorderStyle="Double">
        <div class="auto-style20">
            <strong>
            <asp:Button ID="Button1" runat="server" BackColor="Red" CssClass="auto-style23" OnClick="Button1_Click" Text="ELIMINAR IDIOMA" />
            </strong>
        </div>
    </asp:Panel>
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

