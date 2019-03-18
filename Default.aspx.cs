using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Windows.Forms;


namespace vipcashfast
{ 
    public partial class _Default : System.Web.UI.Page
    {
        Lead oLead = new Lead();        

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 60;

            if (oLead.link_source == "none")
            {
                //Get link source from url
                try
                {
                    if (Request.QueryString["ls"] == null)
                    {
                        oLead.link_source = "direct";
                    }
                    else
                    {
                        oLead.link_source = Request.QueryString["ls"];
                        oLead.status_id = 0;
                    }
                }
                catch
                {
                    oLead.link_source = "direct";
                }
            }

            
            if (!Request.IsSecureConnection)
            {
                string sslUrl;
                sslUrl = "https://vipcashfast.com/?ls=" + oLead.link_source;

                //set test mode for SSL here

                //oLead = null; //
                //Response.Redirect(sslUrl);

                SSLSwitchOn.Visible = false;
                SSLSwitchOff.Visible = true;


                //ShortAppMargin.Style.Add("margin", "5px 125px 15px 0px");
            }
            else if (Request.IsSecureConnection)
            {
                SSLSwitchOn.Visible = true;
                SSLSwitchOff.Visible = false;
            }

            if (!this.IsPostBack)
            {

                //System.Web.UI.WebControls.TextBox first_name = (System.Web.UI.WebControls.TextBox)FindControl("first_name");
                first_name.Focus();
                PopulateRequestedAmount();
                PopulateState();
            }

                oLead.status_id = 4; //UN-Sent for LeadCollider                          

                //Get ip address and url of consumer
                try
                {
                    //client_ip_address
                    string client_ip_address = HttpContext.Current.Request.UserHostAddress;
                    //IP1.Text = client_ip_address;
                    oLead.client_ip_address = client_ip_address;
                }
                catch
                {
                    //IP1.Text = "70.94.100.171"; 
                    oLead.client_ip_address = "70.94.100.171";
                }

                try
                {
                    //client_url_root
                    //string client_url_root = Request.UrlReferrer.ToString();
                    //int getindex = client_url_root.IndexOf("/");
                    //int getlength = client_url_root.Length;

                    //getindex = getindex + 2;
                    //getlength = getlength - (getindex);
                    //client_url_root = client_url_root.Substring(getindex, getlength);
                    //getindex = client_url_root.IndexOf("/");
                    //client_url_root = client_url_root.Remove(getindex);

                    //Referrer1.Text = client_url_root;
                    //oLead.client_url_root = client_url_root;
                    oLead.client_url_root = "vipcashfast.com";
                }
                catch
                {
                    //Referrer1.Text = "www.yahoo.com"; 
                    oLead.client_url_root = "vipcashfast.com";
                }
        }

        protected void PopulateRequestedAmount()
        {
            DataSet dsrequestedamount = SqlHelper.ExecuteDataset(DataAccess.GetConnectionString(), "sp_GetRequestedAmount", null);

            requested_amount.DataSource = dsrequestedamount;
            requested_amount.DataBind();
            dsrequestedamount = null;
        }

        protected void PopulateState()
        {
            DataSet dsState = SqlHelper.ExecuteDataset(DataAccess.GetConnectionString(), "sp_GetState", null);

            state.DataSource = dsState;
            state.SelectedValue = "TX";
            state.DataBind();
            dsState = null;
        }  

        protected void applynow_Click(object sender, EventArgs e)
        {

            try
            {
                //set initial lead tree tracking
                oLead.final_tree = 0;

                //SET INITIAL PLACEMENT TREE
                oLead.curr_tree = 1;

                oLead.short_form_email = 0;
                oLead.denied_email = 0;
                oLead.tree_post_error = 0; //counter for posting errors

                oLead.Lid = ""; //clear out the Lid when new lead
                oLead.Tag = "VCF";

                oLead.post_response = "";

                oLead.first_name = first_name.Text;
                oLead.last_name = last_name.Text;
                oLead.Email = Email.Text;
                oLead.requested_amount = requested_amount.SelectedValue;
                oLead.state = state.SelectedValue;
                oLead.Zip = Zip.Text;
                oLead.created_dt = DateTime.Now;

                //insert lead into lead table
                SqlParameter[] paramValues = DataAccess.GetParameters("sp_InsertLead1");

                paramValues[0].Value = oLead.status_id;
                paramValues[1].Value = oLead.Tag;
                paramValues[2].Value = oLead.client_ip_address;
                paramValues[3].Value = oLead.client_url_root;
                paramValues[4].Value = oLead.first_name;
                paramValues[5].Value = oLead.last_name;
                paramValues[6].Value = oLead.Email;
                paramValues[7].Value = oLead.requested_amount;
                paramValues[8].Value = oLead.state;
                paramValues[9].Value = oLead.Zip;
                paramValues[10].Value = "Short App"; //last_action
                paramValues[11].Value = 1; //accepted_terms
                paramValues[12].Value = oLead.created_dt;
                paramValues[13].Value = oLead.link_source;

                //SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);
                SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);

                oLead.lead_id = Convert.ToInt32(paramValues[14].Value); //the final paramValues holds the output from sp
                
                oLead.lead_no = oLead.Tag + oLead.lead_id.ToString(); //set leadcollider lead number

                Session["s_oLead"] = oLead;

                //insert lead detail into lead detail table
                paramValues = DataAccess.GetParameters("sp_InsertLeadDetail");

                paramValues[0].Value = oLead.lead_id;
                paramValues[1].Value = oLead.lead_no; //lead_no, leadcollider lead identification number
                paramValues[2].Value = oLead.status_id;
                paramValues[3].Value = oLead.Tag;
                paramValues[4].Value = "n/a"; //Lid id from tree (LeadFlash or any tree?)
                paramValues[5].Value = "n/a"; //redirect_url
                paramValues[6].Value = "n/a"; //error_description
                paramValues[7].Value = "n/a"; //declined_description
                paramValues[8].Value = "n/a"; //tree
                paramValues[9].Value = "Short App"; //last_action               
                paramValues[10].Value = oLead.created_dt;

                //SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);
                SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLeadDetail", paramValues);

                //TESTING
                //oLead.is_military = 1;
                //Response.Redirect("Additional.Resources.aspx", false);
                //END TESTING

                oLead = null;
                paramValues = null;

                Response.Redirect("SecureApplication.aspx", false);
            }
            catch
            {
                oLead = null;
                Response.Redirect("https://vipcashfast.com/?ls=RD");
            }
        }
    }
}
