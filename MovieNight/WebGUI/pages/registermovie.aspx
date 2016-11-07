<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registermovie.aspx.cs" Inherits="WebGUI.pages.registermovie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="registerform">

            <asp:Label ID="lbl_movietitleID" AssociatedControlID="txt_movietitleID" runat="server">MovieTitle: 
                <asp:TextBox ID="txt_movietitleID" runat="server"></asp:TextBox>
            </asp:Label>

            <asp:Label ID="lbl_moviedirectorID" AssociatedControlID="txt_moviedirectorID" runat="server">MovieDirector: 
                <asp:TextBox ID="txt_moviedirectorID" runat="server"></asp:TextBox>
            </asp:Label>

            <asp:Label ID="lbl_dropdowngenre" runat="server">Genre: 
                <asp:DropDownList ID="dropdown_moviegenre" runat="server">
                    <asp:ListItem Value="Action">Action</asp:ListItem>
                    <asp:ListItem Value="Romantic">Romantic</asp:ListItem>
                    <asp:ListItem Value="Thriller">Thriller</asp:ListItem>
                    <asp:ListItem Value="Drama">Drama</asp:ListItem>
                    <asp:ListItem Value="Horror">Horror</asp:ListItem>
                    <asp:ListItem Value="Comedy">Comedy</asp:ListItem>
                </asp:DropDownList>
            </asp:Label>

            <asp:Button ID="submit" Text="Register Movie" runat="server" OnClick="submit_Click" />
            <asp:Label ID="lbl_movieregistrationMSG" runat="server"></asp:Label>
            <br />
            <br />
            <a href="../index.html">Return to main menu</a>
        </div>
    </form>
</body>
</html>
