using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sign_in : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] != null)
        {
            Response.Redirect("~/Default.aspx");
        }

    }
    protected void sign_in_btn_ServerClick(object sender, EventArgs e)
    {
        try
        {

            user_infoBO user_creadentails = new user_infoBO();
            UserFunctionsBAL usersignin = new UserFunctionsBAL();
            user_creadentails.email_id = txtEmail.Value.ToString();
            user_creadentails.password = txtPassword.Value.ToString();

            if (usersignin.UserSigIn(user_creadentails))
            {
                Session["user_id"] = Convert.ToInt32(usersignin.UserIdFetch(user_creadentails.email_id));
                
                Response.Redirect("~/UserProfileHome.aspx");
            }
            else
            {
                lblErrorMessage.Text = "Username Or Password Incorrect...!";
            }


        }
        catch (Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("SignIn.aspx", ex.ToString());
            Response.Write("<script type='text/javascript'> $(function(){alert('Some Error Occured \n Please try again later')}); </script>");
        }



    }
   
   
}