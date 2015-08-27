<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="Track_Video_Watching.Statistics" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnShowMinPlat" runat="server" OnClick="btnShowMinPlat_Click" Text="Show minutes by video platform" />
        &nbsp;<br />
        <asp:Chart ID="graMinPlat" runat="server" Height="256px" Width="1201px">
            <series>
                <asp:Series ChartType="Pie" Name="Series1">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
    
    &nbsp;</div>
        <p>
            <asp:DropDownList ID="cboChannel" runat="server">
            </asp:DropDownList>
            <asp:Button ID="btnShowMinChan" runat="server" OnClick="btnShowMinChan_Click" Text="Show minutes by channel" Width="172px" />
        </p>
        <p>
            <asp:Chart ID="graMinCha" runat="server" Height="417px" Width="1165px">
                <Series>
                    <asp:Series ChartType="Pie" Name="Series1">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </p>
    </form>
</body>
</html>
