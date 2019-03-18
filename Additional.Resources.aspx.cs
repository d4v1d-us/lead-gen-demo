using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mail;

namespace vipcashfast
{
    public partial class AdditionalResources : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Lead oLead = (Lead)Session["s_oLead"];

            if (oLead != null)
            {
                try
                {
                    if (oLead.denied_email == 0)
                    {
                        SendDeniedEmail();
                        oLead.denied_email = 1;
                    }
                }
                catch
                {
                    try
                    {
                        SendDeniedErrorEmail();
                    }
                    catch
                    {
                    }
                }
            }

            oLead = null;

            //if (oLead != null)
            //{
            //    PayTo1.Text = oLead.first_name + " " + oLead.last_name;
            //}
            //else
            //{
            //    PayTo1.Text = "Valued Client";
            //}

            //if (oLead != null)
            //{
            //    LoanAmount1.Text = "$" + oLead.requested_amount;
            //}
            //else
            //{
            //    LoanAmount1.Text = "$500";
            //}

            //Military Offer


            //if (oLead != null)
            //{
            //    if (oLead.is_military == 1)
            //    {
            //        militaryloan.Visible = true;
            //    }
            //}

            //if (militaryloan.Visible == true)
            //{
            //    if (oLead != null)
            //    {
            //        PayTo2.Text = oLead.first_name + " " + oLead.last_name;
            //    }
            //    else
            //    {
            //        PayTo2.Text = "Valued Client";
            //    }

            //    if (oLead != null)
            //    {
            //        LoanAmount2.Text = "$" + oLead.requested_amount;
            //    }
            //    else
            //    {
            //        LoanAmount2.Text = "$500";
            //    }
            //}
            //End Military Offer


            //if (oLead != null)
            //{
            //    PayTo3.Text = oLead.first_name + " " + oLead.last_name;
            //}
            //else
            //{
            //    PayTo3.Text = "Valued Client";
            //}


            //if (oLead != null)
            //{
            //    credit1.Text = oLead.first_name + " " + oLead.last_name;
            //}
            //else
            //{
            //    credit1.Text = "Valued Client";
            //}

