using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for funds_BAL
/// </summary>
public class funds_BAL
{
	public funds_BAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    fundsDAl fdal = new fundsDAl();
    public int funds_DAL_insert(fundsBO funds_BO)
    {
        try
        {
            return fdal.funds_DAL_insert(funds_BO);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}

