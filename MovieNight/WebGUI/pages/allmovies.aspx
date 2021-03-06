﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="allmovies.aspx.cs" Inherits="WebGUI.pages.allmovies" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>All Movies: </h2>
        <asp:DropDownList ID="dropdown_movielists" runat="server" AutoPostBack="True">
            <asp:ListItem Value="all">All</asp:ListItem>
            <asp:ListItem Value="available">Available</asp:ListItem>
            <asp:ListItem Value="unavailable">Unavailable</asp:ListItem>
        </asp:DropDownList>

        <article id="movieslisted" runat="server">

        </article>

        <br />
        <br />
        <a href="../index.html">return to main menu</a>
    </div>
    </form>
</body>
</html>
