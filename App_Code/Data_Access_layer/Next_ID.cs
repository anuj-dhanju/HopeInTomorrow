using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Next_ID
/// </summary>
public class Next_ID
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["hit"].ConnectionString);

    public int incrementer(String colname, String tblname)
    {

        try
        {
            
            
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int nid = 0;
            String query = "select max("+colname+") from "+ tblname.ToString();
            SqlCommand cmd = new SqlCommand(query,con);


            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    if (reader[0] != DBNull.Value)
                    {
                        
                        nid = Convert.ToInt32(reader[0]);
                        nid += 1;
                    }
                    else
                    {
                        nid = 1;
                    }
                }
                else
                {
                    nid = 1;
                }
            }

            else
            {
                nid = 1;
            }


            cmd.Dispose();
            reader.Dispose();
            con.Close();
            return nid;
        }

        catch
        {
            throw;
        }
        finally
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }

}