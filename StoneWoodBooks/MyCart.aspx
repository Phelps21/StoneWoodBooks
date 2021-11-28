<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyCart.aspx.cs" Inherits="StoneWoodBooks.MyCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>My Cart</h2>
    <br />

    <asp:Table ID="tblBooks" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>Title</asp:TableHeaderCell>
            <asp:TableHeaderCell>Author Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Price</asp:TableHeaderCell>
            <asp:TableHeaderCell>Genre</asp:TableHeaderCell>
            <asp:TableHeaderCell>ISBN</asp:TableHeaderCell>
            <asp:TableHeaderCell>Remove?</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>

    <asp:Button CssClass="btn" ID="btnConfirm" runat="server" Height="56px" Text="Confirm Order" Width="139px" OnClick="btnConfirm_Click"/>

    

</asp:Content>
