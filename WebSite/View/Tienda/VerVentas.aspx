<%@ Page Title="" Language="C#" MasterPageFile="~/View/Tienda/MasterVendedor.master" AutoEventWireup="true" CodeFile="~/Controller/Tienda/VerVentas.aspx.cs" Inherits="Controller_Tienda_VerVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style16 {
            width: 100%;
        }
        .auto-style17 {
            text-align: center;
            width: 159px;
        }
        .auto-style18 {
            width: 159px;
        }
        .auto-style19 {
            width: 103px;
        }
        .auto-style20 {
            text-align: center;
            width: 103px;
        }
        .auto-style21 {
            width: 59px;
        }
        .auto-style22 {
            width: 59px;
            height: 23px;
        }
        .auto-style23 {
            text-align: center;
            width: 159px;
            height: 23px;
        }
        .auto-style24 {
            width: 103px;
            height: 23px;
        }
        .auto-style25 {
            height: 23px;
        }
        .auto-style26 {
            width: 59px;
            height: 30px;
        }
        .auto-style27 {
            width: 159px;
            height: 30px;
        }
        .auto-style28 {
            width: 103px;
            height: 30px;
        }
        .auto-style29 {
            text-align: center;
            height: 30px;
        }
        .auto-style30 {
            font-size: medium;
        }
        .auto-style31 {
            width: 59px;
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style16">
        <tr>
            <td class="auto-style22"></td>
            <td class="auto-style23">
                <asp:Label ID="L_Ventas" runat="server" Text="Ventas" CssClass="auto-style30"></asp:Label>
            </td>
            <td class="auto-style24"></td>
            <td class="auto-style25"></td>
        </tr>
        <tr>
            <td class="auto-style21"><span class="auto-style30"></td>
            <td class="auto-style17">
                <asp:Label ID="L_Filtrar" runat="server" Text="Filtrar"></asp:Label>
                </span>
            </td>
            <td class="auto-style20">
                <asp:DropDownList ID="DDL_Filtrar" runat="server" Height="16px" CssClass="auto-style30">
                    <asp:ListItem Value="1">Ver Todas</asp:ListItem>
                    <asp:ListItem Value="2">Fecha</asp:ListItem>
                    <asp:ListItem Value="3">Top 10</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style10">
                <asp:Button ID="B_Ir" runat="server" OnClick="B_Ir_Click" Text="IR" style="width: 26px" CssClass="auto-style30" />
            </td>
        </tr>
        <tr>
            <td class="auto-style26">
                <asp:Label ID="L_Entre" runat="server" Text="Entre:" Visible="False" CssClass="auto-style30"></asp:Label>
            </td>
            <td class="auto-style27">
                <asp:TextBox ID="TB_Fecha1" runat="server" TextMode="Date" Visible="False" CssClass="auto-style30"></asp:TextBox>
                <asp:Label ID="L_Y" runat="server" Text="y" Visible="False" CssClass="auto-style30"></asp:Label>
            </td>
            <td class="auto-style28">
                <asp:TextBox ID="TB_Fecha2" runat="server" Visible="False" TextMode="Date" CssClass="auto-style30"></asp:TextBox>
            </td>
            <td class="auto-style29">
                <asp:Button ID="B_Buscar" runat="server" OnClick="B_Buscar_Click" Text="Buscar" Visible="False" CssClass="auto-style30" />
            </td>
        </tr>
        <tr class="auto-style30">
            <td class="auto-style21">&nbsp;</td>
            <td class="auto-style10" colspan="2">
                <asp:Label ID="L_Tabla" runat="server" Text="Tabla de ventas"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style31">&nbsp;</td>
            <td colspan="2">
                <asp:GridView ID="GV_Ventas" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="GV_Ventas_PageIndexChanging" PageSize="5" Width="287px" EmptyDataText="No hay ventas para mostrar." CssClass="auto-style30">
                    <Columns>
                        <asp:TemplateField HeaderText="Cédula Cliente">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idcliente") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("idcliente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("fecha") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Precio">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("precio") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("precio") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
            </td>
            <td class="auto-style30">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style21">&nbsp;</td>
            <td class="auto-style18">&nbsp;</td>
            <td class="auto-style19">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style21">&nbsp;</td>
            <td class="auto-style18">&nbsp;</td>
            <td class="auto-style19">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style21">&nbsp;</td>
            <td class="auto-style18">&nbsp;</td>
            <td class="auto-style19">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>