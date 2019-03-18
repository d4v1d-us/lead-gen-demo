using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vipcashfast
{
    public partial class _04 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string url_root = Request.UrlReferrer.ToString();

            //string host = Request.Headers["Host"].ToString();


            //int getHost = host.IndexOf("vip");
            //if (getHost != -1)
            //{
            msg.Text = "<img src=\"https://vipcashfast.com/images/100.jpg\" alt=\"Sorry, This Page has Moved.\" /><br /><br /><a href=\"http://vipcashfast.com\" class=\"b35\">Click for vipcashfast.com</a>";
            //}
            //else
            //{
            //    msg.Text = "<a href=\"http://opencom.us\" class=\"b35\">opencomUS</a>";
            //}

            Response.Status = "404 Not Found";

        }
    }
}
