using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for AdminLoginDAL
/// </summary>
public class AdminFunctionsDAL
{
	public AdminFunctionsDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    SqlConnection newcon = new SqlConnection(ConfigurationManager.ConnectionStrings["hit"].ConnectionString);
    String query;
    SqlCommand command;
    SqlDataReader reader ;
    SqlDataAdapter adapter;
    DataSet ds;
    //for Updating Events
     public int event_DAL_update(eventsBO event_bo)
    {
        try
        {
           query = "UPDATE events set admin_id=@admin_id,event_title=@event_title,event_desc=@event_desc,event_time=@event_time,event_place=@event_place,event_pic=@event_pic,date_time_of_post=@date_time_of_post where event_id=@event_id";
            if (newcon.State == ConnectionState.Closed)
            { newcon.Open(); }
            command = new SqlCommand(query, newcon);
            command.Parameters.AddWithValue("@admin_id", event_bo.admin_id);
            command.Parameters.AddWithValue("@event_title", event_bo.event_title);
            command.Parameters.AddWithValue("@event_desc", event_bo.event_desc);
            command.Parameters.AddWithValue("@event_time", event_bo.event_time);
            command.Parameters.AddWithValue("@event_place", event_bo.event_place);
            command.Parameters.AddWithValue("@event_pic", event_bo.event_pic);
            command.Parameters.AddWithValue("@date_time_of_post", event_bo.date_time_of_post);
            command.Parameters.AddWithValue("@event_id", event_bo.event_id);
            return command.ExecuteNonQuery();

        }
        catch 
        {

            throw;
        }
        finally { command.Dispose(); newcon.Close(); newcon.Dispose(); }
    }
 
    //for deleting events
    public int event_DAL_del(eventsBO event_bo)
    {
        try
        {
            query = "delete  from events where event_id =@event_id";
            if (newcon.State == ConnectionState.Closed)
            { newcon.Open(); }
            command = new SqlCommand(query, newcon);
            command.Parameters.AddWithValue("@event_id", event_bo.event_id);
            return command.ExecuteNonQuery();


        }
        catch
        {
            throw;
        }
        finally
        {
            newcon.Close();
        }
    }
    public Boolean AdminLoginAuthenticate(admin_infoBO admin_credinatials)
    {
        try
        {
            newcon.Open();
            query = "Select admin_id from admin_info where email_id=@email and password=@pass";

            command = new SqlCommand(query, newcon);

            command.Parameters.AddWithValue("@email", admin_credinatials.email_id);
            command.Parameters.AddWithValue("@pass", admin_credinatials.password);

            reader = command.ExecuteReader();

            command.Dispose();

            if (reader.HasRows)  //username or password is correct
            {
                return true;
            }
            else
            {
                return false;              //Username or password not correct
            }


        }
        catch
        {
            throw;

        }

        finally
        {
            reader.Dispose();
            newcon.Close();
        }
    }                        //end of admin login authentication 



    public admin_infoBO AdminCompleteInfoFetch(admin_infoBO admin_credentials)     //fetching the admin general information
    {
        try
        {

            newcon.Open();

            query = "Select * from admin_info where email_id=@email";

            command = new SqlCommand(query, newcon);

            command.Parameters.AddWithValue("@email", admin_credentials.email_id);
            

            reader = command.ExecuteReader();

            command.Dispose();

            if (reader.HasRows)
            {
                admin_infoBO admin_info = new admin_infoBO();

                reader.Read();

                admin_info.admin_id = Convert.ToInt32(reader[0]);              //admin_id 
                admin_info.first_name = Convert.ToString(reader[3]);           //admin_firstname         
                admin_info.last_name = Convert.ToString(reader[4]);            //admin_lastname  
                return admin_info;
            }
            else
            {
                return null;
            }
        }

        catch
        {
            throw;
        }

        finally
        {
            reader.Dispose();
            newcon.Close();
        }
    }                                             //end of adming information fetch function 



    

    public Boolean AdminPasswordChange(admin_infoBO admin_info,String newpass)     //Admin passwrod change function 
    {
        try
        {

            if (AdminPasswordCheck(admin_info.admin_id, admin_info.password))
            {
                newcon.Open();
                query = "update admin_info set admin_password='@newpass' where admin_id=@admin_id";

                command = new SqlCommand(query, newcon);

                command.Parameters.AddWithValue("@admin_id", admin_info.admin_id);
                command.Parameters.AddWithValue("@newpass", newpass);
                command.ExecuteNonQuery();

                return true;

            }
            else
            {
                return false;
            }
        }
        catch
        {
            throw;
        }

        finally
        {
            command.Dispose();
            newcon.Close();
        }
    }

