<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="OrdersTable.aspx.cs" Inherits="StoneWoodBooks.OrdersTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Orders</h3>
    <br />
    <br />
    <h3>Orders Table</h3>
    <asp:Table ID="tblOrders" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>OrderID</asp:TableHeaderCell>
            <asp:TableHeaderCell>OrderDate</asp:TableHeaderCell>
            <asp:TableHeaderCell>OrderValue</asp:TableHeaderCell>
            <asp:TableHeaderCell>Username</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <br />
    <br />
    <span class="query-text">
        <asp:TextBox ID="txtOrders" runat="server"></asp:TextBox>
    </span>
    <asp:Button ID="btnQueryOrders" runat="server" CssClass="btn btn-primary" text="Run Query" OnClick="btnQueryOrders_Click"/>
</asp:Content>
