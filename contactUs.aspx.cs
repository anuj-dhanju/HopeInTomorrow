using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HopeInTomorrow_contactUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void send_feedBack(object sender, EventArgs e)
    {

        Next_ID nid = new Next_ID();
        suggestionBAL sBal = new suggestionBAL();
        suggestionBO sBO = new suggestionBO();
        try
        {
            sBO.user_name = sugName.Value.Trim() + suglName.Value.Trim();
            sBO.suggestion_id = nid.incrementer("suggestion_id", "suggestion");
            sBO.suggestion_msg = comments.Value;
            sBO.date_time = Convert.ToDateTime(DateTime.Now.ToString());
            sBO.userEmail = txtemail.Value;
            sBO.subject = "";
            

            if (sBal.suggestion_DAL_insert(sBO) > 0)
            {
                Response.Write("<script>alert('Thansk for your valuable feedback ');</script>");
                sugName.Value = "";
                comments.Value = "";
                txtemail.Value = "";
            }
        }
        catch (Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("ContachUs.aspx", ex.ToString());
            Response.Write("<script>alert('An error occured \n Sorry for inconvenience ');</script>");
        }
    }
}