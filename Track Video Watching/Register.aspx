<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Track_Video_Watching.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Username*<br />
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <br />
        <br />
        Email Address*<br />
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <br />
        Password(Beware this website is not secure)*<br />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        Confirm Password*<br />
        <asp:TextBox ID="txtCPassword" runat="server" TextMode="Password"></asp:TextBox>
    
        <br />
        <br />
        <asp:Button ID="cmdRegister" runat="server" OnClick="cmdRegister_Click" Text="Register" />
    
    </div>
    </form>
</body>
</html>
