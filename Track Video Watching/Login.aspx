<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Track_Video_Watching.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Username<br />
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <br />
        <br />
        Password<br />
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="cmdLogin" runat="server" Text="Login" OnClick="cmdLogin_Click" />
&nbsp;<asp:Button ID="cmdRegister" runat="server" Text="Register" OnClick="cmdRegister_Click" />
    
    </div>
    </form>
</body>
</html>
