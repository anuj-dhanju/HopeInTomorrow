using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SocialLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
        {
        


                string socialType = Request["socialType"];
                string txtEmail = Request["email"];
                string name = Request["name"];
                Boolean social = Request["social"].ToString() == "yes" ? true : false;
                string profile_pic = Request["image"];
                Response.Write(socialType + txtEmail + name + social + profile_pic);



                try
                {

                    user_infoBO social_login_info = new user_infoBO();
                    UserFunctionsBAL usersignup = new UserFunctionsBAL();
                    social_login_info.email_id = txtEmail;
                    social_login_info.first_name = name;
                    social_login_info.social_type = socialType;
                    social_login_info.social = social;
                    social_login_info.profile_pic = profile_pic;

                    if (usersignup.UserSignUp(social_login_info))
                    {
                        Session["user_id"] = Convert.ToInt32(usersignup.UserIdFetch(social_login_info.email_id));
                        Session["user_login_social"] = "yes";
                        Session["user_login_type"] = socialType;
                        Session["user_pp"] = profile_pic;
                        //Response.Write(Session["user_pp"].ToString());
                        Response.Redirect("~/UserProfileHome.aspx");
                    }
                    //else
                    //{
                    //    lblErrorMessage.Text = "Username Or Password Incorrect...!";
                    //}


                }
                catch (Exception ex)
                {
                    ErrorReportBAL error = new ErrorReportBAL();
                    error.SendErrorReport("SocialLogin.aspx", ex.ToString());
                    Response.Write("<script type='text/javascript'> alert('Some Error Occured \n Please try again later'); </script>");
                   
                }
            }
                

            

    }
