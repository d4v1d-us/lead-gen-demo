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
/// Summary description for VenderInfo
/// </summary>
public class VenderInfo
{
    //******************
    //LeadFlash Info
    //******************
    protected string gbvendor_id = "325242";
    protected string gbvendor_pass = "242362429";

    //set test_app = 0 for live
    protected int gbtest_app = 0;

    //set to 1 Customer is redirected to leadflash confirmation page.  
    protected int gbauto_redirect = 0;

    //Where applicant will be redirected upon decline 
    protected string gbdeclined_redirect = "";

    //******************
    //PartnerWeekly Info
    //******************

    //Changed site_type soap_oc to soap_pw 5/25/2011
    protected string gbsite_type = "soap_pw";
    protected string gbpage = "app_allinone";

    //Testing Credentials
    // webservice url http://rc.tridentsecuredata.com/cm_soap.php?wsdl
    //protected string gblicense_key = "lic.olp.bb.sample";
    //protected int gbpromo_id = 99999;

    //Live Credentials
    // webservice url https://www.tridentsecuredata.com/cm_soap.php?wsdl
    protected string gblicense_key = "ecab5a9c5ef2f7996807625dd04124b6";
    protected int gbpromo_id = 36172;

    protected string gbpromo_sub_code = "vipcashfast";
    protected string gbpwadvid = "";

    //******************
    //LeadPile Info
    //******************
    //Testing Credentials
    //producer_id 116794713249 
    //producer_key vgdY9inDOeMWHl5NoalqMupWAIqMHgif 

    //Live Credentials
    //producer_id 1282921934481 
    //producer_key AwKNRIdg89kLrxQVq530LLGnh9NIHe5F

    protected string gbproducer_id = "1282921934481";
    protected string gbproducer_key = "AwKNRIdg89kLrxQVq530LLGnh9NIHe5F";
    protected string gblead_type = "payday";
    protected string gbadditional_lead_types = "";
    protected int gbself_select_hours = 72;
    protected string gbminimum_price = "2.00";

    //Maximum number of seconds to wait before timing out the request. Do not post for no timeout.
    protected int gbtimeout_seconds = 120; 

    //The IP address from which the request was received.
    protected string gblead_ip;

    //Optional field which can be used for tracking purposes in your LeadPile account (Sub ID).
    protected string gbsite ="vipcashfast.com";

    //Optional field which can be used for tracking purposes in your LeadPile account (Sub ID).
    protected string gbsource;

    //Optional field which can be used for tracking purposes in your LeadPile account (Sub ID).
    protected string gbcampaign;

    //Optional field which can be used for tracking purposes in your LeadPile account (Sub ID).
    protected string gbad;

    public VenderInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //LeadPile
    public string producer_id
    {
        get { return gbproducer_id; }
        //set { gbproducer_id = value; }
    }
    public string producer_key
    {
        get { return gbproducer_key; }
        //set { gbvendor_pass = value; }
    }
    public string lead_type
    {
        get { return gblead_type; }
        //set { gblead_type = value; }
    }
    public string additional_lead_types
    {
        get { return gbadditional_lead_types; }
        set { gbadditional_lead_types = value; }
    }
    public int self_select_hours
    {
        get { return gbself_select_hours; }
        set { gbself_select_hours = value; }
    }
    public string minimum_price
    {
        get { return gbminimum_price; }
        set { gbminimum_price = value; }
    }
    public int timeout_seconds
    {
        get { return gbtimeout_seconds; }
        set { gbtimeout_seconds = value; }
    }
    public string lead_ip
    {
        get { return gblead_ip; }
        set { gblead_ip = value; }
    }
    public string site
    {
        get { return gbsite; }
        set { gbsite = value; }
    }
    public string source
    {
        get { return gbsource; }
        set { gbsource = value; }
    }
    public string campaign
    {
        get { return gbcampaign; }
        set { gbcampaign = value; }
    }
    public string ad
    {
        get { return gbad; }
        set { gbad = value; }
    }

    //PartnerWeekly
    public string site_type
    {
        get { return gbsite_type; }
    }
    public string license_key
    {
        get { return gblicense_key; }
    }
    public string page
    {
        get { return gbpage; }
    }
    public int promo_id
    {
        get { return gbpromo_id; }
    }
    public string promo_sub_code
    {
        get { return gbpromo_sub_code; }
    }
    public string pwadvid
    {
        get { return gbpwadvid; }
    }

    //LeadFlash
    public string vendor_id
    {
        get { return gbvendor_id; }
        //set { gbvendor_id = value; }
    }
    public string vendor_pass
    {
        get { return gbvendor_pass; }
        //set { gbvendor_pass = value; }
    }
    public int test_app
    {
        get { return gbtest_app; }
        //set { gbtest_app = value; }
    }
    public int auto_redirect
    {
        get { return gbauto_redirect; }
        //set { gbauto_redirect = value; }
    }
    public string declined_redirect
    {
        get { return gbdeclined_redirect; }
        //set { gbdeclined_redirect = value; }
    }

    
    
}
