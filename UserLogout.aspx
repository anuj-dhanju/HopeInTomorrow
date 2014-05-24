<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserLogout.aspx.cs" Inherits="UserLogout" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="js/jquery-1.10.2.js"></script>
    
    
     <script src="https://apis.google.com/js/client.js"></script>
      <script src="http://connect.facebook.net/en_US/all.js" type="text/javascript"></script>
    
   <script>
       
        
            
       
            (function (d) {
                var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
                if (d.getElementById(id)) { return; }
                js = d.createElement('script'); js.id = id; js.async = true;
                js.src = "//connect.facebook.net/en_US/all.js";
                ref.parentNode.insertBefore(js, ref);
            }(document));
            

            // Init the SDK upon load
            var fbl;
            window.fbAsyncInit = function () {
                fbl = FB.init({
                    appId: '411047675666918', // App ID  214812398681584           421695167935164
                    channelUrl: '//' + window.location.hostname + '/channel', // Path to your Channel File
                    status: true, // check login status
                    cookie: true, // enable cookies to allow the server to access the session
                    xfbml: true  // parse XFBML
                   
                    
                });
            }
           

            function facebookLogout() {
                //if (FB.getAuthResponse()) {
                //alert(FB.getAccessToken());
                FB.logout();
                FB.logout(function (response) { window.location.reload(); });
               // alert(FB.getAccessToken());
                document.location.href = "sign_in.aspx";

                //FB.Event.subscribe("auth.logout", function () {alert("say hello");
                //        window.location = '/users/logout'
                //    });
                //    { $callback }
                    
               //}
              
        }
          
  </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
