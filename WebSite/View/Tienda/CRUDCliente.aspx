<%@ Page Title="" Language="C#" MasterPageFile="~/View/Tienda/MasterVendedor.master" AutoEventWireup="true" CodeFile="~/Controller/Tienda/CRUDCliente.aspx.cs" Inherits="View_Tienda_CRUDClient" %><%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style23 {
            font-size: medium;
        }
        .auto-style18 {
            width: 100px;
            height: 28px;
        }
        .auto-style19 {
            height: 28px;
        }
        .auto-style22 {
            margin-bottom: 0px;
        }
        .auto-style20 {
            width: 100px;
            height: 26px;
        }
        .auto-style21 {
            height: 26px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" Height="328px" Width="776px">
        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
            <HeaderTemplate>
                <asp:Label ID="L_AgregarCliente" runat="server"></asp:Label>
            </HeaderTemplate>
            <ContentTemplate>
                <table class="auto-style16">
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Cedula" runat="server" Font-Size="Medium" Text="Cédula:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TB_Cedula" runat="server" max="999999999" min="9999" TextMode="Number"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Nombre" runat="server" Font-Size="Medium" Text="Nombre:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TB_Nombre" runat="server" MaxLength="15"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Apellido" runat="server" Font-Size="Medium" Text="Apellido:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TB_Apellido" runat="server" MaxLength="15"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Direccion" runat="server" Font-Size="Medium" Text="Dirección:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TB_Direccion" runat="server" MaxLength="15"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Telefono" runat="server" Font-Size="Medium" Text="Teléfono:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TB_Telefono" runat="server" MaxLength="12"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Sexo" runat="server" Font-Size="Medium" Text="Sexo:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_Sexo" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">&nbsp;</td>
                        <td>
                            <asp:Button ID="B_Agregar" runat="server" OnClick="B_Agregar_Click" Text="Agregar" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                <asp:Label ID="L_MisClientes" runat="server"></asp:Label>
            </HeaderTemplate>
            <ContentTemplate>
                <table class="auto-style16">
                    <tr>
                        <td class="auto-style17">&nbsp;</td>
                        <td>
                            <asp:GridView ID="GV_Clientes" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="auto-style10" EmptyDataText="No hay clientes ingresados." Font-Size="Medium" Height="146px" OnPageIndexChanging="GV_Clientes_PageIndexChanging" OnRowCommand="GV_Clientes_RowCommand" OnRowDataBound="GV_Clientes_RowDataBound" PageSize="5" Width="436px"><Columns><asp:TemplateField HeaderText="Eliminar" ShowHeader="False"><ItemTemplate><asp:LinkButton ID="LB_Eliminar" runat="server" CausesValidation="False" CommandArgument='<%# Bind("cedula") %>' CommandName="Eliminar" Text="Eliminar"></asp:LinkButton>
                                </ItemTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="Editar" ShowHeader="False"><ItemTemplate><asp:LinkButton ID="LB_Seleccionar" runat="server" CausesValidation="False" CommandArgument='<%# Bind("cedula") %>' CommandName="Editar" Text="Seleccionar"></asp:LinkButton>
                                </ItemTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="Cedula"><EditItemTemplate><asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cedula") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("cedula") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="Nombre"><EditItemTemplate><asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("nombre") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="Apellido"><EditItemTemplate><asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("apellido") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("apellido") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="Direccion"><EditItemTemplate><asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("direccion") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("direccion") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="Telefono"><EditItemTemplate><asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("telefono") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("telefono") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="Sexo"><EditItemTemplate><asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("sexo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("sexo") %>'></asp:Label>
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
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            <HeaderTemplate>
                <asp:Label ID="L_EditarCliente" runat="server"></asp:Label>
            </HeaderTemplate>
            <ContentTemplate>
                <table class="auto-style16">
                    <tr>
                        <td class="auto-style17">&nbsp;</td>
                        <td>
                            <asp:Label ID="L_Editar" runat="server" CssClass="auto-style23" Text="Editar datos de un cliente:"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Cedula0" runat="server" CssClass="auto-style23" Text="Cédula:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TB_Cedula0" runat="server" Enabled="False" max="999999999" min="9999" TextMode="Number" Width="128px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style18">
                            <asp:Label ID="L_Nombre0" runat="server" CssClass="auto-style23" Text="Nombre:"></asp:Label>
                        </td>
                        <td class="auto-style19">
                            <asp:TextBox ID="TB_Nombre0" runat="server" MaxLength="15"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Apellido0" runat="server" CssClass="auto-style23" Text="Apellido:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TB_Apellido0" runat="server" MaxLength="15"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Direccion0" runat="server" CssClass="auto-style23" Text="Dirección:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TB_Direccion0" runat="server" MaxLength="15"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Telefono0" runat="server" CssClass="auto-style23" Text="Teléfono:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TB_Telefono0" runat="server" CssClass="auto-style22" MaxLength="12"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style20">
                            <asp:Label ID="L_Sexo0" runat="server" CssClass="auto-style23" Text="Sexo:"></asp:Label>
                        </td>
                        <td class="auto-style21">
                            <asp:DropDownList ID="DDL_Sexo0" runat="server" Enabled="False">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style17">&nbsp;</td>
                        <td>
                            <asp:Button ID="B_Actualizar" runat="server" OnClick="B_Actualizar_Click" Text="Actualizar" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</asp:Content>