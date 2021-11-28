<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="StoneWoodBooks.Books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Browse Books</h2>
    <br />
    <br />
    <asp:Label ID="lblKeywordSearch" runat="server" CssClass="input" Text="Keyword Search:"></asp:Label>
    <asp:Textbox ID="txtBookSearch" runat="server" CssClass="textInput"></asp:Textbox>
    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnSearch_Click" />
    <asp:Table ID="tblBooks" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>Title</asp:TableHeaderCell>
            <asp:TableHeaderCell>Author Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Price</asp:TableHeaderCell>
            <asp:TableHeaderCell>Genre</asp:TableHeaderCell>
            <asp:TableHeaderCell>ISBN</asp:TableHeaderCell>
            <asp:TableHeaderCell>Publication Date</asp:TableHeaderCell>
            <asp:TableHeaderCell>AddToCart?</asp:TableHeaderCell>
            <asp:TableCell></asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table>

</asp:Content>
