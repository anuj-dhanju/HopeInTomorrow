using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserProfileSuggestion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        



        //------------------------loading news-------------------------

       
    }
    UserFunctionsBAL getusername = new UserFunctionsBAL();
    UserFunctionsBAL blog = new UserFunctionsBAL();

    
  
    //SENDING MAIL to admin 
    protected void suggestion_btn_click(object sender, EventArgs e)
    {
        Next_ID nid = new Next_ID();
        suggestionBO s_bo = new suggestionBO();
        suggestionBAL s_bal = new suggestionBAL();
        try
        {
            s_bo.suggestion_id = nid.incrementer("suggestion_id", "suggestion");
            s_bo.user_name = getusername.UserNameFetch(Convert.ToInt32(Session["user_id"]));
            s_bo.userEmail = getusername.UserEmailFetch(Convert.ToInt32(Session["user_id"]));
            s_bo.subject = DDLEmailSubject.SelectedValue.ToString();
            s_bo.suggestion_msg = writeEmail.Value;
            writeEmail.Value = "";

            //Server.HtmlEncode(hid_Email_body.Value.ToString());

            s_bo.date_time = Convert.ToDateTime(DateTime.Now.ToString());

            if (s_bal.suggestion_DAL_insert(s_bo) > 0)
            {
                Response.Write("<script type='text/javascript'> window.onload=function(){document.getElementById('parent').style.display='block';}; </script>");
                //Response.Redirect("~/UserProfile.aspx");

            }

        }
        catch (Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("UserProfileSuggestion.aspx", ex.ToString());
            Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
        }




    }

  

   
    
}