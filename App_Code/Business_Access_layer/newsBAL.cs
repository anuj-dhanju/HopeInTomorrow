using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Data;

/// <summary>
/// Summary description for newsBAL
/// </summary>
public class newsBAL
{
	public newsBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    newsDAL newsdal = new newsDAL();
    
    
    //loading data
    public DataSet news_DAL_viewALL()
    {
        try
        {
            
            return newsdal.news_DAL_viewALL();
        }

        catch (Exception)
        {
            
            throw;
        }
    }

    //insert
    public int news_DAL_insert(newsBO news_bo)
    {
        try
        {
            return newsdal.news_DAL_insert(news_bo);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    //view by id
    public DataTable  news_DAL_view_id(newsBO news_bo)
    {
        try
        {
            return newsdal.news_DAL_view_id(news_bo);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    //top 5 news
    public DataSet news_top3_BAL_view()
    {
        return newsdal.news_top3_DAL_view();
    }


    //delete
    public int news_DAL_del(newsBO news_bo)
    {
        try
        {
            return newsdal.news_DAL_del(news_bo);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}