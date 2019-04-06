<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/Login-Rec/Idioma.aspx.cs" Inherits="View_Login_Rec_Idioma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 543px;
        }
        .auto-style3 {
            height: 74px;
        }
        .auto-style4 {
            width: 100%;
        }
        .auto-style5 {
            width: 137px;
        }
        .auto-style6 {
            width: 137px;
            text-align: center;
        }
        .auto-style7 {
            text-align: center;
            width: 486px;
        }
        .auto-style8 {
            width: 137px;
            height: 23px;
        }
        .auto-style9 {
            height: 23px;
        }
        .auto-style10 {
            height: 74px;
            width: 824px;
        }
        .auto-style11 {
            width: 486px;
        }
        .auto-style12 {
            height: 23px;
            width: 486px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style10" style="background-color: #FFFFFF">
                    <table class="auto-style4">
                        <tr>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style7" style="background-color: #0066FF">
                    <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Names="Papyrus" ForeColor="White" Text="SCA"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style11" style="background-color: #3399FF">
                                <asp:Label ID="L_Titulo" runat="server" Text="Seleccione un idioma -- Choose a language"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style6">&nbsp;</td>
                            <td class="auto-style7" style="background-color: #3399FF">
                                <asp:DropDownList ID="DDL_Idioma" runat="server">
                                </asp:DropDownList>
                    <asp:Button ID="B_Ok" runat="server" OnClick="Button1_Click" Text="OK" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8"></td>
                            <td class="auto-style12"></td>
                            <td class="auto-style9"></td>
                        </tr>
                        <tr>
                            <td class="auto-style8"></td>
                            <td class="auto-style12"></td>
                            <td class="auto-style9"></td>
                        </tr>
                        <tr>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style11">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td class="auto-style3"></td>
            </tr>
        </table>
    </form>
</body>
</html>
