using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HopeInTomorrow_Blog : System.Web.UI.Page
{
    UserFunctionsBAL blog = new UserFunctionsBAL();

    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(Page.IsPostBack))
        {
            try
            {

                dlBlog.DataSource = blog.ListBlog();
                dlBlog.DataBind();

            }
            catch (Exception ex)
            {
                ErrorReportBAL error = new ErrorReportBAL();
                error.SendErrorReport("Blog.aspx", ex.ToString());
            }

        }
    }


    protected String GetLongDateFormat(DateTime d)
    {
        return d.ToLongDateString();
    }

    protected void lnkbtnReadMore_Command(object sender, CommandEventArgs e)
    {
        Session["viewBlog_id"] = Convert.ToInt32(e.CommandArgument.ToString());
        Response.Redirect("~/ViewPost.aspx");
    }


    protected String GetPosterName(int poster_id, int is_admin)
    {
        String name = "";
        if (is_admin == 0)
        {
            name = blog.UserNameFetch(poster_id);
        }
        else if (is_admin == 1)
        {
            name = blog.AdminNameFetch(poster_id) + " (Admin)";
        }

        return name;
    }


    protected String GetCommentCount(int blog_id)
    {
        return blog.BlogCommentCount(blog_id).ToString();
    }

    protected String GetViewCount(int blog_id)
    {
        return blog.GetBlogViewCount(blog_id).ToString();
    }
    protected void dlBlog_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            
            Image imgpp = (Image)e.Item.FindControl("img_pp");
            imgpp.ImageUrl = GetImageUrl(Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "poster_id")), Convert.ToInt16(DataBinder.Eval(e.Item.DataItem,"is_admin")));


         }
        catch(Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("Blog.aspx",ex.ToString());
        }
    }


    protected String GetImageUrl(int poster_id, int is_admin)
    {
        if (is_admin == 0)
        {
            return blog.GetProfilePicName(poster_id);
        }

        else
        {
            return "/Admin/Resources/Images/ProfilePic/Admin_pp.jpg";
        }
    }

}