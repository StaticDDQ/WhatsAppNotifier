<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="Messaging.aspx.cs" Inherits="MessagingTest.Messaging" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <link href="stylesheet.css" rel="stylesheet" type="text/css" />
    <form id="form1" runat="server">
        <div style="height: 614px">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:RadioButton ID="text" GroupName="MessageType" runat="server" Checked="true" OnCheckedChanged="text_CheckedChanged" AutoPostBack="true"/> Text
                    <asp:RadioButton ID="file" GroupName="MessageType" runat="server" OnCheckedChanged="file_CheckedChanged" AutoPostBack="true"/> File
                    
                    <asp:Panel ID="phonePanel" runat="server" CssClass="phoneRange">
                        <br />
                    </asp:Panel>
                    
                    <asp:Button ID="addPhone" runat="server" OnClick="addPhone_Click" Text="+" CssClass="plusButton"/>
                    <asp:Button ID="removePhone" runat="server" Text="-" OnClick="removePhone_Click" CssClass="minusButton"/>
                
                    <div id="wrapper" style="position: absolute; left: 50%; top: 400px; transform:translate(-50%)">
                        <cc1:AsyncFileUpload runat="server" ID="uploadSpace" Width="400px" UploaderStyle="Modern" OnUploadedComplete="FileUploadComplete" style="display:none"/>
                    </div>

                    <asp:TextBox ID="messageBox" runat="server" CssClass="messageSent" TextMode="MultiLine" />                    
                    <br />
                    
                    <asp:Button ID="sendBtn" runat="server" OnClick="sendBtn_Click" Text="Send" CssClass="sendButton"/>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="sendBtn" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
