<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="returnmovie.aspx.cs" Inherits="WebGUI.pages.returnmovie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Currently hired movies: </h2>
            <article id="hiredmoviesID" runat="server">
                <%-- dynamically add innerhtml here --%>
            </article>

            <asp:Label ID="lbl_rentedmoviesID" runat="server">Choose which rented movie to return:
                <asp:DropDownList ID="dropdown_rentedmovieids" runat="server">
                    <%-- dynamically add data here --%>
                </asp:DropDownList>
            </asp:Label>

            <asp:Button ID="btnsubmit" Text="Return Movie" runat="server" OnClick="btnsubmit_Click" />
            <asp:Label ID="lbl_resultMSG" runat="server" />
            <br />
            <br />
            <a href="../index.html">return to main menu</a>
        </div>
    </form>
</body>
</html>
