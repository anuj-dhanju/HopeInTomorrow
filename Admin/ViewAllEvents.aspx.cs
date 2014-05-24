using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewAllEvents : System.Web.UI.Page
{
    AdminFunctionsBAL adminBlogFunctions = new AdminFunctionsBAL();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["admin_id"] == null)
        {
            Response.Redirect("~/Admin/AdminLogin.aspx");
        }
        else
        {
            if (!(Page.IsPostBack))
            {
                try
                {
                    eventsBO eventbo=new eventsBO();
                    eventbo.event_id=Convert.ToInt32(Request.QueryString["id"]);
                    if (Request.QueryString["type"] == "Delete")
                    {
                        if (adminBlogFunctions.event_BAL_delete(eventbo) > 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "fun", "alert('Event Remove Successfully..........');", true);
                        }
                        else
                        {
                           ClientScript.RegisterStartupScript(this.GetType(), "fun", "alert('Sorry For Inconvenience......');", true);

                        }
                    }
                    dlEvent.DataSource = adminBlogFunctions.AdminEventLister();
                    dlEvent.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("Error Ocured : " + ex.ToString());
                }

            }
        }
    }


    protected String DateTimeFormatting(DateTime d)
    {
        return d.ToShortDateString();
    }

    protected String DateTimeFormatting_full(DateTime d)
    {
        return d.ToShortDateString() + " " + d.ToShortTimeString();
    }


    protected String ChangeStringFormat(String s)
    {
        return Server.HtmlDecode(s);
    }
    protected void lbtnView_Command(object sender, CommandEventArgs e)
    {
       

    }
    protected void lbtnEdit_Command(object sender, CommandEventArgs e)
    {

    }
    protected void lbtnDelete_Command(object sender, CommandEventArgs e)
    {

    }
}