            //oLead = null;

        }

        private void SendDeniedEmail()
        {
            Lead oLead = (Lead)Session["s_oLead"];

            const string SERVER = "relay-hosting.secureserver.net";
            MailMessage oMail = new System.Web.Mail.MailMessage();
            oMail.From = "service@vipcashfast.com";
            oMail.To = oLead.Email;
            oMail.Subject = "Status Update: Your VIPCashFast Application";
            oMail.BodyFormat = MailFormat.Html; // enumeration
            oMail.Priority = MailPriority.High; // enumeration

            oMail.Body = "Dear " + oLead.first_name + ",<br /><br />We apologize that we are unable to find your short term cash advance at this time.<br /><br />";
            
            oMail.Body = oMail.Body + "We work hard to make it easy for you to receive cash in your account by continuing to improve our VIP application system and expanding our network of lenders.<br /><br />";
            
            oMail.Body = oMail.Body + "A couple of important points,<br /><br />";
            
            oMail.Body = oMail.Body + "1. Throughout the week different lenders enter and exit our VIP network dependent on their cash credit funding capabilities. In the long run this lender flexibility improves approval rates. However, you may have received a denied application due to unfortunate lender timing.<br /><br />";
            
            oMail.Body = oMail.Body + "2. Please remember our VIP service is FREE and you can reapply at your convenience, visit <a href=\"http://vipcashfast.com/?ls=DE\" >vipcashfast.com</a> 24/7!<br /><br />";

            oMail.Body = oMail.Body + "Additionally, please consider the following VIP alternative financial resources,<br /><br />";

            //if (oLead.is_military == 1)
            //{
            //    oMail.Body = oMail.Body + "<a href=\"http://www.credit.com/r2/loans/af=p76544&c=140737-3e3d163c75\">PioneerMilitaryLoans.com</a><br /><br />";
            //}

            oMail.Body = oMail.Body + "<a href=\"http://www.sastrk.com/z/5525/CD5193/&dp=289412\">FiscalPayday.com</a><br /><br />";

            oMail.Body = oMail.Body + "<a href=\"http://www.sastrk.com/z/5313/CD5193/&dp=289414\">PacificPayDay.com</a><br /><br />";

            oMail.Body = oMail.Body + "<a href=\"http://www.sastrk.com/z/8739/CD5193/&dp=289411\">FirstLibertyLendingNetwork.com</a><br /><br />";

            //PROBLEM WITH LEADPILE LINKS
            //oMail.Body = oMail.Body + "<a href=" + UrlEncode("http://www.uscashwire.com/?affp=l4ZmsX") + ">USCashWire.com</a><br /><br />";
            //oMail.Body = oMail.Body + "<a href=\"http://www.uscashwire.com/?affp=l4ZmsX\">USCashWire.com</a><br /><br />";
            //oMail.Body = oMail.Body + "<a href=\"http://www.paydaycashstart.com/?affp=l4ZmsX\">PayDayCashStart.com</a><br /><br />";

            //oMail.Body = oMail.Body + "<a href=\"http://www.jdoqocy.com/ia66lnwtnvAEJIKFDDACBIHKGDI\">DiscountAdvances.com</a><br /><br/>";

            oMail.Body = oMail.Body + "These resources will submit your application to lender networks outside our VIP system.<br /><br/>Sincerely,<br />Customer Service Team<br /><a href=\"http://vipcashfast.com/?ls=DE\" >vipcashfast.com</a>";
            
            
            //oMail.Body = "test";
            
            SmtpMail.SmtpServer = SERVER;
            SmtpMail.Send(oMail);

            oLead = null;
            oMail = null; // free up resources
        }

        private void SendDeniedErrorEmail()
        {
            //Lead oLead = (Lead)Session["s_oLead"];

            const string SERVER = "relay-hosting.secureserver.net";
            MailMessage oMail = new System.Web.Mail.MailMessage();
            oMail.From = "service@vipcashfast.com";
            oMail.To = "info@leadcollider.com";
            oMail.Subject = "Declined Email Send Error";
            oMail.BodyFormat = MailFormat.Html; // enumeration
            oMail.Priority = MailPriority.High; // enumeration

            oMail.Body = "Error with Declined Email";
            
            SmtpMail.SmtpServer = SERVER;
            SmtpMail.Send(oMail);

            //oLead = null;
            oMail = null; // free up resources
        }

        //protected void PoPOffer1_Click(object sender, EventArgs e)
        //{
        //    Lead oLead = (Lead)Session["s_oLead"];

        //    if (oLead != null)
        //    {
        //        //long form for pre pop
        //        //string EDP_Post = "http://superaffiliatesoft.net/z/7508/CD5193/&dp=279503&";
        //        //string EDP_post_data = build_EDP_post_data();
        //        //EDP_Post = EDP_Post + EDP_post_data;

        //        //short form 
        //        string EDP_Post = "http://superaffiliatesoft.net/z/5526/CD5193/&dp=259089";
        //        oLead = null;
        //        Response.Redirect(EDP_Post);
        //    }
        //    else
        //    {
        //        oLead = null;
        //        //long form for pre pop
        //        //Response.Redirect("http://superaffiliatesoft.net/z/7508/CD5193/&dp=279503");
        //        //short form
        //        Response.Redirect("http://superaffiliatesoft.net/z/5526/CD5193/&dp=259089");
        //    }
        //}

        //protected void PoPOffer2_Click(object sender, EventArgs e)
        //{
        //    Lead oLead = (Lead)Session["s_oLead"];

        //    if (oLead != null)
        //    {

        //        string Military_Post = "http://www.credit.com/r2/loans/af=p76544&c=140737-3e3d163c75";
        //        oLead = null;
        //        Response.Redirect(Military_Post);
        //    }
        //    else
        //    {
        //        oLead = null;
        //        Response.Redirect("http://www.credit.com/r2/loans/af=p76544&c=140737-3e3d163c75");
        //    }
        //}

        //protected void PoPOffer3_Click(object sender, EventArgs e)
        //{
        //    Lead oLead = (Lead)Session["s_oLead"];

        //    if (oLead != null)
        //    {
        //        //http://superaffiliatesoft.net/z/8262/CD5193/
        //        string EDP_Post = "http://superaffiliatesoft.net/z/8262/CD5193/";
        //        string EDP_post_data = build_EDP_post_data();
        //        EDP_Post = EDP_Post + EDP_post_data;

        //        oLead = null;
        //        Response.Redirect(EDP_Post);
        //    }
        //    else
        //    {
        //        Response.Redirect("http://superaffiliatesoft.net/z/8262/CD5193/");
        //    }
        //}


        //protected void PoPOffer4_Click(object sender, EventArgs e)
        //{
            
        //        Response.Redirect("http://www.credit.com/r2/credit-reports/af=p76544&c=120230-3b666f7d4d");
        //}


        //EDebitPay query string data
        protected string build_EDP_post_data()
        {
            Lead oLead = (Lead)Session["s_oLead"];

            string phone_cell1 = "";
            string phone_cell2 = "";
            string phone_cell3 = ""; 

            if (oLead.phone_cell != "")
            {
                try
                {
                    phone_cell1 = oLead.phone_cell.Substring(0, 3);
                    phone_cell2 = oLead.phone_cell.Substring(3, 3);
                    phone_cell3 = oLead.phone_cell.Substring(5, 4);
                }
                catch
                {
                }
            }


            string phone_home1 = "";
            string phone_home2 = "";
            string phone_home3 = ""; 

            if (oLead.phone_home != "")
            {
                try
                {
                    phone_home1 = oLead.phone_home.Substring(0, 3);
                    phone_home2 = oLead.phone_home.Substring(3, 3);
                    phone_home3 = oLead.phone_home.Substring(5, 4);
                }
                catch
                {
                }
            }

            string phone_work1 = "";
            string phone_work2 = "";
            string phone_work3 = "";

            if (oLead.phone_work != "")
            {
                try
                {
                    phone_work1 = oLead.phone_work.Substring(0, 3);
                    phone_work2 = oLead.phone_work.Substring(3, 3);
                    phone_work3 = oLead.phone_work.Substring(5, 4);
                }
                catch
                {
                }
            }

            string birth_dateY = "";
            string birth_dateM = "";
            string birth_dateD = "";
            string birth_date = "";

            if (oLead.birth_date != "")
            {
                try
                {
                    char[] delimiterChars = { '-', '\t' };
                    string text = oLead.birth_date;
                    string[] words = text.Split(delimiterChars);

                    birth_dateY = words[0];
                    birth_dateM = words[1];
                    birth_dateD = words[2];

                    birth_date = birth_dateM + "-" + birth_dateD + "-" + birth_dateY;
                }
                catch
                {                 
                }
            }

            //string ownrent = "own";
            //if (oLead.own_home == 0)
            //{
            //    ownrent = "rent";
            //}

            //string timetocall = "morning";
            //if (oLead.best_call_time == "AFTERNOON")
            //{
            //    timetocall = "afternoon";
            //}

            //if (oLead.best_call_time == "EVENING")
            //{
            //    timetocall = "evening";  
            //}

            //string incomesource = "employed";
            //if (oLead.income_type == "BENEFITS")
            //{
            //    incomesource = "benefits";  
            //}

            //string payperiod= "weekly";
            //if (oLead.pay_frequency == "BIWEEKLY")
            //{
            //    payperiod = "biweekly";
            //}

            //if (oLead.pay_frequency == "TWICEMONTH")
            //{
            //    payperiod = "semimonthly";
            //}

            //if (oLead.pay_frequency == "MONTHLY")
            //{
            //    payperiod = "monthly";
            //}

            string pay_day1Y = "";
            string pay_day1M = "";
            string pay_day1D = "";
            string pay_day1 = "";

            if (oLead.pay_day1 != "")
            {
                try
                {
                    char[] delimiterChars = { '-', '\t' };
                    string text = oLead.pay_day1;
                    string[] words = text.Split(delimiterChars);

                    pay_day1Y = words[0];
                    pay_day1M = words[1];
                    pay_day1D = words[2];

                    pay_day1 = pay_day1M + "-" + pay_day1D + "-" + pay_day1Y;
                }
                catch
                {                 
                }
            }

            string pay_day2Y = "";
            string pay_day2M = "";
            string pay_day2D = "";
            string pay_day2 = "";

            if (oLead.pay_day2 != "")
            {
                try
                {
                    char[] delimiterChars = { '-', '\t' };
                    string text = oLead.pay_day2;
                    string[] words = text.Split(delimiterChars);

                    pay_day2Y = words[0];
                    pay_day2M = words[1];
                    pay_day2D = words[2];

                    pay_day2 = pay_day2M + "-" + pay_day2D + "-" + pay_day2Y;
                }
                catch
                {                 
                }
            }

            //string paymethod = "checking";
            //if (oLead.bank_account_type == "SAVINGS")
            //{
            //    paymethod = "savings";
            //}

            string ref1phone1 = "";
            string ref1phone2 = "";
            string ref1phone3 = ""; 

            if (oLead.ref_01_phone_home != "")
            {
                try
                {
                    ref1phone1 = oLead.ref_01_phone_home.Substring(0, 3);
                    ref1phone2 = oLead.ref_01_phone_home.Substring(3, 3);
                    ref1phone3 = oLead.ref_01_phone_home.Substring(5, 4);
                }
                catch
                {
                }
            }

            string ref2phone1 = "";
            string ref2phone2 = "";
            string ref2phone3 = ""; 

            if (oLead.ref_02_phone_home != "")
            {
                try
                {
                    ref2phone1 = oLead.ref_02_phone_home.Substring(0, 3);
                    ref2phone2 = oLead.ref_02_phone_home.Substring(3, 3);
                    ref2phone3 = oLead.ref_02_phone_home.Substring(5, 4);
                }
                catch
                {
                }
            }


            string EDP_data = "";

            EDP_data =

                "&fname=" + oLead.first_name +
                "&lname=" + oLead.last_name +
                "&email=" + oLead.Email +
                "&addr1=" + oLead.street_addr1 +
                "&city=" + oLead.city +
                "&state=" + oLead.state +
                "&zipcode=" + oLead.Zip +
                "&xincome=1" +
                "&prePopAll=1" +
                "&phoneAREA=" + phone_cell1 +
                "&phoneEXCHANGE=" + phone_cell2 +
                "&phoneNUMBER=" + phone_cell3 +
                "&date_dob_m=" + birth_dateM +
                "&date_dob_d=" + birth_dateD +
                "&date_dob_y=" + birth_dateY +
                "&ssn1=" + oLead.ssn_part_1 +
                "&ssn2=" + oLead.ssn_part_2 +
                "&ssn3=" + oLead.ssn_part_3 +
                "&routingno=" + oLead.bank_aba +
                "&bankaccno=" + oLead.bank_account +
                "&mothersmaiden=unknown"; 

                //Loan data string
                //"&" + "state=" + oLead.state + "&" +
                //"city=" + oLead.city + "&" +
                //"zip=" + oLead.Zip+ "&" +
                //"fname=" + oLead.first_name + "&" +
                //"lname=" + oLead.last_name + "&" +
                //"address=" + oLead.street_addr1 + "&" +
                //"homephone1=" + phone_home1 + "&" +
                //"homephone2=" + phone_home2 + "&" +
                //"homephone3=" + phone_home3 + "&" +
                //"workphone1=" + phone_work1 + "&" +
                //"workphone2=" + phone_work2 + "&" +
                //"workphone3=" + phone_work3 + "&" +
                //"workphone_ext=" + oLead.phone_work_ext + "&" +
                //"email=" + oLead.Email + "&" +
                //"dob=" + birth_date + "&" +
                //"employer=" + oLead.employer_name + "&" +
                //"monthlyincome=" + oLead.income_monthly + "&" +
                //"ssn1=" + oLead.ssn_part_1 + "&" +
                //"ssn2=" + oLead.ssn_part_2 + "&" +
                //"ssn3=" + oLead.ssn_part_3 + "&" +
                //"aba=" + oLead.bank_aba + "&" +
                //"military=" + oLead.is_military + "&" +
                //"ownrent=" + ownrent + "&" +
                //"timetocall=" + timetocall + "&" +
                //"licensenumber=" + oLead.drivers_license + "&" +
                //"licensestate=" + oLead.drivers_license_st + "&" +
                //"citizen=" + "1" + "&" +
                //"timeatjob=" + oLead.months_employed + "&" +
                //"occupation=" + "" + "&" +
                //"empaddress=" + "" + "&" +
                //"empcity=" + "" + "&" +
                //"empstate=" + "" + "&" +
                //"empzip=" + "" + "&" +
                //"incomesource=" + incomesource + "&" +
                //"payperiod=" + payperiod + "&" +
                //"paydate1=" + pay_day1 + "&" +
                //"paydate2=" + pay_day2 + "&" +
                //"paymethod=" + paymethod + "&" +
                //"ref1name=" + oLead.ref_01_name_full + "&" +
                //"ref1relation=" + oLead.ref_01_relationship + "&" +
                //"ref1phone1=" + ref1phone1 + "&" +
                //"ref1phone2=" + ref1phone2 + "&" +
                //"ref1phone3=" + ref1phone3 + "&" +
                //"ref2name=" + oLead.ref_02_name_full + "&" +
                //"ref2relation=" + oLead.ref_02_relationship + "&" +
                //"ref2phone1=" + ref2phone1 + "&" +
                //"ref2phone2=" + ref2phone2 + "&" +
                //"ref2phone3=" + ref2phone3 + "&" +
                //"bank=" + oLead.bank_name + "&" +
                //"accountnumber=" + oLead.bank_account + "&" +
                //"accounttype=" + paymethod + "&" +
                //"bankphone1=" + "" + "&" +
                //"bankphone2=" + "" + "&" +
                //"bankphone3=" + "" + "&" +
                //"loanamount=" + oLead.requested_amount;

            oLead = null;
            return EDP_data;

        }
        //end EDebitPay
    }
}
