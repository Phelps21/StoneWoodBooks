<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CustomersTable.aspx.cs" Inherits="StoneWoodBooks.CustomersTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Customers</h1>
    <br />
    <br />
    <h3>Customer Table</h3>
    <asp:Table ID="tblCustomer" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>Username</asp:TableHeaderCell>
            <asp:TableHeaderCell>Password</asp:TableHeaderCell>
            <asp:TableHeaderCell>Fname</asp:TableHeaderCell>
            <asp:TableHeaderCell>Lname</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <span class="query-text">
        <asp:TextBox ID="txtCustomer" runat="server"></asp:TextBox>
    </span>
    <asp:Button ID="btnQueryCustomer" runat="server" CssClass="btn btn-primary" text="Run Query" OnClick="btnQueryCustomer_Click"/>
    <br />
    <br />
    <h3>Customer Phone Table</h3>
    <asp:Table ID="tblCustomerPhone" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>Username</asp:TableHeaderCell>
            <asp:TableHeaderCell>Phone</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <span class="query-text">
        <asp:TextBox ID="txtCustomerPhone" runat="server"></asp:TextBox>
    </span>
    <asp:Button ID="btnQueryCustomerPhone" runat="server" CssClass="btn btn-primary" text="Run Query" OnClick="btnQueryCustomerPhone_Click"/>
    <br />
    <br />
    <h3>Customer Email Table</h3>
    <asp:Table ID="tblCustomerEmail" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>Username</asp:TableHeaderCell>
            <asp:TableHeaderCell>Email</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <span class="query-text">
        <asp:TextBox ID="txtCustomerEmail" runat="server"></asp:TextBox>
    </span>
    <asp:Button ID="btnCustomerEmailQuery" runat="server" CssClass="btn btn-primary" text="Run Query" OnClick="btnQueryCustomerEmail_Click"/>
    <br />
    <br />
    <h3>Customer Address Table</h3>
    <asp:Table ID="tblCustomerAddress" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>Username</asp:TableHeaderCell>
            <asp:TableHeaderCell>StreetNum</asp:TableHeaderCell>
            <asp:TableHeaderCell>StreetName</asp:TableHeaderCell>
            <asp:TableHeaderCell>City</asp:TableHeaderCell>
            <asp:TableHeaderCell>State</asp:TableHeaderCell>
            <asp:TableHeaderCell>Zip</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <span class="query-text">
        <asp:TextBox ID="txtCustomerAddress" runat="server"></asp:TextBox>
    </span>
    <asp:Button ID="btnCustomerAddressQuery" runat="server" CssClass="btn btn-primary" text="Run Query" OnClick="btnQueryCustomerAddress_Click"/>
</asp:Content>
