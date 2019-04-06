<%@ Page Title="" Language="C#" MasterPageFile="~/View/Tienda/MasterSuperAdmin.master" AutoEventWireup="true" CodeFile="~/Controller/Tienda/CRUDAdmin.aspx.cs" Inherits="View_Tienda_CRUDAdmi" %><%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

    .auto-style16 {
        height: 25px;
    }
        .auto-style17 {
            width: 101%;
            height: 189px;
        }
        .auto-style18 {
            width: 183px;
        }
        .auto-style19 {
            height: 25px;
            width: 183px;
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" Height="350px" Width="753px">
        <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                Agregar Admin
            </HeaderTemplate>
            <ContentTemplate>
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style11">
                            <asp:Label ID="L_Cedula" runat="server" Text="Cédula:"></asp:Label>
                        </td>
                        <td class="auto-style13">
                            <asp:TextBox ID="TB_Cedula" runat="server" max="999999999" MaxLength="9" min="9999" OnTextChanged="TB_Cedula_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">
                            <asp:Label ID="L_Nombre" runat="server" Text="Nombre:"></asp:Label>
                        </td>
                        <td class="auto-style13">
                            <asp:TextBox ID="TB_Nombre" runat="server" MaxLength="15"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">
                            <asp:Label ID="L_Clave" runat="server" Text="Clave:"></asp:Label>
                        </td>
                        <td class="auto-style13">
                            <asp:TextBox ID="TB_Clave" runat="server" MaxLength="15"></asp:TextBox>
                            <ajaxToolkit:PasswordStrength ID="TB_Clave_PasswordStrength" runat="server" BarBorderCssClass="indicadorenlinea" BehaviorID="TB_Clave_PasswordStrength" MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2" MinimumSymbolCharacters="1" MinimumUpperCaseCharacters="1" PreferredPasswordLength="5" PrefixText="Seguridad: " StrengthIndicatorType="BarIndicator" TargetControlID="TB_Clave" TextStrengthDescriptionStyles="muy_debil;debil;media;fuerte;irrompible" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">
                            <asp:Label ID="L_Direccion" runat="server" Text="Dirección:"></asp:Label>
                        </td>
                        <td class="auto-style13">
                            <asp:TextBox ID="TB_Direccion" runat="server" MaxLength="15"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">
                            <asp:Label ID="L_Telefono" runat="server" Text="Teléfono:"></asp:Label>
                        </td>
                        <td class="auto-style13">
                            <asp:TextBox ID="TB_Telefono" runat="server" MaxLength="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">
                            <asp:Label ID="L_Sexo" runat="server" Text="Sexo:"></asp:Label>
                        </td>
                        <td class="auto-style13">
                            <asp:DropDownList ID="DDL_Sexo" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">
                            <asp:Label ID="L_Sede" runat="server" Text="Sede:"></asp:Label>
                        </td>
                        <td class="auto-style13">
                            <asp:DropDownList ID="DDL_Sedes" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">
                            <asp:Label ID="L_Correo" runat="server" Text="Correo:"></asp:Label>
                        </td>
                        <td class="auto-style13">
                            <asp:TextBox ID="TB_Correo" runat="server" MaxLength="30" TextMode="Email"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">&nbsp;</td>
                        <td class="auto-style13">
                            <asp:Button ID="B_Agregar" runat="server" OnClick="B_Agregar_Click" Text="Agregar" />
                            <asp:Button ID="B_Cancelar" runat="server" OnClick="B_Cancelar1_Click" Text="Cancelar" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Ver Admins
            </HeaderTemplate>
            <ContentTemplate>
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style11">&nbsp;</td>
                        <td class="auto-style13">
                            <asp:Label ID="L_GVAdmin" runat="server" Text="Tabla de Administradores de las sedes."></asp:Label>
                        </td>
                        <td class="auto-style12">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style11">&nbsp;</td>
                        <td class="auto-style13">
                            <asp:GridView ID="GV_Productos" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="auto-style10" EmptyDataText="No hay productos ingresados." OnPageIndexChanging="GV_Productos_PageIndexChanging" OnRowCommand="GV_Productos_RowCommand" OnRowDataBound="GV_Productos_RowDataBound" OnSelectedIndexChanged="GV_Productos_SelectedIndexChanged" PageSize="5">
                                <Columns>
                                    <asp:TemplateField HeaderText="Eliminar" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LB_Eliminar" runat="server" CausesValidation="False" CommandArgument='<%# Bind("cedula") %>' CommandName="Eliminar" Text="Eliminar"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Editar" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LB_Editar" runat="server" CausesValidation="False" CommandArgument='<%# Bind("cedula") %>' CommandName="Editar" Text="Editar"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cedula">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Cedula") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Cedula") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Clave">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Clave") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Clave") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sede">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Sede") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("Sede") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Correo">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Correo") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("Correo") %>'></asp:Label>
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
                            <br />
                        </td>
                        <td class="auto-style12">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            <HeaderTemplate>
                Ediitar Admin
            </HeaderTemplate>
            <ContentTemplate>
                <asp:Panel ID="PanelEditar" runat="server" Enabled="False" Height="215px" Width="452px">
                    <table class="auto-style17">
                        <tr>
                            <td>
                                <asp:Label ID="L_Cedula0" runat="server" Text="Cédula:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TB_Cedula0" runat="server" Enabled="False" max="999999999" min="9999" TextMode="Number"></asp:TextBox>
                            </td>
                            <td class="auto-style18">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="L_Nombre0" runat="server" Text="Nombre:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TB_Nombre0" runat="server" Enabled="False" MaxLength="15"></asp:TextBox>
                            </td>
                            <td class="auto-style18">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style16">
                                <asp:Label ID="L_Clave0" runat="server" Text="Clave:"></asp:Label>
                            </td>
                            <td class="auto-style16">
                                <asp:TextBox ID="TB_Clave0" runat="server" Enabled="False" MaxLength="15"></asp:TextBox>
                                <ajaxToolkit:PasswordStrength 
                                    ID="TB_Clave0_PasswordStrength" 
                                    runat="server" 
                                    BehaviorID="TB_Clave0_PasswordStrength" 
                                    TargetControlID="TB_Clave0" 
                                    MinimumLowerCaseCharacters="2"                                 
                                MinimumSymbolCharacters="1" 
                                MinimumUpperCaseCharacters="1" 
                                BarBorderCssClass ="indicadornelinea"
                                PreferredPasswordLength="5" 
                                PrefixText="Seguridad: "                                 
                                TextStrengthDescriptionStyles="muy_debil;debil;media;fuerte;irrompible"
                                    StrengthIndicatorType="BarIndicator"
                                    />
                            </td>
                            <td class="auto-style19"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="L_Direccion0" runat="server" Text="Dirección:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TB_Direccion0" runat="server" Enabled="False" MaxLength="15"></asp:TextBox>
                            </td>
                            <td class="auto-style18">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="L_Telefono0" runat="server" Text="Teléfono:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TB_Telefono0" runat="server" Enabled="False" MaxLength="15"></asp:TextBox>
                            </td>
                            <td class="auto-style18">
                                <asp:Button ID="B_Actualizar" runat="server" Enabled="False" OnClick="B_Actualizar_Click" Text="Actualizar" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="L_Sexo0" runat="server" Text="Sexo:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DDL_Sexo0" runat="server" Enabled="False">
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style18">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="L_Sede0" runat="server" Text="Sede:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DDL_Sedes0" runat="server" Enabled="False">
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style18">
                                <asp:Button ID="B_Cancelar0" runat="server" Enabled="False" OnClick="B_Cancelar_Click" Text="Cancelar" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="L_Correo0" runat="server" Text="Correo:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TB_Correo0" runat="server" Enabled="False" MaxLength="15"></asp:TextBox>
                            </td>
                            <td class="auto-style18">&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>