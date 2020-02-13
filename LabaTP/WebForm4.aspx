<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="LabaTP.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 242px">
            <asp:Label ID="Label5" runat="server" Text="User name"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox3" runat="server" Height="22px" Width="142px"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="ValidateName" ControlToValidate="TextBox3" 
         ErrorMessage="Имя пустое" Display="Dynamic">*
                </asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Password" Width="146px" style="margin-left: 4px"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox4" runat="server" Width="140px"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="TextBox4" 
         ErrorMessage="Имя пустое" Display="Dynamic">*
                </asp:RequiredFieldValidator>
                <br />
            <asp:Label ID="Label7" runat="server" Text="Repeat Password"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox5" runat="server" style="margin-left: 0px" Width="138px"></asp:TextBox>
            <asp:CompareValidator runat="server" ID="ValidateCompare" ControlToValidate="TextBox4" ControlToCompare="TextBox5" ErrorMessage="Имя не совпадает" Display="Dynamic">*
                </asp:CompareValidator>
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Registration" />
        </div>
    </form>
</body>
</html>
