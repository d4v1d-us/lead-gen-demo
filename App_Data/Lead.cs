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
/// Summary description for Lead
/// </summary>
public class Lead
{
    protected int gblead_id;
    protected string gblead_no;
	protected int gbstatus_id;
	protected int gblead_type_id;
	protected string gbTag;

	protected string gbLid;
	protected string gbfirst_name;
    protected string gbname_middle;
	protected string gblast_name;
	protected string gbstreet_addr1;
	protected string gbstreet_addr2;

	protected string gbcity;
	protected string gbstate;
	protected string gbZip;

	protected string gbmonths_at_address;
    protected string gbmonths_at_address1;
    protected string gbmonths_at_address2;

	protected int gbown_home;

	protected string gbsocial_security;
	protected string gbphone_home;
	protected string gbphone_cell;
    protected string gbphone_fax;
	protected string gbphone_work;
	protected string gbphone_work_ext;

	protected string gbEmail;
	protected string gbemail_alternate;
	protected string gbbirth_date;
	protected string gbdrivers_license;
	protected string gbdrivers_license_st;

	protected int gbis_military;
	protected string gbemployer_name;

	protected string gbmonths_employed;
    protected string gbmonths_employed1;
    protected string gbmonths_employed2;

	protected string gbincome_type;
	protected string gbincome_monthly;

	protected string gbpay_per_period;
    protected string gbpay_per_period1;
    protected string gbpay_per_period2;
    protected string gbpay_per_period3;
    protected string gbpay_per_period4;

	protected string gbpay_frequency;
	protected int gbdirect_deposit;
	protected string gbpay_day1;
	protected string gbpay_day2;

	protected string gbbank_aba;
	protected string gbbank_account;
	protected string gbbank_account_type;
	protected string gbbank_name;

	protected string gbmonths_at_bank;
    protected string gbmonths_at_bank1;
    protected string gbmonths_at_bank2;

	protected string gbrequested_amount;
	protected int gbaccepted_terms;
	protected string gbclient_ip_address;
	protected string gbclient_url_root;
	protected int gbis_live;

	protected string gbredirect_url;
	protected string gberror_description;
	protected string gbdeclined_description;
	protected string gbprice;
	protected string gbbuyer_id;

	protected string gblast_action;
	protected string gbaction_code;
	protected string gbaction_dt;
	protected int gbbulk_email;
	protected int gbexport;

    protected string gblink_source = "none";

	protected string gbCustomer_Notes;
	protected DateTime gbcreated_dt;

    protected string gbtree; //lead sell placement tree tracking for leadcollider
    protected int gbcurr_tree = 1; //current lead sell placement tree 1 to number of intergrated trees
    protected int gbfinal_tree; //has the lead been sent to all trees 1 true, 0 false
    protected string gbpost_response;

    protected int gbtree_post_error;

    protected int gbshort_form_email; //has the email been sent for short form 1 true, 0 false
    protected int gbdenied_email; //has the email been sent for denied application 1 true, 0 false

    protected string gbbest_call_time;
    protected string gbcali_agree = "AGREE";
    protected string gbcitizen = "TRUE";

    protected string gbdate_dob_d;
    protected string gbdate_dob_m;
    protected string gbdate_dob_y;

    protected string gbemployer_length;

    protected string gbhome_unit;

    protected string gbincome_date1_d;
    protected string gbincome_date1_m;
    protected string gbincome_date1_y;

    protected string gbincome_date2_d;
    protected string gbincome_date2_m;
    protected string gbincome_date2_y;

    protected string gbincome_direct_deposit;
    protected string gbincome_frequency;

    protected string gblegal_notice_1 = "TRUE";

    protected string gbmilitary;

    protected string gboffers = "TRUE";

    protected string gbref_01_name_full;
    protected string gbref_01_phone_home;
    protected string gbref_01_relationship;

    protected string gbref_02_name_full;
    protected string gbref_02_phone_home;
    protected string gbref_02_relationship;

    protected string gbresidence_start_date;
    protected string gbresidence_type;

    protected string gbssn_part_1;
    protected string gbssn_part_2;
    protected string gbssn_part_3;

