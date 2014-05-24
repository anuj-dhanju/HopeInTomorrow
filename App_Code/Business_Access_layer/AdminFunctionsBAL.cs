using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AdminLogin
/// </summary>
public class AdminFunctionsBAL
{
    AdminFunctionsDAL adminfunction = new AdminFunctionsDAL();


    public Boolean AdminLoginAuthenticate(admin_infoBO admin_credentials)
    {
        try
        {

            return adminfunction.AdminLoginAuthenticate(admin_credentials);
        }
        catch
        {
            throw;
        }

    }


    public admin_infoBO AdminCompleteInfoFetch(admin_infoBO admin_info)
    {
        try
        {
            return adminfunction.AdminCompleteInfoFetch(admin_info);
        }

        catch
        {
            throw;
        }
    }

    public String AdminPasswordChange(admin_infoBO admin_info,String newpass)
    {

        if (adminfunction.AdminPasswordChange(admin_info, newpass))
        {
            return "Password Changed successfully";
        }

        else
        {
            return "Something went wrong and password didn't change";
        }
    }


    public DataSet ListAllUsers()
    {
        try
        {

            return adminfunction.ListAllUsers();
        }
        catch
        {
            throw;
        }
    }


    public DataSet AdminBlogLister()
    {
        try
        {

            return adminfunction.AdminBlogLister();
        }
        catch 
        {
            throw;
        }
    }

    public DataSet MyBlogLister(int admin_id)
    {
        try
        {
            return adminfunction.MyBlogLister(admin_id);
        }

        catch
        {
            throw;
        }
    }

    public void AdminBlogDelete(blog_postBO blogInfo)
    {
        try
        {
            adminfunction.AdminBlogDelete(blogInfo);
        }
        catch
        {
            throw; 
        }
    }


    public blog_postBO AdminBlogViewer(int blog_id)
    {
        try
        {
            return adminfunction.AdminBlogViewer(blog_id);
        }
        catch
        {
            throw;
        }

    }


   public void AdminBlogEdit(blog_postBO nBlog)
   {
       try
       {
           adminfunction.AdminBlogEdit(nBlog);
       }

       catch
       {
           throw;
       }
   }


   public void AdminPostBlog(blog_postBO nblog)
   {
       try
       {
           adminfunction.AdminPostBlog(nblog);

       }
       catch
       {
           throw;
       }
   }



   public DataSet AdminNewPostRequestList()
   {
       try
       {
           return adminfunction.AdminNewPostRequestList();
       }
       catch
       {
           throw;
       }

   }

   public long numberOfNewPostRequest()
   {
       try
       {
           return adminfunction.numberOfNewPostRequest();
       }
       catch
       {
           throw;
       }

   }

   public void AcceptNewPost(int blog_id)
   {
       try
       {
           adminfunction.AcceptNewPost(blog_id);
       }
       catch
       {
           throw;
       }
   }



   public String AdminName(int admin_id)
   {
       try
       {
           return adminfunction.AdminName(admin_id);
       }
       catch
       {
           throw;
       }
   }

   public DataSet AdminEventLister()
   {
       try
       {
           return adminfunction.AdminEventLister();
       }
       catch
       {
           throw;
       }
   }
    //update events 
   public int event_Bal_Update(eventsBO event_bo)
   {
       try
       {
           return adminfunction.event_DAL_update(event_bo);
       }
       catch
       {
           throw;
       }
   }
    //retriving Events
   public DataSet event_retrive(eventsBO eventbo)
   {
       return adminfunction.events_DAl_Retrive(eventbo);
   }
    //deletind events by using event_id
   public int event_BAL_delete(eventsBO eventbo)
   {
       return adminfunction.event_DAL_del(eventbo);
   }
   public void PostNewEvent(eventsBO new_event)
   {
       try
       {
           adminfunction.PostNewEvent(new_event);
       }

       catch
       {
           throw;
       }
   }
    //top 3 events
   public DataSet TopFiveEvents()
   {
       return adminfunction.TopFiveEvetns();
   }
   //admin inbox
   public DataSet AdminMsgLister()
   {
       try
       {

           return adminfunction.AdminMsgLister();
       }
       catch
       {
           throw;
       }
   }
   public void AdminMsgDelete(suggestionBO sugesstionInfo)
   {
       try
       {
           adminfunction.AdminMsgDelete(sugesstionInfo);
       }
       catch
       {
           throw;
       }
   }
   public suggestionBO AdminMsgViewer(int msg_id)
   {
       try
       {
           return adminfunction.AdminMsgViewer(msg_id);
       }
       catch
       {
           throw;
       }

   }
   public long numberOfNewMsg()
   {
       try
       {
           return adminfunction.numberOfNewMsg();
       }
       catch
       {
           throw;
       }

   }

   
}