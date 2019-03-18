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
using System.Xml;
using System.Xml.Linq;
using System.Text;
using vipcashfast.PWUser_Data;
using System.Collections;


namespace vipcashfast
{
    public partial class SecureApproval : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //protected void Page_LoadComplete(object sender, EventArgs e)
        //protected void Page_PreRender(object sender, EventArgs e) 
        //protected void Page_RenderComplete(object sender, EventArgs e) 
        //protected void Page_Unload(object sender, EventArgs e) 

        protected void Page_Load(object sender, EventArgs e)
        {
            
            //Testing
            //Response.Redirect("Additional.Resources.aspx");

            Session.Timeout = 60;
            Lead oLead = (Lead)Session["s_oLead"];

            //TESTING
            //oLead.is_military = 1;
            //Response.Redirect("Additional.Resources.aspx", false);
            //Response.Redirect("Additional.Resources.aspx", true);
            //END TESTING

            if (oLead == null)
            {
                Response.Redirect("https://vipcashfast.com/?ls=RD", true);
            }

            if (!this.IsPostBack)
            {




                //if (oLead.curr_tree == 1) //if on PW tree
                //{
                //    //Check states for NO PartnerWeekly Tree  
                //    String[] states;
                //    states = new string[6] {"GA","VA","WV","AZ","PA","MD"};

                //    foreach (string str in states)
                //    {
                //        if (oLead.state == str)
                //        {
                //            //Response.Redirect("Additional.Resources.aspx");
                //            oLead.curr_tree = 2;
                //        }
                //    }
                //}

                //if (oLead.curr_tree == 1) //if on PW tree
                //{
                //    //If not employed send to LeadFlash first then LP
                //    if (oLead.income_type == "BENEFITS")
                //    {
                //        oLead.curr_tree = 2;
                //    }
                //}




                //TESTING
                //oLead.curr_tree = 1;

                //PartnerWeekly Tree
                //if (oLead.curr_tree == 1)
                //{
                //    string post_response = "";
                //    post_response = get_PW_post_response();
                //    oLead.post_response = post_response;
                //}


                if (oLead.curr_tree == 1)
                {
                    oLead.curr_tree = 2;
                }




                //LeadFlash Tree
                if (oLead.curr_tree == 2)
                {
                    string post_response = "";
                    post_response = get_LF_post_response();
                    oLead.post_response = post_response;
                }

                //LeadPile Tree
                if (oLead.curr_tree == 3)
                {
                    string post_response = "";
                    post_response = get_LP_post_response();
                    oLead.post_response = post_response;
                }
            }
            oLead = null;
        }

        //START: functions to process the response from placement trees
        //START: PartnerWeekly
        protected void PW_Process_Response()
        {
            Lead oLead = (Lead)Session["s_oLead"];

            string post_response = "";
            post_response = oLead.post_response;

            switch (post_response)
            {
                case "ERROR":
                    {
                        oLead.post_response = "";

                        oLead = null;

                        //appProcessing.Value = "1";
                        //Page.RegisterClientScriptBlock("foo","<script>document.form1.appProcessing.value == 1</script>");
                        //ClientScript.RegisterHiddenField("appProcessing","1");

                        Response.Redirect("SecureApplication.aspx", true);
                        break;
                    }
                case "ACCEPTED":
                    {
                        ////TESTING
                        //oLead.status_id = 3; // 3 is status id for error
                        //oLead.error_description = oLead.redirect_url;

                        oLead = null;
                        Response.Redirect("Congratulations.aspx", true);
                        break;
                    }
                case "DECLINED":
                    {
                        ////break and send to LeadFlash
                        oLead.curr_tree = 2;
                        oLead.tree_post_error = 0;

                        //clear lead tree tracking before send to additional trees
                        oLead.Lid = "";
                        oLead.redirect_url = "";
                        oLead.error_description = "";
                        oLead.declined_description = "";
                        oLead.post_response = "";

                        //send to LF
                        post_response = get_LF_post_response();
                        oLead.post_response = post_response;

                        oLead = null;
                        break;
                    }
                default:
                    {
                        ////break and send to LeadFlash
                        oLead.curr_tree = 2;
                        oLead.tree_post_error = 0;

                        //clear lead tree tracking before send to additional trees
                        oLead.Lid = "";
                        oLead.redirect_url = "";
                        oLead.error_description = "";
                        oLead.declined_description = "";
                        oLead.post_response = "";

                        //send to LF
                        post_response = get_LF_post_response();
                        oLead.post_response = post_response;

                        oLead = null;
                        break;
                    }
            }
        }

        //START: LeadFlash
        protected void LF_Process_Response()
        {
            Lead oLead = (Lead)Session["s_oLead"];

            string post_response = "";
            post_response = oLead.post_response;

            switch (post_response)
            {
                case "ERROR":
                    {
                        oLead.post_response = "";

                        oLead = null;
                        Response.Redirect("SecureApplication.aspx", true);
                        break;
                    }
                case "ACCEPTED":
                    {
                        ////TESTING
                        //oLead.status_id = 3; // 3 is status id for error
                        //oLead.error_description = oLead.redirect_url;
                        //Response.Redirect("SecureApplication.aspx");
                        //break;

                        oLead = null;
                        Response.Redirect("Congratulations.aspx", true);
                        break;
                    }
                case "DECLINED": 
                    {
                        ////break and send to LeadPile
                        oLead.curr_tree = 3;
                        oLead.tree_post_error = 0;

                        //clear lead tree tracking before send to additional trees
                        oLead.Lid = "";
                        oLead.redirect_url = "";
                        oLead.error_description = "";
                        oLead.declined_description = "";
                        oLead.post_response = "";

                        //send to LP
                        post_response = get_LP_post_response();
                        oLead.post_response = post_response;

                        oLead = null;
                        break;
                    }
                default:
                    {

                        ////break and send to LeadPile
                        oLead.curr_tree = 3;
                        oLead.tree_post_error = 0;

                        //clear lead tree tracking before send to additional trees
                        oLead.Lid = "";
                        oLead.redirect_url = "";
                        oLead.error_description = "";
                        oLead.declined_description = "";
                        oLead.post_response = "";

                        //send to LP
                        post_response = get_LP_post_response();
                        oLead.post_response = post_response;

                        oLead = null;
                        break;
                    }
            }
        }

        //START: LeadPile
        protected void LP_Process_Response()
        {
            Lead oLead = (Lead)Session["s_oLead"];

            string post_response = "";
            post_response = oLead.post_response;

            switch (post_response)
            {
                case "ERROR":
                    {
                        oLead.post_response = "";

                        oLead = null;
                        Response.Redirect("SecureApplication.aspx", true);
                        break;
                    }
                case "ACCEPTED":
                    {
                        ////TESTING
                        //oLead.status_id = 3; // 3 is status id for error
                        //oLead.error_description = oLead.redirect_url;
                        //Response.Redirect("SecureApplication.aspx");
                        //break;

                        oLead = null;
                        Response.Redirect("Congratulations.aspx", true);
                        break;
                    }
                case "DECLINED":
                    {
                        oLead.tree_post_error = 0;
                        oLead.post_response = "";

                        oLead = null;
                        Response.Redirect("Additional.Resources.aspx", true);
                        break;
                    }
                default:
                    {
                        ////break and send to Additionalresources for **NOW**
                        oLead.tree_post_error = 0;
                        oLead.post_response = "";

                        oLead = null;
                        Response.Redirect("Additional.Resources.aspx", true);
                        break;
                    }
            }
        }
        //END: functions to process the response from placement trees

