using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for eventsBO
/// </summary>
public class eventsBO
{
	public eventsBO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int event_id
    {
        set;
        get;
    }

    public int admin_id
    {
        set;
        get;
    }


    public String event_title
    {
        set;
        get;
    }

    public String event_desc
    {
        set;
        get;
    }

    public DateTime event_time
    {
        set;
        get;
    }

    public String event_place
    {
        set;
        get;
    }

    public String event_pic
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