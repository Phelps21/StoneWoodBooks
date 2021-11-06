<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CustomersTable.aspx.cs" Inherits="StoneWoodBooks.CustomersTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Customers</h1>
    <br />
    <br />
    <h3>Customers Table</h3>
    <asp:Table ID="tblAuthorsAdmin" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>UserName</asp:TableHeaderCell>
            <asp:TableHeaderCell>LastName</asp:TableHeaderCell>
            <asp:TableHeaderCell>FirstName</asp:TableHeaderCell>
            <asp:TableHeaderCell>Password</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <br />
    <br />
    <h3>Customer Phone</h3>
    <asp:Table ID="TblCustomerPhoneAdmin" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>UserName</asp:TableHeaderCell>
            <asp:TableHeaderCell>Phone</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <br />
    <br />
    <h3>Customer Email</h3>
    <asp:Table ID="tblCustomerEmailAdmin" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>UserName</asp:TableHeaderCell>
            <asp:TableHeaderCell>Email</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <br />
    <br />
    <h3>Customer Address</h3>
    <asp:Table ID="tblCustomerAddressAdmin" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>UserName</asp:TableHeaderCell>
            <asp:TableHeaderCell>StreetNum</asp:TableHeaderCell>
            <asp:TableHeaderCell>StreetName</asp:TableHeaderCell>
            <asp:TableHeaderCell>City</asp:TableHeaderCell>
            <asp:TableHeaderCell>State</asp:TableHeaderCell>
            <asp:TableHeaderCell>Zip</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>
