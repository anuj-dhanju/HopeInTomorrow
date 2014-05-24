using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Admin_newsEdit : System.Web.UI.Page
{
    AdminFunctionsBAL adminBlogFunctions = new AdminFunctionsBAL();
    eventsBO evt = new eventsBO();
    string pathimg;
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

                    if (Request.QueryString["type"] == null)
                    {
                        Response.Redirect("~/Admin/ViewAllEvents.aspx");
                    }
                    else
                    {
                        evt.event_id = Convert.ToInt32(Request.QueryString["id"]);
                        if (Request.QueryString["type"] == "Edit")
                        {
                            //dlEvent.DataSource = adminBlogFunctions.event_retrive(evt);
                            //dlEvent.DataBind();
                            DataSet ds = new DataSet();
                            ds = adminBlogFunctions.event_retrive(evt);
                            DataTable eventdata = new DataTable();
                            eventdata = ds.Tables[0];
                            DataView dv = eventdata.DefaultView;
                            DateTime dt = Convert.ToDateTime(dv[0]["event_time"]);
                            txtEventDate.Text = dt.ToShortDateString();
                            txtEventTime.Value = dt.ToShortTimeString();
                            txtEventTitle.Text = dv[0]["event_title"].ToString();
                            txtEventPlace.Text = dv[0]["event_place"].ToString();
                            txtEventDesc.Text = dv[0]["event_desc"].ToString();
                            pathimg = dv[0]["event_pic"].ToString();
                            if (pathimg!= "")
                            { pic.ImageUrl = pathimg; 
                                
                            }
                            else
                            { pic.ImageUrl = "~/img/no_image.gif"; pathimg = null; }
                            //ClientScript.RegisterStartupScript(this.GetType(), "image", "alert('" +picurl + "');", true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Error Ocured : " + ex.ToString());
                }

            }
        }
    }


    protected String DateTime1(DateTime d)
    {
        return d.ToShortDateString();
    }
    protected string Timedate(DateTime d)
    {
        return d.ToShortTimeString();
    }

    protected String DateTimeFormatting_full(DateTime d)
    {
        return d.ToShortDateString() + " " + d.ToShortTimeString();
    }


    protected String ChangeStringFormat(String s)
    {
        return Server.HtmlDecode(s);
    }
    
    protected void btnUpdateEvent_Click(object sender, EventArgs e)
    {
        try
        {
            evt.admin_id = Convert.ToInt32(Session["admin_id"]);

            evt.event_id = Convert.ToInt32(Request.QueryString["id"]);
            evt.event_title = txtEventTitle.Text;
            evt.event_time = Convert.ToDateTime(txtEventDate.Text + " " + txtEventTime.Value.ToString());
            evt.event_place = txtEventPlace.Text;
            evt.event_desc = txtEventDesc.Text;
            evt.date_time_of_post = System.DateTime.Now;
            if (pic_uploader.HasFile)
            {

                pic_uploader.SaveAs(Server.MapPath("~/Images/events/" + pic_uploader.FileName));
                string path1 = "~/Images/events/"+pic_uploader.FileName;
                evt.event_pic = path1;
            }
            else
            {
                evt.event_pic =pic.ImageUrl;

            }

            if (adminBlogFunctions.event_Bal_Update(evt) > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "image", "alert('Event Updated Successfully........');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "image", "alert('Sorry for Inconvenience And Check the Data Again.......');", true);
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "image", "alert('Sorry for Inconvenience And Check the Data Again......." + ex.ToString() + "');", true);
           /// Response.Write(ex.ToString());
        }
    }
}