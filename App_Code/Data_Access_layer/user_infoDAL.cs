using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for user_infoDAL
/// </summary>
public class user_infoDAL
{
    public user_infoDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["hit"].ToString());
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet dSet;
    string query;
    public bool user_info_insert(user_infoBO u_infbo)
    {
        try
        {

            query = "insert into user_info values(@user_id,@email_id,@first_name,@last_name,@password,@user_type,@country,@city,@join_date,@profile_pic_name)";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user_id", u_infbo.user_id);
            cmd.Parameters.AddWithValue("@email_id", u_infbo.email_id);
            cmd.Parameters.AddWithValue("@first_name", u_infbo.first_name);
            cmd.Parameters.AddWithValue("@last_name", u_infbo.last_name);
            cmd.Parameters.AddWithValue("@password", u_infbo.password);
            cmd.Parameters.AddWithValue("@user_type", u_infbo.user_type);
            cmd.Parameters.AddWithValue("@country", u_infbo.country);
            cmd.Parameters.AddWithValue("@city", u_infbo.city);
            cmd.Parameters.AddWithValue("@join_date", u_infbo.join_date);
            cmd.Parameters.AddWithValue("@profile_pic_name", u_infbo.profile_pic);
            if (cmd.ExecuteNonQuery() >= 1)
                return true;
            else
                return false;
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            con.Close();
        }
    }

    public DataTable view_users(user_infoBO ubo)
    {
        try
        {
            string user_type = Convert.ToString(ubo.user_type);
            if (user_type == "1" || user_type == "0")
            {
                query = "select user_id,email_id,first_name,last_name,user_type,country,city,join_date,profile_pic_name from user_info where user_type=" + user_type + "";
                con.Open();
                cmd = new SqlCommand(query, con);
                da = new SqlDataAdapter(cmd);
                dSet = new DataSet();
                da.Fill(dSet, "user_info");
                return dSet.Tables["user_info"];
            }
            else
            {
                query = "select user_id,email_id,first_name,last_name,user_type,country,city,join_date,profile_pic_name from user_info";
                con.Open();
                cmd = new SqlCommand(query, con);
                da = new SqlDataAdapter(cmd);
                dSet = new DataSet();
                da.Fill(dSet, "user_info");
                return dSet.Tables["user_info"];
            }


        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            dSet.Dispose();
            da.Dispose();
            con.Close();
            con.Dispose();
        }
    }


    public void delete_user(user_infoBO ubo)
    {
        try
        {
            
            query = "delete  from user_info where user_id=@user_id";
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user_id", ubo.user_id);
            cmd.ExecuteNonQuery();


        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            
            
            con.Close();
            con.Dispose();
        }
    }
}