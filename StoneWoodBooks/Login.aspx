<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StoneWoodBooks.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
    <div id="loginPage">
        <h1>Login</h1>
        <asp:Label ID="ulabel" AssociatedControlID="txtUser" runat="server" Text="Username" />
        <asp:textbox ID="txtUser" runat="server" CssClass="textInput"></asp:TextBox>
        <br />
        <asp:Label ID="plabel" AssociatedControlID="txtPassword" runat="server" Text="Password" />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSubmitLogin" runat="server" CssClass="btn active" Text="Submit" OnClick="btnSubmitLogin_Click"></asp:Button>

    </div>
</asp:Content>
