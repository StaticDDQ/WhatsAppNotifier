<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ButtonController.aspx.cs" Inherits="WhatsAppNotify.ButtonController" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="stylesheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 370px">

            <asp:Panel ID="Panel1" runat="server" style="overflow-y:scroll;" CssClass="phoneRange">

            </asp:Panel>
            <br />
            <asp:Button ID="addPhone" runat="server" OnClick="addPhone_Click" Text="+" CssClass="plusButton"/>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="removePhone" runat="server" Text="-" OnClick="removePhone_Click" CssClass="minusButton"/>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="sendBtn" runat="server" OnClick="sendBtn_Click" Text="Send" CssClass="sendButton"/>
        </div>
    </form>
</body>
</html>
