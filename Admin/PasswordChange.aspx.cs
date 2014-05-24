using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_PasswordChange : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnChangepass_Click(object sender, EventArgs e)
    {
        AdminFunctionsBAL adminfunction = new AdminFunctionsBAL();
        admin_infoBO admin_info = new admin_infoBO();

    }
}