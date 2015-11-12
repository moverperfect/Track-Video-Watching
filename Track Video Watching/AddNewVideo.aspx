<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewVideo.aspx.cs" Inherits="Track_Video_Watching.AddNewVideo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add a new video</title>    
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script>
        $(function() {
            var channels = $.ajax({
                url: "/ajaxHelper.aspx",
                dataType: "jsonp",
                data: {
                    'action': "channelsearch",
                    'format': "json"
                },
                async: false,
                success: function(data) {
                    response(data);
                }
            }).responseText;

            channels = $.parseJSON(channels.split("<!DOCTYPE html>")[0]);
            $("#txtChannel").autocomplete({
                source: channels
            });
        })
    </script>
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
            <asp:ListItem>TED</asp:ListItem>
            <asp:ListItem>Other</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPlatform" runat="server" Visible="False"></asp:TextBox>
        <br />
        <br />
        Channel<br />
        <input id="txtChannel" runat="server" class="form-control"/>
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
        <asp:Button ID="btnReturn" runat="server" Text="Return to Dashboard" OnClick="btnReturn_Click" />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
