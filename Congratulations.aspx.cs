using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vipcashfast
{
    public partial class congratulations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            ////Testing
            //Lead oLead = new Lead();
            //oLead.curr_tree = 2;
            //oLead.redirect_url = "http://www.yahoo.com/";

            Session.Timeout = 60;
            Lead oLead = (Lead)Session["s_oLead"];

            if (oLead == null)
            {
                Response.Redirect("https://vipcashfast.com/?ls=RD",true);
            }

            if (oLead.curr_tree == 1) // **1 is for PartnerWeekly will have to do something better in future??**
            {
                string redirect_url = "";
                redirect_url = oLead.redirect_url;
                oLead = null;
                Response.Redirect(redirect_url,true);

                //Old forwarding
                //redirect_url = "<br/><p>Thank you for your application. You have been pre-approved with one of our lending partners.<br /><br />Please click <b><a href=\"" + oLead.redirect_url + "\">here</a></b> to complete your application.</p><p>You will be automatically sent to the page in a few seconds.</p><script type=\"text/javascript\">var script_expression = \"document.location.href ='" + oLead.redirect_url + "'\";var msecs = 2 * 3000;setTimeout(script_expression, msecs);</script>";
                //lblCongratulations.Text = redirect_url;
                
                //if (redirect_url.IndexOf("Please") != -1)
                //{
                //    redirect_url = redirect_url.Replace("Please", "<br /><br />Please");

                //    if (redirect_url.IndexOf("1000") != -1)
                //    {
                //        redirect_url = redirect_url.Replace("1000", "3000");
                //    }

                //    lblCongratulations.Text = redirect_url;
                //}
                //else
                //{
                //    lblCongratulations.Text = oLead.redirect_url;
                //}
            }

            if (oLead.curr_tree == 2) // **2 is for LeadFlash will have to do something better in future??**
            {            
                string redirect_url = "";
                redirect_url = oLead.redirect_url;
                oLead = null;
                Response.Redirect(redirect_url,true);

                //redirect_url = "<br/><p>Thank you for your application. You have been pre-approved with one of our lending partners.<br /><br />Please click <b><a href=\"" + oLead.redirect_url + "\">here</a></b> to complete your application.</p><p>You will be automatically sent to the page in a few seconds.</p><script type=\"text/javascript\">var script_expression = \"document.location.href ='" + oLead.redirect_url + "'\";var msecs = 2 * 3000;setTimeout(script_expression, msecs);</script>";
                //oLead.redirect_url = "<br/><p>Thank you for your application. You have been pre-approved with one of our lending partners.</p><p>Please click <b><a href=\"http://rc.easycashcrew.com/?page=int_redirect&unique_id=cb34efcc496417d9b43d8aa4e2334899\">here</a></b> to complete your application.</p><p>You will be automatically sent to the page in a few seconds.</p><script type=\"text/javascript\">var script_expression = \"document.location.href ='http://rc.easycashcrew.com/?page=int_redirect&unique_id=cb34efcc496417d9b43d8aa4e2334899'\";var msecs = 2 * 1000;setTimeout(script_expression, msecs);</script>";
                //lblCongratulations.Text = redirect_url;
            }

            if (oLead.curr_tree == 3) // **3 is for LeadPile will have to do something better in future??**
            {
                if (oLead.redirect_url != "")
                {
                    string redirect_url = "";
                    redirect_url = oLead.redirect_url;
                    oLead = null;
                    Response.Redirect(redirect_url,true);                  
                    
                    //redirect_url = "<br/><p>Thank you for your application. You have been pre-approved with one of our lending partners.<br /><br />Please click <b><a href=\"" + oLead.redirect_url + "\">here</a></b> to complete your application.</p><p>You will be automatically sent to the page in a few seconds.</p><script type=\"text/javascript\">var script_expression = \"document.location.href ='" + oLead.redirect_url + "'\";var msecs = 2 * 3000;setTimeout(script_expression, msecs);</script>";
                    //lblCongratulations.Text = redirect_url;

                }
                else
                {
                    Response.Redirect("Additional.Resources.aspx",true);
                }
            }
        }
    }
}
