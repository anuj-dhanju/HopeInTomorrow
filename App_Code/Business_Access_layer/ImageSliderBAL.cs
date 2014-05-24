using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ImageSliderBAL
/// </summary>
public class ImageSliderBAL
{


    ImageSliderDAL sliderfunctions = new ImageSliderDAL();
    image_sliderBO sliderinfo = new image_sliderBO();

	public ImageSliderBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public DataTable LoadImageInSlider()
    {
        try
        {
           return  sliderfunctions.LoadImageInSlider();

        }
        catch
        {
            throw;
        }
    }



    public String NextImageName(String currentimage_name)
    {
         try
        {
            return sliderfunctions.NextImageName(currentimage_name);
        }
        catch
        {
            throw;
        }
    }
    


    public void SaveNewImage(String image_name)
    {
        try
        {
            sliderfunctions.SaveNewImage(image_name);
        }
        catch
        {
            throw;
        }
    }

    public void DeleteImage(int image_id)
    {
        try
        {
            sliderfunctions.DeleteImage(image_id);
        }
        catch
        {
            throw;
        }
    }


    public void EditImageAndInfo(image_sliderBO img_obj)
    {
        try
        {
            sliderfunctions.EditImageAndInfo(img_obj);
        }
        catch
        {
            throw;
        }
    }

}