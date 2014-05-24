using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net.Mail;

/// <summary>
/// Summary description for ErrorReport
/// </summary>
public class ErrorReportBAL
{
	public ErrorReportBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void SendErrorReport(String PageName, String errorMsg)
    {
        try
        {
            String msgBody = "<div style='font-family:Arial, Helvetica, sans-serif;'> <h2><font style='color:red'> Hope In Tomorrow : Error Report </font></h2> <br/><br/> <h4><u> Page on which error occured : " + PageName + "</u></h4> <br/><br/> <h5> Error Description : </h5> <br/>" + errorMsg + " </div>";

            MailMessage msg = new MailMessage(ConfigurationManager.AppSettings["FromEmail"], "aktomjerry@gmail.com", "Hope In Tomorrow : Error Report", msgBody);
            msg.IsBodyHtml = true;
            msg.Bcc.Add("456sainiusha@gmail.com");
            msg.Bcc.Add("aktomjerry@hotmail.com");
            msg.Bcc.Add("anuj.kumar.x@venturepact.com");
            msg.Bcc.Add("uinyal.vikas.x@venturepact.com");
            msg.Bcc.Add("deepak.pandey.x@venturepact.com");
            msg.Bcc.Add("usha.saini.x@venturepact.com");
            msg.Bcc.Add("jasvinder.singh.x@venturepact.com");
            msg.Bcc.Add("anujdhanju@gmail.com");
            msg.Bcc.Add("ykcir.deep@hotmail.com");

            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["SMTP"].ToString();
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["FromEmail"].ToString(), ConfigurationManager.AppSettings["Pass"].ToString());
            smtp.Send(msg);
        }
        catch (Exception ex)
        {

        }
    }
}