<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="BooksTable.aspx.cs" Inherits="StoneWoodBooks.BooksTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Books</h1>
    <br />
    <br />
    <h3>Books Table</h3>
    <asp:Table ID="tblBooks" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>ISBN</asp:TableHeaderCell>
            <asp:TableHeaderCell>Title</asp:TableHeaderCell>
            <asp:TableHeaderCell>Price</asp:TableHeaderCell>
            <asp:TableHeaderCell>PublicationDate</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <span class="query-text">
        <asp:TextBox ID="txtBooks" runat="server"></asp:TextBox>
    </span>
    <asp:Button ID="btnQueryBooks" runat="server" CssClass="btn btn-primary" text="Run Query" OnClick="btnQueryBooks_Click"/>
    <br />
    <br />
    <h3>Books_Authored Table</h3>
    <asp:Table ID="tblBooks_Authored" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>ISBN</asp:TableHeaderCell>
            <asp:TableHeaderCell>AuthorID</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <span class="query-text">
        <asp:TextBox ID="txtBooks_Authored" runat="server"></asp:TextBox>
    </span>
    <asp:Button ID="btnQueryBooks_Authored" runat="server" CssClass="btn btn-primary" text="Run Query" OnClick="btnQueryBooks_Authored_Click"/>
    <br />
    <br />
    <h3>BookCategories Table</h3>
    <asp:Table ID="tblBookCategories" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>CategoryID</asp:TableHeaderCell>
            <asp:TableHeaderCell>CategoryDescription</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <span class="query-text">
        <asp:TextBox ID="txtBookCategories" runat="server"></asp:TextBox>
    </span>
    <asp:Button ID="btnQueryBookCategories" runat="server" CssClass="btn btn-primary" text="Run Query" OnClick="btnQueryBookCategories_Click"/>
    <h3>Book_And_Category Table</h3>
    <asp:Table ID="tblBook_And_Category" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>ISBN</asp:TableHeaderCell>
            <asp:TableHeaderCell>CategoryID</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <span class="query-text">
        <asp:TextBox ID="txtBook_And_Category" runat="server"></asp:TextBox>
    </span>
    <asp:Button ID="btnQueryBook_And_Category" runat="server" CssClass="btn btn-primary" text="Run Query" OnClick="btnQueryBook_And_Category_Click"/>
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
