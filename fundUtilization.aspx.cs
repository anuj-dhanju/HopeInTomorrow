using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class fundUtilization : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        fund_utilizationBAL fundBAL = new fund_utilizationBAL();
        fund_utilizationBO fundBO = new fund_utilizationBO();
        fundBO= fundBAL.fund_info_retrive();
        upper_desc.Text = fundBO.upper_detail;
        first_desc.Text= fundBO.first_utilization;
        second_desc.Text = fundBO.second_utilization;
        third_desc.Text = fundBO.third_utilization;
        fourth_desc.Text = fundBO.fourth_utilization;
      
    } 

}