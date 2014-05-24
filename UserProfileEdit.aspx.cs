using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO; 




public partial class UserProfileEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["user_id"]!=null)
        {

        if (!Page.IsPostBack)
        {
            load_default_user_value();
            StatusLabel.Text = "";
        }

        }

        else
        {
            Response.Redirect("~/Default.aspx");
        }


    }
    protected void load_default_user_value()
    {
        try
        {
            user_infoBO ubo = new user_infoBO();
            UserFunctionsBAL ubal = new UserFunctionsBAL();
            ubo.user_id = Convert.ToInt32(Session["user_id"]);
            DataTable dt = new DataTable();
            dt = ubal.getAllUserInfo_bal(ubo);
            DataView dv = dt.DefaultView;
            tbUserFirstName.Value = Convert.ToString(dv[0]["first_name"]);
            tbUserLastName.Value = Convert.ToString(dv[0]["last_name"]);
            tbUserCity.Value = Convert.ToString(dv[0]["city"]);
            tbUserCountry.Value = Convert.ToString(dv[0]["country"]);

        }

        catch(Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("UserProfileEdit.aspx", ex.ToString());
            Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
        }
    }


    //protected void EnableTb_Click(object sender, EventArgs e)
    //{
    //    tbUserPassword.ReadOnly = false;
    //    tbNewPassword.ReadOnly = false;
        
    //}
    protected void UpdateData_Click(object sender, EventArgs e)
    {
        try
        {
            user_infoBO ubo = new user_infoBO();
            UserFunctionsBAL ubal = new UserFunctionsBAL();

            string filename = "";
            ubo.user_id = Convert.ToInt32(Session["user_id"]);
            ubo.first_name = tbUserFirstName.Value;
            ubo.last_name = tbUserLastName.Value;
            ubo.city = tbUserCity.Value;
            ubo.country = tbUserCountry.Value;

            if (tbUserPassword.Value.Trim() != "" && tbNewPassword.Value.Trim() != "")
            {
                ubo.password = tbUserPassword.Value;
                if (ubal.PasswordMatch(ubo))
                {
                    ubo.password = tbNewPassword.Value;
                    filename = ImgUpload();
                    ubo.profile_pic = "/Images/userprofilepic/" + filename;
                    ubal.ProfileUpdate(ubo);
                    StatusLabel.Text = "Profile Successfuly updated";


                }
                else
                {
                    StatusLabel.Text = "old password not match";
                }

            }
            else
            {
                if (ImgUpload() == null)
                {
                    StatusLabel.Text = "image is not valid";
                }
                else
                {
                    filename = ImgUpload();
                    ubo.profile_pic = "/Images/userprofilepic/" + filename;

                    ubo.password = ubal.getPassword(ubo);
                    ubal.ProfileUpdate(ubo);
                    StatusLabel.Text = "Profile Successfuly updated";
                }
            }


            Response.Redirect("~/UserProfileEdit.aspx");
        }

        catch (Exception ex)
        {
            ErrorReportBAL error = new ErrorReportBAL();
            error.SendErrorReport("UserProfileEdit.aspx", ex.ToString());
            Response.Write("<script>alert('Some Error Occured \n Sorry for inconvenience');</script>");
        }

    }

    public String ImgUpload()
    {
        string filename = "";
        String path = "";
        String completepath = "";

        try
        {
            if(PicUpload.HasFile  && (PicUpload.PostedFile.ContentType == "image/jpeg" || PicUpload.PostedFile.ContentType == "image/png" || PicUpload.PostedFile.ContentType == "image/gif"))
            {
               //pic is present and is of correct format 
 
                filename = PicUpload.FileName;
                path = Server.MapPath("~/images/userprofilepic/");
                String path_without_extension ;

                if (PicUpload.PostedFile.ContentType == "image/jpeg")
                {
                    filename = "pp_" + Session["user_id"].ToString() + ".jpg";
                    
                }
                else if (PicUpload.PostedFile.ContentType == "image/png")
                {
                    filename = "pp_" + Session["user_id"].ToString() + ".png";
                }
                else if (PicUpload.PostedFile.ContentType == "image/gif")
                {
                    filename = "pp_" + Session["user_id"].ToString() + ".gif";
                }

                completepath = path + filename;
                
                path_without_extension =  path + "pp_" + Session["user_id"].ToString();

                if(File.Exists(path_without_extension + ".jpg") || File.Exists(path_without_extension + ".png") || File.Exists(path_without_extension + ".gif") )
                {
                    //deleteing the previous existing file , jpg or png or gif

                    if(File.Exists(path_without_extension + ".jpg"))
                    {
                        File.Delete(path_without_extension + ".jpg");
                    }
                    if (File.Exists(path_without_extension + ".png"))
                    {
                        File.Delete(path_without_extension + ".png");
                    }
                    if(File.Exists(path_without_extension + ".gif"))
                    {
                        File.Delete(path_without_extension + ".gif");
                    }

                    
                }


                PicUpload.SaveAs(completepath);

                return filename;
            }
            else
            {
                return null;
            }
        }

        catch
        {

            return null;
        }

   
    }
   
 }
    
   

