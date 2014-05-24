using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class UserLogout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (Session["user_id"] == null && Session["user_login_social"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }


            else
            {
                if (Session["user_login_social"] == "yes")
                {

                    if (Session["user_login_type"].ToString() == "GOOGLE")
                    {
                        Session.Abandon();

                        // Response.Write("<script>googleLogout();</script>");
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "gl", "googleLogout()", true);
                        Response.Redirect("https://www.google.com/accounts/Logout?continue=https://appengine.google.com/_ah/logout?continue=http://hopeintomorrow.org");



                    }
                    if (Session["user_login_type"].ToString() == "FACEBOOK")
                    {
                        Session.Abandon();
                        //Response.Write("<script>facebookLogout();</script>");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "bf", "facebookLogout()", true);
                        //Response.Redirect("https://www.facebook.com/logout.php?next=http://hopeintomorrow.org");
                    }
                    Session.Abandon();

                }

                else                     //user has logged in using hit credentials not any social media 
                {

                    Session.Abandon();

                    Response.Redirect("~/Default.aspx");

                }

            }
        }
        catch (Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("Logout.aspx", ex.ToString());
            //Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
        }
    }
}