using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for suggestionBAL
/// </summary>
public class suggestionBAL
{
	public suggestionBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    suggestionDAL sug_dal = new suggestionDAL();
    public DataTable suggestion_DAL_ViewAll()
    {
        try
        {
            return sug_dal.suggestion_DAL_ViewAll();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public int suggestion_DAL_del(suggestionBO sug_bo)
    {
        try
        {
            return sug_dal.suggestion_DAL_del(sug_bo);
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    public int suggestion_DAL_insert(suggestionBO sug_bo)
    {
        try
        {
            return sug_dal.suggestion_DAL_insert(sug_bo);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}