<%@ Page Title="Forget Password" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="forget_password.aspx.cs" Inherits="forget_password" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
<script src="js/redirect.js" type="text/javascript"></script>
<div id="lower_middle_main">
    	<div id="lower_middle_cont">
        	<div id="div_Sign_in">
           		 <h2>Forget Password?</h2>
                 <h4>Recover your password</h4>
                 <div class="div_line">
                 </div>
                
                 <div class="div_Sign_in_box" style="width:450px;">
                    
               
                    <div id="forget_password">
                        <ul>
                        	<li><label>E-mail Address</label></li>
                            <li style="float:right"><input type="text" required="required" autofocus runat="server" id="txtemail" style="width:270px"/> <br/> <br/><asp:Label ID="lblMessage" runat="server" Text="" ></asp:Label></li>
                        	
                        </ul>
                        <ul>
                          
                        	<li><asp:Button ID="btnSendPassword" runat="server" Text="OK" OnClick="btnSendPassword_Click" CssClass="asp_buttons" Width="100px" Height="30px" /> <li>
                           
                        </ul> 
                    </div>
                 	
                </div>  
                  	
                
               
                	
                <div style="height:100px;width:100%;">

                </div>
                 <div class="div_line_2">
                 </div>
                 <h4 style="color:#262466"> You can connect with us using</h4>
                 	<ul>
                    	<a href="join_us.aspx">
                    	<li >  Volunteer account  and participate in our event</li>
                        </a>
                      	<a href="join_us.aspx">
                        <li>  Register user and write blog's </li>
                        </a>
                        <a href="#">
                        <li>  Subscribe your email and update with all activities </li>
                        </a>
                         <a href="donate.aspx">
                        <li>  You can help children to make  Donation </li>
                        </a>
                     </ul>
                 
            </div>
        </div>
   	</div>
    </asp:content>
 
    