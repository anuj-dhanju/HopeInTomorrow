using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_EventViwer : System.Web.UI.Page
{
    AdminFunctionsBAL adminBlogFunctions = new AdminFunctionsBAL();
    eventsBO evt = new eventsBO();
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
                        evt.event_id = Convert.ToInt32(Request.QueryString["id"]);
                        DataSet ds = new DataSet();
                        ds = adminBlogFunctions.event_retrive(evt);
                        DataTable eventdata = new DataTable();
                        eventdata = ds.Tables[0];
                        DataView dv = eventdata.DefaultView;

                        if (dv== null)
                        {
                            Response.Write("Sorry, But the blog is not present");
                        }
                        else
                        {

                            event_title.Text = dv[0]["event_title"].ToString();
                            event_time.Text = dv[0]["event_time"].ToString();
                            event_body.Text = dv[0]["event_desc"].ToString();
                            string picurl = dv[0]["event_pic"].ToString();
                            pic.ImageUrl = picurl;
                            
                            //div_blog_date_time.InnerText = Server.HtmlDecode((blog.date_time_of_post).ToLongDateString());
                           // div_blog_body.innerhtml = server.htmldecode(dv[0]["event_desc"].ToString() + dv[0]["event_pic"].ToString());
                            //div_blog_body.InnerHtml = Server.HtmlDecode(dv[0]["event_desc"].ToString() + dv[0]["event_pic"].ToString());
                            spn_posterName.InnerText = Server.HtmlDecode("Admin");   //getting the admin name from admin_id
                            spn_timeOfPost.InnerHtml = Server.HtmlDecode(dv[0]["date_time_of_post"].ToString());
                            //spn_timeOfPost.InnerText = Server.HtmlDecode(blog.date_time_of_post.ToShortTimeString());

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
        Response.Redirect("~/Admin/EventsEdit.aspx?type=Edit&&id=" + Request.QueryString["id"]);
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ViewAllEvents.aspx");
    }

}