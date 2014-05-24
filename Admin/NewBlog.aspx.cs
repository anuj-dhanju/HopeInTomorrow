using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_NewBlog : System.Web.UI.Page
{
    blog_postBO blog = new blog_postBO();

    AdminFunctionsBAL postblog = new AdminFunctionsBAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin_id"] == null)
        {
            Response.Redirect("~/Admin/AdminLogin.aspx");
            
        }
    }
    protected void btnPost_Click(object sender, EventArgs e)
    {
        try
        {
            blog.poster_id = Convert.ToInt32(Session["admin_id"]);
            blog.is_admin = true;
            blog.blog_title = Server.HtmlEncode(txtBlogTitle.Value.ToString());       //getting the values from hidden field
            blog.blog_content = Server.HtmlEncode(hid_blog_body.Value.ToString());         //getting the values from hidden field

            postblog.AdminPostBlog(blog);                // calling the bal function here 

            Response.Redirect("~/Admin/AdminBlog.aspx");

        }

        catch (Exception ex)
        {
            Response.Write(ex.ToString());

        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/AdminBlog.aspx");
    }
}