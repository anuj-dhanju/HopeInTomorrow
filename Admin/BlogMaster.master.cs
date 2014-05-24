using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_BlogMaster : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {

        AdminFunctionsBAL newpostrequest = new AdminFunctionsBAL();

        long x = newpostrequest.numberOfNewPostRequest();

        if (x > 0)
        {
            a_menu_newPostRequest.InnerText = "New Post Request (" + x.ToString() + ")"; 
        }
    }
}
