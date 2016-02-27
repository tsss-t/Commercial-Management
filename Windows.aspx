<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Windows.aspx.cs" Inherits="Windows" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Windows.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.6.2.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.8.14.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/Windows.js" type="text/javascript"></script>
</head>
<body id="win">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>

    <div style="height: 100%; width: 100%">
        <%--桌面图标--%>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="Icons" runat="server">
                    <div class="Icon">
                        <asp:ImageButton ID="IM_Stock" runat="server" ImageUrl="images/1apps.png" Width="32px"
                            Height="32px" onclick="IM_Click" AccessKey="1" /><br />
                        商品进货
                    </div>
                    <div class="Icon">
                        <asp:ImageButton ID="IM_Store" runat="server" ImageUrl="images/1public.png" Width="32px"
                            Height="32px" onclick="IM_Click" AccessKey="2"  /><br />
                        商品入库
                    </div>
                    <div class="Icon">
                        <asp:ImageButton ID="IM_Sell" runat="server" ImageUrl="images/1utilities.png" Width="32px"
                            Height="32px" onclick="IM_Click" AccessKey="3"  /><br />
                        商品销售
                    </div>
                    <div class="Icon">
                        <asp:ImageButton ID="IM_User" runat="server" ImageUrl="images/1group.png" Width="32px"
                            Height="32px" onclick="IM_Click" AccessKey="4" /><br />
                        用户管理
                    </div>
                    <div class="Icon">
                        <asp:ImageButton ID="IM_Equipment" runat="server" ImageUrl="images/1music.png" Width="32px"
                            Height="32px" onclick="IM_Click" AccessKey="5" /><br />
                        固定资产
                    </div>
                    <div class="Icon">
                        <asp:ImageButton ID="IM_Money" runat="server" ImageUrl="images/Fresh-addon_02.png"
                            Width="32px" Height="32px" onclick="IM_Click" AccessKey="6" /><br />
                        财务管理
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%--工具栏--%>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
        <div id="MenuBar" runat="server">
            <div id="StartIcon" title="开始按钮">
                <center>
                    <div id="Start">
                    </div>
                </center>
            </div>
            <div id="desktop">
                <div class="Icon">
                    <asp:Image ID="BT_IE" runat="server" ImageUrl="images/ie.png" Width="37px" Height="37px" />
                </div>
            </div>

        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
        <%--开始菜单--%>
<%--        <ajax:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" TargetControlID="StartMenu">
        </ajax:RoundedCornersExtender>--%>
        <div id="StartMenu" class="roundedPanel" runat="server">
            <div id="StartMenu_left">
                <div class="Icons">
                    <div class="Icon">
                        <asp:Image ID="Mu_IM_Stock" runat="server" ImageUrl="images/1apps.png" Width="32px"
                            Height="32px" AccessKey="1" /></div>
                    <div class="Name">
                        商品进货</div>
                </div>
                <div class="Icons">
                    <div class="Icon">
                        <asp:Image ID="Mu_IM_Store" runat="server" ImageUrl="images/1public.png" Width="32px"
                            Height="32px" AccessKey="2" /></div>
                    <div class="Name">
                        商品入库</div>
                </div>
                <div class="Icons">
                    <div class="Icon">
                        <asp:Image ID="Mu_IM_Sell" runat="server" ImageUrl="images/1utilities.png" Width="32px"
                            Height="32px" AccessKey="3"  /></div>
                    <div class="Name">
                        商品销售</div>
                </div>
                <div class="Icons">
                    <div class="Icon">
                        <asp:Image ID="Mu_IM_User" runat="server" ImageUrl="images/1group.png" Width="32px"
                            Height="32px" AccessKey="4" /></div>
                    <div class="Name">
                        用户管理</div>
                </div>
                <div class="Icons">
                    <div class="Icon">
                        <asp:Image ID="Mu_IM_Equipment" runat="server" ImageUrl="images/1music.png" Width="32px"
                            Height="32px" AccessKey="5" /></div>
                    <div class="Name">
                        固定资产</div>
                </div>
                <div class="Icons">
                    <div class="Icon">
                        <asp:Image ID="Mu_Money" runat="server" ImageUrl="images/Fresh-addon_02.png" Width="32px"
                            Height="32px"  AccessKey="6" /></div>
                    <div class="Name">
                        财务管理</div>
                </div>
            </div>
            <div id="StartMenu_right">
                <div id="HeadFrame">
                    <asp:Image ID="Head" runat="server" ImageUrl="images/head.jpg" Width="47px" Height="47px" />
                </div>
                <div id="UserInfo">
                </div>
                <div id="Close">
                    <asp:Button ID="BT_Close" runat="server" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
