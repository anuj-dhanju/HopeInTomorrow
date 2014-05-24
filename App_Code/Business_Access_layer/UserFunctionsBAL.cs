using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Configuration;

using System.Security.Cryptography;

/// <summary>
/// Summary description for UserFunctionsBAL
/// </summary>
public class UserFunctionsBAL
{

    UserFunctionsDAL userFunctions = new UserFunctionsDAL();

    public UserFunctionsBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

//signup from sn
public bool UserSignUp(user_infoBO social_user_info)
    {
        try
        {
            return userFunctions.UserSignUp(social_user_info);
        }
        catch
        {
            throw;
        }
    }


    public bool UserSigIn(user_infoBO user_credentials)
    {
        try
        {
            return userFunctions.UserSignIn(user_credentials);
        }
        catch
        {
            throw;
        }
    }

    
      public bool PasswordMatch(user_infoBO password_user_info)
    {
        try
        {
            return userFunctions.PasswordMatch(password_user_info);
        }
        catch
        {
            throw;
        }
    }
    

    public string ProfileUpdate(user_infoBO uinfo)
    {
        try
        {
            return userFunctions.ProfileUpdate(uinfo);
        }
        catch
        {
            throw;
        }
    }
    public string getPassword(user_infoBO uinfo)
    {
        try
        {
            return userFunctions.getPassword(uinfo);
        }
        catch
        {
            throw;
        }
    }
    public int UserIdFetch(String email_id)
    {
        try
        {
            return userFunctions.UserIDFetch(email_id);
        }
        catch
        {
            throw;
        }
    }

    public String UserNameFetch(int user_id)
    {
        try
        {
            return userFunctions.UserNameFetch(user_id);
        }
        catch
        {
            throw;
        }
    }

    public String AdminNameFetch(int admin_id)
    {
        try
        {
            return userFunctions.AdminNameFetch(admin_id);
        }
        catch
        {
            throw;
        }
    }

    public int NewUserRegister(user_infoBO user_info)
    {
        try
        {
            
            return userFunctions.NewUserRegister(user_info);
        }

        catch
        {
            throw;
        }
    }

    public int ForgotPassword(String email)
    {
        try
        {
            if (userFunctions.check_emailId(email))
            {
                String message = " <h1>Hope In Tomorrow </h1> <br/> <br/> Your Password is : " + userFunctions.GetPass(email).ToString() + "<br/><br/>This is a self generated email , please do not reply";
                String subject = "Hope In Tomorrow : Password Recovery";
                MailMessage mail = new MailMessage(ConfigurationManager.AppSettings["FromEmail"], email, subject, message);
                mail.IsBodyHtml = true;

                SmtpClient client = new SmtpClient();

                client.Host = ConfigurationManager.AppSettings["SMTP"];
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["FromEmail"].ToString(), ConfigurationManager.AppSettings["Pass"].ToString());

                client.Send(mail);

                return 1;
            }

            else
            {
                return 0;
            }
        }
        catch
        {
            throw;
        }
    }

    public void JoinUsMail(String email_id)
    {

        try
        {

            string link = Encrypt(email_id);
          
                String message = " <h1>Hope In Tomorrow </h1> <br/> <br/> <h4> Thank You for joining Hope In Tomorrow </h4><br/><br/>This is a self generated email , please do not reply,your account activation link is<br> Link www.hopeintomorrow.org?link="+link;
                String subject = "Hope In Tomorrow";
                MailMessage mail = new MailMessage(ConfigurationManager.AppSettings["FromEmail"], email_id, subject, message);
                mail.IsBodyHtml = true;

                SmtpClient client = new SmtpClient();

                client.Host = ConfigurationManager.AppSettings["SMTP"];
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["FromEmail"].ToString(), ConfigurationManager.AppSettings["Pass"].ToString());

                client.Send(mail);

        }
        catch
        {
            throw;
        }

    }

    public DataSet ListBlog()
    {
        try
        {
            return userFunctions.ListBlog();
        }
        catch
        {
            throw;
        }
    }

    public blog_postBO UserBlogViewer(int blog_id)
    {
        try
        {
            return userFunctions.UserBlogViewer(blog_id);
        }
        catch
        {
            throw;
        }
    }



    public void UserPostNewBlog(blog_postBO nBlog)
    {
        try
        {
            userFunctions.UserPostNewBlog(nBlog);
        }
        catch
        {
            throw;
        }
    }


    public void SetBlogViewCount(int blog_id)
    {
        try
        {
            userFunctions.SetBlogViewCount(blog_id);
        }
        catch
        {
            throw;
        }


    }


    public int GetBlogViewCount(int blog_id)
    {
        try
        {
            return userFunctions.GetBlogViewCount(blog_id);
        }
        catch
        {
            throw;
        }

    }

    public void BlogPostComments(blog_commentsBO blogComment)
    {
        try
        {
            userFunctions.BlogPostComments(blogComment);
        }
        catch
        {
            throw;
        }
    }

    public DataSet LoadBlogPostComments(int blog_id)
    {
        try
        {
            return userFunctions.LoadBlogPostComments(blog_id);
        }
        catch
        {
            throw;
        }
    }
    
    public void DeleteBlogPostComments(int comment_id)
    {
        try
        {
            userFunctions.DeleteBlogPostComment(comment_id);
        }
        catch
        {
            throw;
        }
    }


    public int BlogCommentCount(int blog_id)
    {
        try
        {
            return userFunctions.BlogCommentCount(blog_id);
        }
        catch
        {
            throw;
        }
    }

   
    //fetching all user info from the database (developer :HawK)

    public DataTable getAllUserInfo_bal(user_infoBO userinfoBO_BO)
    {
        return userFunctions.getAllUserInfo_dal(userinfoBO_BO);

    }
    //fetching useremailfetch
    public String UserEmailFetch(int user_id)
    {
        try
        {
            return userFunctions.UserEmailFetch(user_id);
        }
        catch
        {
            throw;
        }
    }



    public String GetProfilePicName(int user_id)
    {

        try
        {
            return userFunctions.GetProfilePicName(user_id);
        }

        catch
        {
            throw;
        }


    }


    public DataSet continent_retriveBAL()
    {
        return userFunctions.continent_retive();
    }
    public DataTable region_retriveBAL()
    {
        return userFunctions.regions_retive_DAL();
    }
    public string FirstLogin(string link)
    { 
        string email=Decrypt(link);
        return userFunctions.FirstLogin(email);
    }
    //encrypt decrypt authenticatin link
    public static string Encrypt(string data)
    {
        TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

        DES.Mode = CipherMode.ECB;
        DES.Key = Encoding.ASCII.GetBytes("HOPEINTOMORROW01");

        DES.Padding = PaddingMode.PKCS7;
        ICryptoTransform DESEncrypt = DES.CreateEncryptor();
        Byte[] Buffer = ASCIIEncoding.ASCII.GetBytes(data);

        return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
    }

    public static string Decrypt(string data)
    {
        TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

        DES.Mode = CipherMode.ECB;
        DES.Key = Encoding.ASCII.GetBytes("HOPEINTOMORROW01"); 

        DES.Padding = PaddingMode.PKCS7;
        ICryptoTransform DESEncrypt = DES.CreateDecryptor();
        Byte[] Buffer = Convert.FromBase64String(data.Replace(" ", "+"));

        return Encoding.UTF8.GetString(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
    }
}

