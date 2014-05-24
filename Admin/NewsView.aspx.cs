using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_NewsView : System.Web.UI.Page
{
    newsBAL newsbal = new newsBAL();
    newsBO newsbo = new newsBO();
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
                    Response.Redirect("~/Admin/ViewAllNews.aspx");
                }

                else
                {

                    try
                    {
                        newsbo.news_id= Convert.ToInt32(Request.QueryString["id"]);
                        DataTable newsretrive=new DataTable();
                          newsretrive=  newsbal.news_DAL_view_id(newsbo);
                          DataView dv = newsretrive.DefaultView;

                        if (dv == null)
                        {
                            Response.Write("Sorry, But the blog is not present");
                        }
                        else
                        {


                            div_blog_title.InnerHtml = Server.HtmlDecode(dv[0]["news_title"].ToString());
                            
                           news_body.Text = Server.HtmlDecode(dv[0]["news_desc"].ToString());
                             string picurl = dv[0]["news_pic"].ToString();
                             if (picurl == "")
                             {
                                 pic.ImageUrl = "~/img/no-image.gif";
                             }
                             else
                             {
                                 pic.ImageUrl = picurl;
                             }
                            spn_posterName.InnerText = Server.HtmlDecode("Admin");   //getting the admin name from admin_id
                            spn_timeOfPost.InnerHtml = Server.HtmlDecode(dv[0]["date_time_of_post"].ToString());
                         

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
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ViewAllNews.aspx?type=Delete&&id=" + Request.QueryString["id"]);
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ViewAllNews.aspx");
    }
}