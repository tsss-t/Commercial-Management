using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Account_Ajax_GetCompInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string CompName = Request.QueryString["CompName"].ToString();
        Producer_Manager Producer_MG = new Producer_DAO();
        try
        {
            Producer Comp = Producer_MG.Select_Producer(CompName);
        }
        catch (Exception)
        {
            Response.Write("此公司未找到，请先建立此公司的基本资料");
        }

            Response.Write("");
    }
}