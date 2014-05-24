<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PasswordChange.aspx.cs" Inherits="Admin_PasswordChange" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2
        {
            width: 369px;
        }
        .auto-style5
        {
            width: 369px;
            height: 26px;
        }
        .auto-style6
        {
            width: 1320px;
            height: 26px;
        }
        .auto-style7
        {
            width: 1320px;
        }
    </style>
</head>
<body style="height: 197px">
    <form id="form1" runat="server">
   
        <asp:Panel ID="Panel1" runat="server" Height="127px" Width="413px">

             <div>
    
        <table style="width:99%; height: 123px;">
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtoldpass" runat="server" style="margin-left: 0px" TextMode="Password" Width="233px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtnewpass1" runat="server" TextMode="Password" Width="234px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtnewpass3" runat="server" TextMode="Password" Width="234px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Button ID="btnChangepass" runat="server" Height="29px" OnClick="btnChangepass_Click" Text="Button" Width="89px" />
                </td>
            </tr>
        </table>
    
    </div>

        </asp:Panel>
    </form>
</body>
</html>
