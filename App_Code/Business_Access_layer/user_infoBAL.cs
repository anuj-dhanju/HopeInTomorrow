using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for user_infoBAL
/// </summary>
public class user_infoBAL
{
	public user_infoBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    user_infoDAL u_infoDAL = new user_infoDAL();

    public bool user_info_insert(user_infoBO u_infobo)
    {
        try
        {
            return u_infoDAL.user_info_insert(u_infobo);
        }
        catch
        {
            throw;
        }
    }

    public DataTable view_users(user_infoBO ubo)
    {
        user_infoDAL uDAL = new user_infoDAL();
        try
        {
            return uDAL.view_users(ubo);

        }
        catch (Exception)
        {

            throw;
        }
        finally { uDAL = null; }
    }

    public void delete_users(user_infoBO ubo)
    {
        user_infoDAL uDAL = new user_infoDAL();
        try
        {
             uDAL.delete_user(ubo);

        }
        catch (Exception)
        {

            throw;
        }
        finally { uDAL = null; }
    }
}