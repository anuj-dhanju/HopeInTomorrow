using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_MyBlog : System.Web.UI.Page
{
    AdminFunctionsBAL adminBlogFunctions = new AdminFunctionsBAL();

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

                    dlBlog.DataSource = adminBlogFunctions.MyBlogLister(Convert.ToInt32(Session["admin_id"]));
                    dlBlog.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("Error Ocured : " + ex.ToString());
                }

            }
        }
    }


    protected void lbtnDelete_Click(object sender, CommandEventArgs e)
    {
        try
        {

            blog_postBO blogInfo = new blog_postBO();
            blogInfo.blog_id = Convert.ToInt32(e.CommandArgument.ToString());
            adminBlogFunctions.AdminBlogDelete(blogInfo);
            Response.Redirect("~/Admin/MyBlog.aspx");
        }
        catch (Exception ex)
        {
            Response.Write("Error Occured : " + ex.ToString());
        }
    }

    protected void lbtnEdit_Click(object sender, CommandEventArgs e)
    {
        Response.Redirect("~/Admin/BlogEditor.aspx?id=" + e.CommandArgument.ToString());
    }
    protected void lbtnView_Click(object sender, CommandEventArgs e)
    {
        Response.Redirect("~/Admin/BlogViewer.aspx?id=" + e.CommandArgument.ToString());
    }

    protected String DateTimeFormatting(DateTime d)
    {
        return d.ToShortDateString();
    }


    protected String ChangeStringFormat(String s)
    {
        return Server.HtmlDecode(s);
    }

}