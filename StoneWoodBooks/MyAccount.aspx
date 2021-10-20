<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="StoneWoodBooks.MyAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>My Account</h1>
    <div class="row">


        <div class ="col-md-3">
        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
        </div>
        <div class="col-md-9">
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Enabled="False" required ="true"></asp:TextBox>
        </div>
        <br />
        <br />
        <div class ="col-md-3">
        <asp:Label ID="lblAltEmail" runat="server" Text="Alternate Email"></asp:Label>
        </div>
        <div class="col-md-9">
        <asp:TextBox ID="txtAltEmail" runat="server" CssClass="form-control" Enabled="False" required ="false"></asp:TextBox>
        </div>
        <br />
        <br />
        <div class ="col-md-3">
        <asp:Label ID="lblPhone" runat="server" Text="Phone"></asp:Label>
        </div>
        <div class="col-md-9">
        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" Enabled="False" required ="true"></asp:TextBox>
        </div>
        <br />
        <br />
        <div class ="col-md-3">
        <asp:Label ID="lblStreet" runat="server" Text="Street Address"></asp:Label>
        </div>
        <div class="col-md-9">
        <asp:TextBox ID="txtStreet" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
        </div>
        <br />
        <br />
        <div class ="col-md-3">
        <asp:Label ID="lblZip" runat="server" Text="Zip"></asp:Label>
        </div>
        <div class="col-md-9">
        <asp:TextBox ID="txtZip" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
        </div>
        <br />
        <br />
        <div class ="col-md-3">
        <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
        </div>
        <div class="col-md-9">
        <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
        </div>
        <br />
        <br />
        <div class ="col-md-3">
        <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
        </div>
        <div class="col-md-9">
        <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control">
        </asp:DropDownList>
        </div>
       
        
        </div>
        <asp:Button CssClass="btn" ID="btnEditInfo" runat="server" Text="Edit Info" OnClick="Button1_Click" />
        <asp:Button CssClass="btn" ID="btnPW" runat="server" Text="Change Password" Width="133px" OnClick="btnPW_Click" />
    

</asp:Content>
