<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hiremovie.aspx.cs" Inherits="WebGUI.pages.hiremovie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Hire a Movie: </h2>
            <article id="availablemoviesID" runat="server">
            </article>

            <asp:Label ID="lbl_movieID" runat="server">Choose Movie:
                <asp:DropDownList ID="dropdown_movieids" runat="server">
                    <%-- dynamically add data here --%>
                </asp:DropDownList>
            </asp:Label>

            <asp:Label ID="lbl_customerID" runat="server">Choose Customer:
                <asp:DropDownList ID="dropdown_customerids" runat="server">
                    <%-- dynamically add data here --%>
                </asp:DropDownList>
            </asp:Label>

            <asp:Button ID="btnsubmit" Text="Hire Movie" runat="server" OnClick="btnsubmit_Click" />
            <asp:Label ID="lbl_resultMSG" runat="server" />
            <br />
            <br />
            <a href="../index.html">return to main menu</a>
        </div>
    </form>
</body>
</html>
