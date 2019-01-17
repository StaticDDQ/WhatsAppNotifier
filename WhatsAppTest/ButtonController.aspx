<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ButtonController.aspx.cs" Inherits="WhatsAppNotify.ButtonController" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="stylesheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .minusButton {}
        .plusButton {}
        #Text1 {
            height: 134px;
            width: 166px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 370px">

            <asp:Panel ID="Panel1" runat="server" CssClass="phoneRange">

            </asp:Panel>
            <br />
            <asp:TextBox ID="messageBox" runat="server" CssClass="messageSent" TextMode="MultiLine"/>
            <br />
            <asp:Button ID="addPhone" runat="server" OnClick="addPhone_Click" Text="+" CssClass="plusButton"/>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="removePhone" runat="server" Text="-" OnClick="removePhone_Click" CssClass="minusButton"/>

            <asp:Button ID="sendBtn" runat="server" OnClick="sendBtn_Click" Text="Send" CssClass="sendButton"/>

            <asp:Button ID="exit" runat="server" OnClick="ExitApp" Text="Exit" CssClass="exitButton" />
        </div>
    </form>
</body>
</html>
