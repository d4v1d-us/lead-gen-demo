<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecureApplication.aspx.cs"
    Inherits="vipcashfast.SecureApplication" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Cash Advances - Payday Loans - Secure Application vipcashfast.com</title>
    <meta name="Title" content="Cash Advances - Payday Loans - Secure Application vipcashfast.com" />
    
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

    <script language="javascript" type="text/javascript" src="FullDataValidation.js"></script>

</head>
<body id="home">
    <form id="form1" runat="server" onsubmit="return FullDataValidation(this);">
    <br />
    <br />
    <div id="wrapper">
        <%--           Main Page Content            --%>
        <div id="content">
            <center>
                <asp:Panel runat="server" ID="ApplicationPnl" Visible="true">
                    <table border="0" style="width: 95%; height: 95%; vertical-align: middle;">
                        <tr align="center">
                            <td width="width:100%">
                                <table cellpadding="0" cellspacing="0" style="border-color: #1C4388; border-style: solid;
                                    width: 100%; height: 95%; vertical-align: middle; padding-bottom: 0px; padding-top: 0px;
                                    margin-bottom: 0px; margin-top: 0px;">
                                    <tr align="center">
                                        <td colspan="3">
                                            <p class="r16" style="margin:5px 0px 5px 0px;">
                                                <asp:Label ID="ApplicationLabel" runat="server" Width="600" Text="* Required Field"></asp:Label>
                                            </p>
                                        </td>
                                    </tr>
                                    <tr align="center" style="background-color: #1C4388;">
                                        <td colspan="3">
                                            <p class="w16" style="margin:5px 0px 5px 0px;" >
                                                Personal Information
                                            </p>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #DCDCD5;">
                                        <td>
                                            <p class="b16" style="text-align: center; margin: 5px 0px 5px 0px">
                                                1. Your name?</p>
                                        </td>
                                        <td style="width: 330px">
                                            <p class="b16-plain" style="text-align: right; margin: 5px 0px 5px 0px">
                                                First Name:&nbsp;<asp:TextBox ID="first_name" runat="server" Font-Size="Small" Width="100"
                                                    TextMode="SingleLine" MaxLength="50"></asp:TextBox><font class="r18">*</font></p>
                                        </td>
                                        <td style="width: 360px">
                                            <p class="b16-plain" style="text-align: right; margin: 5px 50px 5px 0px">
                                                Last Name:&nbsp;<asp:TextBox ID="last_name" runat="server"
                                                    Font-Size="Small" Width="100" TextMode="SingleLine" MaxLength="50"></asp:TextBox><font class="r18">*</font></p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="b16" style="text-align: center; margin: 5px 0px 5px 0px">
                                                2. Your address?</p>
                                        </td>
                                        <td valign="middle">
                                            <p class="b16-plain" style="text-align: right; margin: 5px 0px 5px 0px">
                                                Street Address:&nbsp;<asp:TextBox ID="street_addr1"
                                                    runat="server" Font-Size="Small" Width="100" TextMode="SingleLine" MaxLength="50"></asp:TextBox><font class="r18">*</font></p>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 8px 5px 0px">
                                                Street Address2:&nbsp;<asp:TextBox ID="street_addr2"
                                                    runat="server" Font-Size="Small" Width="100" TextMode="SingleLine" MaxLength="50"></asp:TextBox></p>
                                            
                                            <%--<p style="text-align: right; margin-right: 50px">
                                                <font color="#1C4388">US citizen over 18:</font>&nbsp;<asp:DropDownList runat="server" ID="citizen">
                                                    <asp:ListItem Value="TRUE">Yes</asp:ListItem>
                                                    <asp:ListItem Value="FALSE">No</asp:ListItem>
                                                </asp:DropDownList>
                                                <font class="r18">*</font></p>--%>
                                        </td>
                                        <td>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 50px 5px 0px">
                                                City:&nbsp;<asp:TextBox ID="city" runat="server" Font-Size="Small"
                                                    Width="100" TextMode="SingleLine" MaxLength="100"></asp:TextBox><font class="r18">*</font></p>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 50px 5px 0px">
                                                State:&nbsp;<asp:DropDownList runat="server" ID="state"
                                                    DataTextField="name" DataValueField="abbreviation">
                                                </asp:DropDownList><font class="r18">*</font></p>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 50px 5px 0px">
                                                Zip Code:&nbsp;<asp:TextBox ID="Zip" runat="server"
                                                    Font-Size="Small" Width="100" TextMode="SingleLine" MaxLength="5"></asp:TextBox><font class="r18">*</font></p>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #DCDCD5;">
                                        <td>
                                            <p class="b16" style="text-align: center; margin: 5px 0px 5px 0px">
                                                3. Residence details?</p>
                                        </td>
                                        <td>
                                            <p class="b16-plain" style="text-align:right; margin: 5px 0px 5px 0px">
                                            
                                            Months at Address:&nbsp;<asp:DropDownList runat="server" ID="months_at_address1">
                                                    <asp:ListItem Selected="True" Value="0">0</asp:ListItem>
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                    <asp:ListItem Value="6">6</asp:ListItem>
                                                    <asp:ListItem Value="7">7</asp:ListItem>
                                                    <asp:ListItem Value="8">8</asp:ListItem>
                                                    <asp:ListItem Value="9">9</asp:ListItem>
                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                </asp:DropDownList>&nbsp;<font class="b15">years</font>&nbsp;<asp:DropDownList runat="server" ID="months_at_address2">
                                                    <asp:ListItem Selected="True" Value="0">0</asp:ListItem>
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                    <asp:ListItem Value="6">6</asp:ListItem>
                                                    <asp:ListItem Value="7">7</asp:ListItem>
                                                    <asp:ListItem Value="8">8</asp:ListItem>
                                                    <asp:ListItem Value="9">9</asp:ListItem>
                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                    <asp:ListItem Value="11">11</asp:ListItem>
                                                </asp:DropDownList>&nbsp;<font class="b15">months</font><font class="r18">*</font>
                                                
                                                
                                            
                                            <%--Months at Address:&nbsp;<asp:DropDownList runat="server" ID="months_at_address">
                                                    <asp:ListItem Value="6">Under 6 Months</asp:ListItem>
                                                    <asp:ListItem Value="12">6 to 12 Months</asp:ListItem>
                                                    <asp:ListItem Selected="True" Value="18">Over 1 Year</asp:ListItem>
                                                    <asp:ListItem Value="36">Over 2 Years</asp:ListItem>
                                                    <asp:ListItem Value="60">5 Years or More</asp:ListItem>
                                                </asp:DropDownList><font class="r18">*</font>--%>
                                                
                                                
                                                <%--Months at Address:&nbsp;<asp:TextBox ID="months_at_address"
                                                    runat="server" Font-Size="Small" Width="100" TextMode="SingleLine"></asp:TextBox><font class="r18">*</font>
                                                --%>    
                                                    
                                                    </p>
                                        </td>
                                        <td>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 50px 5px 0px">
                                                Homeowner:&nbsp;<asp:DropDownList runat="server" ID="own_home">
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                </asp:DropDownList><font class="r18">*</font></p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="b16" style="text-align: center; margin: 5px 0px 5px 0px">
                                                4. Contact details?</p>
                                        </td>
                                        <td>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 0px 5px 0px">
                                                Email Address:&nbsp;<asp:TextBox ID="Email" runat="server"
                                                    Font-Size="Small" Width="100" TextMode="SingleLine"></asp:TextBox><font class="r18">*</font></p>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 8px 5px 0px">
                                                Alternate Email:&nbsp;<asp:TextBox ID="email_alternate"
                                                    runat="server" Font-Size="Small" Width="100" TextMode="SingleLine"></asp:TextBox></p>
                                        </td>
                                        <td>
                                        
                                        
                                        <p class="b16-plain" style="text-align: right; margin: 5px 40px 5px 0px">
                                                Cell/Best Phone #:&nbsp;<asp:TextBox ID="phone_cell1" runat="server"
                                                    Font-Size="Small" Width="20" MaxLength="3" TextMode="SingleLine"></asp:TextBox>
                                                &nbsp;<asp:TextBox ID="phone_cell2" runat="server" Font-Size="Small" Width="20" TextMode="SingleLine"
                                                    MaxLength="3"></asp:TextBox>
                                                &nbsp;<asp:TextBox ID="phone_cell3" runat="server" Font-Size="Small" Width="30" TextMode="SingleLine"
                                                    MaxLength="4"></asp:TextBox><font class="r18">*</font></p>
                                                    
                                                    
                                            <p class="b16-plain" style="text-align: right; margin: 5px 40px 5px 0px">
                                                Home/Alternate Phone #:&nbsp;<asp:TextBox ID="phone_home1" runat="server"
                                                    Font-Size="Small" Width="20" MaxLength="3" TextMode="SingleLine"></asp:TextBox>
                                                &nbsp;<asp:TextBox ID="phone_home2" runat="server" Font-Size="Small" Width="20" TextMode="SingleLine"
                                                    MaxLength="3"></asp:TextBox>
                                                &nbsp;<asp:TextBox ID="phone_home3" runat="server" Font-Size="Small" Width="30" TextMode="SingleLine"
                                                    MaxLength="4"></asp:TextBox><font class="r18">*</font></p>
                                                    
                                                    
                                            
                                            <%--<p style="text-align: right; margin-right: 50px">
                                                <font color="#1C4388">Best Time to Call:</font>&nbsp;<asp:DropDownList runat="server" ID="best_call_time">
                                                    <asp:ListItem Value="MORNING">Morning</asp:ListItem>
                                                    <asp:ListItem Value="AFTERNOON">Afternoon</asp:ListItem>
                                                    <asp:ListItem Value="EVENING">Evening</asp:ListItem>
                                                </asp:DropDownList>
                                                <font class="r18">*</font></p>--%>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #DCDCD5;">
                                        <td>
                                            <p class="b16" style="text-align: center; margin: 5px 0px 5px 0px">
                                                5. Your birthdate?</p>
                                        </td>
                                        <td>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 0px 5px 0px">
                                                Birthdate:&nbsp;<asp:DropDownList runat="server" ID="birth_dateM">
                                                    <asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
                                                    <asp:ListItem Value="01">Jan</asp:ListItem>
                                                    <asp:ListItem Value="02">Feb</asp:ListItem>
                                                    <asp:ListItem Value="03">Mar</asp:ListItem>
                                                    <asp:ListItem Value="04">Apr</asp:ListItem>
                                                    <asp:ListItem Value="05">May</asp:ListItem>
                                                    <asp:ListItem Value="06">Jun</asp:ListItem>
                                                    <asp:ListItem Value="07">Jul</asp:ListItem>
                                                    <asp:ListItem Value="08">Aug</asp:ListItem>
                                                    <asp:ListItem Value="09">Sept</asp:ListItem>
                                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                                    <asp:ListItem Value="11">Nov</asp:ListItem>
                                                    <asp:ListItem Value="12">Dec</asp:ListItem>
                                                </asp:DropDownList>
                                                &nbsp;<asp:DropDownList runat="server" ID="birth_dateD">
                                                    <asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
                                                    <asp:ListItem Value="01">01</asp:ListItem>
                                                    <asp:ListItem Value="02">02</asp:ListItem>
                                                    <asp:ListItem Value="03">03</asp:ListItem>
                                                    <asp:ListItem Value="04">04</asp:ListItem>
                                                    <asp:ListItem Value="05">05</asp:ListItem>
                                                    <asp:ListItem Value="06">06</asp:ListItem>
                                                    <asp:ListItem Value="07">07</asp:ListItem>
                                                    <asp:ListItem Value="08">08</asp:ListItem>
                                                    <asp:ListItem Value="09">09</asp:ListItem>
                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                    <asp:ListItem Value="11">11</asp:ListItem>
                                                    <asp:ListItem Value="12">12</asp:ListItem>
                                                    <asp:ListItem Value="13">13</asp:ListItem>
                                                    <asp:ListItem Value="14">14</asp:ListItem>
                                                    <asp:ListItem Value="15">15</asp:ListItem>
                                                    <asp:ListItem Value="16">16</asp:ListItem>
                                                    <asp:ListItem Value="17">17</asp:ListItem>
                                                    <asp:ListItem Value="18">18</asp:ListItem>
                                                    <asp:ListItem Value="19">19</asp:ListItem>
                                                    <asp:ListItem Value="20">20</asp:ListItem>
                                                    <asp:ListItem Value="21">21</asp:ListItem>
                                                    <asp:ListItem Value="22">22</asp:ListItem>
                                                    <asp:ListItem Value="23">23</asp:ListItem>
                                                    <asp:ListItem Value="24">24</asp:ListItem>
                                                    <asp:ListItem Value="25">25</asp:ListItem>
                                                    <asp:ListItem Value="26">26</asp:ListItem>
                                                    <asp:ListItem Value="27">27</asp:ListItem>
                                                    <asp:ListItem Value="28">28</asp:ListItem>
                                                    <asp:ListItem Value="29">29</asp:ListItem>
                                                    <asp:ListItem Value="30">30</asp:ListItem>
                                                    <asp:ListItem Value="31">31</asp:ListItem>
                                                </asp:DropDownList>
                                                &nbsp;<font class="b15">year</font>&nbsp;<asp:TextBox MaxLength="4" Width="30"
                                                    ID="birth_dateY" runat="server" Font-Size="Small" TextMode="SingleLine"></asp:TextBox><font class="r18">*</font>
                                            </p>
                                        </td>
                                        <td>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 50px 5px 0px">
                                                Are you Active or Ex Military:&nbsp;<asp:DropDownList
                                                    runat="server" ID="is_military">
                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                </asp:DropDownList><font class="r18">*</font>
                                            </p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="b16" style="text-align: center; margin: 5px 0px 5px 0px">
                                                6. Two References?</p>
                                        </td>
                                        <td>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 0px 5px 0px">
                                                1st Full Name:&nbsp;<asp:TextBox ID="ref_01_name_full"
                                                    runat="server" Font-Size="Small" Width="100" MaxLength="100" TextMode="SingleLine"></asp:TextBox><font class="r18">*</font></p>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 0px 5px 0px">
                                                1st Phone No:&nbsp;<asp:TextBox ID="ref_01_phone_home1"
                                                    runat="server" Font-Size="Small" Width="20" MaxLength="3" TextMode="SingleLine"></asp:TextBox>
                                                &nbsp;<asp:TextBox ID="ref_01_phone_home2" runat="server" Font-Size="Small" Width="20"
                                                    TextMode="SingleLine" MaxLength="3"></asp:TextBox>
                                                &nbsp;<asp:TextBox ID="ref_01_phone_home3" runat="server" Font-Size="Small" Width="30"
                                                    TextMode="SingleLine" MaxLength="4"></asp:TextBox><font class="r18">*</font></p>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 0px 5px 0px">
                                            
                                            1st Relationship:&nbsp;<asp:DropDownList
                                                    runat="server" ID="ref_01_relationship">
                                                    <asp:ListItem Value="Co-Worker">Co-Worker</asp:ListItem>
                                                    <asp:ListItem Value="Friend">Friend</asp:ListItem>
                                                    <asp:ListItem Selected="True" Value="Family Member">Family Member</asp:ListItem>
                                                </asp:DropDownList><font class="r18">*</font>
                                                
                                                
                                                <%--1st Relationship:&nbsp;<asp:TextBox ID="ref_01_relationship"
                                                    runat="server" Font-Size="Small" Width="100" MaxLength="100" TextMode="SingleLine"></asp:TextBox><font class="r18">*</font>
                                                --%>    
                                                    
                                                    </p>
                                        </td>
                                        <td>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 50px 5px 0px">
                                                2nd Full Name:&nbsp;<asp:TextBox ID="ref_02_name_full"
                                                    runat="server" Font-Size="Small" Width="100" MaxLength="100" TextMode="SingleLine"></asp:TextBox><font class="r18">*</font></p>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 50px 5px 0px">
                                                2nd Phone No:&nbsp;<asp:TextBox ID="ref_02_phone_home1"
                                                    runat="server" Font-Size="Small" Width="20" MaxLength="3" TextMode="SingleLine"></asp:TextBox>
                                                &nbsp;<asp:TextBox ID="ref_02_phone_home2" runat="server" Font-Size="Small" Width="20"
                                                    TextMode="SingleLine" MaxLength="3"></asp:TextBox>
                                                &nbsp;<asp:TextBox ID="ref_02_phone_home3" runat="server" Font-Size="Small" Width="30"
                                                    TextMode="SingleLine" MaxLength="4"></asp:TextBox><font class="r18">*</font></p>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 50px 5px 0px">
                                            
                                            2nd Relationship:&nbsp;<asp:DropDownList
                                                    runat="server" ID="ref_02_relationship">
                                                    <asp:ListItem Value="Co-Worker">Co-Worker</asp:ListItem>
                                                    <asp:ListItem Value="Friend">Friend</asp:ListItem>
                                                    <asp:ListItem Selected="True" Value="Family Member">Family Member</asp:ListItem>
                                                </asp:DropDownList><font class="r18">*</font>
                                            
                                                <%--2nd Relationship:&nbsp;<asp:TextBox ID="ref_02_relationship"
                                                    runat="server" Font-Size="Small" Width="100" MaxLength="100" TextMode="SingleLine"></asp:TextBox><font class="r18">*</font>
                                                --%>    
                                                    </p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" align="center" style="background-color: #1C4388;">
                                        <p class="w16" style="margin:5px 0px 5px 0px;" >
                                            Employment Information
                                            </p>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #DCDCD5;">
                                        <td>
                                            <p class="b16" style="text-align: center; margin: 5px 0px 5px 0px">
                                                7. Employment details?</p>
                                        </td>
                                        <td>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 0px 5px 0px">
                                                Employer Name:&nbsp;<asp:TextBox ID="employer_name"
                                                    runat="server" Font-Size="Small" Width="100" TextMode="SingleLine" MaxLength="35"></asp:TextBox><font class="r18">*</font></p>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 0px 5px 0px">
                                            
                                            Months Employed:&nbsp;<asp:DropDownList runat="server" ID="months_employed1">
                                                    <asp:ListItem Selected="True" Value="0">0</asp:ListItem>
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                    <asp:ListItem Value="6">6</asp:ListItem>
                                                    <asp:ListItem Value="7">7</asp:ListItem>
                                                    <asp:ListItem Value="8">8</asp:ListItem>
                                                    <asp:ListItem Value="9">9</asp:ListItem>
                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                </asp:DropDownList>&nbsp;<font class="b15">years</font>&nbsp;<asp:DropDownList runat="server" ID="months_employed2">
                                                    <asp:ListItem Selected="True" Value="0">0</asp:ListItem>
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                    <asp:ListItem Value="6">6</asp:ListItem>
                                                    <asp:ListItem Value="7">7</asp:ListItem>
                                                    <asp:ListItem Value="8">8</asp:ListItem>
                                                    <asp:ListItem Value="9">9</asp:ListItem>
                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                    <asp:ListItem Value="11">11</asp:ListItem>
                                                </asp:DropDownList>&nbsp;<font class="b15">months</font><font class="r18">*</font>
                                                
                                            <%--Months Employed:&nbsp;<asp:DropDownList runat="server" ID="months_employed">
                                                   <asp:ListItem Value="6">Under 6 Months</asp:ListItem>
                                                    <asp:ListItem Value="12">6 to 12 Months</asp:ListItem>
                                                    <asp:ListItem Selected="True" Value="18">Over 1 Year</asp:ListItem>
                                                    <asp:ListItem Value="36">Over 2 Years</asp:ListItem>
                                                    <asp:ListItem Value="60">5 Years or More</asp:ListItem>
                                                </asp:DropDownList><font class="r18">*</font>--%>
                                            
                                               <%-- Months Employed:&nbsp;<asp:TextBox ID="months_employed"
                                                    runat="server" Font-Size="Small" Width="100" TextMode="SingleLine" MaxLength="3"></asp:TextBox><font class="r18">*</font>
                                                --%>    
                                                    
                                                    </p>
                                        </td>
                                        <td>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 50px 5px 0px">
                                                Work Phone No:&nbsp;<asp:TextBox ID="phone_work1" runat="server"
                                                    Font-Size="Small" Width="20" MaxLength="3" TextMode="SingleLine"></asp:TextBox>
                                                &nbsp;<asp:TextBox ID="phone_work2" runat="server" Font-Size="Small" Width="20" TextMode="SingleLine"
                                                    MaxLength="3"></asp:TextBox>
                                                &nbsp;<asp:TextBox ID="phone_work3" runat="server" Font-Size="Small" Width="30" TextMode="SingleLine"
                                                    MaxLength="4"></asp:TextBox><font class="r18">*</font></p>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 55px 5px 0px">
                                                Work Phone Ext:&nbsp;<asp:TextBox ID="phone_work_ext"
                                                    runat="server" Font-Size="Small" Width="100" TextMode="SingleLine" MaxLength="5"></asp:TextBox></p>
                                                    
                                              <p class="r11" style="text-align: left; margin: 5px 30px 5px 50px">      
                                                    Note: Identical Work and Home/Alternate Phone numbers may decrease your approval.
                                              </p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="b16" style="text-align: center; margin: 5px 0px 5px 0px">
                                                 8. Income details? </p>
                                        </td>
                                        <td>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 0px 5px 0px">
                                                Type of Income:&nbsp;<asp:DropDownList runat="server"
                                                    ID="income_type" DataTextField="description" DataValueField="incometype">
                                                </asp:DropDownList><font class="r18">*</font></p>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 0px 5px 0px">
                                                Pay Frequency:&nbsp;<asp:DropDownList runat="server"
                                                    ID="pay_frequency" DataTextField="description" DataValueField="payfrequency">
                                                </asp:DropDownList><font class="r18">*</font></p>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 0px 5px 0px">
                                            
                                            
                                            Pay per Period:&nbsp;<font class="b18">$</font>&nbsp;<asp:DropDownList runat="server" ID="pay_per_period1">
                                                    <asp:ListItem Selected="True" Value="0">0</asp:ListItem>
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                    <asp:ListItem Value="6">6</asp:ListItem>
                                                    <asp:ListItem Value="7">7</asp:ListItem>
                                                    <asp:ListItem Value="8">8</asp:ListItem>
                                                    <asp:ListItem Value="9">9</asp:ListItem>
                                                </asp:DropDownList>
                                                
                                                <asp:DropDownList runat="server" ID="pay_per_period2">
                                                    <asp:ListItem Selected="True" Value="0">0</asp:ListItem>
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                    <asp:ListItem Value="6">6</asp:ListItem>
                                                    <asp:ListItem Value="7">7</asp:ListItem>
                                                    <asp:ListItem Value="8">8</asp:ListItem>
                                                    <asp:ListItem Value="9">9</asp:ListItem>
                                                </asp:DropDownList>
                                                
                                                <asp:DropDownList runat="server" ID="pay_per_period3">
                                                    <asp:ListItem Selected="True" Value="0">0</asp:ListItem>
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                    <asp:ListItem Value="6">6</asp:ListItem>
                                                    <asp:ListItem Value="7">7</asp:ListItem>
                                                    <asp:ListItem Value="8">8</asp:ListItem>
                                                    <asp:ListItem Value="9">9</asp:ListItem>
                                                </asp:DropDownList>
                                                
                                                <asp:DropDownList runat="server" ID="pay_per_period4">
                                                    <asp:ListItem Selected="True" Value="0">0</asp:ListItem>
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                    <asp:ListItem Value="6">6</asp:ListItem>
                                                    <asp:ListItem Value="7">7</asp:ListItem>
                                                    <asp:ListItem Value="8">8</asp:ListItem>
                                                    <asp:ListItem Value="9">9</asp:ListItem>
                                                </asp:DropDownList><font class="b18">.00</font><font class="r18">*</font>
                                            
                                            
                                                <%--Pay per Period:&nbsp;<asp:DropDownList runat="server" ID="pay_per_period">
                                                    <asp:ListItem Value="249">Under $250</asp:ListItem>
                                                    <asp:ListItem Value="499">$250 to $500</asp:ListItem>
                                                    <asp:ListItem Selected="True" Value="799">$500 to $800</asp:ListItem>
                                                    <asp:ListItem Value="999">Over $800</asp:ListItem>
                                                </asp:DropDownList><font class="r18">*</font>--%>
                                                
                                                <%--Pay per Period:&nbsp;<asp:TextBox ID="pay_per_period"
                                                    runat="server" Font-Size="Small" Width="100" TextMode="SingleLine" MaxLength="6"></asp:TextBox><font class="r18">*</font>
                                                --%>    
                                                    </p>
                                            
                                            
                                            <p class="b16-plain" style="text-align: right; margin: 5px 0px 5px 0px">
                                            
                                            <%--Monthly Income:&nbsp;<asp:DropDownList runat="server" ID="income_monthly">
                                                    <asp:ListItem Value="999">Under $1000</asp:ListItem>
                                                    <asp:ListItem Selected="True" Value="1999">$1000 to $2000</asp:ListItem>
                                                    <asp:ListItem Value="2999">$2000 to $3000</asp:ListItem>
                                                    <asp:ListItem Value="3999">Over $3000</asp:ListItem>
                                                </asp:DropDownList><font class="r18">*</font>--%>
                                            
                                                <%--Monthly Income:&nbsp;<asp:TextBox Visible="false" ID="income_monthly"
                                                    runat="server" Font-Size="Small" Width="100" TextMode="SingleLine" MaxLength="6"></asp:TextBox><font class="r18">*</font>
                                                 --%>   
                                                    
                                                    
                                                    </p>
                                        </td>
                                        <td valign="middle">
                                            <p class="b16-plain" style="text-align: right; margin: 5px 50px 5px 0px">
                                                Direct Deposit:&nbsp;<asp:DropDownList runat="server"
                                                    ID="direct_deposit">
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                </asp:DropDownList><font class="r18">*</font>
                                            </p>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 5px 5px 0px">
                                                Next Payday:&nbsp;<asp:DropDownList runat="server" ID="pay_day1M">
                                                    <asp:ListItem Value="01">Jan</asp:ListItem>
                                                    <asp:ListItem Value="02">Feb</asp:ListItem>
                                                    <asp:ListItem Value="03">Mar</asp:ListItem>
                                                    <asp:ListItem Value="04">Apr</asp:ListItem>
                                                    <asp:ListItem Value="05">May</asp:ListItem>
                                                    <asp:ListItem Value="06">Jun</asp:ListItem>
                                                    <asp:ListItem Value="07">Jul</asp:ListItem>
                                                    <asp:ListItem Value="08">Aug</asp:ListItem>
                                                    <asp:ListItem Value="09">Sept</asp:ListItem>
                                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                                    <asp:ListItem Value="11">Nov</asp:ListItem>
                                                    <asp:ListItem Value="12">Dec</asp:ListItem>
                                                </asp:DropDownList>
                                                &nbsp;<asp:DropDownList runat="server" ID="pay_day1D">
                                                    <asp:ListItem Value="01">01</asp:ListItem>
                                                    <asp:ListItem Value="02">02</asp:ListItem>
                                                    <asp:ListItem Value="03">03</asp:ListItem>
                                                    <asp:ListItem Value="04">04</asp:ListItem>
                                                    <asp:ListItem Value="05">05</asp:ListItem>
                                                    <asp:ListItem Value="06">06</asp:ListItem>
                                                    <asp:ListItem Value="07">07</asp:ListItem>
                                                    <asp:ListItem Value="08">08</asp:ListItem>
                                                    <asp:ListItem Value="09">09</asp:ListItem>
                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                    <asp:ListItem Value="11">11</asp:ListItem>
                                                    <asp:ListItem Value="12">12</asp:ListItem>
                                                    <asp:ListItem Value="13">13</asp:ListItem>
                                                    <asp:ListItem Value="14">14</asp:ListItem>
                                                    <asp:ListItem Value="15">15</asp:ListItem>
                                                    <asp:ListItem Value="16">16</asp:ListItem>
                                                    <asp:ListItem Value="17">17</asp:ListItem>
                                                    <asp:ListItem Value="18">18</asp:ListItem>
                                                    <asp:ListItem Value="19">19</asp:ListItem>
                                                    <asp:ListItem Value="20">20</asp:ListItem>
                                                    <asp:ListItem Value="21">21</asp:ListItem>
                                                    <asp:ListItem Value="22">22</asp:ListItem>
                                                    <asp:ListItem Value="23">23</asp:ListItem>
                                                    <asp:ListItem Value="24">24</asp:ListItem>
                                                    <asp:ListItem Value="25">25</asp:ListItem>
                                                    <asp:ListItem Value="26">26</asp:ListItem>
                                                    <asp:ListItem Value="27">27</asp:ListItem>
                                                    <asp:ListItem Value="28">28</asp:ListItem>
                                                    <asp:ListItem Value="29">29</asp:ListItem>
                                                    <asp:ListItem Value="30">30</asp:ListItem>
                                                    <asp:ListItem Value="31">31</asp:ListItem>
                                                </asp:DropDownList>
                                                &nbsp;year&nbsp;<asp:TextBox MaxLength="4" Width="30"
                                                    ID="pay_day1Y" runat="server" Font-Size="Small" TextMode="SingleLine"></asp:TextBox><font class="r18">*</font>
                                            </p>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 5px 5px 0px">
                                                2nd Payday:&nbsp;<asp:DropDownList runat="server" ID="pay_day2M">
                                                    <asp:ListItem Value="01">Jan</asp:ListItem>
                                                    <asp:ListItem Value="02">Feb</asp:ListItem>
                                                    <asp:ListItem Value="03">Mar</asp:ListItem>
                                                    <asp:ListItem Value="04">Apr</asp:ListItem>
                                                    <asp:ListItem Value="05">May</asp:ListItem>
                                                    <asp:ListItem Value="06">Jun</asp:ListItem>
                                                    <asp:ListItem Value="07">Jul</asp:ListItem>
                                                    <asp:ListItem Value="08">Aug</asp:ListItem>
                                                    <asp:ListItem Value="09">Sept</asp:ListItem>
                                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                                    <asp:ListItem Value="11">Nov</asp:ListItem>
                                                    <asp:ListItem Value="12">Dec</asp:ListItem>
                                                </asp:DropDownList>
                                                &nbsp;<asp:DropDownList runat="server" ID="pay_day2D">
                                                    <asp:ListItem Value="01">01</asp:ListItem>
                                                    <asp:ListItem Value="02">02</asp:ListItem>
                                                    <asp:ListItem Value="03">03</asp:ListItem>
                                                    <asp:ListItem Value="04">04</asp:ListItem>
                                                    <asp:ListItem Value="05">05</asp:ListItem>
                                                    <asp:ListItem Value="06">06</asp:ListItem>
                                                    <asp:ListItem Value="07">07</asp:ListItem>
                                                    <asp:ListItem Value="08">08</asp:ListItem>
                                                    <asp:ListItem Value="09">09</asp:ListItem>
                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                    <asp:ListItem Value="11">11</asp:ListItem>
                                                    <asp:ListItem Value="12">12</asp:ListItem>
                                                    <asp:ListItem Value="13">13</asp:ListItem>
                                                    <asp:ListItem Value="14">14</asp:ListItem>
                                                    <asp:ListItem Value="15">15</asp:ListItem>
                                                    <asp:ListItem Value="16">16</asp:ListItem>
                                                    <asp:ListItem Value="17">17</asp:ListItem>
                                                    <asp:ListItem Value="18">18</asp:ListItem>
                                                    <asp:ListItem Value="19">19</asp:ListItem>
                                                    <asp:ListItem Value="20">20</asp:ListItem>
                                                    <asp:ListItem Value="21">21</asp:ListItem>
                                                    <asp:ListItem Value="22">22</asp:ListItem>
                                                    <asp:ListItem Value="23">23</asp:ListItem>
                                                    <asp:ListItem Value="24">24</asp:ListItem>
                                                    <asp:ListItem Value="25">25</asp:ListItem>
                                                    <asp:ListItem Value="26">26</asp:ListItem>
                                                    <asp:ListItem Value="27">27</asp:ListItem>
                                                    <asp:ListItem Value="28">28</asp:ListItem>
                                                    <asp:ListItem Value="29">29</asp:ListItem>
                                                    <asp:ListItem Value="30">30</asp:ListItem>
                                                    <asp:ListItem Value="31">31</asp:ListItem>
                                                </asp:DropDownList>
                                                &nbsp;year&nbsp;<asp:TextBox MaxLength="4" Width="30"
                                                    ID="pay_day2Y" runat="server" Font-Size="Small" TextMode="SingleLine"></asp:TextBox><font class="r18">*</font>
                                            </p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" align="center" style="background-color: #1C4388;">
                                        <p class="w16" style="margin:5px 0px 5px 0px;" >
                                            Banking Information
                                            </p>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #DCDCD5;">
                                        <td>
                                            <p class="b16" style="text-align: center; margin: 5px 0px 5px 0px">
                                                9. Bank details?</p>
                                        </td>
                                        <td>

                                            <p style="text-align: right; margin: 10px 0px 10px 0px">
                                                <img src="images/check.jpg" alt="cash advances payday loans" /></p>
                                        </td>
                                        <td valign="top">
                                            <p class="b16-plain" style="text-align: right; margin: 5px 50px 5px 0px">
                                                Bank Name:&nbsp;<asp:TextBox ID="bank_name" runat="server"
                                                    Font-Size="Small" Width="100" TextMode="SingleLine" MaxLength="30"></asp:TextBox><font class="r18">*</font></p>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 50px 5px 0px">
                                            
                                            Months at Bank:&nbsp;<asp:DropDownList runat="server" ID="months_at_bank1">
                                                    <asp:ListItem Selected="True" Value="0">0</asp:ListItem>
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                    <asp:ListItem Value="6">6</asp:ListItem>
                                                    <asp:ListItem Value="7">7</asp:ListItem>
                                                    <asp:ListItem Value="8">8</asp:ListItem>
                                                    <asp:ListItem Value="9">9</asp:ListItem>
                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                </asp:DropDownList>&nbsp;<font class="b15">years</font>&nbsp;<asp:DropDownList runat="server" ID="months_at_bank2">
                                                    <asp:ListItem Selected="True" Value="0">0</asp:ListItem>
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                    <asp:ListItem Value="6">6</asp:ListItem>
                                                    <asp:ListItem Value="7">7</asp:ListItem>
                                                    <asp:ListItem Value="8">8</asp:ListItem>
                                                    <asp:ListItem Value="9">9</asp:ListItem>
                                                    <asp:ListItem Value="10">10</asp:ListItem>
                                                    <asp:ListItem Value="11">11</asp:ListItem>
                                                </asp:DropDownList>&nbsp;<font class="b15">months</font><font class="r18">*</font>
                                                
                                                
                                            <%--Months at Bank:&nbsp;<asp:DropDownList runat="server" ID="months_at_bank">
                                                    <asp:ListItem Value="6">Under 6 Months</asp:ListItem>
                                                    <asp:ListItem Value="12">6 to 12 Months</asp:ListItem>
                                                    <asp:ListItem Selected="True" Value="18">Over 1 Year</asp:ListItem>
                                                    <asp:ListItem Value="36">Over 2 Years</asp:ListItem>
                                                    <asp:ListItem Value="60">5 Years or More</asp:ListItem>
                                                </asp:DropDownList><font class="r18">*</font>--%>
                                            
                                               <%-- Months at Bank:&nbsp;<asp:TextBox ID="months_at_bank"
                                                    runat="server" Font-Size="Small" Width="100" TextMode="SingleLine" MaxLength="3"></asp:TextBox><font class="r18">*</font>
                                               --%>     
                                                    
                                                    </p>
                                                    
                                                    
                                            <p class="b16-plain" style="text-align: right; margin: 5px 50px 5px 0px">
                                                Account Type:&nbsp;<asp:DropDownList runat="server"
                                                    ID="bank_account_type" DataTextField="description" DataValueField="accounttype">
                                                </asp:DropDownList><font class="r18">*</font></p>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 50px 5px 0px">
                                                Bank ABA No:&nbsp;<asp:TextBox ID="bank_aba" runat="server"
                                                    Font-Size="Small" Width="100" TextMode="SingleLine" MaxLength="9"></asp:TextBox><font class="r18">*</font></p>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 50px 5px 0px">
                                                Account No:&nbsp;<asp:TextBox ID="bank_account" runat="server"
                                                    Font-Size="Small" Width="100" TextMode="SingleLine" MaxLength="21"></asp:TextBox><font class="r18">*</font></p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="b16" style="text-align: center; margin: 5px 0px 5px 0px">
                                                10. Identification details?</p>
                                        </td>
                                        <td valign="middle">
                                            <p class="b16-plain" style="text-align: right; margin: 5px 0px 5px 0px">
                                                Social Security No:&nbsp;<asp:TextBox ID="social_security"
                                                    runat="server" Font-Size="Small" Width="100" TextMode="SingleLine" MaxLength="9"></asp:TextBox><font class="r18">*</font></p>
                                            <%--<p runat="server" visible="false" id="show_cali_agree" style="text-align: left; width:300px; ">
                                                <font color="#1C4388"  size="-2">By entering your SSN in this field, you consent to allow us to share your SSN with outside service providers for evaluation of your application and provision of loan services.</font>&nbsp;<asp:DropDownList runat="server" ID="cali_agree">
                                                    <asp:ListItem Value="AGREE">Agree</asp:ListItem>
                                                    <asp:ListItem Value="DISAGREE">Disagree</asp:ListItem>
                                                </asp:DropDownList>
                                                <font class="r18">*</font></p>--%>
                                        </td>
                                        <td>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 50px 5px 0px">
                                                Drivers License No:&nbsp;<asp:TextBox ID="drivers_license"
                                                    runat="server" Font-Size="Small" Width="100" TextMode="SingleLine" MaxLength="25"></asp:TextBox><font class="r18">*</font></p>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 50px 5px 0px">
                                                Drivers State:&nbsp;<asp:DropDownList runat="server"
                                                    ID="drivers_license_st" DataTextField="name" DataValueField="abbreviation">
                                                </asp:DropDownList><font class="r18">*</font></p>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #DCDCD5;">
                                        <td>
                                            <p class="b16" style="text-align: center; margin: 5px 0px 5px 0px;">
                                                11. VIP Cash details?</p>
                                        </td>
                                        <td>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 0px 5px 0px;">
                                                Loan Amount:&nbsp;<asp:DropDownList runat="server" ID="requested_amount" DataTextField="description"
                                                    DataValueField="requestedamount">
                                                </asp:DropDownList><font class="r18">*</font></p>
                                        </td>
                                        <td>
                                            <p class="b16-plain" style="text-align: right; margin: 5px 50px 5px 0px;">
                                                I Agree:&nbsp;<asp:DropDownList runat="server" ID="accepted_terms">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                </asp:DropDownList><font class="r18">*</font>
                                            </p>
                                            <p class="black9-plain" style="text-align: left; margin: 0px 10px 10px 30px;">
                                                Do you agree to receive additional offers, our Terms and Conditions and Privacy Policy?</p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p class="b16" style="text-align: center; margin: 10px 0px 10px 0px;">
                                                12. Send VIP Application!</p>
                                        </td>
                                        <td colspan="2" valign="middle" align="right">
                                            <p class="b16" style="text-align: center; margin: 0px 0px 0px 0px;">
                                                <asp:Button ID="applynow" runat="server" OnClick="applynow_Click" ForeColor="#1C4388"
                                                    Font-Bold="true" Font-Size="Larger" Text="Apply Now" CssClass="buttonNormal"
                                                    ToolTip="Press for VIP Cash Fast" /></p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" align="center" style="background-color: #1C4388;">
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <p class="black9-plain" style="text-align: left; width: 450px; margin-left: 20px;">
                                                <font class="r18">*</font> By Submitting “Yes”, you certify that you were provided
                                                a copy of our Terms and Conditions, Privacy Policy and you agree to be bound by
                                                the terms as set forth therein.
                                                <br />
                                                <a href="Terms.Conditions.aspx" onclick="OpenUrl(this.href,'TermsandConditions');return false;">
                                                    Terms and Conditions</a>
                                                <br />
                                                <a href="Privacy.Policy.aspx" onclick="OpenUrl(this.href,'PrivacyPolicy');return false;">
                                                    Privacy Policy</a>
                                                <br />
                                            </p>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
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

    <%--AdWords Tracking End--%>
    
    <%--Google Code for Short Application Conversion Page--%>

    <script type="text/javascript">
<!--
        var google_conversion_id = 1024728645;
        var google_conversion_language = "en";
        var google_conversion_format = "3";
        var google_conversion_color = "ffffff";
        var google_conversion_label = "J_uDCNWLywEQxbzQ6AM";
        var google_conversion_value = 0;
        if (1) {
            google_conversion_value = 1;
        } 
//-->
    </script>

    <script type="text/javascript" src="https://www.googleadservices.com/pagead/conversion.js">
    </script>

    <noscript>
        <div style="display: inline;">
            <img height="1" width="1" style="border-style: none;" alt="" src="https://www.googleadservices.com/pagead/conversion/1024728645/?value=1&amp;label=J_uDCNWLywEQxbzQ6AM&amp;guid=ON&amp;script=0" />
        </div>
    </noscript>
    <%--End Google Code for Short Application Conversion Page--%>
    
</body>
</html>
