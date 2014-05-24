using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HopeInTomorrow_ViewPost : System.Web.UI.Page
{
    blog_postBO blog = new blog_postBO();
    UserFunctionsBAL blogviewer = new UserFunctionsBAL();
    int id;


    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["viewBlog_id"] == null)
        {
            Response.Redirect("~/Blog.aspx");
        }

        else
        {

            try
            {
                id = Convert.ToInt32(Convert.ToInt32(Session["viewBlog_id"]));
                //Session["viewBlog_id"] = null; 
                blog = blogviewer.UserBlogViewer(id);

                if (blog == null)
                {
                    div_blog_title.InnerText ="Sorry, But the blog is not present";
                }
                else
                {

                    div_blog_title.InnerText = Server.HtmlDecode(blog.blog_title.ToString());
                    div_blog_date_time.InnerText = Server.HtmlDecode((blog.date_time_of_post).ToLongDateString());
                    div_blog_body.InnerHtml = Server.HtmlDecode(blog.blog_content.ToString());
                    spn_posterName.InnerText = Server.HtmlDecode((blogviewer.UserNameFetch(blog.poster_id)).ToString());   //getting the admin name from admin_id
                    spn_timeOfPost.InnerText = Server.HtmlDecode(blog.date_time_of_post.ToShortTimeString());


                    //lading the comments 
                    Listcomments();


                    if (!(Page.IsPostBack))
                    {
                        blogviewer.SetBlogViewCount(Convert.ToInt32(Session["viewBlog_id"]));
                    }

                }
            }
            
            catch (Exception ex)
            {
                ErrorReportBAL error = new ErrorReportBAL();
                error.SendErrorReport("ViewPost.aspx", ex.ToString());
                //Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
            }

        }
    }
    protected void btnPostComment_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["user_id"] != null)
            {
                if (txtcomment.Value.Trim() != "")
                {

                    blog_commentsBO usercomment = new blog_commentsBO();

                    //First : Post the comment 

                    usercomment.blog_id = id;
                    usercomment.is_admin = false;
                    usercomment.poster_id = Convert.ToInt32(Session["user_id"]);
                    usercomment.comment = txtcomment.Value.ToString();

                    blogviewer.BlogPostComments(usercomment);

                    txtcomment.Value = "";

                    // Second : Load the comments 

                    Listcomments();
                }

            }
            else
            {
                String loginStatus = "<script type='text/javascript'> alert('Sign In First To Post Any Comments'); </script>";
                ScriptManager.RegisterClientScriptBlock(this,this.GetType(),"loginStatus",loginStatus,false);
            }
        }
        catch(Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("ViewPost.aspx", ex.ToString());
            //Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
        }
    }


    protected String commenter_name(int id, int is_admin)
    {
        try
        {
            String name = "";
            if (is_admin == 0)
            {
                name = blogviewer.UserNameFetch(id);
            }
            else if (is_admin == 1)
            {
                name = blogviewer.AdminNameFetch(id);
            }

            return name;
        }
        catch (Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("ViewPost.aspx", ex.ToString());
            Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
            return null;
        }

    }

    protected void Listcomments()
    {
        try
        {

            dlBlogComments.DataSource = blogviewer.LoadBlogPostComments(id);
            dlBlogComments.DataBind();
        }
        catch (Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("ViewPost.aspx", ex.ToString());
            Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
        }
    }


    protected String LnToBr(String s)
    {
        String replaced_string = s.Replace("\n", "<br/>");
        return replaced_string;
    }


    protected bool checkForCommentOptions(int comment_id,int poster_id, int is_admin)
    {
        if (Session["user_id"] != null)          // means users has already been logged in 
        {
            if ((Convert.ToInt32(Session["user_id"])) == poster_id && is_admin == 0)     //It's the current logged in user's post , so its ok to load the options "Edit" & "Delete"
            {

            }

        }

            return true;
    }



    protected void lnkbtnDelete_Command(object sender, CommandEventArgs e)
    {
        try
        {
            blogviewer.DeleteBlogPostComments(Convert.ToInt32(e.CommandArgument));
            Listcomments();
        }
        catch(Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("ViewPost.aspx", ex.ToString());
            Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
        }

    }


    protected void dlBlogComments_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        //LinkButton delete_button = (LinkButton)dlBlogComments.FindControl("lnkbtnDelete");
        try
        {

            if (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "poster_id")) == Convert.ToInt32(Session["user_id"]) && Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "is_admin")) == 0)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl divoptions = (System.Web.UI.HtmlControls.HtmlGenericControl)e.Item.FindControl("div_blog_comment_options");

                LinkButton DeleteButton = new LinkButton();
                DeleteButton.ID = "lnkbtnDelete";
                DeleteButton.Command += new CommandEventHandler(lnkbtnDelete_Command);
                DeleteButton.CommandArgument = DataBinder.Eval(e.Item.DataItem, "comment_id").ToString();
                DeleteButton.CssClass = "lnkbtnDelete";
                DeleteButton.Text = "Delete";

                divoptions.Controls.Add(DeleteButton);

                ScriptManager1.RegisterAsyncPostBackControl(DeleteButton);


                //add the profile pic of the commenter 

            }

            Image imgpp = (Image)e.Item.FindControl("img_commenter_pic");
            imgpp.ImageUrl = GetImageUrl(Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "poster_id")), Convert.ToInt16(DataBinder.Eval(e.Item.DataItem, "is_admin")));
        }

        catch (Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("ViewPost.aspx", ex.ToString());
            Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
        }
    }


    protected String GetImageUrl(int poster_id, int is_admin)
    {
        try
        {

            if (is_admin == 0)
            {
                return blogviewer.GetProfilePicName(poster_id);
            }

            else
            {
                return "/Admin/Resources/Images/ProfilePic/Admin_pp.jpg";
            }
        }
        catch (Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("ViewPost.aspx", ex.ToString());
            //Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
            return null;
        }
    }
}