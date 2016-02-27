<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Supplement.aspx.cs" Inherits="Account_Purchase_Supplement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../Scripts/jquery-1.6.2.js" type="text/javascript"></script>
    <script src="../../Scripts/MainPage.js" type="text/javascript"></script>
    <link href="../../Styles/DTH_GetGoods.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
    <ContentTemplate>
    

<asp:DropDownList ID="DDL_Mark" runat="server" 
        onselectedindexchanged="DDL_Mark_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
<br />
    <asp:Repeater ID="Repeater_Sup" runat="server">
        <HeaderTemplate>
            <span style="font-size: 18px;">补差单</span><br />
        </HeaderTemplate>
        <ItemTemplate>
            <asp:HiddenField ID="HF_SupID" Value='<%#DataBinder.Eval(Container.DataItem, "ID")%>' runat="server" />
            <asp:HiddenField ID="HF_Price" Value='<%#DataBinder.Eval(Container.DataItem, "Price")%>' runat="server" />
            商品ID　　
            <%#DataBinder.Eval(Container.DataItem, "Pro_ID")%><br />
            商品名称　
            <%#DataBinder.Eval(Container.DataItem, "Pro_Name")%><br />
            生产商　　
            <%#DataBinder.Eval(Container.DataItem, "Producer_Name")%><br />
            补差数量　
            <%#DataBinder.Eval(Container.DataItem, "Number")%><br />
            以前价格　
            <%#DataBinder.Eval(Container.DataItem, "Old_Price")%><br />
            现在价格　
            <%#DataBinder.Eval(Container.DataItem, "Price")%><br />
            单品补差　
            <%#DataBinder.Eval(Container.DataItem, "SupplementPrice")%><br />
            总共补差　
            <%#DataBinder.Eval(Container.DataItem, "SupplementPriceAll")%><br />
            操作人　　
            <%#DataBinder.Eval(Container.DataItem, "UserName")%><br />
            <asp:Button ID="Sup_Up" runat="server" Text="补差并修改商品原价格" OnClick="Sup_Up_Click" />
            <asp:Button ID="Sup_NoUp" runat="server" Text="补差不修改商品原价格"  OnClick="Sup_NoUp_Click"/>
            <br />
        </ItemTemplate>
        <FooterTemplate>
            <br />
        </FooterTemplate>
    </asp:Repeater>
    <asp:Button ID="BT_Print" runat="server" Text="打印" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
