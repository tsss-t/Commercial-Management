using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (User.IsInRole("保管员"))
        {
            Response.Redirect("~/Account/Fixed Assets/AddAssetForm.aspx");
        }
        else if (User.IsInRole("财务员"))
        {
            Response.Redirect("~/Account/Finance/AddDailyCost.aspx");
        }
        else if (User.IsInRole("采购员"))
        {
            Response.Redirect("~/Account/Purchase/Purchase.aspx");
        }
        else if (User.IsInRole("人事员"))
        {
            Response.Redirect("~/Account/Personnel/register.aspx");
        }
        else if (User.IsInRole("销售员"))
        {
            Response.Redirect("~/Account/Sell/Day_Count.aspx");
        }
        else if (User.IsInRole("储备员"))
        {
            Response.Redirect("~/Account/Inventory/Inventory.aspx");
        }
        else if (User.IsInRole("管理员"))
        {
            Response.Redirect("~/Account/Manager/Add_Shop.aspx");
        }

    }
}


