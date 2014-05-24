using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    newsBAL newsbal = new newsBAL();
    newsBO newsbo = new newsBO();

    protected void btnPostnews_Click(object sender, EventArgs e)
    
    {
        try
        {

            newsbo.admin_id = Convert.ToInt32(Session["admin_id"].ToString());
            newsbo.date_time_of_post = DateTime.Now;
            newsbo.news_title = txtnewsheading.Text;
            newsbo.news_desc = txtNewsDesc.Text;
            if (news_pic_uploader.HasFile)
            {

                news_pic_uploader.SaveAs(Server.MapPath("~/Images/newspic/" + news_pic_uploader.FileName));
                string path1 = "~/Images/newspic/" + news_pic_uploader.FileName;
                newsbo.news_pic = path1;
            }
            else
            {
                newsbo.news_pic = "~/img/no_image.gif";

            }
            if (newsbal.news_DAL_insert(newsbo) > 0)
            {
                Response.Write("<script>alert('News Posted Successfully');</script>");
                
            }
            else
            {
                Response.Write("<script>alert('Check the Inputed Data');</script>");
            }
        }
        catch
        {
            Response.Write("<script>alert('Sorry For the Inconvenience');</script>");
        }
    }
}