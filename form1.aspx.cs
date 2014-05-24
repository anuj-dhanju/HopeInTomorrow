using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

public partial class form1: System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["x_amount"] == null)
        {
            Response.Redirect("Donate_form.aspx");
            
        }
        else
        {
            
            StringBuilder sb = new StringBuilder();
            // x_login^x_fp_sequence^x_fp_timestamp^x_amount^x_currency
            x_login.Value = "WSP-VENTU-58IQZwAhPQ";//x_login
            Random random = new Random();
            x_fp_sequence.Value = (random.Next(0, 1000)).ToString();
            x_test_request.Value = "true";
            x_show_form.Value = "PAYMENT_FORM";
            TimeSpan t = (DateTime.UtcNow - new DateTime(1970, 1, 1));

            int timestamp = (int)t.TotalSeconds;
            x_fp_timestamp.Value = timestamp.ToString();

            x_amount.Value = (string)Session["x_amount"];

            //String x_currency = "USD"; // default empty


            sb.Append(x_login.Value)
                .Append("^")
                .Append(x_fp_sequence.Value)
                .Append("^")
                .Append(x_fp_timestamp.Value)
                .Append("^")
                .Append(x_amount.Value)
                .Append("^")
                .Append("");

            // Convert string to array of bytes. 
            byte[] data = Encoding.UTF8.GetBytes(sb.ToString());

            // key
            byte[] key = Encoding.UTF8.GetBytes("F1pnOOMHVFRaBe_0gMwl");//transaction_key

            // Create HMAC-SHA1 Algorithm;  
            HMACMD5 hmac = new HMACMD5(key);

            // Create HMAC-SHA1 Algorithm;  
            // HMACSHA1 hmac = new HMACSHA1(key);

            // Compute hash. 
            byte[] hashBytes = hmac.ComputeHash(data);

            // Convert to HEX string.  
            x_fp_hash.Value = System.BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            Session["x_amount"] = null;
        }

    }
}