<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="StoneWoodBooks.Books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Browse Books</h2>
    <br />
    <asp:Table ID="tblBooks" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>Title</asp:TableHeaderCell>
            <asp:TableHeaderCell>LastName</asp:TableHeaderCell>
            <asp:TableHeaderCell>Price</asp:TableHeaderCell>
            <asp:TableHeaderCell>GenreName</asp:TableHeaderCell>
            <asp:TableHeaderCell>ISBN</asp:TableHeaderCell>
            <asp:TableHeaderCell>AddToCart?</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <!--Add text box for queries-->
        <asp:Textbox ID="txtBookSearch" runat="server" CssClass="textInput"></asp:Textbox>
    </asp:Table>
</asp:Content>