        //START: functions to POST to placement trees
        //START: PartnerWeekly POST
        //Something to do with ABA,Account# Class 'TSS_SuppressionList_2' not found
        protected string PW_Post(string PW_data)
        {
            Lead oLead = (Lead)Session["s_oLead"];

            string post_response = "";

            try
            {
                //testing to break post
                //PW_data = PW_data + "xxxxxxxxxxxxxxxx";


                tssService dotnetWebservice;
                dotnetWebservice = new tssService();
                post_response = dotnetWebservice.User_Data(PW_data);

                oLead.post_response = post_response.ToString();
                oLead = null;
                return post_response.ToString();
            }
            catch
            {
                int lead_id = oLead.lead_id; //The ID number for the current lead.
                oLead.status_id = 3; // 3 is status id for error
                oLead.Lid = "";
                oLead.error_description = "Internet Communication Issue" + "<br />";
                oLead.price = "0";
                oLead.buyer_id = "0";
                oLead.created_dt = DateTime.Now;

                SqlParameter[] paramValues = DataAccess.GetParameters("sp_UpdateLeadError");

                paramValues[0].Value = lead_id;
                paramValues[1].Value = oLead.status_id;
                paramValues[2].Value = oLead.Lid;
                paramValues[3].Value = oLead.error_description;
                paramValues[4].Value = oLead.price;
                paramValues[5].Value = oLead.buyer_id;
                paramValues[6].Value = "PW Full"; //tree
                paramValues[7].Value = "PW Post Issue"; //last_action
                paramValues[8].Value = oLead.created_dt;

                SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_UpdateLeadError", paramValues);
                //SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);

                //insert lead detail into lead detail table
                paramValues = DataAccess.GetParameters("sp_InsertLeadDetail");

                paramValues[0].Value = lead_id;
                paramValues[1].Value = oLead.lead_no; //lead_no, leadcollider lead identification number
                paramValues[2].Value = oLead.status_id;
                paramValues[3].Value = oLead.Tag;
                paramValues[4].Value = oLead.Lid; //Lid id from tree (LeadFlash or any tree?)
                paramValues[5].Value = "n/a"; //redirect_url
                paramValues[6].Value = oLead.error_description; //error_description
                paramValues[7].Value = "n/a"; //declined_description
                paramValues[8].Value = "PW Full"; //tree
                paramValues[9].Value = "PW Post Issue"; //last_action               
                paramValues[10].Value = oLead.created_dt;

                //SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);
                SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLeadDetail", paramValues);

                oLead.tree_post_error = oLead.tree_post_error + 1; //keep track of posting errors if 2 send to other tree

                if (oLead.tree_post_error == 3)
                {
                    oLead.curr_tree = 2;
                    oLead.tree_post_error = 0;

                    oLead.Lid = "";
                    oLead.redirect_url = "";
                    oLead.declined_description = "";
                    oLead.error_description = "";

                    oLead.post_response = "InternetIssue";
                    post_response = "InternetIssue";
                }
                else
                {
                    oLead.post_response = "ERROR";
                    post_response = "ERROR";
                }

                oLead = null;
                paramValues = null;

                return post_response;
            }
        }
        //END: PartnerWeekly POST

        //START: LeadFlash POST
        protected string LF_Post(string LF_data)
        {
            Lead oLead = (Lead)Session["s_oLead"];

            string post_response = "";

            Uri uri = new Uri("https://ww2.502011tr021731axxxsb.com/api/leadpost.aspx");

            //PostData = "first_name=joe&last_name=doe&state=FL"; //error no login
            //PostData = "vendor_id=325242&vendor_pass=242362429&test_app=1&is_live=1&accepted_terms=1&lead_type_id=14&state=FL"; \\error with login
            //if (uri.Scheme == Uri.UriSchemeHttp)
            //{

            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
                request.Method = WebRequestMethods.Http.Post;
                request.ContentLength = LF_data.Length;
                request.ContentType = "application/x-www-form-urlencoded";
                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(LF_data);
                writer.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream()); string tmp = reader.ReadToEnd();
                response.Close();

                post_response = tmp;

