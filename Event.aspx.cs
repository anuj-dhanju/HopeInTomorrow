using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Event : System.Web.UI.Page
{

    

    protected void Page_Load(object sender, EventArgs e)
    {
        int Eid = 0;
        try
        {
            Eid = Convert.ToInt32(Request.QueryString["id"]);
            if (Eid == 0)
            {
                loadEvent();
            }
            else { displayEventByID(Eid); }

        }
        catch(Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("Event.aspx", ex.ToString());
            Response.Write("<script>alert('Sorry for inconvenience');</script>"); 
        }



        

    }

    protected String datelongformat(DateTime d)
    {
        return d.ToLongDateString();
        
    }

    protected String timeshortformat(DateTime d)
    {
        return d.ToShortTimeString();

    }

    protected void loadEvent()
    {

        AdminFunctionsBAL adminBlogFunctions = new AdminFunctionsBAL();
        eventsBO eventsbo = new eventsBO();
        event_subscriberBO ebo = new event_subscriberBO();
        event_subscriberBAL ebal = new event_subscriberBAL();
        try
        {
            DataSet ds = adminBlogFunctions.AdminEventLister();
            eventLoad.DataSource = ds;
            eventLoad.DataBind();
        }
    
        catch (Exception ex)
        {
            //throw;
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("Event.aspx", ex.ToString());
            Response.Write("<script>alert('Sorry for inconvenience');</script>");
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
            //throw;
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("Event.aspx", ex.ToString());
            Response.Write("<script>alert('Sorry for inconvenience');</script>");
        }

    }
  



    protected void subscribeToIvent_Command(object sender, CommandEventArgs e)
    {
        event_subscriberBAL event_bal = new event_subscriberBAL();
        event_subscriberBO event_bo = new event_subscriberBO();

        event_bo.user_id = Convert.ToInt32(Session["user_id"]);  
        event_bo.event_id = Convert.ToInt32(e.CommandArgument.ToString());


        try
        {

            //if (Session["user_id"] == null)
            //{
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Script", "alert('Please Login First');", true);
            //}
            //else if (event_bal.eventSubscriber_getEvent_id_DAL(event_bo))
            //{
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Script", "alert('You Already Subscribe To This Event');", true);
            //}

            if (event_bal.evetnsubscriberDAL(event_bo)>0)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Script", "alert('You are subscribed to this event');window.open('Event.aspx','_self');", true);
            }

            //Response.Redirect("~/Event.aspx");
        }
        catch (Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("Event.aspx", ex.ToString());
            Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
        }



    }


    protected void Unsubscribe_Command(object sender, CommandEventArgs e)
    {
        event_subscriberBAL event_bal = new event_subscriberBAL();
        event_subscriberBO event_bo = new event_subscriberBO();

        event_bo.user_id = Convert.ToInt32(Session["user_id"]);
        event_bo.event_id = Convert.ToInt32(e.CommandArgument.ToString());

        try
        {

            //if (Session["user_id"] == null)
            //{
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Script", "alert('Please Login First');", true);
            //}
            //else if (event_bal.eventSubscriber_getEvent_id_DAL(event_bo) == false)
            //{
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Script", "alert('You Are Not Subscribed To This Event');", true);
            //}

            if (event_bal.evetnUnSubscribeDAL(event_bo) > 0)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Script", "alert('You Successfully Unsubscribed From This Event'); window.open('Event.aspx','_self');", true);
            }


        }
        catch (Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("Event.aspx", ex.ToString());
            Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
        }
    }

    //protected void load_all_subscibed_ID()
    //{
    //    event_subscriberBAL ebal = new event_subscriberBAL();
    //    event_subscriberBO ebo = new event_subscriberBO();

    //    ebo.user_id = Convert.ToInt32(Session["user_id"]);
    //    DataSet dtUserRegistered = new DataSet();
    //    dtUserRegistered = ebal.eventSubscriber_getSubscibedEventID_DAL(ebo);
      
    //}
    protected void eventLoad_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            event_subscriberBAL event_bal = new event_subscriberBAL();
            event_subscriberBO event_bo = new event_subscriberBO();

            if (Session["user_id"] != null)
            {
                event_bo.user_id = Convert.ToInt32(Session["user_id"]);
                event_bo.event_id = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "event_id"));

                ImageButton imgbtn_subscribe_unsubs = new ImageButton();
                imgbtn_subscribe_unsubs.CssClass = "subscribe_btn";


                if (event_bal.eventSubscriber_getEvent_id_DAL(event_bo))       //already subscribbed make the unsubscribe button 
                {
                    imgbtn_subscribe_unsubs.ImageUrl = "img/unsubscibe.png";
                    imgbtn_subscribe_unsubs.Command += new CommandEventHandler(Unsubscribe_Command);
                    imgbtn_subscribe_unsubs.CommandArgument = DataBinder.Eval(e.Item.DataItem, "event_id").ToString();
                }

                else                                                          //not subcribbed to any event 
                {
                    imgbtn_subscribe_unsubs.ImageUrl = "img/subscibe.png";
                    imgbtn_subscribe_unsubs.Command += new CommandEventHandler(subscribeToIvent_Command);
                    imgbtn_subscribe_unsubs.CommandArgument = DataBinder.Eval(e.Item.DataItem, "event_id").ToString();
                }


                System.Web.UI.HtmlControls.HtmlGenericControl div_subscribe = (System.Web.UI.HtmlControls.HtmlGenericControl)e.Item.FindControl("subscribe");

                div_subscribe.Controls.Add(imgbtn_subscribe_unsubs);
            }

            else
            {
                ImageButton imgbtn_subscribe = new ImageButton();
                imgbtn_subscribe.OnClientClick = "SignInMessage();";
                imgbtn_subscribe.CssClass = "subscribe_btn";
                imgbtn_subscribe.ImageUrl = "img/subscibe.png";
                System.Web.UI.HtmlControls.HtmlGenericControl div_subscribe = (System.Web.UI.HtmlControls.HtmlGenericControl)e.Item.FindControl("subscribe");
                div_subscribe.Controls.Add(imgbtn_subscribe);

            }
        }
        catch (Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("Event.aspx", ex.ToString());
            //Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
        }
    }
}