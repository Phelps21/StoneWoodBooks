<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AuthorsTable.aspx.cs" Inherits="StoneWoodBooks.AuthorsTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Authors</h1>
    <br />
    <br />
    <h3>Authors Table</h3>
    <asp:Table ID="tblAuthorsAdmin" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>AuthorID</asp:TableHeaderCell>
            <asp:TableHeaderCell>LastName</asp:TableHeaderCell>
            <asp:TableHeaderCell>FirstName</asp:TableHeaderCell>
            <asp:TableHeaderCell>Gender</asp:TableHeaderCell>
            <asp:TableHeaderCell>DOB</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <br />
    <br />
    <h3>Books Authored Table</h3>
    <asp:Table ID="tblBooksAuthoredAdmin" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>ISBN</asp:TableHeaderCell>
            <asp:TableHeaderCell>AuthorID</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>
