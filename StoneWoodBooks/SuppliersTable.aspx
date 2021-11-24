<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SuppliersTable.aspx.cs" Inherits="StoneWoodBooks.SuppliersTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Suppliers</h1>
    <br />
    <br />
    <h3>Supplier Table</h3>
    <asp:Table ID="tblSupplier" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>SupplierID</asp:TableHeaderCell>
            <asp:TableHeaderCell>Name</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <span class="query-text">
        <asp:TextBox ID="txtSupplier" runat="server"></asp:TextBox>
    </span>
    <asp:Button ID="btnQuerySupplier" runat="server" CssClass="btn btn-primary" text="Run Query" OnClick="btnQuerySupplier_Click"/>
    <br />
    <br />
    <h3>Supplier Rep Table</h3>
    <asp:Table ID="tblSupplierRep" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>RepID</asp:TableHeaderCell>
            <asp:TableHeaderCell>Lname</asp:TableHeaderCell>
            <asp:TableHeaderCell>Fname</asp:TableHeaderCell>
            <asp:TableHeaderCell>CellNum</asp:TableHeaderCell>
            <asp:TableHeaderCell>WorkNum</asp:TableHeaderCell>
            <asp:TableHeaderCell>Email</asp:TableHeaderCell>
            <asp:TableHeaderCell>SupplierID</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <span class="query-text">
        <asp:TextBox ID="txtSupplierRep" runat="server"></asp:TextBox>
    </span>
    <asp:Button ID="btnQuerySupplierRep" runat="server" CssClass="btn btn-primary" text="Run Query" OnClick="btnQuerySupplierRep_Click"/>
    <br />
    <br />
    <h3>SuppliedBy Table</h3>
    <asp:Table ID="tblSuppliedBy" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>ISBN</asp:TableHeaderCell>
            <asp:TableHeaderCell>SupplierID</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <span class="query-text">
        <asp:TextBox ID="txtSuppliedBy" runat="server"></asp:TextBox>
    </span>
    <asp:Button ID="btnQuerySuppliedBy" runat="server" CssClass="btn btn-primary" text="Run Query" OnClick="btnQuerySuppliedBy_Click"/>
</asp:Content>
