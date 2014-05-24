<%@ Page Title="Sign In" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="sign_in.aspx.cs" Inherits="sign_in"  %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1" ClientIDMode="Static">
<script src="js/redirect.js" type="text/javascript"></script>
    <script src="js/jquery-1.10.2.js"></script>
    <script src="js/facebook_login.js"></script>
    <div id="fb-root"></div> 
     
        
<div id="lower_middle_main">
    	<div id="lower_middle_cont">
        	<div id="div_Sign_in">
           		 <h2>Sign In</h2>
                 <h4>Sign In to your Account</h4>
                 <div class="div_line">
                 </div>
                
                
                 <div class="div_Sign_in_box">
                    <div id="sign_in">
                 	
                    	<ul>
                        	<li><label>E-mail Address</label></li>
                            <li style="float:right"><input type="text" required="required" autofocus id="txtEmail" runat="server"/> </li>
                        	
                        </ul>
                        <ul>
                        	<li><label>Password</label></li>
                            <li style="float:right"><input type="password" required="required" id="txtPassword" runat="server"/>  
                                <br/>
                                <asp:Label ID="lblErrorMessage" runat="server" style="color:rgb(255, 0, 0);"></asp:Label>
                            </li>
                        	
                        </ul>
                        <ul>
                        	<li><asp:Button id="sign_in_btn" runat="server" OnClick="sign_in_btn_ServerClick" CssClass="asp_buttons" Width="100px"  Height="30px"  Text="Sign In"></asp:Button> 
                               <li>
                                     
                            <li><a href="join_us.aspx"><h5> or you can join us now</h5> </a><li>
                        </ul>                 
                 	</div>
                      <div class="social_login_div">
                             <div autologoutlink="true" scope="email,user_checkins"  class="fb_g_btn" id="facebooksignup" onclick="login()">Sign Up With Facebook</div>
                             <div class="fb_g_btn" id="googlesignup">Sign Up With Google+</div>
                         
                          
                          
                      </div>
                    
        
                </div> 
               
                   

                
               
                	<a href="forget_password.aspx">
                        <h6 >Forget Password?</h6>

                	</a>
                
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
    <script src="https://apis.google.com/js/client.js"></script>
  <%--  <script src="https://apis.google.com/js/plusone.js"></script
    <script src="https://apis.google.com/js/client:plusone.js"></script>--%>
    <script src="js/google_login.js"></script>
      <script src="http://connect.facebook.net/en_US/all.js" type="text/javascript"></script>
   
    </asp:content>
 
    