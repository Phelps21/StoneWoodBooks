<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SuppliersTable.aspx.cs" Inherits="StoneWoodBooks.SuppliersTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Suppliers</h1>
    <br />
    <br />
    <h3>Suppliers Table</h3>
    <asp:Table ID="tblSuppliersAdmin" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>SupplierID</asp:TableHeaderCell>
            <asp:TableHeaderCell>SupplierName</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <br />
    <br />
    <h3>Supplier Reps Table</h3>
    <asp:Table ID="tblSupplierRepsAdmin" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>RepID</asp:TableHeaderCell>
            <asp:TableHeaderCell>Lastname</asp:TableHeaderCell>
            <asp:TableHeaderCell>FirstName</asp:TableHeaderCell>
            <asp:TableHeaderCell>CellNum</asp:TableHeaderCell>
            <asp:TableHeaderCell>WorkNum</asp:TableHeaderCell>
            <asp:TableHeaderCell>Lastname</asp:TableHeaderCell>
            <asp:TableHeaderCell>Email</asp:TableHeaderCell>
            <asp:TableHeaderCell>SupplierID</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>
