<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="Admin_AdminLogin" %>
<!DOCTYPE html >
<html xmlns="http://www.w3.org/1999/xhtml">

<head>


    <link href="css/Admin_login_form.css" rel="stylesheet" type="text/css"/>
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="Scripts/AdminLogin.js"></script>
    <link rel="shortcut icon" type="image/x-icon" href="../img/fevicon.PNG"/>


<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Welcome Admin</title>


</head>

<body>
	<!-- Main Container Start -->
    <form id="form1" runat="server">
    <div id="main-container">
    	<!-- Login Outer Start -->
    	<div id="login-outer">
            <div id="login-inner">
            	<div id="header">
                	<h2> Admin  Login</h2>
                </div>
                <!-- Middle Start -->
                <div id="middle">
                		<div class="div-row"></div>
                    	<div class="div-row">
                        	<div class="div-icon"><img src="Resources/Images/webpage_images/user.png" /></div>
                            <div class="div-text"><input class="txtBox" type="text" placeholder="username"  id="txtadmin_email_id" runat="server" /></div>
                        </div>
                    	<div class="div-row"></div>
                    	<div class="div-row">
                       		<div class="div-icon"><img src="Resources/Images/webpage_images/password.png" /></div>
                            <div class="div-text"><input class="txtBox" type="password" placeholder="password"  id="txtpassword" runat="server"  /></div>
                        </div>
                    	<div class="div-row mg-top20">
                        	<div class="div-btn">
                           <%-- <button class="btn" type="button" ID="btnLogin" runat="server" OnClick="btnLogin_Click">LOGIN</button>--%>
                            <asp:Button ID="Button1" runat="server" OnClick="btnLogin_Click" Text="LogIn"   CssClass="btn"/>
                                 </div>
                        	<div class="div-btn">
                            <button class="btn" type="button" >CANCEL</button>
                            </div>
                        </div>
                    	<%--<div class="div-row">
                        	<div class="div-link">
                            	<a href="#" id="forgot-link">Forgot Password?</a>
                            </div>
                        </div>--%>
			   </div>
                <!-- Middle Ends -->                
                <div id="footer">
                </div>
            </div>
        </div>
       	<!-- Login Outer Ends -->
    </div>
    <!-- Main Container Ends -->
    
    
    <!-- Forgot Pop-up Starts -->
    <div id="popup-container">
    	<div id="popup-inner">
        	<div id="top-bar">
	            <div id="forgot-label">Forgot Password ?</div>
            	<div id="popup-cross"><img src="Resources/Images/webpage_images/cross.png" /></div>
        	</div>
			 <!-- Forgot Pop-up Middle Starts -->
           <div id="popup-middle">
           		<div class="div-row">
                	<h3 class="mg-left10">Please enter code and reset your password...</h3>
                </div>
           		<div class="div-row mg-top10">
                	<div class="div-text mg-left100"><input class="popup-txtBox" type="text" placeholder="Code" /></div>
                </div>
           		<div class="div-row mg-top10">
                	<div class="div-text mg-left100"><input class="popup-txtBox" type="text" placeholder="New Password" /></div>
                </div>
           		<div class="div-row mg-top10">
                	<div class="div-text mg-left100"><input class="popup-txtBox" type="text" placeholder="Confirm Password" /></div>
                </div>
                <div class="div-row mg-top20">
                  	<div class="div-btn"><button class="btn" type="button" >UPDATE</button></div>
                    <div class="div-btn">
                   	    <button id="btnCancel" class="btn" type="button" >CANCEL</button></div>
            	</div>
           </div>
			<!-- Forgot Pop-up Middle Starts -->

		</div>
    </div>
    <!-- Forgot Pop-up Ends -->
        </form>

     <!-- google analytics --> 


    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-44794289-1', 'venturepact.com');
        ga('send', 'pageview');

</script>



      <!-- user snap  -->

    <script type="text/javascript">
        var _usersnapconfig = {
            apiKey: 'cd46033a-4057-4739-bbed-6aa53247b9ab',
            valign: 'bottom',
            halign: 'right',
            tools: ["pen", "highlight", "note"],
            lang: 'en',
            commentBox: true,
            emailBox: true
        };
        (function () {
            var s = document.createElement('script');
            s.type = 'text/javascript';
            s.async = true;
            s.src = '//api.usersnap.com/usersnap.js';
            var x = document.getElementsByTagName('head')[0];
            x.appendChild(s);
        })();
</script>


</body>
</html>
