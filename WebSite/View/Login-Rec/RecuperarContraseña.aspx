﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/Login-Rec/RecuperarContraseña.aspx.cs" Inherits="View_RecuperarContraseña" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 354px;
        }
        .auto-style4 {
            width: 438px;
            background-color: #FFFFFF;
        }
        .auto-style5 {
            width: 354px;
            text-align: center;
            font-size: xx-large;
            color: #FFFFFF;
            background-color: #0000CC;
        }
        .auto-style7 {
            background-color: #FFFFFF;
        }
        .auto-style8 {
            width: 354px;
            background-color: #FFFFFF;
        }
        .auto-style9 {
            font-size: medium;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style5" rowspan="10">
                        <asp:Label ID="L_Titulo" runat="server" Text="CONTRASEÑA"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="L_Contrasena" runat="server" CssClass="auto-style9" ForeColor="White" Text="Digite su nueva contraseña:"></asp:Label>
                        <br />
                        <asp:TextBox ID="Tb_Contraseña" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="L_Nueva_Contrasena" runat="server" CssClass="auto-style9" ForeColor="White" Text="Repita su nueva contraseña:"></asp:Label>
                        <br />
                        <asp:TextBox ID="TB_Repetir" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button ID="B_Cambiar" runat="server" OnClick="B_Cambiar_Click" Text="Cambiar" />
                    </td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
            </table>
            <br />
            <table class="auto-style1">
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <asp:Label ID="L_Aviso" runat="server" Text="..."></asp:Label>
        </div>
    </form>
</body>
</html>

