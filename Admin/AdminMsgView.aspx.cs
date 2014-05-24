using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdminMsgView : System.Web.UI.Page
{
    AdminFunctionsBAL msgviewer = new AdminFunctionsBAL();
    suggestionBO msg = new suggestionBO();
   
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
                    Response.Redirect("~/Admin/AdminInbox.aspx");
                }

                else
                {

                    try
                    {
                        msg = msgviewer.AdminMsgViewer(Convert.ToInt32(Request.QueryString["id"]));

                        if (msg == null)
                        {
                            Response.Write("Sorry, But the Message is not present");
                        }
                        else
                        {

                            div_blog_title.InnerText = "Subject "+msg.subject.ToString();
                            spn_timeOfPost.InnerText = Server.HtmlDecode((msg.date_time).ToLongDateString());
                            div_blog_body.InnerHtml = msg.suggestion_msg.ToString();
                            spn_posterName.InnerHtml = msg.user_name.ToString();
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


   
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/AdminInbox.aspx");
    }
}