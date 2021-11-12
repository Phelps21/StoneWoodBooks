<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="MyCart.aspx.cs" Inherits="StoneWoodBooks.WebForm1" %>
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
        </asp:TableHeaderRow>
    </asp:Table>

    

    <asp:Button ID="btnConfirm" runat="server" Height="56px" OnClick="ConfirmOrder" Text="Confirm Order" Width="139px" />

    

</asp:Content>
