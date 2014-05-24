using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Volunteers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin_id"] == null)
        {
            Response.Redirect("~/Admin/AdminLogin.aspx");
        }
        else
        {
            view_users(0);
        }


    }
    protected void view_users(int x)
    {
        user_infoBAL uBAL = new user_infoBAL();
        user_infoBO uBO = new user_infoBO();
        uBO.user_type = x;

        try
        {

            DataTable dt = uBAL.view_users(uBO);
            GridView1.AllowPaging = true;
            GridView1.DataSource = dt;
            
            GridView1.DataBind();
          
            
        }
        catch (Exception ex)
        {

            Response.Write(ex.ToString());
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        user_infoBAL uBAL = new user_infoBAL();
        user_infoBO uBO = new user_infoBO();
        TableCell cell = GridView1.Rows[e.RowIndex].Cells[1];
        string abc = cell.Text;
        uBO.user_id = Convert.ToInt32(abc);


        try
        {
            uBAL.delete_users(uBO);
            Response.Write("<script>alert('Data deleted successfully " + abc + "');</script>");

            view_users(0);
        }
        catch (Exception ex)
        {

            Response.Write(ex.ToString());
        }
    }
    //Changing Header Text in GridView
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)

    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Text = "select";
            e.Row.Cells[1].Text = "User-ID";
            e.Row.Cells[2].Text = "Email-ID";
            e.Row.Cells[3].Text = "First-Name";
            e.Row.Cells[4].Text = "Last-Name";
            e.Row.Cells[5].Text = "User-Type";
            e.Row.Cells[6].Text = "Country";
            e.Row.Cells[7].Text = "City";
            e.Row.Cells[8].Text = "Join Date";
            e.Row.Cells[9].Text = "Profile Pic";
            e.Row.Height = Unit.Pixel(30);
          

        }
        

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        view_users(0);
    }
}