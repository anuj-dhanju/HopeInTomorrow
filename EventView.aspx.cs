using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EventView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int Eid = 0;
        try
        {
            Eid = Convert.ToInt32(Request.QueryString["id"]);
            displayEventByID(Eid);



        }
        catch(Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("EventView.aspx", ex.ToString());
            String scr = "<script type='text/javascript'> alert('Some Error Occured , Sorry for Inconvenience'); </script> ";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script1", scr);
        }

    }

    protected void displayEventByID(int EventID)
    {
        AdminFunctionsBAL adminBlogFunctions = new AdminFunctionsBAL();
        eventsBO eventsbo = new eventsBO();
        eventsbo.event_id = EventID;
        try
        {
            DataSet dt = adminBlogFunctions.event_retrive(eventsbo);
            eventLoad.DataSource = dt;
            eventLoad.DataBind();

        }
        catch (Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("EventView.aspx", ex.ToString());
            String scr = "<script type='text/javascript'> alert('Some Error Occured , Sorry for Inconvenience'); </script> ";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script1", scr);
            
        }
    
    }
}