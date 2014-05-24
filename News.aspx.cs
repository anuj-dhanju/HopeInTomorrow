using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class News : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int Nid = 0;
        try
        {
            Nid = Convert.ToInt32(Request.QueryString["id"]);


            if (Nid == 0)
            {
                loadNews();
            }
            else { displayNewsByID(Nid); }
        }
        catch(Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("News.aspx", ex.ToString());
            Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
        }
        


    }
    protected String datelongformat(DateTime d)
    {
        return d.ToLongDateString();

    }

    protected String timeshortformat(DateTime d)
    {
        return d.ToShortTimeString();

    }


    
    protected void loadNews()
    {

        newsBAL news_bal = new newsBAL();
        newsBO news_bo = new newsBO();
        try
        {
            DataSet ds = news_bal.news_DAL_viewALL();
            newsLoad.DataSource = ds;
            newsLoad.DataBind();

        }
        catch (Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("News.aspx", ex.ToString());
            Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
        }


    }
    protected void displayNewsByID(int NewsID)
    {
       

    }
}