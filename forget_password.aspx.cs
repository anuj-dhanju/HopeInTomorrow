using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class forget_password : System.Web.UI.Page
{
    UserFunctionsBAL sendmail = new UserFunctionsBAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] != null)
        {
            Response.Redirect("~/Default.aspx");
        }
    }


    protected void btnSendPassword_Click(object sender, EventArgs e)
    {
        try
        {
            String email = txtemail.Value.ToString();
            if (sendmail.ForgotPassword(email) == 1)
            {
                lblMessage.Text = "Your password has been mailed to your email id";
                lblMessage.Style.Value = "color:rgb(0,0,0)";
                txtemail.Value = "";
            }
            else
            {
                txtemail.Value = "";
                lblMessage.Text = "Email id is not registered...!";
                lblMessage.Style.Value = "color:rgb(255,0,0)";
            }
        }
        catch(Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("ForgetPassword.aspx", ex.ToString());
            Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
        }
    }
}