<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="StoneWoodBooks.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Administrator Dashboard</h1>
    <br />
    <div class="col-md-9">
        <asp:Button ID="btnViewCustomers" runat="server" CssClass="btn active btn-block" Text="Customers" OnClick="btnViewCustomers_Click" />
        <br />
        <br />
        <asp:Button ID="btnViewSuppliers" runat="server" CssClass="btn active btn-block" Text="Suppliers" OnClick="btnViewSuppliers_Click" />
        <br />
        <br />
        <asp:Button ID="btnViewAuthors" runat="server" CssClass="btn active btn-block" Text="Authors" OnClick="btnViewAuthors_Click" />
        <br />
        <br />
        <asp:Button ID="btnViewOrders" runat="server" CssClass="btn active btn-block" Text="Orders" OnClick="btnViewOrders_Click" />
        <br />
        <br />
        <asp:Button ID="btnViewBooks" runat="server" CssClass="btn active btn-block" Text="Books" OnClick="btnViewBooks_Click" />
    </div>

</asp:Content>