    private Boolean AdminPasswordCheck(int id,String pwd)
    {
        try
        {

            newcon.Open();
            query = "Select admin_pass from admin_info where admin_id=@admin_id";

            command = new SqlCommand(query, newcon);

            command.Parameters.AddWithValue("@admin_id", id);

            reader = command.ExecuteReader();

            command.Dispose();

            if (reader.HasRows)
            {
                reader.Read();
                if (reader[0].ToString() == pwd)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        catch
        {
            throw;
        }

        finally
        {
            reader.Dispose();
            newcon.Close();
        }
           
    }




                                                        //User profile viewing functions 

    public DataSet ListAllUsers()
    {

        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }

            DataSet ds = new DataSet();
            String query = "Select user_id,email_id,first_name,last_name,user_type,join_date from user_info";
            adapter = new SqlDataAdapter(query, newcon);
            adapter.Fill(ds);

            return ds;
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





                                                        //admin blog management functions 


                                                        //blog loader 

    public DataSet AdminBlogLister()
    {
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }

            DataSet ds = new DataSet();
            String query = "Select blog_id,blog_title,date_time_of_post from blog_post where blog_checked = 1 ORDER BY (date_time_of_post) DESC";
            adapter = new SqlDataAdapter(query, newcon);
            adapter.Fill(ds);

            return ds;
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


    public DataSet MyBlogLister(int admin_id)
    {
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }

            DataSet ds = new DataSet();
            String query = "Select blog_id,blog_title,date_time_of_post from blog_post where poster_id="+admin_id+" and is_admin=1 ORDER BY (date_time_of_post) DESC";
            adapter = new SqlDataAdapter(query, newcon);
            adapter.Fill(ds);

            return ds;
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


    public void AdminBlogDelete(blog_postBO blogInfo)
    {
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }

            
            String query = "Delete from blog_post where blog_id = @bid";
            command = new SqlCommand(query, newcon);
            command.Parameters.AddWithValue("@bid", blogInfo.blog_id);
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


    public blog_postBO AdminBlogViewer(int blog_id)
    {
        blog_postBO blog = new blog_postBO();
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }


            String query = "Select * from blog_post where blog_id = @bid";
            command = new SqlCommand(query, newcon);
            command.Parameters.AddWithValue("@bid", blog_id);

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                {
                    blog.blog_id = Convert.ToInt32(reader[0]);
                    blog.blog_title = reader[1].ToString();
                    blog.blog_content = reader[2].ToString();
                    blog.poster_id = Convert.ToInt32(reader[3]);
                    blog.is_admin = (Convert.ToInt16(reader[4]) == 1) ? true : false;
                    blog.date_time_of_post = Convert.ToDateTime(reader[5]);
                    blog.blog_checked = (Convert.ToInt16(reader[7]) == 1) ? true : false;
                }
            }
            else
            {
                blog = null;
            }

            command.Dispose();
            reader.Dispose();
                
            return blog;
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


    public void AdminBlogEdit(blog_postBO nBlog)
    {
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }


            String query = "Update blog_post set blog_title=@title,blog_content=@content where blog_id = @bid";
            command = new SqlCommand(query, newcon);

            command.Parameters.AddWithValue("@title", nBlog.blog_title.ToString());
            command.Parameters.AddWithValue("@content", nBlog.blog_content.ToString());
            command.Parameters.AddWithValue("@bid", nBlog.blog_id);


            command.ExecuteNonQuery();
            command.Dispose();
            newcon.Close();
            
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


    public void AdminPostBlog(blog_postBO nBlog)
    {
        try
        {
            Next_ID nid = new Next_ID();
            nBlog.blog_id = nid.incrementer("blog_id", "blog_post");

            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }


            
            int isadmin = 0;
            
            nBlog.date_time_of_post = System.DateTime.Now;


            if (nBlog.is_admin)
            {
                isadmin = 1;
            }
            else
            {
                isadmin = 0;
            }

            String query = "insert into blog_post(blog_id,blog_title,blog_content,poster_id,is_admin,date_time_of_post,blog_checked) values(@bid,@title,@content,@posterid,@isadmin,@datetime,@blog_checked)";
            command = new SqlCommand(query, newcon);

            command.Parameters.AddWithValue("@bid",nBlog.blog_id);
            command.Parameters.AddWithValue("@title", nBlog.blog_title.ToString());
            command.Parameters.AddWithValue("@content", nBlog.blog_content.ToString());
            command.Parameters.AddWithValue("@posterid",nBlog.poster_id);
            command.Parameters.AddWithValue("@isadmin",isadmin);
            command.Parameters.AddWithValue("@datetime", nBlog.date_time_of_post.ToString());
            command.Parameters.AddWithValue("@blogchecked", 1);
            command.ExecuteNonQuery();
            command.Dispose();
            newcon.Close();
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



    public DataSet AdminNewPostRequestList()
    {
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }

            DataSet ds = new DataSet();
            String query = "Select blog_id,blog_title,date_time_of_post from blog_post where blog_checked=0 ORDER BY (date_time_of_post) DESC";
            adapter = new SqlDataAdapter(query, newcon);
            adapter.Fill(ds);

            return ds;
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

    public long numberOfNewPostRequest()
    {
        try
        {
            long x = 0;

            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }

            String query = "Select count(*) from blog_post where blog_checked=0 ";
            command = new SqlCommand(query, newcon);

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                if (reader[0] != DBNull.Value)
                {
                    x = Convert.ToInt64(reader[0]);
                }

            }

            command.Dispose();
            reader.Dispose();

            return x;
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

    public void AcceptNewPost(int blog_id)
    {
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }
            String query = "Update blog_post set blog_checked = 1  where blog_id=@bid";
            command = new SqlCommand(query, newcon);
            command.Parameters.AddWithValue("@bid", Convert.ToInt32(blog_id));
            command.ExecuteNonQuery();

            command.Dispose();
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



    public String AdminName(int admin_id)
    {
        String AdminName = "";

        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }


            String query = "Select first_name,last_name from admin_info where admin_id = @aid";
            command = new SqlCommand(query, newcon);
            command.Parameters.AddWithValue("@aid", admin_id);

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                {
                    AdminName = reader[0].ToString() + " " + reader[1].ToString();
                }
            }
            else
            {
                AdminName = "";
            }

            command.Dispose();
            reader.Dispose();


            return AdminName;
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



                                                                 // Admin Events functions 

    public void PostNewEvent(eventsBO new_event)                 //post new event 
    {

        try
        {
            Next_ID nid = new Next_ID();
            new_event.event_id = nid.incrementer("event_id", "events");

            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }


            String query = "insert into events(event_id,admin_id,event_title,event_desc,event_time,event_place,event_pic,date_time_of_post) values(@eid,@aid,@title,@desc,@etime,@eplace,@epic,@datetime)";
            command = new SqlCommand(query, newcon);

            command.Parameters.AddWithValue("@eid", new_event.event_id);
            command.Parameters.AddWithValue("@aid",new_event.admin_id);
            command.Parameters.AddWithValue("@title", new_event.event_title.ToString());
            command.Parameters.AddWithValue("@desc",new_event.event_desc.ToString());
            command.Parameters.AddWithValue("@etime",new_event.event_time);
            command.Parameters.AddWithValue("@eplace",new_event.event_place.ToString());
            command.Parameters.AddWithValue("@epic", new_event.event_pic);
            command.Parameters.AddWithValue("@datetime", new_event.date_time_of_post);

            command.ExecuteNonQuery();
            command.Dispose();
            newcon.Close();
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

    public DataSet  events_DAl_Retrive(eventsBO eventbo)
    {
        try
        {
            string s_querry = "Select * from events where event_id =@event_id";
            if (newcon.State == ConnectionState.Closed)
            { newcon.Open(); }
            command = new SqlCommand(s_querry, newcon);
            command.Parameters.AddWithValue("@event_id", eventbo.event_id );
            adapter = new SqlDataAdapter(command);
            ds=new DataSet();
            adapter.Fill(ds);
            return ds;

           
        }
        catch (Exception)
        {

            throw;
        }
    }

    public DataSet AdminEventLister()
    {
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }

            DataSet ds = new DataSet();
            String query = "Select * from events ORDER BY (date_time_of_post) DESC";
            adapter = new SqlDataAdapter(query, newcon);
            adapter.Fill(ds);

            return ds;
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



    //top 3 events
    public DataSet TopFiveEvetns()
    {
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }

            DataSet ds = new DataSet();
            String query = "Select TOP 3 * from events ORDER BY (date_time_of_post) DESC";
            adapter = new SqlDataAdapter(query, newcon);
            adapter.Fill(ds);

            return ds;
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
    //admin inbox
    public DataSet AdminMsgLister()
    {
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }

            DataSet ds = new DataSet();
            String query = "Select * from suggestion ORDER BY (date_time) DESC";
            adapter = new SqlDataAdapter(query, newcon);
            adapter.Fill(ds);

            return ds;
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
    //admin inbox function
    public void AdminMsgDelete(suggestionBO suggestionInfo)
    {
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }


            String query = "Delete from suggestion where suggestion_id = @bid";
            command = new SqlCommand(query, newcon);
            command.Parameters.AddWithValue("@bid", suggestionInfo.suggestion_id);
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
    public suggestionBO AdminMsgViewer(int msg_id)
    {
       suggestionBO suggetionviewer = new suggestionBO();
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }


            String query = "Select * from Suggestion where Suggestion_ID = @sid";
            command = new SqlCommand(query, newcon);
            command.Parameters.AddWithValue("@sid", msg_id);

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                {
                   
                    suggetionviewer.suggestion_id = Convert.ToInt32(reader[0]);
                 
                   suggetionviewer.suggestion_msg= reader[2].ToString();
                   suggetionviewer.date_time = Convert.ToDateTime(reader[3]);
                   suggetionviewer.subject = reader[4].ToString();
                   suggetionviewer.user_name = reader[5].ToString();
                   
                }
                
            }
            else
            {
               suggetionviewer= null;
            }

            command.Dispose();
            reader.Dispose();
            msgChecked(msg_id);
            return suggetionviewer;
            
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
    //method for msg checked in database
    public void msgChecked(int msgId)
    {
        try
        {
            String query1 = "update Suggestion set msgCheck=1 where Suggestion_ID = @msgId";
            command = new SqlCommand(query1, newcon);
            command.Parameters.AddWithValue("@msgId", msgId);
            command.ExecuteNonQuery();
        }
        catch {
            throw;
        }
    }
 
    public long numberOfNewMsg()
    {
        try
        {
            long x = 0;

            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }

            String query = "Select count(*) from suggestion where msgCheck is null";
            command = new SqlCommand(query, newcon);

            if (Convert.ToBoolean(command.ExecuteScalar()))
            {
                x = Convert.ToInt64(command.ExecuteScalar());
            }
            command.Dispose();
           

            return x;
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
    // fund utilisation
    public fund_utilizationBO fund_info_retrive()
    {
        fund_utilizationBO fundBO = new fund_utilizationBO();
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }


            String query = "Select * from fund_utilization";
            command = new SqlCommand(query, newcon);
           

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                {

                    fundBO.upper_detail= reader[0].ToString();

                    fundBO.first_utilization = reader[1].ToString();
                    fundBO.second_utilization = reader[2].ToString();
                    fundBO.third_utilization= reader[3].ToString();
                    fundBO.fourth_utilization = reader[4].ToString();


                }
            }
            else
            {
                fundBO = null;
            }

            command.Dispose();
            reader.Dispose();

            return fundBO;
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
    public bool fund_info_save(fund_utilizationBO fundBO)
    {
        
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }


            String query = "Update fund_utilization set upper_detail=@upper_detail,first_utilization=@first_utilization,second_utilization=@second_utilization,third_utilization=@third_utilization,fourth_utilization=@fourth_utilization";
            command = new SqlCommand(query, newcon);

            command.Parameters.AddWithValue("@upper_detail",fundBO.upper_detail);
            command.Parameters.AddWithValue("@first_utilization", fundBO.first_utilization);
            command.Parameters.AddWithValue("@second_utilization", fundBO.second_utilization);
            command.Parameters.AddWithValue("@third_utilization", fundBO.third_utilization);
            command.Parameters.AddWithValue("@fourth_utilization", fundBO.fourth_utilization);
           
            command.ExecuteNonQuery();
            command.Dispose();
            newcon.Close();

            return true;
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
}



