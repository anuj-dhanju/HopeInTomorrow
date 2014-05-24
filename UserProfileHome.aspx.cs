using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class 
    
    
    UserProfileHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            if (Session["user_id"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            load_news();
            LoadLatestEvents();

        }

        public void load_news()
        {
            newsBO n_bo = new newsBO();
            newsBAL n_bal = new newsBAL();
            try
            {
                DataSet ds = n_bal.news_top3_BAL_view();
                news.DataSource = ds;
                news.DataBind();

            }
            catch (Exception ex)
            {
                ErrorReportBAL error = new ErrorReportBAL();
                error.SendErrorReport("UserProfleHome.aspx", ex.ToString());
                Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
            }

        }

        public void LoadLatestEvents()
        {
            AdminFunctionsBAL viewTop5events = new AdminFunctionsBAL();
            if (!(Page.IsPostBack))
            {
                try
                {
                    top5EventsDL.DataSource = viewTop5events.TopFiveEvents();
                    top5EventsDL.DataBind();
                }
                catch (Exception ex)
                {
                    ErrorReportBAL error = new ErrorReportBAL();
                    error.SendErrorReport("UserProfileHome.aspx", ex.ToString());
                    Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
                }
            }

        }
        protected String datelongformat(DateTime d)
        {
            return d.ToLongDateString();
        }


    }
