using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for blog_comments
/// </summary>
public class blog_commentsBO
{
	public blog_commentsBO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int comment_id
    {
        set;
        get;
    }

    public int blog_id
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


    public String comment
    {
        set;
        get;
    }

    public DateTime date_time_of_comment
    {
        set;
        get;
    }

}