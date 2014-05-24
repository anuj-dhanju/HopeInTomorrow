using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ViewAllNews : System.Web.UI.Page
{
    newsBAL newsbal = new newsBAL();
    newsBO newsbo = new newsBO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin_id"] == null)
        {
            Response.Redirect("~/Admin/AdminLogin.aspx");
        }
        else
        {
            if (!(Page.IsPostBack))
            {
                try
                {
                    
                    newsbo.news_id = Convert.ToInt32(Request.QueryString["id"]);
                    if (Request.QueryString["type"] == "Delete")
                    {
                        if (newsbal.news_DAL_del(newsbo) > 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "fun", "alert('News Deleted Successfully..........');", true);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "fun", "alert('Sorry For Inconvenience......');", true);

                        }
                    }
                    dlnews.DataSource = newsbal.news_DAL_viewALL();
                    dlnews.DataBind();

                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "fun", "alert('Sorry For Inconvenience......');", true);
                }
            }
        }
    }

    protected String DateTimeFormatting(DateTime d)
    {
        return d.ToShortDateString();
    }

    protected String DateTimeFormatting_full(DateTime d)
    {
        return d.ToShortDateString() + " " + d.ToShortTimeString();
    }


    protected String ChangeStringFormat(String s)
    {
        return Server.HtmlDecode(s);
    }
    protected void lbtnView_Command(object sender, CommandEventArgs e)
    {

    }
    protected void lbtnEdit_Command(object sender, CommandEventArgs e)
    {

    }
    protected void lbtnDelete_Command(object sender, CommandEventArgs e)
    {
        newsbo.news_id = Convert.ToInt32(e.CommandArgument.ToString());
            
       // Response.Write("<script>confirm('Are you sure you want to delete this entry?');</script>");
        //newsbal.news_DAL_del(newsbo);
     

    }
}