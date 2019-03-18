using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Web.Mail;
//using System.Windows.Forms;

namespace vipcashfast
{
    public partial class SecureApplication : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 60;
            Lead oLead = (Lead)Session["s_oLead"];

            if (!this.IsPostBack)
            {
                PopulateState();
                PopulateDrivers_license_st();
                PopulateIncome_type();
                PopulatePayfrequency();
                PopulateBankAccountType();
                PopulateRequestedAmount();

                try
                {
                    if (oLead.short_form_email == 0)
                    {
                        SendShortAppEmail();
                        oLead.short_form_email = 1;
                    }
                }
                catch
                {
                }

                try
                {
                    first_name.Text = oLead.first_name;
                    last_name.Text = oLead.last_name;
                    Email.Text = oLead.Email;

                    state.SelectedValue = oLead.state;
                    //if (oLead.state == "CA")
                    //{
                    //    show_cali_agree.Visible = true;
                    //}

                    requested_amount.SelectedValue = oLead.requested_amount;
                    Zip.Text = oLead.Zip;
                    drivers_license_st.SelectedValue = oLead.state;

                    try
                    {
                        string month;
                        string day;
                        string year;

                        DateTime GetNextPayDay1 = GetNextPayDay(DateTime.Now, 7);
                        month = GetNextPayDay1.Month.ToString();
                        if (month.Length == 1)
                        {
                            month = "0" + month;
                        }
                        pay_day1M.SelectedValue = month;

                        day = GetNextPayDay1.Day.ToString();
                        if (day.Length == 1)
                        {
                            day = "0" + day;
                        }
                        pay_day1D.SelectedValue = day;

                        year = GetNextPayDay1.Year.ToString();
                        pay_day1Y.Text = year;

                        DateTime GetNextPayDay2 = GetNextPayDay(DateTime.Now, 21);
                        month = GetNextPayDay2.Month.ToString();
                        if (month.Length == 1)
                        {
                            month = "0" + month;
                        }
                        pay_day2M.SelectedValue = month;

                        day = GetNextPayDay2.Day.ToString();
                        if (day.Length == 1)
                        {
                            day = "0" + day;
                        }
                        pay_day2D.SelectedValue = day;

                        year = GetNextPayDay2.Year.ToString();
                        pay_day2Y.Text = year;
                    }
                    catch
                    {
                        pay_day1Y.Text = DateTime.Now.Year.ToString();
                        pay_day2Y.Text = DateTime.Now.Year.ToString();
                    }

                    street_addr1.Focus();
                }
                catch
                {
                    oLead = null;
                    Response.Redirect("https://vipcashfast.com/?ls=RD");
                }

                if (oLead.status_id == 3) //if error status show message for resubmit
                {
                    //LeadPile
                    if (oLead.error_description.IndexOf("authorized",0) != -1)
                    {
                        //oLead.curr_tree = 3;
                        //oLead.tree_post_error = 0;
                        //oLead.Lid = "";
                        //oLead.redirect_url = "";
                        //oLead.declined_description = "";
                        //oLead.error_description = "";
                        //oLead.post_response = "";
                        oLead = null;
                        //Response.Redirect("SecureApproval.aspx");

                        Response.Redirect("Additional.Resources.aspx");
                    }

                    //if fraudulent send to LeadPile
                    if (oLead.error_description == "Applicant appears to have entered fraudulent information")
                    {
                        oLead.curr_tree = 3;
                        oLead.tree_post_error = 0;
                        oLead.Lid = "";
                        oLead.redirect_url = "";
                        oLead.declined_description = "";
                        oLead.error_description = "";
                        oLead.post_response = "";
                        oLead = null;
                        Response.Redirect("SecureApproval.aspx");

                        //Response.Redirect("Additional.Resources.aspx");
                    }

                    //some leadflash error msg just send to LeadPile
                    if (oLead.error_description == "Lead was recently posted by another source")
                    {
                        oLead.curr_tree = 3;
                        oLead.tree_post_error = 0;
                        oLead.Lid = "";
                        oLead.redirect_url = "";
                        oLead.declined_description = "";
                        oLead.error_description = "";
                        oLead.post_response = "";
                        oLead = null;
                        Response.Redirect("SecureApproval.aspx");

                        //Response.Redirect("Additional.Resources.aspx");
                    }

                    //some leadflash error msg just send to LeadPile
                    if (oLead.error_description == "Invalid Repost. Lead was previously sold or has been shown to our entire list of clients.")
                    {
                        oLead.curr_tree = 3;
                        oLead.tree_post_error = 0;
                        oLead.Lid = "";
                        oLead.redirect_url = "";
                        oLead.declined_description = "";
                        oLead.error_description = "";
                        oLead.post_response = "";
                        oLead = null;
                        Response.Redirect("SecureApproval.aspx");

                        //Response.Redirect("Additional.Resources.aspx");
                    }

                    ApplicationLabel.Text = "Processing Error<br><br>" + oLead.error_description + "<br>Please Resubmit your Application";

                    first_name.Text = oLead.first_name;
                    last_name.Text = oLead.last_name;
                    street_addr1.Text = oLead.street_addr1;
                    city.Text = oLead.city;
                    street_addr2.Text = oLead.street_addr2;
                    state.SelectedValue = oLead.state;
                    Zip.Text = oLead.Zip;

                    months_at_address1.SelectedValue = oLead.months_at_address1;
                    months_at_address2.SelectedValue = oLead.months_at_address2;

                    own_home.SelectedValue = oLead.own_home.ToString();
                    Email.Text = oLead.Email;

                    if (oLead.phone_home != "")
                    {
                        try
                        {
                            phone_home1.Text = oLead.phone_home.Substring(0, 3);
                            phone_home2.Text = oLead.phone_home.Substring(3, 3);
                            phone_home3.Text = oLead.phone_home.Substring(5, 4);
                        }
                        catch
                        {
                            phone_home1.Text = "";
                            phone_home2.Text = "";
                            phone_home3.Text = "";
                        }
                    }

                    email_alternate.Text = oLead.email_alternate;

                    if (oLead.phone_cell != "")
                    {
                        try
                        {
                            phone_cell1.Text = oLead.phone_cell.Substring(0, 3);
                            phone_cell2.Text = oLead.phone_cell.Substring(3, 3);
                            phone_cell3.Text = oLead.phone_cell.Substring(5, 4);
                        }
                        catch
                        {
                            phone_cell1.Text = "";
                            phone_cell2.Text = "";
                            phone_cell3.Text = "";
                        }
                    }

                    if (oLead.birth_date != "")
                    {
                        try
                        {
                            char[] delimiterChars = { '-', '\t' };
                            string text = oLead.birth_date;
                            string[] words = text.Split(delimiterChars);

                            birth_dateY.Text = words[0];
                            birth_dateM.SelectedValue = words[1];
                            birth_dateD.SelectedValue = words[2];
                        }
                        catch
                        {
                            birth_dateY.Text = "";

                            birth_dateM.SelectedValue = "Select";
                            birth_dateD.SelectedValue = "Select";
                        }
                    }

                    is_military.SelectedValue = oLead.is_military.ToString();
                    employer_name.Text = oLead.employer_name;

                    if (oLead.phone_work != "")
                    {
                        try
                        {
                            phone_work1.Text = oLead.phone_work.Substring(0, 3);
                            phone_work2.Text = oLead.phone_work.Substring(3, 3);
                            phone_work3.Text = oLead.phone_work.Substring(5, 4);
                        }
                        catch
                        {
                            phone_work1.Text = "";
                            phone_work2.Text = "";
                            phone_work3.Text = "";
                        }
                    }

                    months_employed1.SelectedValue = oLead.months_employed1;
                    months_employed2.SelectedValue = oLead.months_employed2;

                    phone_work_ext.Text = oLead.phone_work_ext;
                    income_type.SelectedValue = oLead.income_type;
                    direct_deposit.SelectedValue = oLead.direct_deposit.ToString();
                    pay_frequency.SelectedValue = oLead.pay_frequency;

                    if (oLead.pay_day1 != "")
                    {
                        try
                        {
                            char[] delimiterChars = { '-', '\t' };
                            string text = oLead.pay_day1;
                            string[] words = text.Split(delimiterChars);

                            pay_day1Y.Text = words[0];
                            pay_day1M.SelectedValue = words[1];
                            pay_day1D.SelectedValue = words[2];
                        }
                        catch
                        {
                            //pay_day1Y.Text = "";
                            //pay_day1M.SelectedValue = "Select";
                            //pay_day1D.SelectedValue = "Select";
                        }
                    }                 
                    
                    //pay_per_period.SelectedValue = oLead.pay_per_period;
                    pay_per_period1.SelectedValue = oLead.pay_per_period1;
                    pay_per_period2.SelectedValue = oLead.pay_per_period2;
                    pay_per_period3.SelectedValue = oLead.pay_per_period3;
                    pay_per_period4.SelectedValue = oLead.pay_per_period4;


                    if (oLead.pay_day2 != "")
                    {
                        try
                        {
                            char[] delimiterChars = { '-', '\t' };
                            string text = oLead.pay_day2;
                            string[] words = text.Split(delimiterChars);

                            pay_day2Y.Text = words[0];
                            pay_day2M.SelectedValue = words[1];
                            pay_day2D.SelectedValue = words[2];
                        }
                        catch
                        {
                            //pay_day2Y.Text = "";
                            //pay_day2M.SelectedValue = "Select";
                            //pay_day2D.SelectedValue = "Select";
                        }
                    }    
                    
                    //income_monthly.SelectedValue = oLead.income_monthly;
                    //income_monthly.Text = oLead.income_monthly;

                    bank_name.Text = oLead.bank_name;

                    months_at_bank1.SelectedValue = oLead.months_at_bank1;
                    months_at_bank2.SelectedValue = oLead.months_at_bank2;

                    bank_account_type.SelectedValue = oLead.bank_account_type;
                    bank_aba.Text = oLead.bank_aba;
                    bank_account.Text = oLead.bank_account;
                    social_security.Text = oLead.social_security;
                    drivers_license.Text = oLead.drivers_license;
                    drivers_license_st.SelectedValue = oLead.drivers_license_st;
                    requested_amount.Text = oLead.requested_amount;
                    accepted_terms.SelectedValue = oLead.accepted_terms.ToString();

                    //references
                    ref_01_name_full.Text = oLead.ref_01_name_full;
                    ref_01_relationship.SelectedValue = oLead.ref_01_relationship;

                    if (oLead.ref_01_phone_home != "")
                    {
                        try
                        {
                            ref_01_phone_home1.Text = oLead.ref_01_phone_home.Substring(0, 3);
                            ref_01_phone_home2.Text = oLead.ref_01_phone_home.Substring(3, 3);
                            ref_01_phone_home3.Text = oLead.ref_01_phone_home.Substring(5, 4);
                        }
                        catch
                        {
                            ref_01_phone_home1.Text = "";
                            ref_01_phone_home2.Text = "";
                            ref_01_phone_home3.Text = "";
                        }
                    }

                    ref_02_name_full.Text = oLead.ref_02_name_full;
                    ref_02_relationship.SelectedValue = oLead.ref_02_relationship;

                    if (oLead.ref_02_phone_home != "")
                    {
                        try
                        {
                            ref_02_phone_home1.Text = oLead.ref_02_phone_home.Substring(0, 3);
                            ref_02_phone_home2.Text = oLead.ref_02_phone_home.Substring(3, 3);
                            ref_02_phone_home3.Text = oLead.ref_02_phone_home.Substring(5, 4);
                        }
                        catch
                        {
                            ref_02_phone_home1.Text = "";
                            ref_02_phone_home2.Text = "";
                            ref_02_phone_home3.Text = "";
                        }
                    }  
                }              
            }
        }

        public static DateTime GetNextPayDay (DateTime sdate, int NextDays ) 
        {
            //(sdate.Year, sdate.Month, 1);
            DateTime GetNextPayDay = DateTime.Now;
            while (GetNextPayDay.DayOfWeek != DayOfWeek.Friday) 
            { 
                GetNextPayDay = GetNextPayDay.AddDays(1); 
            }
            GetNextPayDay = GetNextPayDay.AddDays(NextDays);
            return GetNextPayDay; 
        }

        private void SendShortAppEmail()
        {
            Lead oLead = (Lead)Session["s_oLead"];

            const string SERVER = "relay-hosting.secureserver.net";
            MailMessage oMail = new System.Web.Mail.MailMessage();
            oMail.From = "service@vipcashfast.com";
            oMail.To = oLead.Email;
            oMail.Subject = "Your VIPCashFast Application";
            oMail.BodyFormat = MailFormat.Html; // enumeration
            oMail.Priority = MailPriority.High; // enumeration

            oMail.Body = "Dear " + oLead.first_name + ",<br /><br />Your action is required.<br /><br />Insure processing of your application confirm your email address now.<br /><br />With approval you will be contacted by your lender.<br /><br /><a href=\"https://app.expressemailmarketing.com/Survey.aspx?SFID=104471\">Click here now to confirmation your email address!</a><br /><br /><br /><br />Sincerely,<br />Customer Service Team<br /><a href=\"http://vipcashfast.com/\" >vipcashfast.com</a>";
            SmtpMail.SmtpServer = SERVER;
            SmtpMail.Send(oMail);

            oLead = null;
            oMail = null; // free up resources
        }

        protected void PopulateState()
        {
            DataSet dsState = SqlHelper.ExecuteDataset(DataAccess.GetConnectionString(), "sp_GetState", null);

            state.DataSource = dsState;
            state.DataBind();
            dsState = null;
        }    

        protected void PopulateDrivers_license_st()
        {
            DataSet dsState = SqlHelper.ExecuteDataset(DataAccess.GetConnectionString(), "sp_GetState", null);

            drivers_license_st.DataSource = dsState;           
            drivers_license_st.DataBind();
            dsState = null;
        }

        protected void PopulateIncome_type()
        {
            DataSet dsincome_type = SqlHelper.ExecuteDataset(DataAccess.GetConnectionString(), "sp_GetIncomeType", null);

            income_type.DataSource = dsincome_type;
            income_type.DataBind();
            dsincome_type = null;
        }

        protected void PopulatePayfrequency()
        {
            DataSet dspayfrequency = SqlHelper.ExecuteDataset(DataAccess.GetConnectionString(), "sp_GetPayFrequency", null);

            pay_frequency.DataSource = dspayfrequency;
            pay_frequency.DataBind();

            pay_frequency.SelectedValue = "BIWEEKLY";
            dspayfrequency = null;
        }

        protected void PopulateBankAccountType()
        {
            DataSet dsbankaccounttype = SqlHelper.ExecuteDataset(DataAccess.GetConnectionString(), "sp_GetAccountType", null);

            bank_account_type.DataSource = dsbankaccounttype;
            bank_account_type.DataBind();
            dsbankaccounttype = null;
        }

        protected void PopulateRequestedAmount()
        {
            DataSet dsrequestedamount = SqlHelper.ExecuteDataset(DataAccess.GetConnectionString(), "sp_GetRequestedAmount", null);

            requested_amount.DataSource = dsrequestedamount;
            requested_amount.DataBind();
            dsrequestedamount = null;
        }

        protected void applynow_Click(object sender, EventArgs e)
        {
            Lead oLead = (Lead)Session["s_oLead"];

            //Build query to update LeadCollider database.
            //////////////////////////////////////////////
            int lead_id = oLead.lead_id; //The ID number for the current lead.
            oLead.lead_type_id = 14; //14 for Payday Loan for LeadFlash
            
            string client_ip_address = oLead.client_ip_address;
            string client_url_root = oLead.client_url_root;
            
            oLead.is_live = 1; //LeadFlash

            //Set first Tree
            //oLead.curr_tree = 1;

            //Possible to change LeadCollider status here in future
            oLead.status_id = 4; //UN-Sent for LeadCollider          
            oLead.first_name = first_name.Text;
            oLead.last_name = last_name.Text;
            oLead.street_addr1 = street_addr1.Text;
            oLead.city = city.Text;
            oLead.street_addr2 = street_addr2.Text;
            oLead.state = state.SelectedValue;
            oLead.Zip = Zip.Text;

            //MONTHS AT ADDRESS
            oLead.months_at_address1 = months_at_address1.SelectedValue;
            oLead.months_at_address2 = months_at_address2.SelectedValue;

            double months_at_address_y = Convert.ToInt32(months_at_address1.SelectedValue);
                months_at_address_y = months_at_address_y * 12;
            double months_at_address_m = Convert.ToInt32(months_at_address2.SelectedValue);
            double months_at_address = months_at_address_y + months_at_address_m;

            //double months_at_address_rate = months_at_address * .149;
            //months_at_address = months_at_address + months_at_address_rate;
            //months_at_address = Math.Ceiling(months_at_address);

            if (months_at_address == 0)
            {
                months_at_address = 13;
            }
            oLead.months_at_address = months_at_address.ToString();

            oLead.own_home = Convert.ToInt32(own_home.SelectedValue);
            oLead.Email = Email.Text;
            oLead.phone_home = phone_home1.Text + phone_home2.Text + phone_home3.Text;
            oLead.email_alternate = email_alternate.Text;
            oLead.phone_cell = phone_cell1.Text + phone_cell2.Text + phone_cell3.Text;
            oLead.birth_date = birth_dateY.Text + "-" + birth_dateM.SelectedValue + "-" + birth_dateD.SelectedValue;
            oLead.is_military = Convert.ToInt32(is_military.SelectedValue);
            oLead.employer_name = employer_name.Text;
            oLead.phone_work = phone_work1.Text + phone_work2.Text + phone_work3.Text;

            //MONTHS EMPLOYED
            oLead.months_employed1 = months_employed1.SelectedValue;
            oLead.months_employed2 = months_employed2.SelectedValue;

            double months_employed_y = Convert.ToInt32(months_employed1.SelectedValue);
            months_employed_y = months_employed_y * 12;
            double months_employed_m = Convert.ToInt32(months_employed2.SelectedValue);
            double months_employed = months_employed_y + months_employed_m;

            //double months_employed_rate = months_employed * .149;
            //months_employed = months_employed + months_employed_rate;
            //months_employed = Math.Ceiling(months_employed);

            if (months_employed == 0)
            {
                months_employed = 8;
            }
            oLead.months_employed = months_employed.ToString();

            oLead.phone_work_ext = phone_work_ext.Text;
            oLead.income_type = income_type.SelectedValue;
            oLead.direct_deposit = Convert.ToInt32(direct_deposit.SelectedValue);
            oLead.pay_day1 = pay_day1Y.Text + "-" + pay_day1M.SelectedValue + "-" + pay_day1D.SelectedValue;

            oLead.pay_per_period1 = pay_per_period1.SelectedValue;
            oLead.pay_per_period2 = pay_per_period2.SelectedValue;
            oLead.pay_per_period3 = pay_per_period3.SelectedValue;
            oLead.pay_per_period4 = pay_per_period4.SelectedValue;

            if (pay_per_period1.SelectedValue != "0")
            {
            oLead.pay_per_period = pay_per_period1.SelectedValue + pay_per_period2.SelectedValue + pay_per_period3.SelectedValue + pay_per_period4.SelectedValue;
            }
            else
            {
                oLead.pay_per_period = pay_per_period2.SelectedValue + pay_per_period3.SelectedValue + pay_per_period4.SelectedValue;
            }

            oLead.pay_day2 = pay_day2Y.Text + "-" + pay_day2M.SelectedValue + "-" + pay_day2D.SelectedValue;
            
            oLead.pay_frequency = pay_frequency.SelectedValue;

            //oLead.income_monthly = income_monthly.SelectedValue;

            double m_income = 0;
            //double m_rate = 0;

            double pay_p_period = Convert.ToInt32(oLead.pay_per_period);
            
            try
            {
                switch (oLead.pay_frequency)
                {
                    case "WEEKLY":
                        {
                            m_income = pay_p_period * 4;
                            
                            //m_rate = m_income * .089;
                            //m_income = m_income + m_rate;
                            //m_income = Math.Ceiling(m_income);

                            oLead.income_monthly = m_income.ToString();
                            break;
                        }
                    case "BIWEEKLY":
                        {
                            m_income = pay_p_period * 2;

                            //m_rate = m_income * .089;
                            //m_income = m_income + m_rate;
                            //m_income = Math.Ceiling(m_income);

                            oLead.income_monthly = m_income.ToString();
                            break;
                        }
                    case "TWICEMONTH":
                        {
                            m_income = pay_p_period * 2;

                            //m_rate = m_income * .089;
                            //m_income = m_income + m_rate;
                            //m_income = Math.Ceiling(m_income);

                            oLead.income_monthly = m_income.ToString();
                            break;
                        }
                    case "MONTHLY":
                        {
                            m_income = pay_p_period;

                            //m_rate = m_income * .089;
                            //m_income = m_income + m_rate;
                            //m_income = Math.Ceiling(m_income);

                            oLead.income_monthly = m_income.ToString();
                            break;
                        }
                    default:
                        {
                            oLead.income_monthly = "967";
                            break;
                        }
                }
            }
            catch
            {
                oLead.income_monthly = "934";
            }

            
            oLead.bank_name = bank_name.Text;

            //MONTHS AT BANK
            oLead.months_at_bank1 = months_at_bank1.SelectedValue;
            oLead.months_at_bank2 = months_at_bank2.SelectedValue;

            double months_at_bank_y = Convert.ToInt32(months_at_bank1.SelectedValue);
            months_at_bank_y = months_at_bank_y * 12;
            double months_at_bank_m = Convert.ToInt32(months_at_bank2.SelectedValue);
            double months_at_bank = months_at_bank_y + months_at_bank_m;

            //double months_at_bank_rate = months_at_bank * .149;
            //months_at_bank = months_at_bank + months_at_bank_rate;
            //months_at_bank = Math.Ceiling(months_at_bank);

            if (months_at_bank == 0)
            {
                months_at_bank = 8;
            }
            oLead.months_at_bank = months_at_bank.ToString();

            oLead.bank_account_type = bank_account_type.SelectedValue;
            oLead.bank_aba = bank_aba.Text;
            oLead.bank_account = bank_account.Text;
            oLead.social_security = social_security.Text;
            oLead.drivers_license = drivers_license.Text;
            oLead.drivers_license_st = drivers_license_st.SelectedValue;
            oLead.requested_amount = requested_amount.Text;
            oLead.accepted_terms = Convert.ToInt32(accepted_terms.SelectedValue);

            //PartnerWeekly additional fields
            oLead.ref_01_name_full = ref_01_name_full.Text;
            oLead.ref_01_phone_home = ref_01_phone_home1.Text + ref_01_phone_home2.Text + ref_01_phone_home3.Text;
            oLead.ref_01_relationship = ref_01_relationship.SelectedValue;

            oLead.ref_02_name_full = ref_02_name_full.Text;
            oLead.ref_02_phone_home = ref_02_phone_home1.Text + ref_02_phone_home2.Text + ref_02_phone_home3.Text;
            oLead.ref_02_relationship = ref_02_relationship.SelectedValue;

            //Do not need to update database
            oLead.date_dob_d = birth_dateD.SelectedValue;
            oLead.date_dob_m = birth_dateM.SelectedValue;
            oLead.date_dob_y = birth_dateY.Text;

            oLead.income_date1_d = pay_day1D.SelectedValue;
            oLead.income_date1_m = pay_day1M.SelectedValue;
            oLead.income_date1_y = pay_day1Y.Text;

            oLead.income_date2_d = pay_day2D.SelectedValue;
            oLead.income_date2_m = pay_day2M.SelectedValue;
            oLead.income_date2_y = pay_day2Y.Text;

            try
            {
                oLead.ssn_part_1 = social_security.Text.Substring(0, 3);
                oLead.ssn_part_2 = social_security.Text.Substring(3, 2);
                oLead.ssn_part_3 = social_security.Text.Substring(5, 4);
            }
            catch
            {
                oLead.ssn_part_1 = "123";
                oLead.ssn_part_2 = "45";
                oLead.ssn_part_3 = "6789";
            }

            DateTime time = new DateTime();
            time = DateTime.Now;
            oLead.created_dt = time;

            //if it is past midnight but before noon "MORNING." 
            if (time.Hour >= 0 && time.Hour < 12)
            {
                oLead.best_call_time = "MORNING";
            }
            //if it is past noon but before 6PM, print "AFTERNOON." 
            else if (time.Hour >= 12 && time.Hour < 18)
            {
                oLead.best_call_time = "AFTERNOON";
            }
            //if it is past 6PM, print "EVENING." 
            else if (time.Hour >= 18)
            {
                oLead.best_call_time = "EVENING";
            }
            else
            {
                oLead.best_call_time = "MORNING";
            }

            if (Convert.ToInt32(oLead.months_employed) >= 2) //Maybe should be 3?????
            {
                oLead.employer_length = "TRUE";
            }
            else
            {
                oLead.employer_length = "FALSE";
            }

            if(Convert.ToInt32(direct_deposit.SelectedValue) == 1)
            {
                oLead.income_direct_deposit = "TRUE";
            }
            else
            {
                oLead.income_direct_deposit = "FALSE";
            }

            if(Convert.ToInt32(own_home.SelectedValue) == 1)
            {
                oLead.residence_type = "OWN";
            }
            else
            {
                oLead.residence_type = "RENT";
            }          

            if(pay_frequency.SelectedValue == "WEEKLY")
            {
                oLead.income_frequency = "WEEKLY";
            }
            else if(pay_frequency.SelectedValue == "BIWEEKLY")
            {
                oLead.income_frequency = "BI_WEEKLY";
            }
            else if(pay_frequency.SelectedValue == "TWICEMONTH")
            {
                oLead.income_frequency = "TWICE_MONTHLY";
            }
            else if(pay_frequency.SelectedValue == "MONTHLY")
            {
                oLead.income_frequency = "MONTHLY";
            }
            else
            {
                oLead.income_frequency = "WEEKLY";
            }

            if(Convert.ToInt32(is_military.SelectedValue) == 1)
            {
                oLead.military = "TRUE";
            }
            else
            {
                oLead.military = "FALSE";
            }

            try
            {
                SqlParameter[] paramValues = DataAccess.GetParameters("sp_UpdateLead1");

                paramValues[0].Value = lead_id;
                paramValues[1].Value = oLead.status_id;
                paramValues[2].Value = oLead.lead_type_id;
                paramValues[3].Value = oLead.Tag;
                paramValues[4].Value = oLead.first_name;
                paramValues[5].Value = oLead.last_name;
                paramValues[6].Value = oLead.street_addr1;
                paramValues[7].Value = oLead.street_addr2;
                paramValues[8].Value = oLead.city;
                paramValues[9].Value = oLead.state;
                paramValues[10].Value = oLead.Zip;
                paramValues[11].Value = oLead.months_at_address;
                paramValues[12].Value = oLead.own_home;
                paramValues[13].Value = oLead.social_security;
                paramValues[14].Value = oLead.phone_home;
                paramValues[15].Value = oLead.phone_cell;
                paramValues[16].Value = oLead.phone_work;
                paramValues[17].Value = oLead.phone_work_ext;
                paramValues[18].Value = oLead.Email;
                paramValues[19].Value = oLead.email_alternate;
                paramValues[20].Value = oLead.birth_date;
                paramValues[21].Value = oLead.drivers_license;
                paramValues[22].Value = oLead.drivers_license_st;
                paramValues[23].Value = oLead.is_military;
                paramValues[24].Value = oLead.employer_name;
                paramValues[25].Value = oLead.months_employed;
                paramValues[26].Value = oLead.income_type;
                paramValues[27].Value = oLead.income_monthly;
                paramValues[28].Value = oLead.pay_per_period;
                paramValues[29].Value = oLead.pay_frequency;
                paramValues[30].Value = oLead.direct_deposit;
                paramValues[31].Value = oLead.pay_day1;
                paramValues[32].Value = oLead.pay_day2;
                paramValues[33].Value = oLead.bank_aba;
                paramValues[34].Value = oLead.bank_account;
                paramValues[35].Value = oLead.bank_account_type;
                paramValues[36].Value = oLead.bank_name;
                paramValues[37].Value = oLead.months_at_bank;
                paramValues[38].Value = oLead.requested_amount;
                paramValues[39].Value = oLead.accepted_terms;
                paramValues[40].Value = oLead.client_ip_address;
                paramValues[41].Value = oLead.client_url_root;
                paramValues[42].Value = oLead.is_live;

                paramValues[43].Value = oLead.ref_01_name_full;
                paramValues[44].Value = oLead.ref_01_phone_home;
                paramValues[45].Value = oLead.ref_01_relationship;
                paramValues[46].Value = oLead.ref_02_name_full;
                paramValues[47].Value = oLead.ref_02_phone_home;
                paramValues[48].Value = oLead.ref_02_relationship;
                paramValues[49].Value = "Full App"; //last_action

                paramValues[50].Value = oLead.created_dt;             

                SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_UpdateLead1", paramValues);
                //SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);

                //insert lead detail into lead detail table
                paramValues = DataAccess.GetParameters("sp_InsertLeadDetail");

                paramValues[0].Value = oLead.lead_id;
                paramValues[1].Value = oLead.lead_no; //lead_no, leadcollider lead identification number
                paramValues[2].Value = oLead.status_id;
                paramValues[3].Value = oLead.Tag;
                paramValues[4].Value = oLead.Lid; //Lid id from tree (LeadFlash or any tree)
                paramValues[5].Value = "n/a"; //redirect_url
                paramValues[6].Value = "n/a"; //error_description
                paramValues[7].Value = "n/a"; //declined_description
                paramValues[8].Value = "n/a"; //tree
                paramValues[9].Value = "Full App"; //last_action               
                paramValues[10].Value = oLead.created_dt;

                //SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);
                SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLeadDetail", paramValues);

                oLead = null;
                paramValues = null;

                Response.Redirect("SecureApproval.aspx", false);
            }
            catch
            {
                oLead = null;
                Response.Redirect("https://vipcashfast.com/?ls=RD");
            }

        }     
    }
}
