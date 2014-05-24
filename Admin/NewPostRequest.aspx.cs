using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NewPostRequest : System.Web.UI.Page
{
    AdminFunctionsBAL newpostlister = new AdminFunctionsBAL();

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

                    dlBlog.DataSource = newpostlister.AdminNewPostRequestList();
                    dlBlog.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("Error Ocured : " + ex.ToString());
                }

            }
        }
    }





    protected String DateTimeFormatting(DateTime d)
    {
        return d.ToShortDateString();
    }


    protected String ChangeStringFormat(String s)
    {
        return Server.HtmlDecode(s);
    }


    protected void lbtnView_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("~/Admin/BlogViewer.aspx?id=" + e.CommandArgument.ToString());
    }

    protected void lbtnDelete_Command(object sender, CommandEventArgs e)
    {

        try
        {

            blog_postBO blogInfo = new blog_postBO();
            blogInfo.blog_id = Convert.ToInt32(e.CommandArgument.ToString());
            newpostlister.AdminBlogDelete(blogInfo);
            Response.Redirect("~/Admin/NewPostRequest.aspx");
        }
        catch (Exception ex)
        {
            Response.Write("Error Occured : " + ex.ToString());
        }
    }
}