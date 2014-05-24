using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for suggestion
/// </summary>
public class suggestionBO
{
	public suggestionBO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int suggestion_id
    {
        set;
        get;
    }

    public string user_name
    {
        set;
        get;
    }

    public String suggestion_msg
    {
        set;
        get;
    }

    public DateTime date_time
    {
        set;
        get;
    }
    public string userEmail
    {
        set;
        get;
    }
public string subject
{
set;
get;
}

}