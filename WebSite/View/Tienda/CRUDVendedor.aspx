<%@ Page Title="" Language="C#" MasterPageFile="~/View/Tienda/MasterAdmin.master" AutoEventWireup="true" CodeFile="~/Controller/Tienda/CRUDVendedor.aspx.cs" Inherits="View_Tienda_CRUDVendedo" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style17 {
            width: 82px;
        }
        .indicadorenlinea{
            border-style:solid;
            border-width:2px;
            width:190px;
            padding:2px;
        }
        .muy_debil{
            background-color:gray;
            color:white;
        }
        .debil{
            background-color:red;
            color:red;
        }
        .media{
            background-color:orange;
            color:orange;
        }
        .fuerte{
            background-color:yellow;
            color:yellow;
        }
        .irrompible{
            background-color:green;
            color:green;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="328px" Width="703px">
        <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                Agregar Vendedor
            </HeaderTemplate>
            <ContentTemplate>
                <table class="auto-style16">
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Cedula" runat="server" Text="Cédula:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TB_Cedula" runat="server" max="999999999" min="9999" TextMode="Number"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Nombre" runat="server" Text="Nombre:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TB_Nombre" runat="server" MaxLength="15"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Clave" runat="server" Text="Clave:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TB_Clave" runat="server" MaxLength="15"></asp:TextBox>
                            <ajaxToolkit:PasswordStrength
                                StrengthIndicatorType="BarIndicator"
                                ID="TB_Clave_PasswordStrength" 
                                runat="server" 
                                BehaviorID="TB_Clave_PasswordStrength"
                                MinimumLowerCaseCharacters="2" 
                                MinimumNumericCharacters="2" 
                                MinimumSymbolCharacters="1" 
                                MinimumUpperCaseCharacters="1" 
                                BarBorderCssClass ="indicadornelinea"
                                PreferredPasswordLength="5" 
                                PrefixText="Seguridad: " 
                                TargetControlID="TB_Clave"
                                TextStrengthDescriptionStyles="muy_debil;debil;media;fuerte;irrompible"
                                />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Direccion" runat="server" Text="Dirección:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TB_Direccion" runat="server" MaxLength="15"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Telefono" runat="server" Text="Teléfono:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TB_Telefono" runat="server" MaxLength="12" TextMode="Number"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Sexo" runat="server" Text="Sexo:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_Sexo" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Correo" runat="server" Text="Correo:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TB_Correo" runat="server" MaxLength="30"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">&nbsp;</td>
                        <td>
                            <asp:Button ID="B_Agregar" runat="server" OnClick="B_Agregar_Click" Text="Agregar" />
                            <br />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Vendedores de la sede
            </HeaderTemplate>
            <ContentTemplate>
                <asp:GridView ID="GV_Usuarios" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="auto-style10" EmptyDataText="No hay productos ingresados." OnRowCommand="GV_Usuarios_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Editar" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Seleccionar" CommandArgument='<%# Bind("cedula") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Eliminar" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Eliminar" Text="Eiminar" CommandArgument='<%# Bind("cedula") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cedula">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cedula") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("cedula") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("nombre") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Clave">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("clave") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("clave") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Direccion">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("direccion") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("direccion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Telefono">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("telefono") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("telefono") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sexo">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("sexo") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("sexo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Correo">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("correo") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("correo") %>'></asp:Label>
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
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            <HeaderTemplate>
                Editar Vendedor
            </HeaderTemplate>
            <ContentTemplate>
                <table class="auto-style16">
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Cedula0" runat="server" Text="Cédula:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TB_Cedula0" runat="server" max="999999999" min="9999" TextMode="Number" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Nombre0" runat="server" Text="Nombre:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TB_Nombre0" runat="server" MaxLength="15"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Clave0" runat="server" Text="Clave:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TB_Clave0" runat="server" MaxLength="15"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Direccion0" runat="server" Text="Dirección:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TB_Direccion0" runat="server" MaxLength="15"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Telefono0" runat="server" Text="Teléfono:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TB_Telefono0" runat="server" MaxLength="12" TextMode="Number"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Sexo0" runat="server" Text="Sexo:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DDL_Sexo0" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="L_Correo0" runat="server" Text="Correo:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TB_Correo0" runat="server" MaxLength="30"></asp:TextBox>
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