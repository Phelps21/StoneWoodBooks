<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="StoneWoodBooks.MyAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col-md-1">

    <h1>My Account</h1>
        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" Enabled="False" required ="true"></asp:TextBox>
    <br />
        <asp:Label ID="lblPhone" runat="server" Text="Phone"></asp:Label>
        <asp:TextBox ID="txtPhone" runat="server" Enabled="False" required ="true"></asp:TextBox>
        <br />
        <asp:Label ID="lblStreet" runat="server" Text="Street Address"></asp:Label>
        <asp:TextBox ID="txtStreet" runat="server" Enabled="False"></asp:TextBox>
        <br />
        <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
        <asp:TextBox ID="txtCity" runat="server" Enabled="False"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Zip"></asp:Label>
        <asp:TextBox ID="txtZip" runat="server" Enabled="False"></asp:TextBox>
        <br />
        <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
        <asp:DropDownList ID="ddlState" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <br />

        <asp:Button ID="btnEditInfo" runat="server" Text="Edit Info" OnClick="Button1_Click" />
        <asp:Button ID="btnPW" runat="server" Text="Change Password" Width="133px" OnClick="btnPW_Click" />
        </div>
    

</asp:Content>