    protected string gbtrack_key;
	
    public Lead()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string best_call_time
    {
        get { return gbbest_call_time; }
        set { gbbest_call_time = value; }
    }

    public string cali_agree
    {
        get { return gbcali_agree; }
        set { gbcali_agree = value; }
    }

    public string citizen
    {
        get { return gbcitizen; }
        set { gbcitizen = value; }
    }

    public string date_dob_d
    {
        get { return gbdate_dob_d; }
        set { gbdate_dob_d = value; }
    }

    public string date_dob_m
    {
        get { return gbdate_dob_m; }
        set { gbdate_dob_m = value; }
    }

    public string date_dob_y
    {
        get { return gbdate_dob_y; }
        set { gbdate_dob_y = value; }
    }

    public string employer_length
    {
        get { return gbemployer_length; }
        set { gbemployer_length = value; }
    }

    public string home_unit
    {
        get { return gbhome_unit; }
        set { gbhome_unit = value; }
    }

    public string income_date1_d
    {
        get { return gbincome_date1_d; }
        set { gbincome_date1_d = value; }
    }

    public string income_date1_m
    {
        get { return gbincome_date1_m; }
        set { gbincome_date1_m = value; }
    }

    public string income_date1_y
    {
        get { return gbincome_date1_y; }
        set { gbincome_date1_y = value; }
    }

    public string income_date2_d
    {
        get { return gbincome_date2_d; }
        set { gbincome_date2_d = value; }
    }

    public string income_date2_m
    {
        get { return gbincome_date2_m; }
        set { gbincome_date2_m = value; }
    }

    public string income_date2_y
    {
        get { return gbincome_date2_y; }
        set { gbincome_date2_y = value; }
    }

    public string income_direct_deposit
    {
        get { return gbincome_direct_deposit; }
        set { gbincome_direct_deposit = value; }
    }

    public string income_frequency
    {
        get { return gbincome_frequency; }
        set { gbincome_frequency = value; }
    }

    public string legal_notice_1
    {
        get { return gblegal_notice_1; }
        set { gblegal_notice_1 = value; }
    }

    public string military
    {
        get { return gbmilitary; }
        set { gbmilitary = value; }
    }

    public string offers
    {
        get { return gboffers; }
        set { gboffers = value; }
    }

    public string ref_01_name_full
    {
        get { return gbref_01_name_full; }
        set { gbref_01_name_full = value; }
    }

    public string ref_01_phone_home
    {
        get { return gbref_01_phone_home; }
        set { gbref_01_phone_home = value; }
    }

    public string ref_01_relationship
    {
        get { return gbref_01_relationship; }
        set { gbref_01_relationship = value; }
    }

    public string ref_02_name_full
    {
        get { return gbref_02_name_full; }
        set { gbref_02_name_full = value; }
    }

    public string ref_02_phone_home
    {
        get { return gbref_02_phone_home; }
        set { gbref_02_phone_home = value; }
    }

    public string ref_02_relationship
    {
        get { return gbref_02_relationship; }
        set { gbref_02_relationship = value; }
    }

    public string residence_start_date
    {
        get { return gbresidence_start_date; }
        set { gbresidence_start_date = value; }
    }

    public string residence_type
    {
        get { return gbresidence_type; }
        set { gbresidence_type = value; }
    }

    public string ssn_part_1
    {
        get { return gbssn_part_1; }
        set { gbssn_part_1 = value; }
    }

    public string ssn_part_2
    {
        get { return gbssn_part_2; }
        set { gbssn_part_2 = value; }
    }

    public string ssn_part_3
    {
        get { return gbssn_part_3; }
        set { gbssn_part_3 = value; }
    }

    public string track_key
    {
        get { return gbtrack_key; }
        set { gbtrack_key = value; }
    }

    public int lead_id
    {
        get { return gblead_id; }
        set { gblead_id = value; }
    }

    public string lead_no
    {
        get { return gblead_no; }
        set { gblead_no = value; }
    }

    public int status_id
    {
        get { return gbstatus_id; }
        set { gbstatus_id = value; }
    }

