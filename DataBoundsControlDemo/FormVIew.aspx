<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormVIew.aspx.cs" Inherits="DataBoundsControlDemo.FormVIew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:FormView ID="FormView1" runat="server"  DefaultMode="ReadOnly" AllowPaging="true" OnPageIndexChanging="FormView1_PageIndexChanging">
                <ItemTemplate>
        <table style="border:1px solid #ccc; padding:10px; width:300px; background-color:#f9f9f9;">
            <tr>
                <td style="font-weight:bold;">Roll No:</td>
                <td><%# Eval("RollNo") %></td>
            </tr>
            <tr>
                <td style="font-weight:bold;">Name:</td>
                <td><%# Eval("Name") %></td>
            </tr>
            <tr>
                <td style="font-weight:bold;">Course:</td>
                <td><%# Eval("Course") %></td>
            </tr>
        </table>
    </ItemTemplate>
            </asp:FormView>

        </div>
    </form>
</body>
</html>
