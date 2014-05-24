using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ImageSliderBAL slider_function = new ImageSliderBAL();

        DataTable dt = new DataTable();
        dt = slider_function.LoadImageInSlider();

         int k = 0;

         int max_val = dt.Rows.Count, min_val=1;
         try
         {
             if (dt.Rows.Count > 0)
             {
                 foreach (DataRow i in dt.Rows)
                 {
                     k++;

                     Panel div_slider = new Panel();                          //div image holder 
                     div_slider.CssClass = "im";
                     div_slider.ID = "slider_" + k.ToString();
                     //div_slider.Style.Add("background-image", "url("+ i[2].ToString() +")");
                     char[] r = { '.', '.', '/' };
                     div_slider.BackImageUrl = i[2].ToString().TrimStart(r);



                     Panel div_slider_info_img = new Panel();                     //div & information bar image 
                     div_slider_info_img.CssClass = "div_slider_info";
                     div_slider_info_img.ID = "div_slider_info_img_" + k.ToString();


                     Panel div_slider_info = new Panel();                    //div information holder 
                     div_slider_info.CssClass = "slider_info";
                     div_slider_info.ID = "div_slider_info_" + k.ToString();


                     Label spn_slider_info_headtext = new Label();               //span Info Text : First Word 
                     spn_slider_info_headtext.Style.Add("font-size", "14px");
                     spn_slider_info_headtext.ID = "spn_head_text_" + k.ToString();

                     String[] temp = i[1].ToString().Split(' ');
                     spn_slider_info_headtext.Text = temp[0].ToString();

                     Label spn_slider_info_resttext = new Label();                        //span Info Text : rest of the text 
                     spn_slider_info_headtext.ID = "spn_rest_text_" + k.ToString();
                     spn_slider_info_resttext.Text = i[1].ToString();




                     //joining panels 


                     div_slider_info.Controls.Add(spn_slider_info_headtext);         //internal div for slider info 
                     div_slider_info.Controls.Add(spn_slider_info_resttext);



                     div_slider_info_img.Controls.Add(div_slider_info);            //Adding the internal div to middle div 


                     div_slider.Controls.Add(div_slider_info_img);                  // Adding the middle div to the external div 

                     div_image_slider.Controls.Add(div_slider);                      //Adding the sliders to the main image slider 



                 }




                 String x = "<script type='text/javascript'> $(function(){  var i = " + max_val.ToString() + "; var j = " + min_val + "; var slider = setInterval(slideit,6200); function slideit(){ if(i<=" + min_val.ToString() + "){ if(j>=" + (max_val + 1).ToString() + ") { j=" + min_val.ToString() + "; i=" + max_val.ToString() + "; } else { $('#slider_'+j).fadeIn(5000); j++; } } else { $('#slider_'+i).fadeOut(5000); i--; } } }); </script>";

                 Page.ClientScript.RegisterStartupScript(this.GetType(), "myscript", x);

                 dt.Dispose();
             }
         }
         catch(Exception ex)
         {
             ErrorReportBAL error = new ErrorReportBAL();
             error.SendErrorReport("Default.aspx", ex.ToString());
         }
    }
}