<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AuthorsTable.aspx.cs" Inherits="StoneWoodBooks.AuthorsTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Authors</h1>
    <br />
    <br />
    <h3>Authors Table</h3>
    <asp:Table ID="tblAuthor" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>AID</asp:TableHeaderCell>
            <asp:TableHeaderCell>Fname</asp:TableHeaderCell>
            <asp:TableHeaderCell>Lname</asp:TableHeaderCell>
            <asp:TableHeaderCell>Gender</asp:TableHeaderCell>
            <asp:TableHeaderCell>DOB</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>

    <span class="query-text">
        <asp:TextBox ID="txtAuthors" runat="server"></asp:TextBox>
    </span>
    <asp:Button ID="btnQueryAuthor" runat="server" CssClass="btn btn-primary" text="Run Query" OnClick="btnQueryAuthor_Click"/>
    <br />
    <br />
    <h3>Books Authored Table</h3>
    <asp:Table ID="tblBooks_Authored" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>ISBN</asp:TableHeaderCell>
            <asp:TableHeaderCell>AuthorID</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <span class="query-text">
        <asp:TextBox ID="txtBooks_Authored" runat="server"></asp:TextBox>
    </span>
    <asp:Button ID="btnQueryBooksAuthored" runat="server" CssClass="btn btn-primary" text="Run Query" OnClick="btnQueryBooksAuthored_Click"/>
</asp:Content>
