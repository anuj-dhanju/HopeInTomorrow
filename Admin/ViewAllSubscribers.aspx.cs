using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ViewAllSubscribers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin_id"] == null)
        {
            Response.Redirect("~/Admin/AdminLogin.aspx");
        }
        event_subs();
    }
    protected void event_subs()
    {
        event_subscriberBAL event_subBAL = new event_subscriberBAL();
      try
        {

            DataTable dt = event_subBAL.evetns_sub_userifoBAL();

            
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {

            Response.Write(ex.ToString());
        }
    }
    

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            
            e.Row.Cells[0].Text = "Event_id";
            e.Row.Cells[1].Text = "User_id";
            e.Row.Cells[2].Text = "Event_Title";
            e.Row.Cells[3].Text = "First-Name";
            e.Row.Cells[4].Text = "Last-Name";


            e.Row.Height = Unit.Pixel(30);

        }

    }
    
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        event_subs();
    }
}