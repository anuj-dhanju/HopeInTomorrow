using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for suggestionDAL
/// </summary>
public class suggestionDAL
{
	public suggestionDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HIT"].ToString());
    SqlCommand cmd;
    SqlDataAdapter da;
    string s_querry;

    DataSet dSet = new DataSet();

    public DataTable suggestion_DAL_ViewAll()
    {
        try
        {
             
            s_querry = "select * from suggestion";

            con.Open();
            cmd = new SqlCommand(s_querry, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(dSet, "suggestion");
            return dSet.Tables["suggestion"];

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

    public int suggestion_DAL_del(suggestionBO sug_bo)
    {
        try
        {
            con.Open();
            s_querry = "delete from suggestion where suggestion_id=@suggestion_id";
            cmd = new SqlCommand(s_querry, con);
            cmd.Parameters.AddWithValue("@suggestion_id", sug_bo.suggestion_id);
            return cmd.ExecuteNonQuery();
        }
        catch { throw; }
        finally { cmd.Dispose(); con.Close(); con.Dispose(); }
    
    }

    public int suggestion_DAL_insert(suggestionBO sbo)
    {
        try
        {
            s_querry = "insert into suggestion (suggestion_id,subject,userEmail,suggestion_msg,userName,date_time) values(@suggestion_id,@subject,@userEmail,@suggestion_msg,@userName,@date_time)";
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(s_querry, con);
            cmd.Parameters.AddWithValue("@suggestion_id",sbo.suggestion_id);
            cmd.Parameters.AddWithValue("@userName", sbo.user_name);
            cmd.Parameters.AddWithValue("@suggestion_msg",sbo.suggestion_msg);
            cmd.Parameters.AddWithValue("@date_time",sbo.date_time);
            cmd.Parameters.AddWithValue("@userEmail", sbo.userEmail);
            cmd.Parameters.AddWithValue("@subject", sbo.subject);
            
            return cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {

            throw;
        }
        finally { cmd.Dispose(); con.Close(); con.Dispose(); }

    }

}