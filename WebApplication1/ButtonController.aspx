<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="ButtonController.aspx.cs" Inherits="MessagingTest.ButtonController" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="stylesheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <script type="text/javascript" language="javascript">
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
                function EndRequestHandler(sender, args){
                    if (args.get_error() != undefined){
                        args.set_errorHandled(true);
                    }
                }
            </script>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                 
                    <asp:Panel ID="phonePanel" runat="server" CssClass="phoneRange">
                        <br />
                    </asp:Panel>
                    
                    <asp:Button ID="addPhone" runat="server" OnClick="addPhone_Click" Text="+" CssClass="plusButton"/>
                    <asp:Button ID="removePhone" runat="server" Text="-" OnClick="removePhone_Click" CssClass="minusButton"/>
                    <br />
                
                    <asp:TextBox ID="messageBox" runat="server" CssClass="messageSent" TextMode="MultiLine"/>
                    <asp:Button ID="sendBtn" runat="server" OnClick="sendBtn_Click" Text="Send" CssClass="sendButton"/>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
