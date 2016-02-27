using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Printing;
using BLL;
using Model;
using AjaxControlToolkit;
using System.Web.Security;

public partial class Account_Purchase_Purchase : System.Web.UI.Page
{
    #region 初始化方法
    Product_Manager Product_MG = new Product_DAO();
    Producer_Manager Producer_MG = new Producer_DAO();
    VW_Product_Manager PTP_MG = new VW_Product_DAO();
    Stock_Manager Stock_MG = new Stock_DAO();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack)
        {
            for (int i = 0; i < Get_StrokCount(); i++)
            {
                //ReturnComp();
                Creat_Order(i + 1);
            }
        }
    }
    #endregion
    #region 动态添加方法
    private void Creat_Order(int? i)
    {
        if (i == null)
        {
            i = 0;
        }
        TableRow TR = new TableRow();
        TableCell TC1 = new TableCell();
        TableCell TC2 = new TableCell();
        TableCell TC3 = new TableCell();
        TableCell TC4 = new TableCell();
        TableCell TC5 = new TableCell();
        TableCell TC6 = new TableCell();
        TextBox TB = new TextBox() { ID = "TB" + i.ToString() };
        EventHandler EH = new EventHandler(TextChangged);
        TB.TextChanged += EH;
        TB.AutoPostBack = true;
        AutoCompleteExtender AC = new AutoCompleteExtender()
        {
            TargetControlID = TB.ID,
            ServiceMethod = "GetSpecificationList",
            MinimumPrefixLength = 1,
            UseContextKey = true
        };
        TC1.Controls.Add(new Label() { Text = "商品名：" });
        TC3.Controls.Add(new Label() { Text = "进货数量：" });
        TC5.Controls.Add(new Label() { Text = "生产厂家：" });
        TC2.Controls.Add(TB);
        TC2.Controls.Add(AC);
        TC4.Controls.Add(new TextBox());
        TC6.Controls.Add(new DropDownList() { Width = 150 });
        TR.Controls.Add(TC1);
        TR.Controls.Add(TC2);
        TR.Controls.Add(TC3);
        TR.Controls.Add(TC4);
        TR.Controls.Add(TC5);
        TR.Controls.Add(TC6);
        Table1.Controls.Add(TR);
        //this.ClientScript.RegisterStartupScript(this.GetType(), "1", "<script>readybind(){$('.ProName').bind('focusout', function (event) {event = event || window.event;var obj = event.target;JudgeProName(obj)}</script>");
    }
    private int Get_StrokCount()
    {
        if (ViewState["Strok_Count"] == null)
        {
            ViewState["Strok_Count"] = 0;
        }
        return Convert.ToInt32(ViewState["Strok_Count"]);
    }
    #endregion
    #region 辅助商品输入功能
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetSpecificationList(string prefixText, int count, string contextKey)
    {
        Product_Manager Product_MG = new Product_DAO();
        List<string> Select_Name = Product_MG.Select_ProductS(
            P => P.Pro_Name.Contains(prefixText),
            K => K.Pro_Name);
        List<string> Select_EasyPing = Product_MG.Select_ProductS(
            P => P.Pro_EasyPing.Contains(prefixText.ToLower()),
            K => K.Pro_Name
            ).ToList();
        return Select_Name.Union(Select_EasyPing).ToArray();
    }
    #endregion
    #region 按钮事件
    protected void BT_CreatOrder_Click(object sender, EventArgs e)
    {
        Creat_Order(0);
        ViewState["Strok_Count"] = Convert.ToInt32(ViewState["Strok_Count"]) + 1;
    }
    protected void TextChangged(object sender, EventArgs e)
    {
        TextBox TB_ProName = ((TextBox)sender);
        string ProName = TB_ProName.Text;
        DropDownList DDL = (DropDownList)TB_ProName.Parent.Parent.Controls[5].Controls[0];
        DDL.Items.Clear();
        try
        {
            List<Product> ListPro = Product_MG.Select_ProductS(P => P.Pro_Name == ProName);
            if (ListPro.Count == 0)
            {
                DDL.Items.Add(new ListItem() { Text = "数据库为找到该商品" });
            }
            foreach (Product Pro in ListPro)
            {
                DDL.Items.Add(new ListItem() { Text = Producer_MG.Select_Producer(Pro.Pro_ComID).Producer_Name });
            }
        }
        catch (Exception)
        {
            DDL.Items.Add(new ListItem() { Text = "数据库未找到该商品" });
        }
    }
    protected void BT_Next_Click(object sender, EventArgs e)
    {
        int count = Table1.Rows.Count;
        List<Stock_Temp> Stock_List = new List<Stock_Temp>();
        List<int> Stock_Num_List = new List<int>();

        for (int i = 1; i < count; i++)
        {
            //在3个文本框都有值，且商品厂商有值的情况下进行添加
            if (((TextBox)Table1.Rows[i].Cells[1].Controls[0]).Text.ToString() != "" &&
                ((DropDownList)Table1.Rows[i].Cells[5].Controls[0]).SelectedValue.ToString() != "" &&
                !((DropDownList)Table1.Rows[i].Cells[5].Controls[0]).SelectedValue.ToString().Contains("数据库未找到该商品") &&
                ((TextBox)Table1.Rows[i].Cells[3].Controls[0]).Text != "")
            {
                Stock_List.Add(new Stock_Temp(PTP_MG.Select_VW_Product(((TextBox)Table1.Rows[i].Cells[1].Controls[0]).Text.ToString(),
                    ((DropDownList)Table1.Rows[i].Cells[5].Controls[0]).SelectedValue.ToString()),
                    Convert.ToInt32(((TextBox)Table1.Rows[i].Cells[3].Controls[0]).Text)));
            }
        }
        Repeater_Table.DataSource = Stock_List;
        Repeater_Table.DataBind();
        MV.ActiveViewIndex += 1;
    }
    protected void BT_Forward_Click(object sender, EventArgs e)
    {
        MV.ActiveViewIndex -= 1;
    }
    protected void BT_Submit_Click(object sender, EventArgs e)
    {
        int count = Table1.Rows.Count;
        List<Stock> L_Stock = new List<Stock>();
        List<Stock> Temp_Stock = Stock_MG.Select_StockS(DateTime.Now);
        int DateCount;
        if (Temp_Stock.Count != 0)
        {
            String MarkName = Temp_Stock.Last().Stock_Mark.ToString();
            DateCount = Convert.ToInt32(MarkName[MarkName.Length - 1]) - 47;
        }
        else
        {
            DateCount = 0;
        }
        for (int i = 1; i < count; i++)
        {

            //在3个文本框都有值，且商品厂商有值的情况下进行添加
            if (((TextBox)Table1.Rows[i].Cells[1].Controls[0]).Text.ToString() != "" &&
                ((DropDownList)Table1.Rows[i].Cells[5].Controls[0]).SelectedValue.ToString() != "" &&
                !((DropDownList)Table1.Rows[i].Cells[5].Controls[0]).SelectedValue.ToString().Contains("数据库未找到该商品") &&
                ((TextBox)Table1.Rows[i].Cells[3].Controls[0]).Text != "")
            {
                L_Stock.Add(new Stock()
                {
                    Stock_Time = DateTime.Now,
                    Stock_Mark = "JH" + DateTime.Now.Year + DateTime.Now.Month.ToString("D2") + DateTime.Now.Day.ToString("D2") + DateCount.ToString("D3"),
                    Stock_UID = (Guid)Membership.GetUser(User.Identity.Name).ProviderUserKey,
                    Stock_Number = Convert.ToInt32(((TextBox)Table1.Rows[i].Cells[3].Controls[0]).Text),
                    Stock_Pro_ID = PTP_MG.Select_VW_Product(((TextBox)Table1.Rows[i].Cells[1].Controls[0]).Text.ToString(), ((DropDownList)Table1.Rows[i].Cells[5].Controls[0]).SelectedValue.ToString()).Pro_ID
                });
            }
        }
        if (Stock_MG.Insert_Stock(L_Stock))
        {
            LB_Result.Text = "成功";
        }
        else
        {
            LB_Result.Text = "失败";
        }
        MV.ActiveViewIndex += 1;
    }
    #endregion

}