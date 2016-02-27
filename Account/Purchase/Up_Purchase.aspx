<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Up_Purchase.aspx.cs" Inherits="Account_Purchase_Up_Purchase" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../Scripts/jquery-1.6.2.js" type="text/javascript"></script>
    <script src="../../Scripts/MainPage.js" type="text/javascript"></script>
    <link href="../../Styles/DTH_GetGoods.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:DropDownList ID="DDL_Mark" runat="server" Width="150px" AutoPostBack="true"
                OnSelectedIndexChanged="DDL_Mark_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:Label ID="LB_test" runat="server" />
            <asp:Repeater ID="Repeater_Stock" runat="server" 
                onitemdatabound="Repeater_Stock_ItemDataBound">
                <HeaderTemplate>
                    <table id="Print" border="1" width="100%" style="font-family: 微软雅黑">
                        <tr>
                            <td colspan="8" align="center" style="font-size: 22px;">
                                进货单
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            商品ID：
                        </td>
                        <td>
                            <%#DataBinder.Eval(Container.DataItem, "Pro_ID")%>
                        </td>
                        <td>
                            商品名：
                        </td>
                        <td>
                            <%#DataBinder.Eval(Container.DataItem,"Pro_Name") %>
                        </td>
                        <td>
                            购买数量：
                        </td>
                        <td>
                            <%#DataBinder.Eval(Container.DataItem, "Stock_Number")%>
                        </td>
                        <td>
                            批准文号：
                        </td>
                        <td>
                            <%#DataBinder.Eval(Container.DataItem, "Pro_Approval_Number")%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            生产厂商：
                        </td>
                        <td colspan="3">
                            <%#DataBinder.Eval(Container.DataItem, "Producer_Name")%>
                        </td>
                        <td>
                            商品产地：
                        </td>
                        <td colspan="3">
                            <%#DataBinder.Eval(Container.DataItem, "Producer_Place")%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            规格：
                        </td>
                        <td>
                            <%#DataBinder.Eval(Container.DataItem, "Pro_Specifications")%>
                        </td>
                        <td>
                            规格量度：
                        </td>
                        <td>
                            <%#DataBinder.Eval(Container.DataItem, "Pro_Number")%>
                        </td>
                        <td>
                            进货时间：
                        </td>
                        <td>
                            <%=DateTime.Now.ToString("D")%>
                        </td>
                        <td>
                            开单员工：
                        </td>
                        <td>
                            <%=User.Identity.Name%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8" align="center">
                            <asp:Button ID="BT_Fix" runat="server" Text="修改" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <ajax:ModalPopupExtender ID="ModalPopupExtender1" BackgroundCssClass="modalBackground"
                            PopupControlID="PL_Stock_Info" TargetControlID="BT_Fix" runat="server">
                        </ajax:ModalPopupExtender>
                        <asp:Panel ID="PL_Stock_Info" runat="server" CssClass="modalPanel" Style="display: none">
                            <asp:Panel ID="PL_inside" runat="server" CssClass="modalPopup">
                            <asp:HiddenField ID="HF_Stock_ID" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "Stock_ID")%>'  />
                            <asp:TextBox ID="TB_Pro_Name" runat="server" Width="80px" AutoPostBack="true" OnTextChanged="TB_Pro_Name_TextChanged" Text=' <%#DataBinder.Eval(Container.DataItem,"Pro_Name") %>'/>
                            <asp:TextBox ID="TB_Pro_Number" runat="server" Width="80px" Text='<%#DataBinder.Eval(Container.DataItem,"Stock_Number") %>' />
                            <asp:DropDownList ID="DDL_Comp" runat="server" Width="100px" >
                            </asp:DropDownList>
                                     <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                                        Enabled="True" ServicePath="" TargetControlID="TB_Pro_Name" ServiceMethod="GetSpecificationList"
                                        MinimumPrefixLength="1" UseContextKey="True">
                                    </ajax:AutoCompleteExtender>
                                <asp:Button ID="BT_Submit" runat="server" Text="确认修改" OnClientClick="if(!Toop('您确定要修改订单？')){return false;}" OnClick="BT_Submit_Click" ValidationGroup="Submit" />
                                <asp:Button ID="BT_Delete" runat="server" Text="取消进货" OnClientClick="if(!Toop('您确定要取消订货？')){return false;}" OnClick="BT_Delete_Click" />
                                <asp:Button ID="BT_Cancel" runat="server" Text="取消" />
                            </asp:Panel>
                        </asp:Panel>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
