<%@ Page Title="" Language="C#" MasterPageFile="~/View/Tienda/MasterSuperAdmin.master" AutoEventWireup="true" CodeFile="~/Controller/Tienda/CRUDProducto.aspx.cs" Inherits="View_Tienda_CRUDProduc" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style16 {
            height: 27px;
        }
        .auto-style20 {
            height: 24px;
            text-align: center;
            width: 308px;
        }
        .auto-style27 {
            height: 35px;
            text-align: center;
            width: 308px;
        }
        .auto-style28 {
            height: 35px;
            text-align: center;
            width: 260px;
        }
        .auto-style21 {
            text-align: center;
            width: 308px;
            height: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="270px" Width="618px">
        <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                <asp:Label ID="L_AgregarProducto" runat="server"></asp:Label>
            </HeaderTemplate>
            <ContentTemplate>
                <asp:Panel ID="Panel3" runat="server" Height="171px" Width="557px">
                    <div class="auto-style16">
                        <table class="auto-style1">
                            <tr>
                                <td>
                                    <asp:Label ID="L_Referencia" runat="server" Text="Referencia Producto"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TB_ReferenciaProducto" runat="server" MaxLength="10"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="L_Precio" runat="server" Text="Precio"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TB_Precio" runat="server" MaxLength="6"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="L_Cantidad" runat="server" Text="Cantidad"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TB_Cantidad" runat="server" MaxLength="3"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="L_Talla" runat="server" Text="Talla"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDL_Tallas" runat="server">
                                        <asp:ListItem>Seleccione una talla</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>1.5</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>2.5</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>3.5</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>4.5</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>5.5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>6.5</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>7.5</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>8.5</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>9.5</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>10.5</asp:ListItem>
                                        <asp:ListItem>11</asp:ListItem>
                                        <asp:ListItem>11.5</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2"></td>
                                <td class="auto-style2">
                                    <asp:Button ID="B_AgregarProducto" runat="server" OnClick="B_AgregarProducto_Click" style="margin-bottom: 0px" Text="Agregar" Width="66px" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
               <asp:Label ID="L_VerProductos" runat="server"></asp:Label><br />
            </HeaderTemplate>
            <ContentTemplate>
                <asp:Panel ID="Panel4" runat="server" Height="223px">
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DeleteMethod="eliminarProducto" SelectMethod="verProductos" TypeName="Datos.DAOUsuario">
                        <DeleteParameters>
                            <asp:Parameter Name="idproducto" Type="Int32" />
                        </DeleteParameters>
                    </asp:ObjectDataSource>
                    <asp:GridView ID="GV_Productos" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderWidth="6px" CellPadding="4" CssClass="auto-style10" DataSourceID="ObjectDataSource2" EmptyDataText="No hay productos ingresados." OnPageIndexChanged="GV_Productos_PageIndexChanged" OnPageIndexChanging="GV_Productos_PageIndexChanging" OnRowCommand="GV_Productos_RowCommand" OnRowDataBound="GV_Productos_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="4">
                        <Columns>
                            <asp:TemplateField HeaderText="Editar" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LB_Seleccionar" runat="server" CausesValidation="False" CommandArgument='<%# Bind("idproducto") %>' CommandName="Editar" Text="Seleccionar"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Eliminar" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LB_Eliminar" runat="server" CausesValidation="False" CommandArgument='<%# Bind("idproducto") %>' CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Referencia Producto">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("referenciaproducto") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("referenciaproducto") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cantidad">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cantidad") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("cantidad") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Talla">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("talla") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("talla") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Precio">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("precio") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("precio") %>'></asp:Label>
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
                    <ajaxToolkit:RoundedCornersExtender ID="GV_Productos_RoundedCornersExtender" runat="server" BehaviorID="GV_Productos_RoundedCornersExtender" BorderColor="Black" Color="Black" Radius="6" TargetControlID="GV_Productos" />
                </asp:Panel>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            <HeaderTemplate>
                <asp:Label ID="L_EditarProductos" runat="server"></asp:Label>
            </HeaderTemplate>
            <ContentTemplate>
                <asp:Panel ID="Panel5" runat="server" Height="164px">
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style20">&nbsp;</td>
                            <td class="auto-style11">
                                <asp:Label ID="L_Editar" runat="server" Text="Editar Datos"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style27">
                                <asp:Label ID="L_Referencia0" runat="server" Text="Referencia Producto"></asp:Label>
                            </td>
                            <td class="auto-style28">
                                <asp:TextBox ID="TB_EditarReferencia" runat="server" Enabled="False" MaxLength="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style20">
                                <asp:Label ID="L_Precio0" runat="server" Text="Precio"></asp:Label>
                            </td>
                            <td class="auto-style11">
                                <asp:TextBox ID="TB_EditarPrecio" runat="server" MaxLength="6"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style20">
                                <asp:Label ID="L_Cantidad0" runat="server" Text="Cantidad"></asp:Label>
                            </td>
                            <td class="auto-style11">
                                <asp:TextBox ID="TB_EditarCantidad" runat="server" MaxLength="3" TextMode="Number"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style20">
                                <asp:Label ID="L_Talla0" runat="server" Text="Talla"></asp:Label>
                            </td>
                            <td class="auto-style11">
                                <asp:DropDownList ID="DDL_EditarTallas" runat="server" Enabled="False" EnableTheming="False">
                                    <asp:ListItem Value="0">Seleccione una talla</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>1.5</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>2.5</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>3.5</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>4.5</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>5.5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>6.5</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>7.5</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>8.5</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>9.5</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>10.5</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>11.5</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style21">
                                <asp:Button ID="B_EditarProducto" runat="server" Enabled="False" OnClick="B_EditarProducto_Click" Text="Actualizar" Width="130px" />
                                <td><asp:Button ID="B_Cancelar" runat="server" Enabled="False" OnClick="B_Cancelar_Click" Text="Cancelar" Width="116px" /></td>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

