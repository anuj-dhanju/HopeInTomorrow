using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class NewsView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int  Eid = 0;
        try
        {
            Eid = Convert.ToInt32(Request.QueryString["id"]);
            displaynewsByID(Eid);

        }
        catch(Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("NewsView.aspx", ex.ToString());
            Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
        }
    }

    protected void displaynewsByID(int NewsID)
    {
        newsBAL news_bal = new newsBAL();
        newsBO news_bo = new newsBO();
        news_bo.news_id = NewsID;
        try
        {
            DataTable dt = news_bal.news_DAL_view_id(news_bo);
            newsLoad.DataSource = dt;
            newsLoad.DataBind();

        }
        catch (Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("NewsView.aspx", ex.ToString());
            Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
        }
    }
}
