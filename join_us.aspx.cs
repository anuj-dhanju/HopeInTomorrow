using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class join_us : System.Web.UI.Page
{
    UserFunctionsBAL continent = new UserFunctionsBAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["user_id"] != null)
            {
                Response.Redirect("~/login_user.aspx");
            }

            rdoVolunteer.Checked = true;
            loadcountry();
        }
    }


    protected void bntJoinMe_Click(object sender, EventArgs e)
    {
        try
        {

            UserFunctionsBAL registeruser = new UserFunctionsBAL();

            user_infoBO user_info = new user_infoBO();

            String email_id = user_info.email_id = txtEmail.Value.ToString();
            user_info.first_name = txtFname.Value.ToString();
            user_info.last_name = txtLname.Value.ToString();
            user_info.country = ListCountry.SelectedValue.ToString();
            user_info.city = StateLoad.SelectedValue.ToString();
            user_info.password = txtPassword.Value.ToString();
            if (rdoBlogger.Checked == true)
            {
                user_info.user_type = 1;
            }
            else
            {
                user_info.user_type = 0;
            }

            int check = registeruser.NewUserRegister(user_info);

            if (check == 1)
            {
                Response.Write("<script type='text/javascript'> alert('Email ID Already Registered ... !') </script>");
            }
            else if (check == 2)
            {
                //Response.Write("<script>alert('Thanks For Joining Us ... !'); </script>");
                registeruser.JoinUsMail(email_id);

                String okmessage = "<script type='text/javascript'>  alert('Thank You For Joining Us'); </script>";

                Page.ClientScript.RegisterStartupScript(this.GetType(), "okmessage", okmessage);

                //Response.Redirect("~/sign_in.aspx");
            }

            txtEmail.Value = "";
            txtFname.Value = "";
            txtLname.Value = "";
            rdoBlogger.Checked = false;
            rdoVolunteer.Checked = false;
        }
        catch (Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("JoinUs.aspx", ex.ToString());
            Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
        }

    }
    private void loadcountry()
    {
        try
        {
            DataTable dt = (DataTable)((DataSet)continent.continent_retriveBAL()).Tables[0];
            ListCountry.DataSource = dt;
            ListCountry.DataTextField = "country";
            ListCountry.DataValueField = "id";

            ListCountry.DataBind();
            ListCountry.Items.Insert(0, new ListItem("Select Country", "0"));
        }
        catch (Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("JoinUs.aspx", ex.ToString());
            Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
        }

    }
    protected void ListCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int cid = Convert.ToInt32(ListCountry.SelectedValue);
            DataView dv = continent.region_retriveBAL().DefaultView;
            dv.RowFilter = "state_id='" + cid + "'";
            StateLoad.DataSource = dv;
            StateLoad.DataTextField = "state";
            StateLoad.DataValueField = "State_id";

            StateLoad.DataBind();
            StateLoad.Items.Insert(0, new ListItem("Select State", "0"));
        }
        catch (Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("JoinUs.aspx", ex.ToString());
            Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
        }
    }
}




