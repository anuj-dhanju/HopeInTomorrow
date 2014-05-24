using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for event_subscriberDAL
/// </summary>
public class event_subscriberDAL
{
	public event_subscriberDAL()
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
    DataTable dt;

    public int evetnsubscriberDAL(event_subscriberBO event_subscriber_bo)
    {
        try
        {

            s_querry = "insert into event_subscriber values(@event_id,@user_id)";
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(s_querry, con);
            cmd.Parameters.AddWithValue("@event_id", event_subscriber_bo.event_id);
            cmd.Parameters.AddWithValue("@user_id",event_subscriber_bo.user_id);
           
            return cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {

            throw;
        }
        finally { cmd.Dispose(); con.Close();  }

    }

    //int eventID;
    //public DataTable eventSubscriber_getSubscibedEvent_DAL(event_subscriberBO event_subscriber_bo)
    //{
      
    //    try
    //    {
    //        s_querry = "select event_id from event_subscriber where user_id='" + event_subscriber_bo.user_id + "' ";
    //        if (con.State == ConnectionState.Closed)
    //        { con.Open(); }
    //        cmd = new SqlCommand(s_querry, con);
    //        dt = new DataTable();
    //        da = new SqlDataAdapter(cmd);
    //        da.Fill(dt);
    //        return dt;

    //    }
    //    catch (Exception)
    //    {

    //        throw;
    //    }
    //    finally { cmd.Dispose(); dr.Dispose(); con.Dispose(); }
    //}

    //checking  event subscribed



    //retriving user and events info 
    public DataTable event_sub_userinfoDAL()
    {
        try
        {
            s_querry = "select event_subscriber.event_id,event_subscriber.user_id,events.event_title,user_info.first_name,user_info.last_name from event_subscriber JOIN events On events.event_id=event_subscriber.event_id JOIN user_info on user_info.user_id=event_subscriber.event_id";
           if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand(s_querry, con);
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        catch
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    //Deleting event_subs
    public int event_subs_delDAL(event_subscriberBO event_subsbo)
    {
        try
        {
            s_querry = "Delete from event_subscriber where event_id=@event_id";
             if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.Parameters.AddWithValue("@event_id",event_subsbo.event_id);
            cmd = new SqlCommand(s_querry, con);
           return cmd.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        
       
    }

    public bool eventSubscriber_getEvent_id_DAL(event_subscriberBO event_subscriber_bo)
    {

        try
        {
            s_querry = "select event_id from event_subscriber where user_id='" + event_subscriber_bo.user_id + "' AND event_id = '" + event_subscriber_bo.event_id+ "' ";
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(s_querry, con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
          

        }
        catch (Exception)
        {

            throw;
        }
        finally { cmd.Dispose(); con.Close(); dr.Close(); dr.Dispose();}
    }

    //unsubscirbe event
    public int evetnUnSubscribeDAL(event_subscriberBO event_subscriber_bo)
    {
        try
        {
            // con = new SqlConnection(ConfigurationManager.ConnectionStrings["HIT"].ToString());
            s_querry = "delete from event_subscriber where event_id =" + event_subscriber_bo.event_id + " AND user_id=" + event_subscriber_bo.user_id + "";
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            cmd = new SqlCommand(s_querry, con);
            return cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {

            throw;
        }
        finally { cmd.Dispose(); con.Close(); }

    }

}