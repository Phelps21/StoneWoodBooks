<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="OrdersTable.aspx.cs" Inherits="StoneWoodBooks.OrdersTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Orders</h3>
    <br />
    <br />
    <h3>Orders Table</h3>
    <asp:Table ID="tblOrdersAdmin" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>OrderID</asp:TableHeaderCell>
            <asp:TableHeaderCell>OderDate</asp:TableHeaderCell>
            <asp:TableHeaderCell>OrderValue</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>