    public int lead_type_id
    {
        get { return gblead_type_id; }
        set { gblead_type_id = value; }
    }

    public string tree
    {
        get { return gbtree; }
        set { gbtree = value; }
    }

    public int curr_tree
    {
        get { return gbcurr_tree; }
        set { gbcurr_tree = value; }
    }

    public int final_tree
    {
        get { return gbfinal_tree; }
        set { gbfinal_tree = value; }
    }

    public int short_form_email
    {
        get { return gbshort_form_email; }
        set { gbshort_form_email = value; }
    }

    public int denied_email
    {
        get { return gbdenied_email; }
        set { gbdenied_email = value; }
    }

    public string Tag
    {
        get { return gbTag; }
        set { gbTag = value; }
    }

    public string Lid
    {
        get { return gbLid; }
        set { gbLid = value; }
    }

    public string first_name
    {
        get { return gbfirst_name; }
        set { gbfirst_name = value; }
    }

    public string name_middle
    {
        get { return gbname_middle; }
        set { gbname_middle = value; }
    }

    public string last_name
    {
        get { return gblast_name; }
        set { gblast_name = value; }
    }

    public string street_addr1
    {
        get { return gbstreet_addr1; }
        set { gbstreet_addr1 = value; }
    }

    public string street_addr2
    {
        get { return gbstreet_addr2; }
        set { gbstreet_addr2 = value; }
    }

    public string city
    {
        get { return gbcity; }
        set { gbcity = value; }
    }

    public string state
    {
        get { return gbstate; }
        set { gbstate = value; }
    }

    public string Zip
    {
        get { return gbZip; }
        set { gbZip = value; }
    }

    public string months_at_address
    {
        get { return gbmonths_at_address; }
        set { gbmonths_at_address = value; }
    }

    public string months_at_address1
    {
        get { return gbmonths_at_address1; }
        set { gbmonths_at_address1 = value; }
    }

    public string months_at_address2
    {
        get { return gbmonths_at_address2; }
        set { gbmonths_at_address2 = value; }
    }

    public int own_home
    {
        get { return gbown_home; }
        set { gbown_home = value; }
    }

    public string social_security
    {
        get { return gbsocial_security; }
        set { gbsocial_security = value; }
    }

    public string phone_home
    {
        get { return gbphone_home; }
        set { gbphone_home = value; }
    }

    public string phone_cell
    {
        get { return gbphone_cell; }
        set { gbphone_cell = value; }
    }

    public string phone_fax
    {
        get { return gbphone_fax; }
        set { gbphone_fax = value; }
    }

    public string phone_work
    {
        get { return gbphone_work; }
        set { gbphone_work = value; }
    }

    public string phone_work_ext
    {
        get { return gbphone_work_ext; }
        set { gbphone_work_ext = value; }
    }

    public string Email
    {
        get { return gbEmail; }
        set { gbEmail = value; }
    }

    public string email_alternate
    {
        get { return gbemail_alternate; }
        set { gbemail_alternate = value; }
    }

    public string birth_date
    {
        get { return gbbirth_date; }
        set { gbbirth_date = value; }
    }

    public string drivers_license
    {
        get { return gbdrivers_license; }
        set { gbdrivers_license = value; }
    }

    public string drivers_license_st
    {
        get { return gbdrivers_license_st; }
        set { gbdrivers_license_st = value; }
    }

    public int is_military
    {
        get { return gbis_military; }
        set { gbis_military = value; }
    }

    public string employer_name
    {
        get { return gbemployer_name; }
        set { gbemployer_name = value; }
    }

    public string months_employed
    {
        get { return gbmonths_employed; }
        set { gbmonths_employed = value; }
    }

    public string months_employed1
    {
        get { return gbmonths_employed1; }
        set { gbmonths_employed1 = value; }
    }

    public string months_employed2
    {
        get { return gbmonths_employed2; }
        set { gbmonths_employed2 = value; }
    }

    public string income_type
    {
        get { return gbincome_type; }
        set { gbincome_type = value; }
    }

    public string income_monthly
    {
        get { return gbincome_monthly; }
        set { gbincome_monthly = value; }
    }

