using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

public partial class donate_form : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    int usertype;  //CHECKING USER TYPE GLOBAL
    protected void donate_form_btn_click(object sender, EventArgs e)
    {
        if (Session["user_id"] == null)
        {
            try
            {
                usertype = 0;
                fillFundDetails();
            }
            catch (Exception ex)
            {
                ErrorReportBAL error = new ErrorReportBAL();
                error.SendErrorReport("DonateFrom.aspx", ex.ToString());
                Response.Write("<script> alert('Some error occor please try again later')</script>");
            }
        
            
        }
        else {

            try
            {
                usertype = 1;
                fillFundDetails();
            }
            catch (Exception ex)
            {
                ErrorReportBAL error = new ErrorReportBAL();
                error.SendErrorReport("DonateForm.aspx", ex.ToString());
                Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
            }
        
        }


      

        Session["x_amount"] = x_amount.Value;
        Response.Redirect("form1.aspx");
       
       
       

        


    }
    protected void fillFundDetails()
    {
        try
        {

            fundsBO fbo = new fundsBO();
            funds_BAL fbal = new funds_BAL();
            fbo.email_id = TB_Email.Value;
            fbo.first_name = TB_FirstName.Value;
            fbo.last_name = TB_LastName.Value;
            fbo.unknown_user = Convert.ToBoolean(usertype);
            fbal.funds_DAL_insert(fbo);
        }

        catch (Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("DonateForm.aspx", ex.ToString());
            Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
        }
    }
}