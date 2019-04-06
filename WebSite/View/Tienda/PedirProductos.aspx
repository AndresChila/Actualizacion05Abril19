<%@ Page Title="" Language="C#" MasterPageFile="~/View/Tienda/MasterAdmin.master" AutoEventWireup="true" CodeFile="~/Controller/Tienda/PedirProductos.aspx.cs" Inherits="View_Tienda_PedirProductos" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .auto-style16 {
            width: 100%;
        }
        .auto-style17 {
            width: 165px;
        }
        .auto-style18 {
            width: 93px;
        }
        .auto-style19 {
            width: 165px;
            text-align: center;
        }
        .auto-style24 {
            width: 93px;
            height: 42px;
        }
        .auto-style25 {
            width: 165px;
            text-align: center;
            height: 42px;
        }
        .auto-style26 {
            width: 165px;
            height: 42px;
        }
        .auto-style27 {
            height: 42px;
        }
        .auto-style28 {
            background-color: #000099;
        }
        .auto-style29 {
            width: 93px;
            height: 29px;
        }
        .auto-style30 {
            width: 165px;
            text-align: center;
            height: 29px;
        }
        .auto-style31 {
            height: 29px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style16">
        <tr>
            <td class="auto-style18">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style24"></td>
            <td class="auto-style25" runat="server">
                <asp:Label ID="L_Tabla" runat="server" Text="Tabla de productos en bodega principal"></asp:Label>
            </td>
            <td class="auto-style26"></td>
            <td class="auto-style27"></td>
        </tr>
        <tr>
            <td class="auto-style18">&nbsp;</td>
            <td class="auto-style17">
                <asp:GridView ID="GV_Pedidos" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource4" PageSize="5" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowCommand="GV_Pedidos_RowCommand" OnRowDataBound="GV_Pedidos_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Seleccionar" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LB_Seleccionar" CommandArgument='<%# Bind("talla") %>' CommandName='<%# Bind("referencia") %>' runat="server" CausesValidation="False" Text="Seleccionar"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Referencia">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("referencia") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="L_Referencia" runat="server" Text='<%# Bind("referencia") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Talla">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("talla") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="L_Talla" runat="server" Text='<%# Bind("talla") %>'></asp:Label>
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
            <td class="auto-style19">
                &nbsp;</td>
            <td>
                <table class="auto-style16">
                    <tr>
                        <td>
                            <asp:Label ID="L_Referencia0" runat="server" Text="Referencia"></asp:Label>
                            <br />
                            <asp:Label ID="L_Referencia" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="L_Talla0" runat="server" Text="Talla"></asp:Label>
                            <br />
                            <asp:Label ID="L_Talla" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="L_Cantidad" runat="server" Text="Cantidad"></asp:Label>
                            <br />
                            <asp:TextBox ID="TB_Cantidad" runat="server" MaxLength="3"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="B_Agregar" runat="server" OnClick="B_Agregar_Click" Text="Agregar al Pedido" Height="26px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style18">&nbsp;</td>
            <td class="auto-style19">
                &nbsp;</td>
            <td class="auto-style19">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style29"></td>
            <td class="auto-style30">
                <asp:Label ID="L_Pedido" runat="server" Text="Pedido a enviar"></asp:Label>
                <asp:Button ID="B_Ver" runat="server" Text="VER" />
                <ajaxToolkit:ModalPopupExtender ID="B_Ver_ModalPopupExtender" 
                    runat="server" 
                    BehaviorID="B_Ver_ModalPopupExtender" 
                    TargetControlID="B_Ver"
                    PopupControlID ="Panel2"
                    OkControlID ="B_Pedir"
                    CancelControlID="B_SeguirAgregando"
                    DropShadow ="true"
                    >
                </ajaxToolkit:ModalPopupExtender>
            </td>
            <td class="auto-style30">
                    </td>
            <td class="auto-style31"></td>
        </tr>
        <tr>
            <td class="auto-style18">&nbsp;</td>
            <td class="auto-style19">
                <asp:Panel ID="Panel2" runat="server" CssClass="auto-style28" Height="237px" Width="274px">
                    <asp:GridView ID="GV_Ped" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="GV_Ped_SelectedIndexChanged" PageSize="5" EmptyDataText="Seleccione Productos ">
                        <Columns>
                            <asp:TemplateField HeaderText="Referencia">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Referencia") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Referencia") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Talla">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Talla") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Talla") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cantidad">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Cantidad") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle BackColor="White" Font-Size="Medium" />
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
                    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="Productos" TypeName="Datos.DAOUsuario"></asp:ObjectDataSource>
                    <asp:Button ID="B_Pedir" runat="server" OnClick="B_Pedir_Click1" Text="Pedir" />
                    <asp:Button ID="B_SeguirAgregando" runat="server" Text="Seguir Agregando" />
                </asp:Panel>
                <ajaxToolkit:RoundedCornersExtender ID="Panel2_RoundedCornersExtender" runat="server" BehaviorID="Panel2_RoundedCornersExtender" BorderColor="Blue" Color="Blue" Radius="10" TargetControlID="Panel2" />
            </td>
            <td class="auto-style19">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
               
    </table>
</asp:Content>
