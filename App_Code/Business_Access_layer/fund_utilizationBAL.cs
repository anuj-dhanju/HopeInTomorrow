using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for fund_utilizationBAL
/// </summary>
public class fund_utilizationBAL
{
	public fund_utilizationBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    AdminFunctionsDAL fundDAL = new AdminFunctionsDAL();
    fund_utilizationBO fundBO = new fund_utilizationBO();
    public fund_utilizationBO fund_info_retrive()
    {
        try
        {

            return fundDAL.fund_info_retrive();
        }

        catch (Exception)
        {

            throw;
        }
    }
    public bool fund_info_save( fund_utilizationBO fundBO1)
    {
        try
        {

            return fundDAL.fund_info_save(fundBO1);
            }

        catch (Exception)
        {

            throw;
        }
    }


}