    public string pay_per_period
    {
        get { return gbpay_per_period; }
        set { gbpay_per_period = value; }
    }

    public string pay_per_period1
    {
        get { return gbpay_per_period1; }
        set { gbpay_per_period1 = value; }
    }

    public string pay_per_period2
    {
        get { return gbpay_per_period2; }
        set { gbpay_per_period2 = value; }
    }

    public string pay_per_period3
    {
        get { return gbpay_per_period3; }
        set { gbpay_per_period3 = value; }
    }

    public string pay_per_period4
    {
        get { return gbpay_per_period4; }
        set { gbpay_per_period4 = value; }
    }

    public string pay_frequency
    {
        get { return gbpay_frequency; }
        set { gbpay_frequency = value; }
    }

    public int direct_deposit
    {
        get { return gbdirect_deposit; }
        set { gbdirect_deposit = value; }
    }

    public string pay_day1
    {
        get { return gbpay_day1; }
        set { gbpay_day1 = value; }
    }

    public string pay_day2
    {
        get { return gbpay_day2; }
        set { gbpay_day2 = value; }
    }

    public string bank_aba
    {
        get { return gbbank_aba; }
        set { gbbank_aba = value; }
    }

    public string bank_account
    {
        get { return gbbank_account; }
        set { gbbank_account = value; }
    }

    public string bank_account_type
    {
        get { return gbbank_account_type; }
        set { gbbank_account_type = value; }
    }

    public string bank_name
    {
        get { return gbbank_name; }
        set { gbbank_name = value; }
    }

    public string months_at_bank
    {
        get { return gbmonths_at_bank; }
        set { gbmonths_at_bank = value; }
    }

    public string months_at_bank1
    {
        get { return gbmonths_at_bank1; }
        set { gbmonths_at_bank1 = value; }
    }

    public string months_at_bank2
    {
        get { return gbmonths_at_bank2; }
        set { gbmonths_at_bank2 = value; }
    }

    public string requested_amount
    {
        get { return gbrequested_amount; }
        set { gbrequested_amount = value; }
    }

    public int accepted_terms
    {
        get { return gbaccepted_terms; }
        set { gbaccepted_terms = value; }
    }

    public string client_ip_address
    {
        get { return gbclient_ip_address; }
        set { gbclient_ip_address = value; }
    }

    public string client_url_root
    {
        get { return gbclient_url_root; }
        set { gbclient_url_root = value; }
    }

    public int is_live
    {
        get { return gbis_live; }
        set { gbis_live = value; }
    }

    public string redirect_url
    {
        get { return gbredirect_url; }
        set { gbredirect_url = value; }
    }

    public string error_description
    {
        get { return gberror_description; }
        set { gberror_description = value; }
    }

    public string declined_description
    {
        get { return gbdeclined_description; }
        set { gbdeclined_description = value; }
    }
    public string price
    {
        get { return gbprice; }
        set { gbprice = value; }
    }

    public string buyer_id
    {
        get { return gbbuyer_id; }
        set { gbbuyer_id = value; }
    }

    public string last_action
    {
        get { return gblast_action; }
        set { gblast_action = value; }
    }

    public string action_code
    {
        get { return gbaction_code; }
        set { gbaction_code = value; }
    }

    public string action_dt
    {
        get { return gbaction_dt; }
        set { gbaction_dt = value; }
    }

    public int bulk_email
    {
        get { return gbbulk_email; }
        set { gbbulk_email = value; }
    }

    public int export
    {
        get { return gbexport; }
        set { gbexport = value; }
    }

    public string link_source
    {
        get { return gblink_source; }
        set { gblink_source = value; }
    }

    public string Customer_Notes
    {
        get { return gbCustomer_Notes; }
        set { gbCustomer_Notes = value; }
    }

    public DateTime created_dt
    {
        get { return gbcreated_dt; }
        set { gbcreated_dt = value; }
    }

    public int tree_post_error
    {
        get { return gbtree_post_error; }
        set { gbtree_post_error = value; }
    }

    public string post_response
    {
        get { return gbpost_response; }
        set { gbpost_response = value; }
    }
    

}
