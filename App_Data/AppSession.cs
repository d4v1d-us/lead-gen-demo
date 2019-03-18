using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for AppSession
/// </summary>
public class AppSession
{
    // private constructor 
    private AppSession() { }

    // Gets the current session. 
    public static AppSession Current
    {
        get
        {
            AppSession session =
              (AppSession)HttpContext.Current.Session["__AppSession__"];
            if (session == null)
            {
                session = new AppSession();
                HttpContext.Current.Session["__AppSession__"] = session;
            }
            return session;
        }
    }

    // **** add your session properties here, e.g like this: 
    public string Property1 { get; set; }
    public DateTime MyDate { get; set; }
    public int LoginId { get; set; }



}
