using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HopeInTomorrow_UserMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] != null)
        {
            UserFunctionsBAL getusername = new UserFunctionsBAL();
            
            a_signin.InnerText = getusername.UserNameFetch(Convert.ToInt32(Session["user_id"]));
            a_signin.HRef = "UserProfileHome.aspx";
            a_joinus.InnerText = "Sign Out";
            a_joinus.HRef = "UserLogout.aspx";

           // a_verticalmenu_home.HRef = "UserProfileHome.aspx"; 

        }
    }
}
