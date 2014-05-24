<%@ Page Language="C#" AutoEventWireup="true" CodeFile="contactUs.aspx.cs" Inherits="HopeInTomorrow_contactUs" MasterPageFile="~/UserMasterPage.master" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">  
<script src="js/redirect.js" type="text/javascript"></script>
    <style>
        .btn_donate_join:hover {
            color:#244b73;
        }
    </style>

    <div id="lower_middle_main">
    	<div id="lower_middle_cont" style="text-align:left">
            <div id="div_wrapper">
    	<div id="div_wrapper_inner">

    <div id="div_form">
    <div id="div_header">
     Contact us
        <br />
    </div>
    <div id="div_regular_content">
        
   For more information about Hope In Tomorrow, for questions, or to join our team, please contact us below and one of our team members will respond to your inquiry as soon as possible. 
     
            </div>
     <div id="div_info_conatiner">

     <div id="div_content_left">
     First Name <br/> 
     <input type="text" class="text" runat="server" id="sugName" required="required"/>
     <br /><br />
     Last Name <br/> 
     <input type="text" class="text" runat="server" id="suglName"  /> 
     </div>
     <div id="div_content_right">
     EMAIL <br/>
         
     <input type="text"  class="text" runat="server" id="txtemail" required="required" />
     </div>
     </div>
     <br />
     <br />
     <div id="div_container">
     <br />
         <br /><br /> 
     Message <br />
	<textarea id="comments" cols="64" rows="8" placeholder="Enter your message here...." required="required" runat="server"></textarea>
	</div>
    <div id="div_button">
       
        <asp:Button runat ="server" class="btn_donate_join"  Text="Submit" OnClick="send_feedBack" />
        
    </div>
    </div>
    <div id="div_info">
    <div id="div_1">
    <h4 style="line-height:5px;color:#900;">EMAIL</h4> <br />
     hopeintomorrowfoundation@gmail.com
    </div>
   <br/> <br/><br/>

<div id="div_4">
    <h4 style="line-height:5px;color:#900;">ADDRESS</h4> <br />
    3720 Spruce Street <br/>
    MB 316 <br/>
    Philadelphia <br/>
    PA 19104 <br/>
    
    
    </div>
        

    </div>
            </div>
                </div>
            </div>
        </div>
   
</asp:Content>