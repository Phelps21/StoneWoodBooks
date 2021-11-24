<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StoneWoodBooks.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
    <script>
        let d = new Date();
        console.log(d);
    </script>
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
        <asp:Button ID="btnCreateAccount" runat="server" CssClass="btn active" Text="Create new account" OnClick="btnCreateAccount_Click"></asp:Button>
        <br />
        <br />
        <asp:Button ID="btnAdminLogin" runat="server" CssClass="btn active" Text="Admin" OnClick="btnAdminLogin_Click"></asp:Button>
    </div>
</asp:Content>
