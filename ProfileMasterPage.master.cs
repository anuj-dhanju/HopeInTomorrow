using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;




public partial class ProfileMasterPage : System.Web.UI.MasterPage
{
    
        
    UserFunctionsBAL getusername = new UserFunctionsBAL();
    UserFunctionsBAL blog = new UserFunctionsBAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (Session["user_id"] == null)
            {
                Response.Redirect("~/sign_in.aspx");
            }

            UserName.Text = getusername.UserNameFetch(Convert.ToInt32(Session["user_id"]));


            //profile_pic.Src = "/HitFromDeepak" + getusername.GetProfilePicName(Convert.ToInt32(Session["user_id"]));

            if (Session["user_login_social"] != null)
            {
                String image_path = Session["user_pp"].ToString();


                String[] newpath = image_path.Split('?');

                img_profile_pic.Src= newpath[0] + "?width=200&height=200";

            }

            else
            {
                img_profile_pic.Src = getusername.GetProfilePicName(Convert.ToInt32(Session["user_id"]));
            }

        }
        catch (Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("ProfileMasterPage.aspx", ex.ToString());
            Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
        }

    }
    

   
}
