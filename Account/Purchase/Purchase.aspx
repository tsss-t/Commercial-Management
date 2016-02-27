<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Purchase.aspx.cs" Inherits="Account_Purchase_Purchase" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../Scripts/jquery-1.6.2.js" type="text/javascript"></script>
    <script src="../../Scripts/MainPage.js" type="text/javascript"></script>
    <link href="../../Styles/DTH_GetGoods.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function preview() {
            bdhtml = window.document.body.innerHTML;
            sprnstr = " <!--startprint--> ";
            eprnstr = " <!--endprint--> ";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            window.print();
            //prnform.htext.value=prnhtml; 
            //prnform.submit(); 
            //alert(prnhtml); 
        } 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <ContentTemplate>
                <asp:MultiView ID="MV" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <asp:Table ID="Table1" runat="server" Width="100%">
                            <asp:TableHeaderRow>
                                <asp:TableHeaderCell ColumnSpan="6">
                        进货单
                                </asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="LB_ProName" runat="server" Text="商品名：" />
                                </asp:TableCell><asp:TableCell>
                                    <asp:TextBox ID="TB_ProName" runat="server" OnTextChanged="TextChangged" AutoPostBack="true">
                                    
                                    </asp:TextBox>
                                    <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                                        Enabled="True" ServicePath="" TargetControlID="TB_ProName" ServiceMethod="GetSpecificationList"
                                        MinimumPrefixLength="1" UseContextKey="True">
                                    </ajax:AutoCompleteExtender>
                                </asp:TableCell><asp:TableCell>
                                    <asp:Label ID="LB_Num" runat="server" Text="进货数量：" />
                                </asp:TableCell><asp:TableCell>
                                    <asp:TextBox ID="TB_Num" runat="server"></asp:TextBox>
                                </asp:TableCell><asp:TableCell>
                                    <asp:Label ID="TB_Comp" runat="server" Text="生产厂家：" />
                                </asp:TableCell><asp:TableCell>
                                    <asp:DropDownList ID="DDL_Comp" runat="server" Width="150px">
                                    </asp:DropDownList>
                                </asp:TableCell><asp:TableCell>
                                    <asp:Label ID="LB0" runat="server" />
                                </asp:TableCell></asp:TableRow>
                        </asp:Table>
                        <asp:Button ID="BT_CreatOrder" runat="server" OnClick="BT_CreatOrder_Click" Text="新增进货项目" />
                        <asp:Button ID="BT_Next" runat="server" Text="生成进货表单" OnClick="BT_Next_Click" /></asp:View>
                    <asp:View ID="View2" runat="server">
                        <!--startprint-->
                        <asp:Repeater ID="Repeater_Table" runat="server">
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
                                        <%#DataBinder.Eval(Container.DataItem, "Pro_Num")%>
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
                                    <td colspan="8">
                                        &nbsp
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <!--endprint-->
                        <asp:Button ID="BT_Forword" runat="server" OnClick="BT_Forward_Click" Text="返回修改" />
                        <asp:Button ID="BT_Submit" runat="server" Text="保存到数据库" OnClick="BT_Submit_Click" /></asp:View>
                    <asp:View ID="View3" runat="server">
                        <asp:Label ID="LB_Result" runat="server" />
                        <asp:Button ID="BT_Print" runat="server" OnClientClick="preview()" Text="打印" />
                    </asp:View>
                </asp:MultiView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Label ID="LB_Test" runat="server" />
    </div>
</asp:Content>


