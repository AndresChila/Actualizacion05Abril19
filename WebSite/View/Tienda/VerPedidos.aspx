<%@ Page Title="" Language="C#" MasterPageFile="~/View/Tienda/MasterAdmin.master" AutoEventWireup="true" CodeFile="~/Controller/Tienda/VerPedidos.aspx.cs" Inherits="View_Tienda_VerPedidos" %>



<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <CR:CrystalReportSource ID="CRS_Pedidos" runat="server">
        <Report FileName="\View\Tienda\Reportes\CR_Pedidos.rpt">
        </Report>
    </CR:CrystalReportSource>
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Volver" />
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ReportSourceID="CRS_Pedidos" />
</asp:Content>

