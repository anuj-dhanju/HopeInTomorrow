using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for newsDAL
/// </summary>
public class newsDAL
{
	public newsDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //---------------------------------------------------------
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HIT"].ToString());
    SqlCommand cmd;
    string s_querry;
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet dSet;
    //-------------------------------------------------

    public DataSet news_DAL_viewALL()
    {
         try
        {
            
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand("select * from news order by date_time_of_post desc", con);
            da = new SqlDataAdapter(cmd);
            dSet = new DataSet();
            da.Fill(dSet, "news");
            return dSet;
        }
        catch (Exception)
        {
            throw;
        }
        finally { cmd.Dispose(); con.Close(); con.Dispose(); }
    }


    //getting top five news from news table 
    public DataSet news_top3_DAL_view()
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            {
                cmd = new SqlCommand("SELECT TOP 3 * FROM news;", con);
                da = new SqlDataAdapter(cmd);
                dSet = new DataSet();
                da.Fill(dSet);
                return dSet;
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            con.Close();
        }
    }


    //inserting data into news
    public int news_DAL_insert(newsBO news_bo)
    {
        try
        {
            Next_ID nid = new Next_ID();
            news_bo.news_id = nid.incrementer("news_id","news");
            s_querry = "insert into news values(@news_id,@admin_id,@news_title,@news_desc,@date_time_of_post,@news_pic)";
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(s_querry, con);
            cmd.Parameters.AddWithValue("@news_id",news_bo.news_id);
            cmd.Parameters.AddWithValue("@admin_id",news_bo.admin_id);
            cmd.Parameters.AddWithValue("@news_title",news_bo.news_title);
            cmd.Parameters.AddWithValue("@news_desc",news_bo.news_desc);
            cmd.Parameters.AddWithValue("@date_time_of_post",news_bo.date_time_of_post);
            cmd.Parameters.AddWithValue("@news_pic", news_bo.news_pic);
            return cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {

            throw;
        }
        finally { cmd.Dispose(); con.Close(); con.Dispose(); }

    }

    //delete
    public int news_DAL_del(newsBO news_bo)
    {
        try
        {
            s_querry = "delete  from news where news_id =@news_id";
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(s_querry, con);
            cmd.Parameters.AddWithValue("@news_id", news_bo.news_id);
            return cmd.ExecuteNonQuery();

           
        }
        catch
        {
            throw;
        }
        finally
        {
            con.Close();
        }
    }
           
   
   //view news byr news_id
    public DataTable news_DAL_view_id(newsBO news_bo)
    {
        try
        {
            s_querry = "select * from news where news_id =@news_id";
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(s_querry, con);

            cmd.Parameters.AddWithValue("@news_id", news_bo.news_id);
            da = new SqlDataAdapter(cmd);
            dSet=new DataSet();
            da.Fill(dSet);
            return (DataTable)dSet.Tables[0];

        }
        catch (Exception)
        {

            throw;
        }
        finally { cmd.Dispose(); con.Close(); con.Dispose(); }
    }
}