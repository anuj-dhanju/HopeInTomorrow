using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for event_subscriberBAL
/// </summary>
public class event_subscriberBAL
{
	public event_subscriberBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    event_subscriberDAL event_subscriber__dal = new event_subscriberDAL();
    //del events subscri
    public int evetns_sub_delBAL(event_subscriberBO event_subBO)
    {
        try
        {
            return event_subscriber__dal.event_subs_delDAL(event_subBO);
        }
        catch (Exception)
        {

            throw;
        }
    }
    //unsubscirbe event
    public int evetnUnSubscribeDAL(event_subscriberBO event_subscriber_bo)
    {
        try
        {
            return event_subscriber__dal.evetnUnSubscribeDAL(event_subscriber_bo);
        }
        catch (Exception)
        {

            throw;
        }
    }
    //displaying user info and events details
    public DataTable evetns_sub_userifoBAL()
    {
        try
        {
            return event_subscriber__dal.event_sub_userinfoDAL();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public int evetnsubscriberDAL(event_subscriberBO event_subscriber_bo)
    {
        try
        {
           return event_subscriber__dal.evetnsubscriberDAL(event_subscriber_bo);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    //public DataTable eventSubscriber_getEvetnID_DAL(event_subscriberBO event_subscriber_bo)
    //{
    //    try
    //    {
    //        return event_subscriber__dal.eventSubscriber_getEvetnID_DAL(event_subscriber_bo);
    //    }
    //    catch (Exception)
    //    {
            
    //        throw;
    //    }
    //}


    public bool eventSubscriber_getEvent_id_DAL(event_subscriberBO event_subscriber_bo)
    {
        try
        {
            return event_subscriber__dal.eventSubscriber_getEvent_id_DAL(event_subscriber_bo);
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}