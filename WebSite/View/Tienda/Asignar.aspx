<%@ Page Title="" Language="C#" MasterPageFile="~/View/Tienda/MasterSuperAdmin.master" AutoEventWireup="true" CodeFile="~/Controller/Tienda/Asignar.aspx.cs" Inherits="View_Tienda_Asigna" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style29 {
            width: 206px;
            text-decoration: none;
            text-align: center;
        }
        .auto-style30 {
            text-align: center;
        }
        .auto-style37 {
            height: 24px;
            text-align: center;
            width: 292px;
        }
        .auto-style28 {
            width: 206px;
            height: 23px;
            text-align: center;
        }
        .auto-style38 {
            height: 24px;
            width: 292px;
        }
        .auto-style16 {
            width: 206px;
            height: 24px;
            text-align: left;
        }
        .auto-style32 {
            height: 23px;
            text-align: center;
            width: 292px;
        }
        .auto-style33 {
            height: 30px;
            text-align: center;
            width: 292px;
        }
        .auto-style34 {
            margin-right: 0px;
        }
        .auto-style24 {
        width: 206px;
        height: 30px;
    }
        .auto-style42 {
            height: 49px;
            text-align: right;
            width: 292px;
        }
        .auto-style39 {
            width: 206px;
            height: 49px;
            text-align: center;
        }
        .auto-style45 {
            text-align: left;
        }
        .auto-style44 {
            height: 23px;
        }
        .auto-style35 {
            height: 53px;
            text-align: center;
            width: 292px;
        }
        .auto-style26 {
            width: 206px;
            height: 53px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" Height="509px" Width="665px">
        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
            <HeaderTemplate>
                Bodega
            </HeaderTemplate>
            <ContentTemplate>
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style29">
                            <asp:Label ID="L_Productos_Bodega" runat="server" Text="Productos en bodega:"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">
                            <div class="auto-style30">
                                <asp:GridView ID="GV_Productos_Bodega" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ObjectDataSource4" PageSize="5"><Columns><asp:BoundField DataField="referencia" HeaderText="referencia" SortExpression="referencia" /><asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" /><asp:BoundField DataField="Talla" HeaderText="Talla" SortExpression="Talla" /><asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" /><asp:BoundField DataField="Entregado" HeaderText="Entregado" SortExpression="Entregado" />
                                    </Columns>
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <sortedascendingcellstyle backcolor="#EDF6F6" />
                                    <sortedascendingheaderstyle backcolor="#0D4AC4" />
                                    <sorteddescendingcellstyle backcolor="#D6DFDF" />
                                    <sorteddescendingheaderstyle backcolor="#002876" />
                                </asp:GridView>
                            </div>
                            <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="Productos" TypeName="Datos.DAOUsuario"></asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Asignaciones Pendientes
            </HeaderTemplate>
            <ContentTemplate>
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style37">
                            <asp:Label ID="L_Asignaciones_Pendientes" runat="server" Text="Asignaciones pendientes:"></asp:Label>
                            <asp:Label ID="L_Cantidad_Pendiente" runat="server"></asp:Label>
                        </td>
                        <td class="auto-style28">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style37">
                            <asp:GridView ID="GV_Pendientes" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ObjectDataSource5" OnRowCommand="GV_Pedido_RowCommand" OnRowDataBound="GV_Pendientes_RowDataBound" OnSelectedIndexChanged="GV_Pedido_SelectedIndexChanged" PageSize="5"><Columns><asp:TemplateField HeaderText="Seleccionar" ShowHeader="False"><ItemTemplate><asp:LinkButton ID="LB_Seleccionar_AP" runat="server" CausesValidation="False" CommandArgument='<%# Bind("idpedido") %>' CommandName="Select" Text="Seleccionar"></asp:LinkButton>
                                </ItemTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="IdPedido"><EditItemTemplate><asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("idpedido") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("idpedido") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="Sede"><EditItemTemplate><asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("sede") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("sede") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="Fecha"><EditItemTemplate><asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("fecha") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                <RowStyle BackColor="White" ForeColor="#003399" />
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <sortedascendingcellstyle backcolor="#EDF6F6" />
                                <sortedascendingheaderstyle backcolor="#0D4AC4" />
                                <sorteddescendingcellstyle backcolor="#D6DFDF" />
                                <sorteddescendingheaderstyle backcolor="#002876" />
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server"></asp:ObjectDataSource>
                        </td>
                        <td class="auto-style28">&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="L_Detalle_Pedido" runat="server" Text="Detalle del pedido:"></asp:Label>
                            <asp:GridView ID="GV_Pedidos" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" EmptyDataText="Seleccione un pedido para ver su detalle." Width="326px"><Columns><asp:TemplateField HeaderText="Referencia"><EditItemTemplate><asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("referencia") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LB_Referencia_P" runat="server" Text='<%# Bind("referencia") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="Talla"><EditItemTemplate><asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("talla") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="L_Talla" runat="server" Text='<%# Bind("talla") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="Cantidad"><EditItemTemplate><asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Cantidad") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="L_Cantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                <RowStyle BackColor="White" ForeColor="#003399" />
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <sortedascendingcellstyle backcolor="#EDF6F6" />
                                <sortedascendingheaderstyle backcolor="#0D4AC4" />
                                <sorteddescendingcellstyle backcolor="#D6DFDF" />
                                <sorteddescendingheaderstyle backcolor="#002876" />
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" SelectMethod="verPedido" TypeName="Datos.DAOUsuario"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style38"></td>
                        <td class="auto-style16">
                            <asp:Button ID="B_Validar" runat="server" BackColor="#9966FF" OnClick="Button2_Click" Text="Validar" />
                            <asp:Button ID="B_Asignar1" runat="server" BackColor="#6699FF" Enabled="False" ForeColor="#000066" OnClick="Button2_Click1" Text="Asignar" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            <HeaderTemplate>
                Asignar sin Pedido
            </HeaderTemplate>
            <ContentTemplate>
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style32">
                            <asp:Label ID="L_Asignacion_Sin_Pedido" runat="server" Text="Asignación sin pedido:"></asp:Label>
                        </td>
                        <td class="auto-style12">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style33">
                            <asp:GridView ID="GV_Asignar_Sin_Pedido" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="auto-style34" DataSourceID="ObjectDataSource1" OnRowCommand="GV_AsignarSinPedido_RowCommand" OnRowDataBound="GV_Asignar_Sin_Pedido_RowDataBound" PageSize="5"><Columns><asp:TemplateField HeaderText="Seleccionar" ShowHeader="False"><ItemTemplate><asp:LinkButton ID="LB_Seleccionar_ASP" runat="server" CausesValidation="False" CommandArgument='<%# Bind("Talla") %>' CommandName='<%# Bind("referencia") %>' Text="Seleccionar"></asp:LinkButton>
                                </ItemTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="Referencia"><EditItemTemplate><asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("referencia") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="L_Referencia" runat="server" Text='<%# Bind("referencia") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="Talla"><EditItemTemplate><asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Talla") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="L_Talla2" runat="server" Text='<%# Bind("Talla") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                <RowStyle BackColor="White" ForeColor="#003399" />
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <sortedascendingcellstyle backcolor="#EDF6F6" />
                                <sortedascendingheaderstyle backcolor="#0D4AC4" />
                                <sorteddescendingcellstyle backcolor="#D6DFDF" />
                                <sorteddescendingheaderstyle backcolor="#002876" />
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Productos" TypeName="Datos.DAOUsuario"></asp:ObjectDataSource>
                        </td>
                        <td class="auto-style24">
                            <table class="auto-style1">
                                <tr>
                                    <td>
                                        <asp:Label ID="L_Referencia1" runat="server" Text="Referencia"></asp:Label>
                                        <br />
                                        <asp:Label ID="L_Referencia" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="L_Talla1" runat="server" Text="Talla"></asp:Label>
                                        <br />
                                        <asp:Label ID="L_Talla" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="L_Cantidad" runat="server" Text="Cantidad"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="TB_Cantidad" runat="server" MaxLength="3"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="B_Agregar" runat="server" OnClick="B_Agregar_Click" Text="Agregar" />
                                    </td>
                                </tr>
                            </table>
                            <asp:GridView ID="GV_Asignacion_Final" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="155px" OnRowDataBound="GV_Asignacion_Final_RowDataBound" PageSize="5" Width="346px"><Columns><asp:TemplateField HeaderText="Eliminar" ShowHeader="False"><ItemTemplate><asp:LinkButton ID="LB_Seleccionar_AF" runat="server" CausesValidation="False" CommandName="Select" Text="Seleccionar"></asp:LinkButton>
                                </ItemTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="Referencia"><EditItemTemplate><asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Referencia") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Referencia") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="Talla"><EditItemTemplate><asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("Talla") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Talla") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="Cantidad"><EditItemTemplate><asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("Cantidad") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                <RowStyle BackColor="White" ForeColor="#003399" />
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <sortedascendingcellstyle backcolor="#EDF6F6" />
                                <sortedascendingheaderstyle backcolor="#0D4AC4" />
                                <sorteddescendingcellstyle backcolor="#D6DFDF" />
                                <sorteddescendingheaderstyle backcolor="#002876" />
                            </asp:GridView>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style42">
                            <asp:Label ID="L_Sede" runat="server" Text="Sede:"></asp:Label>
                            <table class="auto-style1">
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td class="auto-style39">
                            <table class="auto-style1">
                                <tr>
                                    <td class="auto-style45">
                                        <asp:DropDownList ID="DL_Sedes" runat="server" DataSourceID="ObjectDataSource3" DataTextField="NombreSede" DataValueField="NombreSede" Height="16px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="Sedes" TypeName="Datos.DAOUsuario"></asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style44">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style35"></td>
                        <td class="auto-style26">
                            <asp:Button ID="B_Asignar" runat="server" BackColor="#9999FF" OnClick="B_Asignar_Click" Text="Asignar" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>