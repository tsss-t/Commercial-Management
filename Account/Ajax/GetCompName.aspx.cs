using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Account_Ajax_GetCompName : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ProName = Request.QueryString["ProName"].ToString();
        //string ProName = "胃必治";
        Product_Manager Product_MG = new Product_DAO();
        Producer_Manager Producer_MG = new Producer_DAO();
        List<string> ListName = new List<string>();
        String RT = "";
        try
        {
            List<Product> Products = Product_MG.Select_ProductS(P => P.Pro_Name == ProName);
            foreach (Product Pro in Products)
            {
                Producer huhuh = Producer_MG.Select_Producer(Pro.Pro_ComID);
                ListName.Add(huhuh.Producer_Name.ToString());
            }
        }
        catch (Exception E)
        {
            Response.Write("<Option Value=OP>此公司未找到，请先建立此公司的基本资料</Option>");
            Response.Write(E.Message);
        }
        for (int i = 0; i < ListName.Count(); i++)
        {
            RT += "<Option Value=OP" + (i + 1) + ">" + ListName[i] + "</Option>";
        }
        Response.Write(RT);
        Response.End();
    }
}