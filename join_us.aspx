<%@ Page Title="Join Us" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="join_us.aspx.cs" Inherits="join_us" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1"> 
<script src="js/redirect.js" type="text/javascript"></script>
    <script>

        //$(function () {

        //    $("body").css("background-image", "url('img/s3.jpg')");
        //    $("body").css("background-attachment", "fixed");
        //    $("body").css("background-repeat", "no-repeat");
        //    $("body").css("background-repeat", "no-repeat");
        //    $("#header_main").css("background", "rgba(255,255,255,0.9)");
            

        //});
        </script>
     <%--<div id="middle_main">
        <div id="join_us_upper">
          <div class="join_us_upper_cont">
              <div class="join_us_upper_heading">
               <h1>Do Help Make World</h1><br /> 
                 <h1> Better</h1> 


              </div>

          </div>
       </div>
   </div>

   --%>

<div id="lower_middle_main">
    	<div id="lower_middle_cont">
            
        	<div id="div_join_us">
           		 <h2>Join us</h2>
                 <h4>Create your account</h4>
                 <div class="div_line">
                 </div>
                 <div class="div_join_us_box">
                 	<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                               
                    	<ul>
                        	<li><label>First Name</label></li>
                            <li style="float:right"><input type="text" required="required" autofocus runat="server" id="txtFname"/> </li>
                        	
                        </ul>
                        <ul>
                        	<li><label>Last Name</label></li>
                            <li style="float:right"><input type="text" runat="server" id="txtLname"  required="required" />  </li>
                        	
                        </ul>
                      <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>     <!-- Update Panel Starts  here for country and cities  -->
                        <ul>
                        	<li><label>Country</label></li>
                            <li style="float:right">
                               
                                <asp:DropDownList ID="ListCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ListCountry_SelectedIndexChanged"></asp:DropDownList>
                                
                                
                        	
                        </ul>
                        <ul>
                        	<li><label>City</label></li>
                            <li style="float:right"><%--<select  runat="server" id="sltCity" ><option value="California" >California</option></select>--%>
                                <asp:DropDownList ID="StateLoad" runat="server"></asp:DropDownList>
                               
                            </li>
                        	
                        </ul>
                                          </ContentTemplate></asp:UpdatePanel>      <!-- Update Panel ends here for country and cities  -->
                        <ul>
                        	<li><label>Email Address</label></li>
                            <li style="float:right"><input required="required" runat="server" id="txtEmail"/> </li>
                        	
                        </ul>
                        <ul>
                        	<li><label>Password</label></li>
                            <li style="float:right"><input type="password" required="required" runat="server" id="txtPassword" /> </li>
                        	
                        </ul>
                        <ul>
                        	<li><label>Retype Password</label></li>
                            <li style="float:right"><input type="password"  required="required" id="cnfPasswd" runat="server"/> </li>
                            <li><label runat="server" id="msg" style="color:red;"><asp:CompareValidator runat="server" ControlToCompare="txtPassword" ControlToValidate="cnfPasswd" ForeColor="Red">Password not matched</asp:CompareValidator></label></li>
                        	
                        </ul>
                        <ul >
                        	<li><label>User type</label></li>
                            <li style="float: right; padding:10px">
                            	<div style="float:left; margin-right:30px">
                            	<input style=" float:left; width:20px" name="user" value="Volunteer" runat="server" id="rdoVolunteer" type="radio"/>Voulnteer 
                                </div>
                                <div style="float:left">
                                <input style=" float:left; width:20px" name="user" value="Blogger" runat="server" id="rdoBlogger"  type="radio"/>Blogger
                                </div>
                           	</li> 
                        </ul>
                        <ul>
                            <li></li>
                            <li><br /></li>
                        	<li>  <asp:Button ID="bntJoinMe" CssClass="asp_buttons" runat="server" Text="Join Us" Width="100px"  Height="30px" OnClick="bntJoinMe_Click" /> </li>
                            <li><input  type="reset" class="asp_buttons" style="width:100px;height:30px" /> </li>
                            <li><a href="sign_in.aspx"><h5>or  already register sign in here</h5> </a></li>
                        </ul>                
                 	
                 </div>	
                 
               

               
               
                  <div class="div_about_user_cont">
                       
                  	 <div class="div_about_user_box">
                            <a href="http://www.google.com?search=Children hospital At Philadelphia">
                           
                           <img src="img/Emma_April17_WEB.jpg" />
                         
                           <h5>Read more...</h5></a>
                 	 </div>
                     
                   </div>
                 </div>
			</div>
                
       
   	</div>
   
    </asp:Content>