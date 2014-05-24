using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Summary description for UserFunctionsDAL
/// </summary>
public class UserFunctionsDAL
{
	public UserFunctionsDAL()
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

    public string FirstLogin(string email)
    {

        try
        {
            if ((check_emailId(email)))
            {
                newcon.Open();
                query = "update user_info set conf=1 where email_id=@email";

                command = new SqlCommand(query, newcon);

                command.Parameters.AddWithValue("@email", email);

                command.ExecuteNonQuery();
               
                command.Dispose();
                return email;
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

            newcon.Close();
        }
    }

  
    public bool UserSignIn(user_infoBO user_credentials )
    {

        try
        {
            newcon.Open();
            query = "Select user_id from user_info where email_id=@email and password=@pass and conf=1";

            command = new SqlCommand(query, newcon);

            command.Parameters.AddWithValue("@email", user_credentials.email_id.ToString());
            command.Parameters.AddWithValue("@pass", user_credentials.password.ToString());

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
    }

    public int UserIDFetch(String user_emial)
    {
        try
        {
            user_infoBO user_info = new user_infoBO();
            if (newcon.State == ConnectionState.Closed)
            {

                newcon.Open();
            }
            query = "Select user_id from user_info where email_id=@email";

            command = new SqlCommand(query, newcon);

            command.Parameters.AddWithValue("@email", user_emial.ToString());


            reader = command.ExecuteReader();

            command.Dispose();

            if (reader.HasRows)
            {
                

                reader.Read();

                user_info.user_id = Convert.ToInt32(reader[0]);

                
            }

            return user_info.user_id;

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

    public String UserNameFetch(int user_id)
    {
        String UserName = "";

        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }


            String query = "Select first_name,last_name from user_info where user_id = @uid";
            command = new SqlCommand(query, newcon);
            command.Parameters.AddWithValue("@uid", user_id);

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                {
                    UserName = reader[0].ToString() + " " + reader[1].ToString();
                }
            }
            else
            {
                UserName = "";
            }

            command.Dispose();
            reader.Dispose();


            return UserName;
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

    public String AdminNameFetch(int admin_id)
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

    public int NewUserRegister(user_infoBO user_info)
    {
        try
        {

            if (!(check_emailId(user_info.email_id)))
            {


                if (newcon.State == ConnectionState.Closed)
                {
                    newcon.Open();
                }

                Next_ID newid = new Next_ID();

                user_info.user_id = newid.incrementer("user_id", "user_info");

                user_info.join_date = System.DateTime.Now;

               String query = "Insert into user_info(user_id,email_id,first_name,last_name,password,country,join_date) values(@user_id,@email_id,@first_name,@last_name,@password,@country,@join_date)";

                command = new SqlCommand(query, newcon);
                command.Parameters.AddWithValue("@user_id", user_info.user_id);
                command.Parameters.AddWithValue("@email_id", user_info.email_id);
                command.Parameters.AddWithValue("@first_name", user_info.first_name);
                command.Parameters.AddWithValue("@last_name", user_info.last_name);
                command.Parameters.AddWithValue("@password", user_info.password);
                //command.Parameters.AddWithValue("@user_type",user_info.user_type);
                command.Parameters.AddWithValue("@country", user_info.country);
                //command.Parameters.AddWithValue("@city", user_info.city);
                command.Parameters.AddWithValue("@join_date", user_info.join_date.ToString());

                command.ExecuteNonQuery();
                command.Dispose();

                return 2;
            }
            else
            {
               return 1;
            }
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

    public bool PasswordMatch(user_infoBO password_user_info)

    {
        String pass = "";
        String user_id = password_user_info.user_id.ToString();
        String oldpassword = password_user_info.password;

        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }


            String query = "Select password from user_info where user_id = @uid";
            command = new SqlCommand(query, newcon);
            command.Parameters.AddWithValue("@uid",user_id);

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                {
                    pass = reader[0].ToString();
                }
            }
            else
            {
                pass = "";
            }

            command.Dispose();
            reader.Dispose();


            if (pass == oldpassword)
            {
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
            if (newcon.State == ConnectionState.Open)
            {
                newcon.Close();
            }
        }

       


    }
    public string getPassword(user_infoBO password_user_info)
    {
        String pass = "";
        String user_id = password_user_info.user_id.ToString();
        
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }


            String query = "Select password from user_info where user_id = @uid";
            command = new SqlCommand(query, newcon);
            command.Parameters.AddWithValue("@uid", user_id);

            reader = command.ExecuteReader();
            command.Dispose();
            if (reader.HasRows)
            {
                reader.Read();
                {
                    pass = reader[0].ToString();
                }
                return pass;
            }
            else
            {
                return "password not exist";
            }
          
        }

        catch
        {
            throw;
        }
        finally
        {
            reader.Dispose();
            if (newcon.State == ConnectionState.Open)
            {
                newcon.Close();
            }
        }




    }



    public String GetProfilePicName(int user_id)
    {
        try
        {
            String ProfilePicName = "" ;  

            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }


            String query = "Select profile_pic from user_info where user_id = @uid";
            command = new SqlCommand(query, newcon);
            command.Parameters.AddWithValue("@uid", user_id);

            reader = command.ExecuteReader();
            command.Dispose();

            if (reader.HasRows)
            {
                reader.Read();
                if (reader[0] != DBNull.Value)
                {
                    ProfilePicName = reader[0].ToString();
                }
                else
                {
                    ProfilePicName = "/Images/userprofilepic/NoPic.jpg";
                }
                
            }

            reader.Dispose();

            return ProfilePicName;


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





    /*profile update */
    public string ProfileUpdate(user_infoBO user_info){

         try
        {

            String query = "UPDATE user_info SET ";
            int f = 0;

                if (user_info.first_name != null )
                {

                    if (f == 1)
                    {
                        query += ",";
                    }
                    query += ("first_name='" + user_info.first_name + "'");

                    f = 1;
                }

                if (user_info.last_name != null)
                {

                    if (f == 1)
                    {
                        query += ",";
                    }
                    query += ("last_name='" + user_info.last_name + "'");
                    f = 1;
                }
                if (user_info.password != null)
                {
                    if (f == 1)
                    {
                        query += ",";
                    }
                    query += ("password='" + user_info.password + "'");
                    f = 1;
                }
                if (user_info.country != null)
                {

                    if (f == 1)
                    {
                        query += ",";
                    }
                    query += ("country='" + user_info.country + "'");

                    f = 1;
                }
                if (user_info.profile_pic != null)
                {
                    if (f == 1)
                    {
                        query += ",";
                    }
                    query += ("profile_pic='" + user_info.profile_pic + "'");
                    f = 1;
                }

                if (newcon.State == ConnectionState.Closed)
                {
                    newcon.Open();
                }
                query += " where user_id=@user_id";

                command = new SqlCommand(query, newcon);

                command.Parameters.AddWithValue("@user_id", user_info.user_id);

                command.ExecuteNonQuery();
                command.Dispose();

                return "profile Successfully updated";
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

    /*end profile update*/

    public bool check_emailId(String email)
    {
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }

            String query = "select * from user_info where email_id=@email_id";

            command = new SqlCommand(query, newcon);
            command.Parameters.AddWithValue("@email_id", email.ToString());
            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                return true;     //email present 
            }
            else
            {
                return false;     //not present 
            }
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

    public String GetPass(String emailid)
    {
        String pass = "";

        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }


            String query = "Select password from user_info where email_id = @eid";
            command = new SqlCommand(query, newcon);
            command.Parameters.AddWithValue("@eid", emailid);

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                {
                    pass = reader[0].ToString();
                }
            }
            else
            {
                pass = "";
            }

            command.Dispose();
            reader.Dispose();


            return pass;
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

    public DataSet ListBlog()
    {
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }

            DataSet ds = new DataSet();
            String query = "Select TOP 5 * from blog_post where blog_checked = 1 ORDER BY (date_time_of_post) DESC";
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

    public blog_postBO UserBlogViewer(int blog_id)
    {
        blog_postBO blog = new blog_postBO();
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }


            String query = "Select * from blog_post where blog_id = @bid and blog_checked=1 ";
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

    public void UserPostNewBlog(blog_postBO nBlog)
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
            int blog_checked = 0; ;
            nBlog.date_time_of_post = System.DateTime.Now;


            if (nBlog.is_admin)
            {
                isadmin = 1;
                blog_checked = 1;
            }
            else
            {
                isadmin = 0;
                blog_checked = 0;
            }

            String query = "insert into blog_post(blog_id,blog_title,blog_content,poster_id,is_admin,date_time_of_post,blog_checked) values(@bid,@title,@content,@posterid,@isadmin,@datetime,@blog_checked)";
            command = new SqlCommand(query, newcon);

            command.Parameters.AddWithValue("@bid", nBlog.blog_id);
            command.Parameters.AddWithValue("@title", nBlog.blog_title.ToString());
            command.Parameters.AddWithValue("@content", nBlog.blog_content.ToString());
            command.Parameters.AddWithValue("@posterid", nBlog.poster_id);
            command.Parameters.AddWithValue("@isadmin", isadmin);
            command.Parameters.AddWithValue("@datetime", nBlog.date_time_of_post.ToString());
            command.Parameters.AddWithValue("@blog_checked", blog_checked);

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


    public void SetBlogViewCount(int blog_id)
    {
        try
        {

            int newViewCount = GetBlogViewCount(blog_id) + 1;           // get the new value for blog view count 

            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }

            DataSet ds = new DataSet();
            String query = "update blog_post set blog_views=@newViewCount where blog_id=@blog_id";
            command = new SqlCommand(query, newcon);
            command.Parameters.AddWithValue("@newViewCount", newViewCount);
            command.Parameters.AddWithValue("@blog_id", blog_id);
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


    public int GetBlogViewCount(int blog_id)
    {
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }

            int viewcount = 0;

            DataSet ds = new DataSet();
            String query = "select blog_views from blog_post where blog_id=@blog_id";
            command = new SqlCommand(query, newcon);
            command.Parameters.AddWithValue("@blog_id", blog_id);
            reader = command.ExecuteReader();
            command.Dispose();

            if (reader.HasRows)
            {
                reader.Read();
                if (reader[0] == DBNull.Value)
                {
                    viewcount = 0;
                }
                else
                {
                    viewcount = Convert.ToInt32(reader[0]);
                }
            }

            reader.Dispose();
            return viewcount;
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

    public void BlogPostComments(blog_commentsBO blogComment)
    {
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }

            Next_ID id = new Next_ID();

            blogComment.comment_id = id.incrementer("comment_id","blog_comments");
            blogComment.date_time_of_comment = System.DateTime.Now;

            String query = "insert into blog_comments values(@comment_id,@blog_id,@poster_id,@is_admin,@comment,@date_time_of_post)";
            command = new SqlCommand(query, newcon);

            command.Parameters.AddWithValue("@comment_id", blogComment.comment_id);
            command.Parameters.AddWithValue("@blog_id",blogComment.blog_id);
            command.Parameters.AddWithValue("@poster_id",blogComment.poster_id);
            command.Parameters.AddWithValue("@is_admin", Convert.ToInt32((blogComment.is_admin ? 1 : 0)));
            command.Parameters.AddWithValue("@comment",blogComment.comment.ToString());
            command.Parameters.AddWithValue("@date_time_of_post", blogComment.date_time_of_comment.ToString());

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

    public DataSet LoadBlogPostComments(int blog_id)
    {
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }

            DataSet ds = new DataSet();
            String query = "Select TOP 5 * from blog_comments where blog_id="+ blog_id +" ORDER BY (date_time_of_comment) DESC";
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

    public void DeleteBlogPostComment(int comment_id)
    {
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }

            DataSet ds = new DataSet();
            String query = "Delete from blog_comments where comment_id=@comment_id and is_admin = 0 ";
            command = new SqlCommand(query, newcon);
            command.Parameters.AddWithValue("@comment_id", comment_id);
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

    public int BlogCommentCount(int blog_id)
    {
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }

            int commentcount = 0; 

            DataSet ds = new DataSet();
            String query = "select count(blog_id) from blog_comments where blog_id=@blog_id";
            command = new SqlCommand(query, newcon);
            command.Parameters.AddWithValue("@blog_id", blog_id);
            reader = command.ExecuteReader();
            command.Dispose();

            if (reader.HasRows)
            {
                reader.Read();
                if (reader[0] == DBNull.Value)
                {
                    commentcount = 0;
                }
                else
                {
                    commentcount = Convert.ToInt32(reader[0]);
                }
            }

            reader.Dispose();
            return commentcount; 
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


    //fetching all user info from the database (developer :HawK)

    public DataTable getAllUserInfo_dal(user_infoBO userinfoBO_BO)
    {
        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }

            DataTable dt = new DataTable();
            String query = "Select * from user_info where user_id=" + userinfoBO_BO.user_id + "";
            adapter = new SqlDataAdapter(query, newcon);
            adapter.Fill(dt);

            return dt;
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
    //------------------------------Getting email address from database======================================================
    public String UserEmailFetch(int user_id)
    {
        String UserEmail = "";

        try
        {
            if (newcon.State == ConnectionState.Closed)
            {
                newcon.Open();
            }


            String query = "Select email_id from user_info where user_id = @uid";
            command = new SqlCommand(query, newcon);
            command.Parameters.AddWithValue("@uid", user_id);

            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                {
                    UserEmail = reader[0].ToString();
                }
            }
            else
            {
                UserEmail = "";
            }

            command.Dispose();
            reader.Dispose();


            return UserEmail;
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

public bool UserSignUp(user_infoBO social_login_info)
    {
        try
        {
            if (check_emailId(social_login_info.email_id.ToString()))
            {
                return true;
            }
            else
            { 
                
                if (newcon.State == ConnectionState.Closed)
                {
                    newcon.Open();
                }

                Next_ID newid = new Next_ID();

                int social = social_login_info.social == true ? 1 : 0  ;      //getting the bit value for social field in db 

                social_login_info.user_id = newid.incrementer("user_id", "user_info");

              


                social_login_info.join_date = System.DateTime.Now;
                String query = "Insert into user_info(user_id,email_id,first_name,join_date,social_type,social,profile_pic) values(@user_id,@email_id,@first_name,@join_date,@social_type,@social,@profile_pic)";

                command = new SqlCommand(query, newcon);
                command.Parameters.AddWithValue("@user_id", social_login_info.user_id);
                command.Parameters.AddWithValue("@email_id", social_login_info.email_id);
                command.Parameters.AddWithValue("@first_name", social_login_info.first_name);
                command.Parameters.AddWithValue("@social_type", social_login_info.social_type);
                command.Parameters.AddWithValue("@social", social);
                command.Parameters.AddWithValue("@profile_pic", social_login_info.profile_pic);
              

                command.Parameters.AddWithValue("@join_date", social_login_info.join_date.ToString());

                command.ExecuteNonQuery();
                command.Dispose();

                return true;
            }
          
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





//fetching continents
public DataSet continent_retive()
{
    try
    {

        query = "select * from continent";
        if (newcon.State == ConnectionState.Closed)
        {

            newcon.Open();
        }
        command = new SqlCommand(query, newcon);
        DataSet ds = new DataSet();
        adapter = new SqlDataAdapter(command);
        adapter.Fill(ds);
        return ds;
    }
    catch
    {
        throw;
    }
}
//fetch regions
public DataTable regions_retive_DAL()
{
    try
    {

        query = "select * from region";
        if (newcon.State == ConnectionState.Closed)
        {

            newcon.Open();
        }
        command = new SqlCommand(query, newcon);
        adapter = new SqlDataAdapter(command);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        return dt;
    }

    catch
    {
        throw;
    }


}
}