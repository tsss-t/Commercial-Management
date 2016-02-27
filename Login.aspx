<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" " http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns=" http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <style type="text/css">
         #style
         {
              margin:140px 0px 50px 200px;
             width :848px;
             height:260px;
               background-image:url(images/bg.jpg);
             }
        #style1
         {                      
          margin:0px 20px 50px 382px;           
         }
     </style>
</head>
<body bgcolor="#1A356A">
    <form id="form1" runat="server">
    <div id="style">
    <div id="style1">
<asp:Login ID="Login1"  runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE" 
        BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
        Font-Size="15px" ForeColor="#333333" Height="250px" Width="456px">
      
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
     
        <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" 
            BorderWidth="0px" Font-Names="Verdana" Font-Size="15px" ForeColor="#284E98" />

        <TextBoxStyle Font-Size="0.8em" />
        <TitleTextStyle  BackColor="#507CD1" Font-Bold="True" Font-Size="20px" 
            ForeColor="White" />
    </asp:Login>
     </div>
     </div>
    </form>
</body>
</html>