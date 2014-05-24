using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Admin_ImageSlider : System.Web.UI.Page
{

    ImageSliderBAL sliderfunctions = new ImageSliderBAL();
    image_sliderBO sliderinfo = new image_sliderBO();

    protected void Page_Load(object sender, EventArgs e)
    {

        AdminFunctionsBAL newpostrequest = new AdminFunctionsBAL();

        long x = newpostrequest.numberOfNewPostRequest();

        if (x > 0)
        {
            a_menu_BlogManagement.InnerText = "Blog Management ( " + x.ToString() + " New)";
        }

        DataTable dt = sliderfunctions.LoadImageInSlider();
        int k = 0;
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow i in dt.Rows)
            {

                //div main image & controls holder 

                k++;

                Panel pnl = new Panel();
                pnl.ID = "div_pnl" + k.ToString();
                pnl.CssClass = "div_pnl";
                pnl.Attributes["onmouseover"] = "showInfoText(" + k.ToString() + ");";
                pnl.Attributes["onmouseout"] = "hideInfoText(" + k.ToString() + ");";

                Panel pnlEdit = new Panel();                              //Edit Button div
                pnlEdit.ID = "lnkbtnEdit" + k.ToString();
                pnlEdit.CssClass = "div_pnlEdit";
                pnlEdit.Attributes["onclick"] = "showEditPanel(" + k.ToString() + ");";

                    Label pnlEditText = new Label();                    //Edit Button
                    pnlEditText.Text = "Edit";
                    pnlEditText.ID = "pnl_EditText_" + k.ToString();

                    pnlEdit.Controls.Add(pnlEditText);
                
                Panel pnlDelete = new Panel();                              //Delete Button Div
                pnlDelete.ID = "lnkbtnDelete" + k.ToString();
                pnlDelete.CssClass = "div_pnlDelete";
                pnlDelete.Attributes["onclick"] = "showDeleteWarning(" + k.ToString() + ");";
                    Label pnlDeleteText = new Label();                      //Delete Button
                    pnlDeleteText.Text = "Delete";
                    pnlDeleteText.ID = "pnl_DeleteText_" + k.ToString();

                    pnlDelete.Controls.Add(pnlDeleteText);


                Image img = new Image();
                img.Height = Unit.Pixel(170);
                img.Width = Unit.Pixel(300);
                img.ImageUrl = i[2].ToString();




                //div image info 

                Panel info = new Panel();
                info.ID = "div_info" + k.ToString();
                info.CssClass = "div_pnlinfo";
                Label lblinfo = new Label();
                lblinfo.Text = i[1].ToString();
                info.Controls.Add(lblinfo);



                //div image delete warning message 

                Panel deleteWarning = new Panel();
                deleteWarning.ID = "div_deleteWarning" + k.ToString();
                deleteWarning.CssClass = "div_deleteWarning";
                
                Panel DeleteWarningMessage = new Panel();
                DeleteWarningMessage.ID = "div_deleteWarningMessage" + k.ToString();
                DeleteWarningMessage.CssClass = "div_deleteWarningMessage";

                    Label lbldeleteWarning = new Label();
                    lbldeleteWarning.Text = " Are you sure you want to delete this image ? ";
                    lbldeleteWarning.CssClass = "lblDeleteWarning";

                    DeleteWarningMessage.Controls.Add(lbldeleteWarning);
                    
                Panel DeleteButtonHolder = new Panel();
                DeleteButtonHolder.ID = "div_EditPanelButtonHolder" + k.ToString();
                DeleteButtonHolder.CssClass = "divEditPanelButtonHolder";

                Button btnDelete = new Button();
                btnDelete.Text = "Delete";
                btnDelete.CommandArgument = i[0].ToString();
                btnDelete.Command += new CommandEventHandler(btnDelete_Command);
                btnDelete.CssClass = "btnDelete";

                Panel pnlDeleteWarningCancel = new Panel();
                pnlDeleteWarningCancel.ID = "div_deleteWarningCancel" + k.ToString();
                pnlDeleteWarningCancel.CssClass = "div_deleteWarningCancel_button";
                pnlDeleteWarningCancel.Attributes["onclick"] = "hideDeleteWarning(" + k.ToString() +");";

                    Label lblDeleteWarningCancel_text = new Label();
                    lblDeleteWarningCancel_text.Text = "Cancel";
                    lblDeleteWarningCancel_text.ID = "lblDeleteWarningCancel_text" + k.ToString();

                    pnlDeleteWarningCancel.Controls.Add(lblDeleteWarningCancel_text);


                    DeleteButtonHolder.Controls.Add(btnDelete);
                    DeleteButtonHolder.Controls.Add(pnlDeleteWarningCancel);

                deleteWarning.Controls.Add(DeleteWarningMessage);
                deleteWarning.Controls.Add(DeleteButtonHolder);




                //div image edit panel 

                Panel editImage = new Panel();
                editImage.ID = "div_editImage" + k.ToString();
                editImage.CssClass = "div_editImage";

                TextBox txtImgInfo = new TextBox();
                txtImgInfo.Text = i[1].ToString();
                txtImgInfo.ID = "txt_imgInfo" + k.ToString();
                txtImgInfo.CssClass = "txt_imgInfo";

                FileUpload ImageUpload = new FileUpload();
                ImageUpload.ID = "ImageUpload" + k.ToString();
                ImageUpload.CssClass = "imgUpload";

                Panel ButtonHolder = new Panel();
                ButtonHolder.ID = "div_EditPanelButtonHolder" + k.ToString();
                ButtonHolder.CssClass = "divEditPanelButtonHolder";

                Button btnSave = new Button();
                btnSave.Text = "Save";
                btnSave.CommandArgument = i[0].ToString();
                btnSave.Command += new CommandEventHandler(btnSave_Command);
                btnSave.CssClass = "btnSave";

                Panel pnlEditImageCancel = new Panel();
                pnlEditImageCancel.ID = "div_editImageCancel" + k.ToString();
                pnlEditImageCancel.CssClass = "div_editImageCancel_button";
                pnlEditImageCancel.Attributes["onclick"] = "hideEditPanel(" + k.ToString() + ");";

                    Label lblEditImageCancel_text = new Label();
                    lblEditImageCancel_text.Text = "Cancel";
                    lblEditImageCancel_text.ID = "lblEditImageCancel_text" + k.ToString();

                    pnlEditImageCancel.Controls.Add(lblEditImageCancel_text);


                    ButtonHolder.Controls.Add(btnSave);
                    ButtonHolder.Controls.Add(pnlEditImageCancel);


                
                editImage.Controls.Add(txtImgInfo);
                editImage.Controls.Add(ImageUpload);

                editImage.Controls.Add(ButtonHolder);


                //add the controls to image & controls holder division  

                pnl.Controls.Add(img);
                pnl.Controls.Add(info);
                pnl.Controls.Add(pnlEdit);
                pnl.Controls.Add(pnlDelete);
                pnl.Controls.Add(deleteWarning);
                pnl.Controls.Add(editImage);
                //Add the panel to the page 

                div_images.Controls.Add(pnl);

                


            }


            dt.Dispose();
        }
    }

    protected void btnSave_Command(object sender, CommandEventArgs e)
    {
        try
        {
            Panel mainImagePanel = (Panel)div_images.FindControl("div_pnl"+e.CommandArgument.ToString());
            Panel editPanel = (Panel)mainImagePanel.FindControl("div_editImage"+e.CommandArgument.ToString());
            TextBox txtImgInfo = (TextBox)editPanel.FindControl("txt_imgInfo" + e.CommandArgument.ToString());
            FileUpload newImage = (FileUpload)editPanel.FindControl("ImageUpload"+e.CommandArgument.ToString());
            sliderinfo.img_info = txtImgInfo.Text.Trim();
            sliderinfo.img_id = Convert.ToInt32(e.CommandArgument);

            sliderfunctions.EditImageAndInfo(sliderinfo);

            if (newImage.HasFile && (newImage.PostedFile.ContentType == "image/jpeg" || newImage.PostedFile.ContentType == "image/png" || newImage.PostedFile.ContentType == "image/gif"))
            {
                String path = Server.MapPath("~/Images/sliderImages/");
                String filename = e.CommandArgument.ToString() + ".jpg";

                if (newImage.PostedFile.ContentType == "image/jpeg")
                {
                    filename = e.CommandArgument.ToString() + ".jpg";                    
                }
                else if (newImage.PostedFile.ContentType == "image/png")
                {
                    filename = e.CommandArgument.ToString() + ".png";
                }
                else if (newImage.PostedFile.ContentType == "image/gif")
                {
                    filename = e.CommandArgument.ToString() + ".gif";
                }

                if (File.Exists(path + e.CommandArgument.ToString() + ".jpg"))
                {
                    File.Delete(path + e.CommandArgument.ToString() + ".jpg");
                }

                if (File.Exists(path + e.CommandArgument.ToString() + ".png"))
                {
                    File.Delete(path + e.CommandArgument.ToString() + ".png");
                }

                if (File.Exists(path + e.CommandArgument.ToString() + ".gif"))
                {
                    File.Delete(path + e.CommandArgument.ToString() + ".gif");
                }

                newImage.SaveAs(path + filename);

                
            }

            String scr = "<script> alert('Image Updated');window.location='ImageSlider.aspx'; </script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "error", scr);
        }
        catch (Exception ex)
        {
            ErrorReportBAL ErrorReport = new ErrorReportBAL();
            ErrorReport.SendErrorReport("ImageSlider", ex.ToString());
            String scr = "<script> alert('Some error has occured , please try again later '); </script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "error", scr);
        }
    }

    protected void btnDelete_Command(object sender, CommandEventArgs e)
    {
        try
        {
            sliderfunctions.DeleteImage(Convert.ToInt32(e.CommandArgument));
            String path = Server.MapPath("~/Images/sliderImages/");

            if (File.Exists(path + e.CommandArgument.ToString() + ".jpg"))
            {
                File.Delete(path + e.CommandArgument.ToString() + ".jpg");
            }

            if (File.Exists(path + e.CommandArgument.ToString() + ".png"))
            {
                File.Delete(path + e.CommandArgument.ToString() + ".png");
            }

            if (File.Exists(path + e.CommandArgument.ToString() + ".gif"))
            {
                File.Delete(path + e.CommandArgument.ToString() + ".gif");
            }

            String scr = "<script> alert('Image Deleted'); window.location='ImageSlider.aspx'; </script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "delete message", scr);
        }
        catch(Exception ex)
        {
            ErrorReportBAL ErrorReport = new ErrorReportBAL();
            ErrorReport.SendErrorReport("ImageSlider", ex.ToString());
            String scr = "<script> alert('Some error has occured , please try again later '); </script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "error", scr);

        }
    }


    protected void btnAddNewImage_Click(object sender, EventArgs e)
    {
        try
        {

            if (NewImageUpload.HasFile && (NewImageUpload.PostedFile.ContentType == "image/jpeg" || NewImageUpload.PostedFile.ContentType == "image/png" || NewImageUpload.PostedFile.ContentType == "image/gif"))
            {

                String newimagename = sliderfunctions.NextImageName(NewImageUpload.FileName);

                String path = Server.MapPath("~/Images/sliderImages/");
                String fullimgpath = path + newimagename;


                if (File.Exists(fullimgpath))
                {
                    File.Delete(fullimgpath);
                }

                NewImageUpload.SaveAs(fullimgpath);

                sliderfunctions.SaveNewImage(newimagename);

                Response.Redirect("~/Admin/ImageSlider.aspx");

            }
        }

        catch (Exception ex)
        {
            ErrorReportBAL reportError = new ErrorReportBAL();
            reportError.SendErrorReport("ImageSlider.aspx",ex.ToString());
        }
    }


}