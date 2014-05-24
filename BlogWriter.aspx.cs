using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HopeInTomorrow_BlogWriter : System.Web.UI.Page
{
    blog_postBO newblog = new blog_postBO();
    UserFunctionsBAL postblog = new UserFunctionsBAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] != null)
        {
            if (Request.QueryString["status"] != null)
            {
                if (Request.QueryString["status"].ToString() == "true")
                {
                    div_message_text.InnerText = "Blog has been saved successfully. \n Once Admin checks it , then it will get posted.";
                    Response.Write("<script type='text/javascript'> window.onload=function(){ document.getElementById('div_message').style.display='block'; }; </script>");
                }
            }
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
    }
    protected void btnPost_Click(object sender, EventArgs e)
    {
        try
        {
            newblog.poster_id = Convert.ToInt32(Session["user_id"]);
            newblog.is_admin = false;

            newblog.blog_title = Server.HtmlEncode(txtBlogTitle.Value.ToString());
            newblog.blog_content = Server.HtmlEncode(hid_blog_body.Value.ToString());

            postblog.UserPostNewBlog(newblog);

            Response.Redirect("~/BlogWriter.aspx?status=" + "true");
        }
        catch(Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("BlogWriter.aspx", ex.ToString());
            String script = "alert('Some Error Occured \n Sorry for Incovenience')";
            ClientScript.RegisterStartupScript(this.GetType(),"script",script,true);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtBlogTitle.Value = "";
        div_blog_body.InnerHtml = "";
        div_blog_body.InnerText = "";
        hid_blog_body.Value = "";
    }
}