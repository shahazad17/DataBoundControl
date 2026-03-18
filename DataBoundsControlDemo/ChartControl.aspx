<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChartControl.aspx.cs" Inherits="DataBoundsControlDemo.ChartControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Chart ID="Chart1" runat="server" Width="600px" Height="400px">
                <Series>
                    <asp:Series Name="BooksSeries" ChartType="Column"
                        XValueMember="Author" YValueMembers="BookID">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="MainArea"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>

            <asp:XmlDataSource ID="XmlDataSource1" runat="server"
                DataFile="~/App_Data/Books.xml"
                XPath="Books/Book"></asp:XmlDataSource>

        </div>
    </form>
</body>
</html>
