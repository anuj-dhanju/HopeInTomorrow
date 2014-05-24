using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdminHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin_id"] == null)
        {
            Response.Redirect("AdminLogin.aspx");
        }
        else
        {
            AdminFunctionsBAL newpostrequest = new AdminFunctionsBAL();

            long x = newpostrequest.numberOfNewPostRequest();
            long msg = newpostrequest.numberOfNewMsg();


            if (x > 0)
            {
                a_menu_BlogManagement.InnerText = "Blog Management ( " + x.ToString() + " New)";
            }
            if (msg > 0)
            {
                newMsg.Text =" ("+ msg.ToString()+")";
            }
        }
    }

    protected void bntLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("AdminLogin.aspx");
    }
    protected void lbtBlog_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminBlog.aspx");
    }
}