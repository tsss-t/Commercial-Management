using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Account_Purchase_Supplement : System.Web.UI.Page
{
    #region 初始化实例
    Supplement_Manager Sup_MG = new Supplement_DAO();
    VW_Supplement_Manager VW_Sup_MG = new VW_Supplement_DAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_DDL();
        }
    }
    #endregion
    #region 辅助绑定方法
    private void Bind_DDL()
    {
        DDL_Mark.Items.Clear();
        DDL_Mark.DataSource = Sup_MG.Select_Supplement_Mark();
        DDL_Mark.DataBind();
        DDL_Mark.Items.Add(new ListItem() { Text = "<--请选择总单号-->", Selected = true });
    }

    private void Bind_Repeater()
    {
        List<VW_Supplement> LV= VW_Sup_MG.Select_SupplementS(DDL_Mark.Items[DDL_Mark.SelectedIndex].Text);
        Repeater_Sup.DataSource =LV;
        ViewState["DDL_State"] = DDL_Mark.Items[DDL_Mark.SelectedIndex].Text;
        Repeater_Sup.DataBind();
    }
    private void Bind_Repeater_Frush()
    {
        bool Info = false;
        foreach (ListItem LI in DDL_Mark.Items)
        {
            if (LI.Text == ViewState["DDL_State"].ToString())
            {
                Repeater_Sup.DataSource =VW_Sup_MG.Select_SupplementS(ViewState["DDL_State"].ToString());
                Repeater_Sup.DataBind();
                Info = true;
            }
        }
        if (!Info)
        {
            Bind_DDL();
        }
    }
    #endregion
    #region 前台事件响应
    protected void DDL_Mark_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_Repeater();
    }

    protected void Sup_Up_Click(object sender, EventArgs e)
    {
        Button Sup_Up = (Button)sender;
        int Sup_ID =Convert.ToInt32(((HiddenField)Sup_Up.Parent.Controls[1]).Value);
        decimal Pro_Price = Convert.ToDecimal(((HiddenField)Sup_Up.Parent.Controls[3]).Value);
        if (Sup_MG.Update_IsSup_Price(Sup_ID, Pro_Price))
        {
            Bind_Repeater_Frush();
        }
    }
    protected void Sup_NoUp_Click(object sender, EventArgs e)
    {
        Button Sup_Up = (Button)sender;
        int Sup_ID = Convert.ToInt32(((HiddenField)Sup_Up.Parent.Controls[1]).Value);
        decimal Pro_Price = Convert.ToDecimal(((HiddenField)Sup_Up.Parent.Controls[3]).Value);
        if (Sup_MG.Update_IsSup(Sup_ID))
        {
            Bind_Repeater_Frush();
        }
    }
    #endregion
}