                oLead = null;
                return post_response;
            }
            catch
            {
                int lead_id = oLead.lead_id; //The ID number for the current lead.
                oLead.status_id = 3; // 3 is status id for error
                oLead.Lid = "";
                oLead.error_description = "Internet Communication Issue" + "<br />";
                oLead.price = "0";
                oLead.buyer_id = "0";
                oLead.created_dt = DateTime.Now;

                SqlParameter[] paramValues = DataAccess.GetParameters("sp_UpdateLeadError");

                paramValues[0].Value = lead_id;
                paramValues[1].Value = oLead.status_id;
                paramValues[2].Value = oLead.Lid;
                paramValues[3].Value = oLead.error_description;
                paramValues[4].Value = oLead.price;
                paramValues[5].Value = oLead.buyer_id;
                paramValues[6].Value = "LF Full"; //tree
                paramValues[7].Value = "LF Post Issue"; //last_action
                paramValues[8].Value = oLead.created_dt;

                SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_UpdateLeadError", paramValues);
                //SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);

                //insert lead detail into lead detail table
                paramValues = DataAccess.GetParameters("sp_InsertLeadDetail");

                paramValues[0].Value = lead_id;
                paramValues[1].Value = oLead.lead_no; //lead_no, leadcollider lead identification number
                paramValues[2].Value = oLead.status_id;
                paramValues[3].Value = oLead.Tag;
                paramValues[4].Value = oLead.Lid; //Lid id from tree (LeadFlash or any tree?)
                paramValues[5].Value = "n/a"; //redirect_url
                paramValues[6].Value = oLead.error_description; //error_description
                paramValues[7].Value = "n/a"; //declined_description
                paramValues[8].Value = "LF Full"; //tree
                paramValues[9].Value = "LF Post Issue"; //last_action               
                paramValues[10].Value = oLead.created_dt;

                //SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);
                SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLeadDetail", paramValues);

                oLead.tree_post_error = oLead.tree_post_error + 1; //keep track of posting errors if 2 send to other tree

                if (oLead.tree_post_error == 3)
                {
                    oLead.curr_tree = 3;
                    oLead.tree_post_error = 0;

                    oLead.Lid = "";
                    oLead.redirect_url = "";
                    oLead.declined_description = "";
                    oLead.error_description = "";

                    oLead.post_response = "InternetIssue";
                    post_response = "InternetIssue";
                }
                else
                {
                    //Testing for LF error control that should send to LeadPile
                    //Applicant appears to have entered fraudulent information
                    //Lead was recently posted by another source
                    //Invalid Repost. Lead was previously sold or has been shown to our entire list of clients.
                    
                    //oLead.error_description = "Invalid Repost. Lead was previously sold or has been shown to our entire list of clients.";
                    //post_response = "ERROR";

                    //Live
                    oLead.post_response = "ERROR";
                    post_response = "ERROR";
                }

                oLead = null;
                paramValues = null;
                return post_response;
            }
        }
        //END: LeadFlash POST

        //START: LeadPile POST
        protected string LP_Post(string LP_data)
        {
            Lead oLead = (Lead)Session["s_oLead"];

            string post_response = "";

            //LIVE https://www.leadpile.com/cgi-bin/openmarket
            //TESTING http://test.leadpile.com/cgi-bin/openmarket

            Uri uri = new Uri("https://www.leadpile.com/cgi-bin/openmarket");

            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
                request.Method = WebRequestMethods.Http.Post;
                request.ContentLength = LP_data.Length;
                request.ContentType = "application/x-www-form-urlencoded";
                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(LP_data);
                writer.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream()); string tmp = reader.ReadToEnd();
                response.Close();

                post_response = tmp;

                oLead = null;
                return post_response;
            }
            catch
            {
                int lead_id = oLead.lead_id; //The ID number for the current lead.
                oLead.status_id = 3; // 3 is status id for error
                oLead.Lid = "";
                oLead.error_description = "Internet Communication Issue" + "<br />";
                oLead.price = "0";
                oLead.buyer_id = "0";
                oLead.created_dt = DateTime.Now;

                SqlParameter[] paramValues = DataAccess.GetParameters("sp_UpdateLeadError");

                paramValues[0].Value = lead_id;
                paramValues[1].Value = oLead.status_id;
                paramValues[2].Value = oLead.Lid;
                paramValues[3].Value = oLead.error_description;
                paramValues[4].Value = oLead.price;
                paramValues[5].Value = oLead.buyer_id;
                paramValues[6].Value = "LP Full"; //tree
                paramValues[7].Value = "LP Post Issue"; //last_action
                paramValues[8].Value = oLead.created_dt;

                SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_UpdateLeadError", paramValues);
                //SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);

                //insert lead detail into lead detail table
                paramValues = DataAccess.GetParameters("sp_InsertLeadDetail");

                paramValues[0].Value = lead_id;
                paramValues[1].Value = oLead.lead_no; //lead_no, leadcollider lead identification number
                paramValues[2].Value = oLead.status_id;
                paramValues[3].Value = oLead.Tag;
                paramValues[4].Value = oLead.Lid; //Lid id from tree (LeadFlash or any tree?)
                paramValues[5].Value = "n/a"; //redirect_url
                paramValues[6].Value = oLead.error_description; //error_description
                paramValues[7].Value = "n/a"; //declined_description
                paramValues[8].Value = "LP Full"; //tree
                paramValues[9].Value = "LP Post Issue"; //last_action               
                paramValues[10].Value = oLead.created_dt;

                //SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);
                SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLeadDetail", paramValues);

                oLead.tree_post_error = oLead.tree_post_error + 1; //keep track of posting errors if 2 send to other tree
                
                // if more than 2 post issues send to declined
                if (oLead.tree_post_error == 3)
                {
                    oLead.curr_tree = 0;
                    oLead.tree_post_error = 0;

                    oLead.Lid = "";
                    oLead.redirect_url = "";
                    oLead.declined_description = "";
                    oLead.error_description = "";
                    oLead.post_response = "";

                    oLead = null;
                    Response.Redirect("Additional.Resources.aspx", true);

                }
                else
                {
                    oLead.post_response = "ERROR";
                    post_response = "ERROR";
                }

                oLead = null;
                paramValues = null;
                return post_response;
            }
        }
        //END: LeadPile POST
        //END: functions to post to placement trees

        //START: functions to get response from placement trees
        //START: PartnerWeekly
        protected string get_PW_post_response()
        {
            string post_response = "";

            Lead oLead = (Lead)Session["s_oLead"];

            //Testing for declined
            //oLead = null;
            //post_response = "DECLINED";
            //return post_response;


            //PartnerWeekly
            string PW_data = build_PW_post_data();
            string PW_Response = PW_Post(PW_data);

            //if posting error to tree break for error
            if (PW_Response == "ERROR")
            {
                post_response = "ERROR";

                oLead = null;
                return post_response;
            }

            if (PW_Response == "InternetIssue")
            {
                post_response = "InternetIssue";

                oLead = null;
                return post_response;
            }

            XElement tree_response = XElement.Parse(@PW_Response);
            IEnumerable<XElement> unique_id =
                from item in tree_response.Descendants("data")
                where (string)item.Attribute("name") == "unique_id"
                select item;

            string Lid = "";
            try
            {
                Lid = unique_id.ElementAt(0).Value;
            }
            catch
            {   //if no id returned 
                Lid = "no id returned";
            }
            oLead.Lid = Lid;

            IEnumerable<XElement> appStatus =
                from item in tree_response.Descendants("data")
                where (string)item.Attribute("name") == "page"
                select item;

            string currStatus = "";
            try
            {
                currStatus = appStatus.ElementAt(0).Value;
            }
            catch
            {   // **MAYBE CHANGE LATER** if no status returned set declined keep moving to other trees 
                currStatus = "app_declined";
            }

            //error
            if (currStatus == "app_allinone")
            {
                string errorMsg = "";
                string currMsg = "";
                string checkDup = "";

                //foreach (XElement x in tree_response.Elements("errors").Elements("data").Select(t => t.Value).Distinct().ToString())
                foreach (XElement x in tree_response.Elements("errors").Elements("data"))
                {
                    currMsg = x.Value;

                    if (currMsg != checkDup)
                    {
                        errorMsg = errorMsg + currMsg + "<br />";
                    }
                    checkDup = currMsg;
                }

                int lead_id = oLead.lead_id; //The ID number for the current lead.
                oLead.status_id = 3; // 3 is status id for error
                oLead.error_description = errorMsg;
                oLead.price = "0";
                oLead.buyer_id = "0";
                oLead.created_dt = DateTime.Now;

                try
                {
                    SqlParameter[] paramValues = DataAccess.GetParameters("sp_UpdateLeadError");

                    paramValues[0].Value = lead_id;
                    paramValues[1].Value = oLead.status_id;
                    paramValues[2].Value = oLead.Lid;
                    paramValues[3].Value = oLead.error_description;
                    paramValues[4].Value = oLead.price;
                    paramValues[5].Value = oLead.buyer_id;
                    paramValues[6].Value = "PW Full"; //tree
                    paramValues[7].Value = "PW Error"; //last_action
                    paramValues[8].Value = oLead.created_dt;

                    SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_UpdateLeadError", paramValues);
                    //SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);

                    //insert lead detail into lead detail table
                    paramValues = DataAccess.GetParameters("sp_InsertLeadDetail");

                    paramValues[0].Value = lead_id;
                    paramValues[1].Value = oLead.lead_no; //lead_no, leadcollider lead identification number
                    paramValues[2].Value = oLead.status_id;
                    paramValues[3].Value = oLead.Tag;
                    paramValues[4].Value = oLead.Lid; //Lid id from tree
                    paramValues[5].Value = "n/a"; //redirect_url
                    paramValues[6].Value = oLead.error_description; //error_description
                    paramValues[7].Value = "n/a"; //declined_description
                    paramValues[8].Value = "PW Full"; //tree
                    paramValues[9].Value = "PW Error"; //last_action               
                    paramValues[10].Value = oLead.created_dt;

                    //SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);
                    SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLeadDetail", paramValues);

                    //Testing
                    //oLead.error_description = PW_Response;
                    /////////////////////////////

                    post_response = "ERROR";

                    oLead = null;
                    paramValues = null;
                    return post_response;
                }
                catch
                {
                    post_response = "ERROR";

                    oLead = null;
                    return post_response;
                }

            }
            //declined
            if (currStatus == "app_declined")
            {
                //This should get PW declined description maybe need it in future
                //string declined_description = "";
                //foreach (XElement x in tree_response.Elements("content").Elements("section"))
                //{
                //    declined_description = x.Value;
                //}

                int lead_id = oLead.lead_id; //The ID number for the current lead.
                oLead.status_id = 2; // 2 is status id for declined
                oLead.declined_description = "We're sorry but you do not qualify for a payday loan at this time.";
                oLead.price = "0";
                oLead.buyer_id = "0";
                oLead.created_dt = DateTime.Now;

                try
                {
                    SqlParameter[] paramValues = DataAccess.GetParameters("sp_UpdateLeadDeclined");

                    paramValues[0].Value = lead_id;
                    paramValues[1].Value = oLead.status_id;
                    paramValues[2].Value = oLead.Lid;
                    paramValues[3].Value = oLead.declined_description;
                    paramValues[4].Value = oLead.price;
                    paramValues[5].Value = oLead.buyer_id;
                    paramValues[6].Value = "PW Full"; //tree
                    paramValues[7].Value = "PW Declined"; //last_action
                    paramValues[8].Value = oLead.created_dt;

                    SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_UpdateLeadDeclined", paramValues);
                    //SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);

                    //insert lead detail into lead detail table
                    paramValues = DataAccess.GetParameters("sp_InsertLeadDetail");

                    paramValues[0].Value = lead_id;
                    paramValues[1].Value = oLead.lead_no; //lead_no, leadcollider lead identification number
                    paramValues[2].Value = oLead.status_id;
                    paramValues[3].Value = oLead.Tag;
                    paramValues[4].Value = oLead.Lid; //Lid id from tree (LeadFlash or any tree?)
                    paramValues[5].Value = "n/a"; //redirect_url
                    paramValues[6].Value = "n/a"; //error_description
                    paramValues[7].Value = oLead.declined_description; //declined_description
                    paramValues[8].Value = "PW Full"; //tree
                    paramValues[9].Value = "PW Declined"; //last_action               
                    paramValues[10].Value = oLead.created_dt;

                    //SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);
                    SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLeadDetail", paramValues);

                    paramValues = null;
                }
                catch
                {
                    post_response = "DECLINED";

                    oLead = null;
                    return post_response;
                }
                post_response = "DECLINED";

                oLead = null;
                return post_response;
            }

            //accepted
            if (currStatus == "app_completed")
            {
                IEnumerable<XElement> earned_lead_amount =
                from item in tree_response.Descendants("data")
                where (string)item.Attribute("name") == "earned_lead_amount"
                select item;

                string price = "";
                try
                {
                    price = earned_lead_amount.ElementAt(0).Value;
                }
                catch
                {   //if no lead price returned set 0
                    price = "0";
                }

                string redirect_url = "";
                foreach (XElement x in tree_response.Elements("content").Elements("section"))
                {
                    redirect_url = x.Value;
                }

                int lead_id = oLead.lead_id; //The ID number for the current lead.
                oLead.status_id = 1; // 1 is status id for accepted
                //oLead.Lid = Lid; set above
                oLead.redirect_url = redirect_url;
                oLead.price = price;
                oLead.buyer_id = "n/a";
                oLead.created_dt = DateTime.Now;

                try
                {
                    SqlParameter[] paramValues = DataAccess.GetParameters("sp_UpdateLeadAccepted");

                    paramValues[0].Value = lead_id;
                    paramValues[1].Value = oLead.status_id;
                    paramValues[2].Value = oLead.Lid;
                    paramValues[3].Value = oLead.redirect_url;
                    paramValues[4].Value = oLead.price;
                    paramValues[5].Value = oLead.buyer_id;
                    paramValues[6].Value = "PW Full"; //tree
                    paramValues[7].Value = "PW Accepted"; //last_action
                    paramValues[8].Value = oLead.created_dt;

                    SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_UpdateLeadAccepted", paramValues);
                    //SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);

                    //insert lead detail into lead detail table
                    paramValues = DataAccess.GetParameters("sp_InsertLeadDetail");

                    paramValues[0].Value = lead_id;
                    paramValues[1].Value = oLead.lead_no; //lead_no, leadcollider lead identification number
                    paramValues[2].Value = oLead.status_id;
                    paramValues[3].Value = oLead.Tag;
                    paramValues[4].Value = oLead.Lid; //Lid id from tree (LeadFlash or any tree?)
                    paramValues[5].Value = oLead.redirect_url; //redirect_url
                    paramValues[6].Value = "n/a"; //error_description
                    paramValues[7].Value = "n/a"; //declined_description
                    paramValues[8].Value = "PW Full"; //tree
                    paramValues[9].Value = "PW Accepted"; //last_action               
                    paramValues[10].Value = oLead.created_dt;

                    //SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);
                    SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLeadDetail", paramValues);

                    paramValues = null;

                }
                catch
                {
                    post_response = "ACCEPTED";

                    oLead = null;
                    return post_response;
                }
                post_response = "ACCEPTED";

                oLead = null;
                return post_response;
            }

            // **MAYBE CHANGE LATER** CATCH ALL SET TO DECLINED FOR NOW
            post_response = "DECLINED";

            oLead = null;
            return post_response;

        }//End PartnerWeekly

        //START: LeadFlash
        protected string get_LF_post_response()
        {
            string post_response = "";

            Lead oLead = (Lead)Session["s_oLead"];

            //Testing for declined
            //oLead = null;
            //post_response = "DECLINED";
            //return post_response;

            string LF_data = build_LF_post_data();
            string LF_Response = LF_Post(LF_data);

            //if posting error to tree break for error
            if (LF_Response == "ERROR")
            {
                post_response = "ERROR";

                oLead = null;
                return post_response;
            }

            if (LF_Response == "InternetIssue")
            {
                post_response = "InternetIssue";

                oLead = null;
                return post_response;
            }

            //string ResponseMsg = "";
            char[] delimiterChars = { '|', '\t' };

            string text = LF_Response;

            //ResponseMsg = "Original text:" + text + "<br>";
            //System.Console.WriteLine("Original text: '{0}'", text);

            string[] words = text.Split(delimiterChars);
            //ResponseMsg = ResponseMsg + "Words in text:" + words.Length + "<br>";
            //System.Console.WriteLine("{0} words in text:", words.Length);
            //string wordsstr = "";

            if (words[0].ToLower() == "error")
            {
                int lead_id = oLead.lead_id; //The ID number for the current lead.
                oLead.status_id = 3; // 3 is status id for error
                oLead.Lid = words[1];
                oLead.error_description = words[2];
                oLead.price = words[3];
                oLead.buyer_id = words[4];
                oLead.created_dt = DateTime.Now;

                try
                {
                    SqlParameter[] paramValues = DataAccess.GetParameters("sp_UpdateLeadError");

                    paramValues[0].Value = lead_id;
                    paramValues[1].Value = oLead.status_id;
                    paramValues[2].Value = oLead.Lid;
                    paramValues[3].Value = oLead.error_description;
                    paramValues[4].Value = oLead.price;
                    paramValues[5].Value = oLead.buyer_id;
                    paramValues[6].Value = "LF Full"; //tree
                    paramValues[7].Value = "LF Error"; //last_action
                    paramValues[8].Value = oLead.created_dt;

                    SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_UpdateLeadError", paramValues);
                    //SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);

                    //insert lead detail into lead detail table
                    paramValues = DataAccess.GetParameters("sp_InsertLeadDetail");

                    paramValues[0].Value = lead_id;
                    paramValues[1].Value = oLead.lead_no; //lead_no, leadcollider lead identification number
                    paramValues[2].Value = oLead.status_id;
                    paramValues[3].Value = oLead.Tag;
                    paramValues[4].Value = oLead.Lid; //Lid id from tree (LeadFlash or any tree?)
                    paramValues[5].Value = "n/a"; //redirect_url
                    paramValues[6].Value = oLead.error_description; //error_description
                    paramValues[7].Value = "n/a"; //declined_description
                    paramValues[8].Value = "LF Full"; //tree
                    paramValues[9].Value = "LF Error"; //last_action               
                    paramValues[10].Value = oLead.created_dt;

                    //SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);
                    SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLeadDetail", paramValues);

                    post_response = "ERROR";

                    oLead = null;
                    paramValues = null;
                    return post_response;
                }
                catch
                {
                    post_response = "ERROR";

                    oLead = null;
                    return post_response;
                }
            }

            if (words[0].ToLower() == "declined")
            {
                int lead_id = oLead.lead_id; //The ID number for the current lead.
                oLead.status_id = 2; // 2 is status id for declined
                oLead.Lid = words[1];
                oLead.declined_description = words[2];
                oLead.price = words[3];
                oLead.buyer_id = words[4];
                oLead.created_dt = DateTime.Now;

                try
                {
                    SqlParameter[] paramValues = DataAccess.GetParameters("sp_UpdateLeadDeclined");

                    paramValues[0].Value = lead_id;
                    paramValues[1].Value = oLead.status_id;
                    paramValues[2].Value = oLead.Lid;
                    paramValues[3].Value = oLead.declined_description;
                    paramValues[4].Value = oLead.price;
                    paramValues[5].Value = oLead.buyer_id;
                    paramValues[6].Value = "LF Full"; //tree
                    paramValues[7].Value = "LF Declined"; //last_action
                    paramValues[8].Value = oLead.created_dt;

                    SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_UpdateLeadDeclined", paramValues);
                    //SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);

                    //insert lead detail into lead detail table
                    paramValues = DataAccess.GetParameters("sp_InsertLeadDetail");

                    paramValues[0].Value = lead_id;
                    paramValues[1].Value = oLead.lead_no; //lead_no, leadcollider lead identification number
                    paramValues[2].Value = oLead.status_id;
                    paramValues[3].Value = oLead.Tag;
                    paramValues[4].Value = oLead.Lid; //Lid id from tree (LeadFlash or any tree?)
                    paramValues[5].Value = "n/a"; //redirect_url
                    paramValues[6].Value = "n/a"; //error_description
                    paramValues[7].Value = oLead.declined_description; //declined_description
                    paramValues[8].Value = "LF Full"; //tree
                    paramValues[9].Value = "LF Declined"; //last_action               
                    paramValues[10].Value = oLead.created_dt;

                    //SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);
                    SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLeadDetail", paramValues);

                    paramValues = null;
                }
                catch
                {
                    post_response = "DECLINED";

                    oLead = null;
                    return post_response;
                }

                post_response = "DECLINED";

                oLead = null;
                return post_response;
            }

            if (words[0].ToLower() == "accepted")
            {
                int lead_id = oLead.lead_id; //The ID number for the current lead.
                oLead.status_id = 1; // 1 is status id for accepted
                oLead.Lid = words[1];
                oLead.redirect_url = words[2];
                oLead.price = words[3];
                oLead.buyer_id = words[4];
                oLead.created_dt = DateTime.Now;

                try
                {
                    SqlParameter[] paramValues = DataAccess.GetParameters("sp_UpdateLeadAccepted");

                    paramValues[0].Value = lead_id;
                    paramValues[1].Value = oLead.status_id;
                    paramValues[2].Value = oLead.Lid;
                    paramValues[3].Value = oLead.redirect_url;
                    paramValues[4].Value = oLead.price;
                    paramValues[5].Value = oLead.buyer_id;
                    paramValues[6].Value = "LF Full"; //tree
                    paramValues[7].Value = "LF Accepted"; //last_action
                    paramValues[8].Value = oLead.created_dt;

                    SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_UpdateLeadAccepted", paramValues);
                    //SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);

                    //insert lead detail into lead detail table
                    paramValues = DataAccess.GetParameters("sp_InsertLeadDetail");

                    paramValues[0].Value = lead_id;
                    paramValues[1].Value = oLead.lead_no; //lead_no, leadcollider lead identification number
                    paramValues[2].Value = oLead.status_id;
                    paramValues[3].Value = oLead.Tag;
                    paramValues[4].Value = oLead.Lid; //Lid id from tree (LeadFlash or any tree?)
                    paramValues[5].Value = oLead.redirect_url; //redirect_url
                    paramValues[6].Value = "n/a"; //error_description
                    paramValues[7].Value = "n/a"; //declined_description
                    paramValues[8].Value = "LF Full"; //tree
                    paramValues[9].Value = "LF Accepted"; //last_action               
                    paramValues[10].Value = oLead.created_dt;

                    //SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);
                    SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLeadDetail", paramValues);

                    paramValues = null;
                }
                catch
                {
                    post_response = "ACCEPTED";

                    oLead = null;
                    return post_response;
                }

                post_response = "ACCEPTED";

                oLead = null;
                return post_response;
            }

            // **MAYBE CHANGE LATER** CATCH ALL SET TO DECLINED FOR NOW
            post_response = "DECLINED";
            return post_response;

        }
        //End LeadFlash

        //START: LeadPile
        protected string get_LP_post_response()
        {
            string post_response = "";

            Lead oLead = (Lead)Session["s_oLead"];

            //If not employed do not send to LeadPile
            //if (oLead.income_type == "BENEFITS")
            //{
            //    Response.Redirect("Additional.Resources.aspx");
            //}

            //LeadPile
            string LP_data = build_LP_post_data();
            string LP_Response = LP_Post(LP_data);

            //if posting error to tree break for error
            if (LP_Response == "ERROR")
            {
                post_response = "ERROR";

                oLead = null;
                return post_response;
            }

            XElement tree_response = XElement.Parse(@LP_Response);

            string appStatus = "";
            foreach (XElement x in tree_response.Elements("status"))
            {
                appStatus = x.Value;
            }

            string currStatus = "";
            currStatus = appStatus;

            //if cannot get the status from LP
            //set to NOREALTIME for now 
            //SHOULD NOT REALLY HAPPEN
            if (currStatus == "")
            {
                currStatus = "NOREALTIME";
            }

            int isDECLINED = currStatus.IndexOf("NO");
            if (isDECLINED != -1)
            {
                currStatus = "NOREALTIME";
            }

            //error
            if (currStatus == "reject")
            {
                //Check for error messages.
                string errorMsg = "";
                string currMsg = "";
                string checkDup = "";
                foreach (XElement x in tree_response.Elements("errors").Elements("error"))
                {
                    currMsg = x.Value;

                    if (currMsg != checkDup)
                    {
                        errorMsg = errorMsg + currMsg + "<br />";
                    }
                    checkDup = currMsg;
                }

                int lead_id = oLead.lead_id; //The LeadCollider ID number for the current lead.
                oLead.status_id = 3; // 3 is status id for error
                //oLead.Lid = Lid; set above ---Will not have from tree
                oLead.error_description = errorMsg;
                oLead.price = "0";
                oLead.buyer_id = "0";
                oLead.created_dt = DateTime.Now;

                try
                {
                    SqlParameter[] paramValues = DataAccess.GetParameters("sp_UpdateLeadError");

                    paramValues[0].Value = lead_id;
                    paramValues[1].Value = oLead.status_id;
                    paramValues[2].Value = oLead.Lid;
                    paramValues[3].Value = oLead.error_description;
                    paramValues[4].Value = oLead.price;
                    paramValues[5].Value = oLead.buyer_id;
                    paramValues[6].Value = "LP Full"; //tree
                    paramValues[7].Value = "LP Error"; //last_action
                    paramValues[8].Value = oLead.created_dt;

                    SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_UpdateLeadError", paramValues);
                    //SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);

                    //insert lead detail into lead detail table
                    paramValues = DataAccess.GetParameters("sp_InsertLeadDetail");

                    paramValues[0].Value = lead_id;
                    paramValues[1].Value = oLead.lead_no; //lead_no, leadcollider lead identification number
                    paramValues[2].Value = oLead.status_id;
                    paramValues[3].Value = oLead.Tag;
                    paramValues[4].Value = oLead.Lid; //Lid id from tree (LeadFlash or any tree?)
                    paramValues[5].Value = "n/a"; //redirect_url
                    paramValues[6].Value = oLead.error_description; //error_description
                    paramValues[7].Value = "n/a"; //declined_description
                    paramValues[8].Value = "LP Full"; //tree
                    paramValues[9].Value = "LP Error"; //last_action               
                    paramValues[10].Value = oLead.created_dt;

                    //SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);
                    SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLeadDetail", paramValues);

                    //Testing
                    //oLead.error_description = LP_Response;
                    /////////////////////////////

                    post_response = "ERROR";

                    oLead = null;
                    paramValues = null;
                    return post_response;
                }
                catch
                {
                    post_response = "ERROR";

                    oLead = null;
                    return post_response;
                }
            }

            //accepted
            if (currStatus == "accept")
            {
                //Lead ID from LP
                string unique_id = "";
                foreach (XElement x in tree_response.Elements("id"))
                {
                    unique_id = x.Value;
                }
                string Lid = "";
                Lid = unique_id;
                oLead.Lid = Lid;

                //Price from LP
                string price = "";
                foreach (XElement x in tree_response.Elements("sale").Elements("price"))
                {
                    price = x.Value;
                }

                if (price == "")
                {
                    oLead.price = "0";
                }
                else
                {
                    oLead.price = price;
                }

                string redirect_url = "";
                foreach (XElement x in tree_response.Elements("sale").Elements("redirect"))
                {
                    redirect_url = x.Value;
                }

                int lead_id = oLead.lead_id; //The ID number for the current lead.
                oLead.status_id = 1; // 1 is status id for accepted
                oLead.redirect_url = redirect_url;
                oLead.price = price;
                oLead.buyer_id = "n/a";
                oLead.created_dt = DateTime.Now;

                try
                {
                    SqlParameter[] paramValues = DataAccess.GetParameters("sp_UpdateLeadAccepted");

                    paramValues[0].Value = lead_id;
                    paramValues[1].Value = oLead.status_id;
                    paramValues[2].Value = oLead.Lid;
                    paramValues[3].Value = oLead.redirect_url;
                    paramValues[4].Value = oLead.price;
                    paramValues[5].Value = oLead.buyer_id;
                    paramValues[6].Value = "LP Full"; //tree
                    paramValues[7].Value = "LP Accepted"; //last_action
                    paramValues[8].Value = oLead.created_dt;

                    SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_UpdateLeadAccepted", paramValues);
                    //SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);

                    //insert lead detail into lead detail table
                    paramValues = DataAccess.GetParameters("sp_InsertLeadDetail");

                    paramValues[0].Value = lead_id;
                    paramValues[1].Value = oLead.lead_no; //lead_no, leadcollider lead identification number
                    paramValues[2].Value = oLead.status_id;
                    paramValues[3].Value = oLead.Tag;
                    paramValues[4].Value = oLead.Lid; //Lid id from tree (LeadFlash or any tree?)
                    paramValues[5].Value = oLead.redirect_url; //redirect_url
                    paramValues[6].Value = "n/a"; //error_description
                    paramValues[7].Value = "n/a"; //declined_description
                    paramValues[8].Value = "LP Full"; //tree
                    paramValues[9].Value = "LP Accepted"; //last_action               
                    paramValues[10].Value = oLead.created_dt;

                    //SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);
                    SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLeadDetail", paramValues);

                    paramValues = null;

                }
                catch
                {
                    post_response = "ACCEPTED";

                    oLead = null;
                    return post_response;
                }
                post_response = "ACCEPTED";

                oLead = null;
                return post_response;
            }


            //NO REAL TIME SALE
            if (currStatus == "NOREALTIME")
            {
                //Lead ID from LP
                string unique_id = "";
                foreach (XElement x in tree_response.Elements("id"))
                {
                    unique_id = x.Value;
                }
                string Lid = "";
                Lid = unique_id;
                oLead.Lid = Lid;

                //Check for error messages.
                //error messages will exist for time out
                string errorMsg = "";
                string currMsg = "";
                string checkDup = "";
                foreach (XElement x in tree_response.Elements("errors").Elements("error"))
                {
                    currMsg = x.Value;

                    if (currMsg != checkDup)
                    {
                        errorMsg = errorMsg + currMsg + "<br />";
                    }
                    checkDup = currMsg;
                }

                if (errorMsg == "")
                {
                    errorMsg = "n/a";
                }

                int lead_id = oLead.lead_id; //The ID number for the current lead.
                oLead.status_id = 2; // 2 is status id for declined
                oLead.declined_description = errorMsg;
                oLead.price = "0";
                oLead.buyer_id = "0";
                oLead.created_dt = DateTime.Now;

                try
                {
                    SqlParameter[] paramValues = DataAccess.GetParameters("sp_UpdateLeadDeclined");

                    paramValues[0].Value = lead_id;
                    paramValues[1].Value = oLead.status_id;

                    //??????? Lid
                    paramValues[2].Value = oLead.Lid;
                    paramValues[3].Value = oLead.declined_description;
                    paramValues[4].Value = oLead.price;
                    paramValues[5].Value = oLead.buyer_id;
                    paramValues[6].Value = "LP Full"; //tree
                    paramValues[7].Value = "LP NO RT"; //last_action
                    paramValues[8].Value = oLead.created_dt;

                    SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_UpdateLeadDeclined", paramValues);
                    //SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);

                    //insert lead detail into lead detail table
                    paramValues = DataAccess.GetParameters("sp_InsertLeadDetail");

                    paramValues[0].Value = lead_id;
                    paramValues[1].Value = oLead.lead_no; //lead_no, leadcollider lead identification number
                    paramValues[2].Value = oLead.status_id;
                    paramValues[3].Value = oLead.Tag;
                    paramValues[4].Value = oLead.Lid; //Lid id from tree (LeadFlash or any tree?)
                    paramValues[5].Value = "n/a"; //redirect_url
                    paramValues[6].Value = "n/a"; //error_description
                    paramValues[7].Value = oLead.declined_description; //declined_description
                    paramValues[8].Value = "LP Full"; //tree
                    paramValues[9].Value = "LP NO RT"; //last_action               
                    paramValues[10].Value = oLead.created_dt;

                    //SqlHelper.ExecuteNonQuery(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLead1", paramValues);
                    SqlHelper.ExecuteScalar(DataAccess.GetConnectionString(), CommandType.StoredProcedure, "sp_InsertLeadDetail", paramValues);

                    paramValues = null;
                }
                catch
                {
                    post_response = "DECLINED";

                    oLead = null;
                    return post_response;
                }
                post_response = "DECLINED";

                oLead = null;
                return post_response;
            }

            // **MAYBE CHANGE LATER** CATCH ALL SET TO DECLINED FOR NOW
            post_response = "DECLINED";

            oLead = null;
            return post_response;
        }//End LeadPile
        //END: functions to get response from placement trees

        //START: functions to build data to send to placement trees 
        //PartnerWeekly XML data
        protected string build_PW_post_data()
        {
            Lead oLead = (Lead)Session["s_oLead"];
            VenderInfo oVenderInfo = new VenderInfo();
         
            XElement PW_data =
                new XElement("tss_loan_request",
                    new XElement("signature",
                        new XElement("data",
                            new XAttribute("name", "site_type"), oVenderInfo.site_type),
                        new XElement("data",
                            new XAttribute("name", "license_key"), oVenderInfo.license_key),
                        new XElement("data",
                            new XAttribute("name", "page"), oVenderInfo.page),
                        new XElement("data",
                            new XAttribute("name", "promo_id"), oVenderInfo.promo_id),
                        new XElement("data",
                            new XAttribute("name", "promo_sub_code"), oVenderInfo.promo_sub_code)),
                                new XElement("collection",
                                    new XElement("data",
                                        new XAttribute("name", "bank_aba"), oLead.bank_aba),
                                    new XElement("data",
                                        new XAttribute("name", "bank_account"), oLead.bank_account),

                                    new XElement("data",
                                        new XAttribute("name", "bank_account_type"), oLead.bank_account_type),

                                    //Added bank_length_months 5/25/2011
                                    new XElement("data",
                                        new XAttribute("name", "bank_length_months"), oLead.months_at_bank),

                                    new XElement("data",
                                        new XAttribute("name", "bank_name"), oLead.bank_name),
                                    new XElement("data",
                                        new XAttribute("name", "best_call_time"), oLead.best_call_time),

                                    //Removed citizen 5/25/2011
                                    //new XElement("data",
                                    //    new XAttribute("name", "citizen"), oLead.citizen),

                                    new XElement("data",
                                        new XAttribute("name", "client_ip_address"), oLead.client_ip_address),
                                    new XElement("data",
                                        new XAttribute("name", "client_url_root"), oLead.client_url_root),

                                    //Added customer_id 5/25/2011
                                    new XElement("data",
                                        new XAttribute("name", "customer_id"), oLead.lead_no),

                                    new XElement("data",
                                        new XAttribute("name", "date_dob_d"), oLead.date_dob_d),
                                    new XElement("data",
                                        new XAttribute("name", "date_dob_m"), oLead.date_dob_m),
                                    new XElement("data",
                                        new XAttribute("name", "date_dob_y"), oLead.date_dob_y),
                                    new XElement("data",
                                        new XAttribute("name", "email_primary"), oLead.Email),
                                    
                                        //Changed employer_length to employer_length_months 5/25/2011 
                                    new XElement("data",
                                        new XAttribute("name", "employer_length_months"), oLead.months_employed),
                                    
                                    new XElement("data",
                                        new XAttribute("name", "employer_name"), oLead.employer_name),
                                    new XElement("data",
                                        new XAttribute("name", "ext_work"), oLead.phone_work_ext),
                                    new XElement("data",
                                        new XAttribute("name", "home_street"), oLead.street_addr1),
                                    new XElement("data",
                                        new XAttribute("name", "home_city"), oLead.city),
                                    new XElement("data",
                                        new XAttribute("name", "home_state"), oLead.state),
                                    new XElement("data",
                                        new XAttribute("name", "home_unit"), oLead.street_addr2),
                                    new XElement("data",
                                        new XAttribute("name", "home_zip"), oLead.Zip),
                                    new XElement("data",
                                        new XAttribute("name", "income_date1_d"), oLead.income_date1_d),
                                    new XElement("data",
                                        new XAttribute("name", "income_date1_m"), oLead.income_date1_m),
                                    new XElement("data",
                                        new XAttribute("name", "income_date1_y"), oLead.income_date1_y),
                                    new XElement("data",
                                        new XAttribute("name", "income_date2_d"), oLead.income_date2_d),
                                    new XElement("data",
                                        new XAttribute("name", "income_date2_m"), oLead.income_date2_m),
                                    new XElement("data",
                                        new XAttribute("name", "income_date2_y"), oLead.income_date2_y),
                                    new XElement("data",
                                        new XAttribute("name", "income_direct_deposit"), oLead.income_direct_deposit),
                                    new XElement("data",
                                        new XAttribute("name", "income_frequency"), oLead.income_frequency),

                                    //Changed income_monthly_net to income_monthly 5/25/2011
                                    new XElement("data",
                                        new XAttribute("name", "income_monthly"), oLead.income_monthly),
                                    new XElement("data",
                                        new XAttribute("name", "income_type"), oLead.income_type),

                                    //Removed legal_notice_1 5/25/2011    
                                    //ADDED LEGAL NOTICE OUTSIDE OF LEAD.CS 1/27/2011 DEFAULTED
                                    //new XElement("data",
                                    //    new XAttribute("name", "legal_notice_1"), "TRUE"),

                                    //ADDED loan_amount_desired 1/27/2011 per email request
                                    new XElement("data",
                                        new XAttribute("name", "loan_amount_desired"), oLead.requested_amount),
                                    new XElement("data",
                                        new XAttribute("name", "military"), oLead.military),
                                    new XElement("data",
                                        new XAttribute("name", "name_first"), oLead.first_name),
                                    new XElement("data",
                                        new XAttribute("name", "name_last"), oLead.last_name),
                                    new XElement("data",
                                        new XAttribute("name", "name_middle"), oLead.name_middle),

                                    //Removed offers 5/25/2011
                                    //new XElement("data",
                                    //    new XAttribute("name", "offers"), oLead.offers),

                                    new XElement("data",
                                        new XAttribute("name", "phone_cell"), oLead.phone_cell),
                                    
                                    //Removed phone_fax 5/25/2011
                                    //new XElement("data",
                                    //    new XAttribute("name", "phone_fax"), oLead.phone_fax),
                                    
                                    new XElement("data",
                                        new XAttribute("name", "phone_home"), oLead.phone_home),
                                    new XElement("data",
                                        new XAttribute("name", "phone_work"), oLead.phone_work),
                                    new XElement("data",
                                        new XAttribute("name", "ref_01_name_full"), oLead.ref_01_name_full),
                                    new XElement("data",
                                        new XAttribute("name", "ref_01_phone_home"), oLead.ref_01_phone_home),
                                    new XElement("data",
                                        new XAttribute("name", "ref_01_relationship"), oLead.ref_01_relationship),
                                    new XElement("data",
                                        new XAttribute("name", "ref_02_name_full"), oLead.ref_02_name_full),
                                    new XElement("data",
                                        new XAttribute("name", "ref_02_phone_home"), oLead.ref_02_phone_home),
                                    new XElement("data",
                                        new XAttribute("name", "ref_02_relationship"), oLead.ref_02_relationship),
                                    //Changed residence_start_date to residence_length_months 5/25/2011 
                                    new XElement("data",
                                        new XAttribute("name", "residence_length_months"), oLead.months_at_address),
                                    new XElement("data",
                                        new XAttribute("name", "residence_type"), oLead.residence_type),
                                    new XElement("data",
                                        new XAttribute("name", "ssn_part_1"), oLead.ssn_part_1),
                                    new XElement("data",
                                        new XAttribute("name", "ssn_part_2"), oLead.ssn_part_2),
                                    new XElement("data",
                                        new XAttribute("name", "ssn_part_3"), oLead.ssn_part_3),
                                    new XElement("data",
                                        new XAttribute("name", "state_id_number"), oLead.drivers_license),
                                    new XElement("data",
                                        new XAttribute("name", "state_issued_id"), oLead.drivers_license_st)));

            //Removed cali_agree 5/25/2011
            //if (oLead.state == "CA")
            //{
            //    XElement cali_agree = new XElement("data",
            //        new XAttribute("name", "cali_agree"), oLead.cali_agree);

            //    XElement collection = PW_data.Element("collection");
            //    collection.Add(cali_agree);
            //}

            oLead = null;
            oVenderInfo = null; 
            return PW_data.ToString();
        }
        //end PartnerWeekly

        //LeadFlash query string data
        protected string build_LF_post_data()
        {
            Lead oLead = (Lead)Session["s_oLead"];
            VenderInfo oVenderInfo = new VenderInfo();

            string LF_data = "";

            LF_data =
                "vendor_id=" + oVenderInfo.vendor_id + "&" +
                "vendor_pass=" + oVenderInfo.vendor_pass + "&" +
                "lead_type_id=" + oLead.lead_type_id + "&" +
                "Tag=" + oLead.Tag + "&" +
                "Lid=" + oLead.Lid + "&" + //try to pass Lid for error "Invalid Repost...."
                "test_app=" + oVenderInfo.test_app + "&" +
                "auto_redirect=" + oVenderInfo.auto_redirect + "&" +
                "declined_redirect=" + oVenderInfo.declined_redirect + "&" +
                "first_name=" + oLead.first_name + "&" +
                "last_name=" + oLead.last_name + "&" +
                "street_addr1=" + oLead.street_addr1 + "&" +
                "street_addr2=" + oLead.street_addr2 + "&" +
                "city=" + oLead.city + "&" +
                "state=" + oLead.state + "&" +
                "Zip=" + oLead.Zip + "&" +
                "social_security=" + oLead.social_security + "&" +
                "phone_home=" + oLead.phone_home + "&" +
                "phone_cell=" + oLead.phone_cell + "&" +
                "phone_work=" + oLead.phone_work + "&" +
                "phone_work_ext=" + oLead.phone_work_ext + "&" +
                "Email=" + oLead.Email + "&" +
                "birth_date=" + oLead.birth_date + "&" +
                "employer_name=" + oLead.employer_name + "&" +
                "pay_per_period=" + oLead.pay_per_period + "&" +
                "pay_frequency=" + oLead.pay_frequency + "&" +
                "direct_deposit=" + oLead.direct_deposit + "&" +
                "pay_day1=" + oLead.pay_day1 + "&" +
                "pay_day2=" + oLead.pay_day2 + "&" +
                "bank_aba=" + oLead.bank_aba + "&" +
                "bank_account=" + oLead.bank_account + "&" +
                "bank_name=" + oLead.bank_name + "&" +
                "income_monthly=" + oLead.income_monthly + "&" +
                "own_home=" + oLead.own_home + "&" +
                "drivers_license=" + oLead.drivers_license + "&" +
                "drivers_license_st=" + oLead.drivers_license_st + "&" +
                "client_ip_address=" + oLead.client_ip_address + "&" +
                "client_url_root=" + oLead.client_url_root + "&" +
                "email_alternate=" + oLead.email_alternate + "&" +
                "months_employed=" + oLead.months_employed + "&" +
                "income_type=" + oLead.income_type + "&" +
                "is_military=" + oLead.is_military + "&" +
                "is_live=" + oLead.is_live + "&" +
                "bank_account_type=" + oLead.bank_account_type + "&" +
                "requested_amount=" + oLead.requested_amount + "&" +
                "accepted_terms=" + oLead.accepted_terms + "&" +
                "months_at_address=" + oLead.months_at_address + "&" +
                "months_at_bank=" + oLead.months_at_bank;

            oLead = null;
            oVenderInfo = null;
            return LF_data;

        }
        //end LeadFlash

        //LeadPile query string data
        protected string build_LP_post_data()
        {
            Lead oLead = (Lead)Session["s_oLead"];
            VenderInfo oVenderInfo = new VenderInfo();

            string LP_data = "";

            string isMIL = "";
            if (oLead.military == "TRUE")
            {
                isMIL = "YES";
            }
            else
            {
                isMIL = "NO";
            }

            string dDeposit = "";
            if (oLead.direct_deposit == 0)
            {
                dDeposit = "NO";
            }
            else
            {
                dDeposit = "YES";
            }

            string payF = "";
            switch (oLead.pay_frequency)
            {
                case "WEEKLY":
                    {
                        payF = "WEEKLY";
                        break;
                    }
                case "BIWEEKLY":
                    {
                        payF = "BI-WEEKLY";
                        break;
                    }
                case "TWICEMONTH":
                    {
                        payF = "TWICE_MONTHLY";
                        break;
                    }
                case "MONTHLY":
                    {
                        payF = "MONTHLY";
                        break;
                    }
                default:
                    {
                        payF = "BI-WEEKLY";
                        break;
                    }
            }

            if (oLead.direct_deposit == 0)
            {
                dDeposit = "NO";
            }
            else
            {
                dDeposit = "YES";
            }

            string r1FN = "";
            string r1LN = "";
            if (oLead.ref_01_name_full != "")
            {
                try
                {
                    char[] delimiterChars = { ' ' };
                    string text = oLead.ref_01_name_full;
                    text = text.Trim();
                    string[] words = text.Split(delimiterChars);

                    r1FN = words[0];
                    r1LN = words[1];
                }
                catch
                {
                    r1FN = oLead.ref_01_name_full;
                    r1LN = oLead.ref_01_name_full;
                }
            }
            else
            {
                r1FN = "UNKNOWN";
                r1LN = "UNKNOWN";
            }
            
            string r2FN = "";
            string r2LN = "";
            if (oLead.ref_02_name_full != "")
            {
                try
                {
                    char[] delimiterChars = { ' ' };
                    string text = oLead.ref_02_name_full;
                    text = text.Trim();
                    string[] words = text.Split(delimiterChars);

                    r2FN = words[0];
                    r2LN = words[1];
                }
                catch
                {
                    r2FN = oLead.ref_02_name_full;
                    r2LN = oLead.ref_02_name_full;
                }
            }
            else
            {
                r2FN = "UNKNOWN";
                r2LN = "UNKNOWN";
            }

            LP_data =
                "producer_id=" + oVenderInfo.producer_id + "&" +
                "producer_key=" + oVenderInfo.producer_key + "&" +
                "lead_type=" + oVenderInfo.lead_type + "&" +
                "additional_lead_types=" + oVenderInfo.additional_lead_types + "&" +
                "self_select_hours=" + oVenderInfo.self_select_hours + "&" + 
                "minimum_price=" + oVenderInfo.minimum_price + "&" +
                "timeout_seconds=" + oVenderInfo.timeout_seconds + "&" +
                "lead_ip=" + oLead.client_ip_address + "&" +
                "site=" + oLead.client_url_root + "&" +
                "source=" + "" + "&" +
                "campaign=" + "" + "&" +
                "ad=" + "" + "&" +
                "state=" + oLead.state + "&" +
                "first_name=" + oLead.first_name + "&" +
                "last_name=" + oLead.last_name + "&" +
                "email=" + oLead.Email + "&" +
                "home_phone=" + oLead.phone_home + "&" +
                "work_phone=" + oLead.phone_work + "&" +
                "postal_code=" + oLead.Zip + "&" +
                "address=" + oLead.street_addr1 + "&" +
                "city=" + oLead.city + "&" +
                "housing=" + oLead.residence_type + "&" +
                "working_in_us=" + "YES" + "&" +
                "active_military=" + isMIL + "&" +
                "best_time_to_call=" + oLead.best_call_time + "&" +
                "monthly_income=" + oLead.income_monthly + "&" +
                "has_bank_account=" + oLead.bank_account_type + "&" +
                "direct_deposit=" + dDeposit + "&" +
                "pay_period=" + payF + "&" +
                "next_pay_date=" + oLead.pay_day1 + "&" +
                "second_pay_date=" + oLead.pay_day2 + "&" +
                "requested_loan_amount=" + oLead.requested_amount + "&" +
                "income_type=" + oLead.income_type + "&" +
                "months_at_residence=" + oLead.months_at_address + "&" +
                "occupation=" + "EMPLOYED" + "&" +
                "employer=" + oLead.employer_name + "&" +
                "supervisor_name=" + "UNKNOWN" + "&" +
                "supervisor_phone=" + "8888888888" + "&" +
                "months_employed=" + oLead.months_employed + "&" +
                "bank_name=" + oLead.bank_name + "&" +
                "account_number=" + oLead.bank_account + "&" +
                "routing_number=" + oLead.bank_aba + "&" +
                "bank_phone=" + "8888888888" + "&" +
                "driving_license_state=" + oLead.drivers_license_st + "&" +
                "driving_license_number=" + oLead.drivers_license + "&" +
                "mother_maiden_name=" + "UNKNOWN" + "&" +
                "birth_date=" + oLead.birth_date + "&" +
                "social_security_number=" + oLead.social_security + "&" +
                "reference_1_first_name=" + r1FN + "&" +
                "reference_1_last_name=" + r1LN + "&" +
                "reference_1_relationship=" + oLead.ref_01_relationship + "&" +
                "reference_1_phone=" + oLead.ref_01_phone_home + "&" +
                "reference_2_first_name=" + r2FN + "&" +
                "reference_2_last_name=" + r2LN + "&" +
                "reference_2_relationship=" + oLead.ref_02_relationship + "&" +
                "reference_2_phone=" + oLead.ref_02_phone_home;

            oLead = null;
            oVenderInfo = null;
            return LP_data;

        }
        //end LeadPile
        //END: functions to build data to send to placement trees

        //Start: Timer to display progress bar
        protected void ResponseTimer_Tick(object sender, EventArgs e)
        {
            Lead oLead = (Lead)Session["s_oLead"];

            if (oLead.post_response != "")
            {
                if (oLead.curr_tree == 1)
                {
                    PW_Process_Response();

                    oLead = null;
                    return;
                }

                if (oLead.curr_tree == 2)
                {
                    LF_Process_Response();

                    oLead = null;
                    return;
                }

                if (oLead.curr_tree == 3)
                {
                    LP_Process_Response();

                    oLead = null;
                    return;
                }
            }

            oLead = null;
            return;
        }
        //END: Timer

    }
}
