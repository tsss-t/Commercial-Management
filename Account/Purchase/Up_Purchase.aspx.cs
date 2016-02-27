using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;


public partial class Account_Purchase_Up_Purchase : System.Web.UI.Page
{
    #region 初始化变量
    VW_Stock_Manager View_Stock_MG = new VW_Stock_DAO();
    VW_Product_Manager View_Product_MG = new VW_Product_DAO();
    Stock_Manager Stock_MG = new Stock_DAO();
    Producer_Manager Producer_MG = new Producer_DAO();
    Product_Manager Product_MG = new Product_DAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_DDL();
            
        }
    }
    #endregion
    #region 前台页面辅助方法
    private void Bind_DDL()
    {
        DDL_Mark.Items.Clear();
        DDL_Mark.DataSource = Stock_MG.Select_StockS(P => P.Stock_ID >= 0 && P.Is_Store == false, K => K.Stock_Mark).Distinct();
        DDL_Mark.DataBind();
        DDL_Mark.Items.Add(new ListItem() { Text = "<-请选择订单号->", Selected = true });
    }
    /// <summary>
    /// 手动刷新页面绑定repeater方法
    /// </summary>
    private void Bind_Repeater()
    {
        Bind_DDL();
        String Mark = ViewState["Mark"].ToString();
        bool Info = false;
        foreach(ListItem LI in DDL_Mark.Items)
        {
            if (LI.Text == Mark)
            {
                LI.Selected = true;
                Info = true;
            }
            if (Info && LI.Text == "<-请选择订单号->")
            {
                LI.Selected = false;
            }
        }
        if (Info)
        {
            Repeater_Stock.DataSource = View_Stock_MG.Select_VW_StockS(Mark);
            Repeater_Stock.DataBind();
        }
        else
        {
            Repeater_Stock.DataSource = null;
            Repeater_Stock.DataBind();
        }

    }



    #endregion
    #region 前台事件绑定方法
    protected void DDL_Mark_SelectedIndexChanged(object sender, EventArgs e)
    {
        String Mark = DDL_Mark.Items[DDL_Mark.SelectedIndex].Text;
        ViewState["Mark"] = Mark;
        Repeater_Stock.DataSource = View_Stock_MG.Select_VW_StockS(Mark);
        Repeater_Stock.DataBind();
    }
    protected void TB_Pro_Name_TextChanged(object sender, EventArgs e)
    {
        TextBox TB_Pro_Name = (TextBox)sender;
        String Pro_Name = TB_Pro_Name.Text;
        DropDownList DDL_Comp = (DropDownList)TB_Pro_Name.Parent.Controls[4];
        DDL_Comp.Items.Clear();
        try
        {
            List<Product> ListPro = Product_MG.Select_ProductS(P => P.Pro_Name == Pro_Name);
            if (ListPro.Count == 0)
            {
                DDL_Comp.Items.Add(new ListItem() { Text = "数据库为找到该商品" });
            }
            foreach (Product Pro in ListPro)
            {
                DDL_Comp.Items.Add(new ListItem() { Text = Producer_MG.Select_Producer(Pro.Pro_ComID).Producer_Name });
            }
        }
        catch (Exception)
        {
            DDL_Comp.Items.Add(new ListItem() { Text = "数据库未找到该商品" });

        }
    }
    protected void BT_Submit_Click(object sender, EventArgs e)
    {
        Button BT_Submit = (Button)sender;
        int Stock_ID = Convert.ToInt32((BT_Submit.Parent.Controls[1] as HiddenField).Value);
        String Pro_Name = ((TextBox)BT_Submit.Parent.Controls[3]).Text;
        int Pro_Number =Convert.ToInt32(((TextBox)BT_Submit.Parent.Controls[5]).Text);
        String Comp_Name = ((DropDownList)BT_Submit.Parent.Controls[7]).Items[((DropDownList)BT_Submit.Parent.Controls[7]).SelectedIndex].Text;
        Stock   New_Stock=Stock_MG.Selete_Stock(Stock_ID);
        New_Stock.Stock_Number=Pro_Number;
        New_Stock.Stock_Pro_ID=View_Product_MG.Select_VW_Product(Pro_Name,Comp_Name).Pro_ID;
        if (Stock_MG.Update_Stock(New_Stock))
        {
            ScriptManager.RegisterStartupScript(this,this.GetType(), "test", "alert('修改成功')", true);
            Bind_Repeater();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this,this.GetType(), "test", "alert('修改失败，请检查拼写')", true);

        }
    }
    protected void BT_Delete_Click(object sender, EventArgs e)
    {
        Button BT_Delete = (Button)sender;
        int Stock_ID = Convert.ToInt32((BT_Delete.Parent.Controls[1] as HiddenField).Value);
        if (Stock_MG.Delete_Stock(Stock_ID))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "show_delete_sc", "alert('删除成功！')", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "show_delete_error", "alert('删除失败！')", true);
        }
        Bind_Repeater();
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
    #region Repeater绑定公司名称
    protected void Repeater_Stock_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        for (int i = 0; i != Repeater_Stock.Items.Count; i++)
        {
            DropDownList DDL_Comp = (DropDownList)Repeater_Stock.Items[i].FindControl("DDL_Comp");
            String Pro_Name = ((TextBox)Repeater_Stock.Items[i].FindControl("TB_Pro_Name")).Text;
            List<Product> List_Pro = Product_MG.Select_ProductS(Pro_Name);
            List<String> Producer_Name=new List<string>();
            foreach (Product Pro in List_Pro)
            {
                Producer_Name.Add(Producer_MG.Select_ProducerS(P => P.Producer_ID == Pro.Pro_ComID).First().Producer_Name);
            }
            DDL_Comp.DataSource = Producer_Name;
            DDL_Comp.DataBind();
        }
    }
    #endregion
}