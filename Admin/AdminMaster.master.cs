using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdminMaster : System.Web.UI.MasterPage
{
    AdminFunctionsBAL adminBlogFunctions = new AdminFunctionsBAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin_id"] == null)
        {
            Response.Redirect("AdminLogin.aspx");
        }
        else
        {
            lblHelloAdmin.Text = "Welcome<b> " + adminBlogFunctions.AdminName(Convert.ToInt32(Session["admin_id"])) + "</b>";
        }

    }

    //protected void lnkbtnLogout_Click(object sender, EventArgs e)
    //{
    //    Session.Abandon();
    //    Response.Redirect("~/Admin/AdminLogin.aspx");
    //}
}
