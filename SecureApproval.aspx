<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecureApproval.aspx.cs"
    Inherits="vipcashfast.SecureApproval" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Cash Advances - Payday Loans - Secure Approval vipcashfast.com</title>
    <meta name="Title" content="Cash Advances - Payday Loans - Secure Approval vipcashfast.com" />
    
    <meta name="Subject" content="Cash Advances - Payday Loans - Personal Financial Resources" />
    <meta name="description" content="Free online Cash Advance, Payday Loan application for your Instant Short Term Loan Approval. Cash Advances, Payday loans are Easy, Secure, Confidential and an Excellent Short Term Loan Personal Financial Resource. We continuously work for YOU expanding our VIP Network of Personal Financial Resources facilitating the freedom you desire." />     
   
    <meta name="robots" content="noarchive" />
    <meta name="robots" content="noindex, nofollow" /> 
    
    <meta name="googlebot" content="noindex, nofollow" />
    <meta name="googlebot" content="noarchive" />  
    <meta name="googlebot" content="nosnippet" /> 
    <meta name="googlebot" content="noodp" /> 

    <meta name="slurp" content="noindex, nofollow" /> 
    <meta name="slurp" content="noarchive" /> 
    <meta name="slurp" content="noodp" /> 
    <meta name="slurp" content="noydir" /> 

    <meta name="msnbot" content="noindex, nofollow" /> 
    <meta name="msnbot" content="noarchive" /> 
    <meta name="msnbot" content="noodp" /> 

    <meta name="teoma" content="noindex, nofollow" /> 
    <meta name="teoma" content="noarchive" />
    
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link href="css/template.css" rel="stylesheet" type="text/css" />
    
</head>
<body id="home">
    <form id="form1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <br />
    <div id="wrapper">
        <%--           Main Page Content            --%>
        <div id="content">
            <center>
                <table style="width: 95%; height: 95%; vertical-align: middle;">
                    <tr align="center">
                        <td width="width:100%">
                            <%--15000--%>
                            <asp:Timer ID="ResponseTimer" runat="server" Interval="8000" OnTick="ResponseTimer_Tick"
                                Enabled="true">
                            </asp:Timer>
                            <asp:UpdatePanel ID="ResponsePanel" runat="server" UpdateMode="Conditional" Visible="true">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ResponseTimer" EventName="Tick" />
                                </Triggers>
                                <ContentTemplate>
                                    <table style="width: 95%; height: 95%; vertical-align: middle;">
                                        <tr align="center">
                                            <td align="center">
                                                <div>
                                                <br />
                                                <br /><br />
                                                <br /><br />
                                                <br />
                                                <div>
                                                    <font class="b25"> Congratulations</font><font class="b20">, Your Application is 
                                                    Processing!</font> 
                                                    <br />
                                                <br />
                                                    <font class="r25">Please allow 1 to 2 Minutes for all VIP Networks.</font> 
                                                    <br />
                                                <br />
                                                <font class="b20">
                                                    Your application status will be displayed when Processing is Complete. 
                                                    <br />
                                                <br />
                                                    In case of Error, You will be returned to the application for Resubmission. 
                                                    <br />
                                                    <br />
                                                    <%--If you experience Technical Difficulties, Please let us know!--%>
                                                </font>
                                                </div>
                                                <br />
                                                <br />
                                                <img src="images/progressbar.gif" alt="cash advances payday loans" />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </center>
        </div>
        <!-- #include file ="SecureHeader.inc" -->
        <!-- #include file ="footer.inc" -->
    </div>
    </form>
    <%--AdWords Tracking --%>

    <script type="text/javascript">
        var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
        document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
    </script>

    <script type="text/javascript">
        try {
            var pageTracker = _gat._getTracker("UA-15269938-1");
            pageTracker._trackPageview();
        } catch (err) { }
    </script>

    <%--AdWords Tracking End --%>

</body>
</html>

