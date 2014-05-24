using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


/// <summary>
/// Summary description for ImageSliderDAL
/// </summary>
public class ImageSliderDAL
{
	public ImageSliderDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    SqlConnection newcon = new SqlConnection(ConfigurationManager.ConnectionStrings["hit"].ConnectionString);
    String query;
    SqlCommand command;
    SqlDataReader reader;
    SqlDataAdapter adapter; 

    public DataTable LoadImageInSlider()
    {
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }

            DataSet ds = new DataSet();
            String query = "Select * from image_slider Order By img_order Desc ";

            adapter = new SqlDataAdapter(query, newcon);
            adapter.Fill(ds);

            return ds.Tables[0];
        }
        catch
        {
            throw;
        }
        finally
        {
            if (newcon.State == ConnectionState.Open)
            {
                newcon.Close();
            }
        }
    }      //load the image to the slider 





    public void SaveNewImage(String image_name)
    {
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }

            Next_ID generateimageid =  new Next_ID();

            image_sliderBO newimage = new image_sliderBO();

            newimage.img_id = generateimageid.incrementer("img_id", "image_slider");

            newimage.img_link = "../Images/sliderImages/" + image_name;

            String query = "insert into image_slider(img_id,img_link) values(@img_id,@img_link)";
            command = new SqlCommand(query,newcon);

            command.Parameters.AddWithValue("@img_id",newimage.img_id);
            command.Parameters.AddWithValue("@img_link",newimage.img_link);
            command.ExecuteNonQuery();

        }
        catch
        {
            throw;
        }
        finally
        {
            if (newcon.State == ConnectionState.Open)
            {
                newcon.Close();
            }
        }
    }




    public String NextImageName(String currentimage_name)
    {
        try
        {

            Next_ID generateimageid = new Next_ID();

            int newImageID = generateimageid.incrementer("img_id", "image_slider");    //got now image ID , now change the image name to img_id.jpg
            
            String[] temp = currentimage_name.Split('.');
            String img_extension = temp[1];
            String newimage_name = newImageID.ToString() + "." + img_extension;    // New name for the image 

            return newimage_name;
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
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }

            query = "Delete from image_slider where img_id = @img_id";
            command = new SqlCommand(query, newcon);
            command.Parameters.AddWithValue("@img_id", image_id);
            command.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
        finally
        {
            command.Dispose();
            if (newcon.State == ConnectionState.Open)
            {
                newcon.Close();
            }
        }
    }

    public void EditImageAndInfo(image_sliderBO img_obj)
    {
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }

            query = "UPDATE image_slider SET img_info = @img_info where img_id = @img_id";
            command = new SqlCommand(query, newcon);
            command.Parameters.AddWithValue("@img_info",img_obj.img_info.ToString());
            command.Parameters.AddWithValue("@img_id",img_obj.img_id);
            command.ExecuteNonQuery();

        }
        catch
        {
            throw;
        }
        finally
        {
            command.Dispose();
            if (newcon.State == ConnectionState.Open)
            {
                newcon.Close();
            }
        }
    }


}