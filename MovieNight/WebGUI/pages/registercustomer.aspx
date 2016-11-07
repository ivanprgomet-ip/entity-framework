<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registercustomer.aspx.cs" Inherits="WebGUI.pages.registercustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="registerform">
            <asp:Label ID="lbl_customername" runat="server" AssociatedControlID="txt_customername">Name: 
                <asp:TextBox ID="txt_customername" runat="server"></asp:TextBox>
            </asp:Label>

            <asp:Label ID="lbl_customeradress" runat="server" AssociatedControlID="txt_customeradress">Adress: 
                <asp:TextBox ID="txt_customeradress" runat="server"></asp:TextBox>
            </asp:Label>

            <asp:Label ID="lbl_customerphone" runat="server" AssociatedControlID="txt_customerphone">Phone: 
                <asp:TextBox ID="txt_customerphone" runat="server"></asp:TextBox>
            </asp:Label>

            <asp:Button ID="submit" Text="Register Customer" runat="server" OnClick="submit_Click" />
            <asp:Label ID="lbl_customerregistrationMSG" runat="server"></asp:Label>
            <br />
            <br />
            <a href="../index.html">Return to main menu</a>
        </div>
    </form>
</body>
</html>
