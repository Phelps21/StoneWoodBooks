<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdatePW.aspx.cs" Inherits="StoneWoodBooks.UpdatePW" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style ="height:370px; width:750px; border:solid; border-width:10px; vertical-align:auto;
        border-radius:10px; margin:auto; text-align:center; vertical-align:auto; margin-top:50px">
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="lblpw" runat="server" Text="Type in your current password" Height="30px"></asp:Label>
    <br />
        <asp:TextBox ID="txtPW" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="Submit" />
        <asp:Button ID="btnChangePW" runat="server" Text="Change Password" Enabled="False" OnClick="btnChangePW_Click" Visible="False" />
    </div>

</asp:Content>
