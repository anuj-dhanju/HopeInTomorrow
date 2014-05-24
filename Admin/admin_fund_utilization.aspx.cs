using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Admin_fund_utilization : System.Web.UI.Page
{
    fund_utilizationBAL fundBAL = new fund_utilizationBAL();
    fund_utilizationBO fundBO = new fund_utilizationBO();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["admin_id"] == null)
        {
            Response.Redirect("AdminLogin.aspx");
        }
        else
        {
            if (!IsPostBack)
            {

                fundBO = fundBAL.fund_info_retrive();

                upper_desc.Value = fundBO.upper_detail;
                first_desc.Value = fundBO.first_utilization;
                second_desc.Value = fundBO.second_utilization;
                third_desc.Value = fundBO.third_utilization;
                fourth_desc.Value = fundBO.fourth_utilization;
            }
        }
    }
   protected void submit_desc(object sender, EventArgs e)
    {
        fundBO.upper_detail = upper_desc.Value;
        fundBO.first_utilization = first_desc.Value;
        fundBO.second_utilization = second_desc.Value;
        fundBO.third_utilization = third_desc.Value;
        fundBO.fourth_utilization = fourth_desc.Value;
        if (fundBAL.fund_info_save(fundBO))
        {
            Response.Write("<script> alert('Value is successfully submit')</script>");
        };
    }
}