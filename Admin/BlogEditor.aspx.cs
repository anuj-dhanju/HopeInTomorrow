using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_BlogEditor : System.Web.UI.Page
{

    AdminFunctionsBAL blogedit = new AdminFunctionsBAL();
    blog_postBO blog = new blog_postBO();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["admin_id"] == null)
        {
            Response.Redirect("AdminLogin.aspx");
        }
        else
        {
        if (!(Page.IsPostBack))
        {

            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("~/Admin/AdminBlog.aspx");
            }

            else
            {

                try
                {
                    blog = blogedit.AdminBlogViewer(Convert.ToInt32(Request.QueryString["id"]));

                    if (blog == null)
                    {
                        Response.Write("Sorry, But the blog is not present");
                    }
                    else
                    {
                        txtBlogTitle.Value = Server.HtmlDecode(blog.blog_title.ToString());
                        div_blog_body.InnerHtml = Server.HtmlDecode(blog.blog_content.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Error Ocured : " + ex.ToString());
                }

            }
        }
        }
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/AdminBlog.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            blog.blog_id = Convert.ToInt32(Request.QueryString["id"]);
            blog.blog_content = Server.HtmlEncode(hid_blog_body.Value.ToString());
            blog.blog_title = Server.HtmlEncode(txtBlogTitle.Value.ToString());
            blogedit.AdminBlogEdit(blog);
            Response.Redirect("~/Admin/BlogViewer.aspx?id=" + blog.blog_id.ToString());
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
}