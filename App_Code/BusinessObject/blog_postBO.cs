using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for blogBO
/// </summary>
public class blog_postBO
{
    public blog_postBO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int blog_id
    {
        set;
        get;
    }

    public String blog_content
    {
        set;
        get;
    }


    public String blog_title
    {
        set;
        get;
    }

    public int poster_id
    {
        set;
        get;
    }

    public Boolean is_admin
    {
        set;
        get;
    }

    public DateTime date_time_of_post
    {
        set;
        get;
    }

    public Boolean blog_checked
    {
        set;
        get;
    }

}