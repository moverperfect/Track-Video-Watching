<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewVideo.aspx.cs" Inherits="Track_Video_Watching.AddNewVideo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Video Platform<br />
        <asp:DropDownList ID="cboPlatform" runat="server" OnSelectedIndexChanged="cboPlatform_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem>YouTube</asp:ListItem>
            <asp:ListItem>Twitch</asp:ListItem>
            <asp:ListItem>BBC Iplayer</asp:ListItem>
            <asp:ListItem>C4 OD</asp:ListItem>
            <asp:ListItem>Netflix</asp:ListItem>
            <asp:ListItem>ITV Player</asp:ListItem>
            <asp:ListItem>Other</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPlatform" runat="server" Visible="False"></asp:TextBox>
        <br />
        <br />
        Channel<br />
        <asp:TextBox ID="txtChannel" runat="server"></asp:TextBox>
        <br />
        <br />
        Date uploaded/Watched<asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        <br />
        Length<br />
        <asp:TextBox ID="txtHour" runat="server" MaxLength="2" Width="16px"></asp:TextBox>
        :<asp:TextBox ID="txtMin" runat="server" Width="16px"></asp:TextBox>
        :<asp:TextBox ID="txtSec" runat="server" Width="16px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="Add Video" OnClick="btnAdd_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnReturn" runat="server" Text="Return to Dashboard" />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
