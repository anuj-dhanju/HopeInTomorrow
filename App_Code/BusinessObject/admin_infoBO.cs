using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoginBO
/// </summary>
public class admin_infoBO
{
	public admin_infoBO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int admin_id
    {
        get;
        set;
    }
    public String email_id
    {
        get;
        set;
    }

    public String password
    {
        get;
        set;
    }

    public String first_name
    {
        get;
        set;
    }

    public String last_name
    {
        get;
        set;
    }


}