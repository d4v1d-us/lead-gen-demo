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
/// Summary description for User
/// </summary>
public class User
{
    protected int gbuser_id;
    protected string gbcollider_no;
    protected string gbname;
    protected string gbuname;
    protected string gbpword;
    protected string gbphone;
    protected string gbposition;
    protected string gbaccess;
	
    public User()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int user_id
    {
        get { return gbuser_id; }
        set { gbuser_id = value; }
    }
    public string collider_no
    {
        get { return gbcollider_no; }
        set { gbcollider_no = value; }
    }
    public string name
    {
        get { return gbname; }
        set { gbname = value; }
    }
    public string uname
    {
        get { return gbuname; }
        set { gbuname = value; }
    }
    public string pword
    {
        get { return gbpword; }
        set { gbpword = value; }
    }
    public string phone
    {
        get { return gbphone; }
        set { gbphone = value; }
    }
    public string position
    {
        get { return gbposition; }
        set { gbposition = value; }
    }
    public string access
    {
        get { return gbaccess; }
        set { gbaccess = value; }
    }
}
