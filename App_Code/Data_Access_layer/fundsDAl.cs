using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


/// <summary>
/// Summary description for fundsDAl
/// </summary>
public class fundsDAl
{
	public fundsDAl()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HIT"].ToString());
    SqlCommand cmd;
    string s_querry;
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet dSet;

    //inserting into database
    public int funds_DAL_insert(fundsBO funds_BO)
    {
        try
        {
            Next_ID nid = new Next_ID();
            funds_BO.sl_no= nid.incrementer("sl_no", "funds");
            s_querry = "insert into funds(sl_no,first_name,last_name,email_id,uknown_user,amount) values(@sl_no,@first_name,@last_name,@email_id,@uknown_user,@amount)";
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(s_querry, con);
            cmd.Parameters.AddWithValue("@sl_no", funds_BO.sl_no);
            cmd.Parameters.AddWithValue("@first_name", funds_BO.first_name);
            cmd.Parameters.AddWithValue("@last_name", funds_BO.last_name);
            cmd.Parameters.AddWithValue("@email_id", funds_BO.email_id);
            cmd.Parameters.AddWithValue("@uknown_user", funds_BO.unknown_user);
            cmd.Parameters.AddWithValue("@amount", funds_BO.amount);
            
            return cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {

            throw;
        }
        finally { cmd.Dispose(); con.Close(); con.Dispose(); }

    }


}