using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using AjaxControlToolkit;

public partial class Windows : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //BT_Start.Attributes["onmouseover"] = "javascript:this.src='images/start1.png';";
        //BT_Start.Attributes["onmouseout"] = "javascript:this.src='images/Start2.png';";
    }
    private void Creat_Window(int WindowID)
    {

    }
    protected void IM_Click(object sender, ImageClickEventArgs e)
    {
     
            GenerateControls(sender);
 
    }

    private void GenerateControls(object sender)
    {
        ImageButton IB = (ImageButton)sender;
        int WindowID = Convert.ToInt32(IB.AccessKey);

        Panel window = new Panel();//主面板
        Panel OS = new Panel();//上方控制条
        Panel Control = new Panel();//下方控制区域
        Panel Close = new Panel();//关闭按钮
        Panel Max = new Panel();//最大化
        Panel Min = new Panel();//最小化
        //设置css样式
        window.CssClass = "Window";
        OS.CssClass = "OS";
        Control.CssClass = "Control";
        Close.CssClass = "Close";
        Max.CssClass = "Max";
        Min.CssClass = "Min";

        //设置js方法
        Close.Attributes.Add("onclick", "Window_Close(this)");
        Max.Attributes.Add("onclick", "Window_Max(this)");
        Min.Attributes.Add("onclick", "Window_Min(this)");

        switch (WindowID)
        {
            case 1://商品进货
                {
                    Creat_MinIcon("images/1apps.png", "商品进货", OS);
                    Creat_MinWindow("images/1apps.png", "商品进货");
                    Creat_Icon("images/Fresh-addon_11.png", "<br/>新增进货单", Control);
                    Creat_Icon("images/Fresh-addon_11.png", "<br/>查看进货单", Control);
                    break;
                }
            case 2://商品入库
                {
                    break;
                }
            case 3://商品销售
                {
                    break;
                }
            case 4://用户管理
                {
                    break;
                }
            case 5://固定资产
                {
                    break;
                }
            case 6://财务管理
                {
                    break;
                }
        }
        OS.Controls.Add(Close);
        OS.Controls.Add(Max);
        OS.Controls.Add(Min);
        window.Controls.Add(OS);
        window.Controls.Add(Control);
        Icons.Controls.Add(window);
    }
    private void Creat_Icon(String URL, String Name,Panel Control)
    {
        Panel Icon = new Panel();
        Icon = new Panel();
        Icon.CssClass = "Icon";
        ImageButton Win_IM_Stock = new ImageButton();
        Win_IM_Stock.Click += new ImageClickEventHandler(Win_IM_Stock_Click);
        Win_IM_Stock.ImageUrl = URL;
        Win_IM_Stock.Height = 32;
        Win_IM_Stock.Width = 32;
        Icon.Controls.Add(Win_IM_Stock);
        Icon.Controls.Add(new LiteralControl(Name));
        Control.Controls.Add(Icon);
    }

    void Win_IM_Stock_Click(object sender, ImageClickEventArgs e)
    {
        GenerateControls(sender);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "test", "alert('aa')", true);
    }
    private void Creat_MinIcon(String URL,String Name,Panel OS)
    {
        Panel PL = new Panel();
        PL.CssClass = "PL";
        Image IM = new Image();
        IM.CssClass = "IM";
        IM.Height = 18;
        IM.Width = 18;
        IM.ImageUrl = URL;
        Label LB = new Label();
        LB.CssClass = "LB";
        LB.Text=Name;
        PL.Controls.Add(IM);
        OS.Controls.Add(PL);
        OS.Controls.Add(LB);
    }
    private void Creat_MinWindow(String URL, String Name)
    {
        Panel Min_Panel = new Panel();
        Min_Panel.CssClass = "Min_Panel";

        Image IM = new Image();
        IM.CssClass = "IM";
        IM.Height = 25;
        IM.Width = 25;
        IM.ImageUrl = URL;
        
        Label LB = new Label();
        LB.CssClass = "LB";
        LB.Text = Name;
        

        Min_Panel.Controls.Add(IM);
        Min_Panel.Controls.Add(LB);
        MenuBar.Controls.Add(Min_Panel);
    }
}