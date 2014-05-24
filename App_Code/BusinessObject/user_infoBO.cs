using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for user_info_BO
/// </summary>
public class user_infoBO
{
	public user_infoBO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int user_id
    {
        set;
        get;
    }

    public String email_id
    {
        set;
        get;
    }


    public String first_name
    {
        get;
        set;
    }

    public String last_name
    {
        set;
        get;
    }

    public String password
    {
        set;
        get;
    }

    public int user_type
    {
        set;
        get;
    }

    public String country
    {
        set;
        get;
    }

    public String city
    {
        set;
        get;
    }

    public DateTime join_date
    {
        set;
        get;
    }

    public String profile_pic
    {
        set;
        get;
    }

    public Boolean social
    {
        get;
        set; 
    }
    public String social_type
    {
        get;
        set;
    }

}