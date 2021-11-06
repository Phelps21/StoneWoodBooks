<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="StoneWoodBooks.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %> Us</h2>
    <h3 style="text-align:center;">We may not be superheroes - but we'll give you our origin story anyway.</h3>
    <div id="aboutBooks">
        <img src="Images/books_resized.jpg" alt="Books"/>
    </div>
    <br />
    <p>We founded Stonewood Books as a way to exploit the uber wealthy's need to feel exclusive and rich - think of us
        as a country club for books. Because we are a high-class members-only platform, our customers are willing
        to pay top dollar for the same books that can be found on any other non-exlusive platform for a third of
        the price. We want your money - if you don't have any, then Stonewood isn't for you.
    </p>
</asp:Content>
