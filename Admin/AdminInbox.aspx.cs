using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdminInbox : System.Web.UI.Page
{
    AdminFunctionsBAL adminInboxFunctions = new AdminFunctionsBAL();
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

                    dlBlog.DataSource = adminInboxFunctions.AdminMsgLister();
                    dlBlog.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("Error Ocured : " + ex.ToString());
                }

            }
        }
    }



    protected void lbtnDelete_Click(object sender, CommandEventArgs e)
    {
        try
        {

            suggestionBO suggetionobj = new suggestionBO();
            suggetionobj.suggestion_id = Convert.ToInt32(e.CommandArgument.ToString());
            
            adminInboxFunctions.AdminMsgDelete(suggetionobj);
            Response.Redirect("~/admin/AdminInbox.aspx");
        }
        catch (Exception ex)
        {
            Response.Write("error occured : " + ex.ToString());
        }
    }

    
    protected void lbtnView_Click(object sender, CommandEventArgs e)
    {
        Response.Redirect("~/Admin/AdminMsgView.aspx?id=" + e.CommandArgument.ToString());
    }
    
    protected String DateTimeFormatting(DateTime d)
    {
        return d.ToShortDateString();
    }


   

    
}