<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reviews.aspx.cs" Inherits="StoneWoodBooks.Reviews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Reviews</h3>
    <br />
    <br />
    <asp:Table ID="tblReviews" runat="server" CssClass="table table-stripe">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>ISBN</asp:TableHeaderCell>
            <asp:TableHeaderCell>Username</asp:TableHeaderCell>
            <asp:TableHeaderCell>Description</asp:TableHeaderCell>
            <asp:TableHeaderCell>Number of Stars</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <br />
    <br />
    <h3>Review This Book</h3>
    <br />
    <br />
    <div class ="col-md-3">
        <asp:Label ID="lblDescription" runat="server" Text="Description(Up to 140 Characters):"></asp:Label>
    </div>
    <div class="col-md-9">
        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" Enabled="True"></asp:TextBox>
    </div>
    <br />
    <br />
    <div class="col-md-3">
        <asp:Label ID="lblNumStars" runat="server" Text="Number of Stars(Required):"></asp:Label>
    </div>
    <asp:DropDownList ID="ddlStars" runat="server">
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button CssClass="btn" ID="btnSubmit" runat="server" Text="Submit Review" OnClick="btnSubmit_Click" />
</asp:Content>
