using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for news
/// </summary>
public class newsBO
{
	public newsBO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int news_id
    {
        set;
        get;
    }
    public string news_pic
    {
        get;
        set;
    }
    public int admin_id
    {
        set;
        get;
    }



    public String news_title
    {
        get;
        set;
    }

    public String news_desc
    {
        set;
        get;
    }

    public DateTime date_time_of_post
    {
        set;
        get;
    }



}