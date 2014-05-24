
  
// Init the SDK upon load
window.fbAsyncInit = function () {
    FB.init({
        appId: '411047675666918', // App ID  214812398681584
        channelUrl: 'www.hopeintomorrow.org', // Path to your Channel File
        status: true, // check login status
        cookie: true, // enable cookies to allow the server to access the session
        xfbml: true  // parse XFBML

    });
};


// Load the SDK Asynchronously

(function (d) {
    var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement('script'); js.id = id; js.async = true;
    js.src = "//connect.facebook.net/en_US/all.js";
    ref.parentNode.insertBefore(js, ref);
}(document));


function login() {
   
    
              FB.login(function (response) {
                  
                  
                  FB.api('/me', function (response) {
                      if (response.name) {
                          

                       
                          var name = "";
                          var email = "";
                          var social = "yes";
                          var image = "";
                          var id = "";
                          var socialtype = "FACEBOOK";
                          name = response.name;
                          id = response.id;
                          image = "http://graph.facebook.com/" + id + "/picture";
                        

                          email = response.email;
                         
                         
                          // username = response.username 
                          if (email == undefined) {
                              
                              FB.logout(function () {
                                  window.location.reload();
                                  document.location.href = "sign_in.aspx";

                              });


                          }
                          else 
                          {
                              
                              //FB.logout(function () { });   //few changes here 
                              document.location.href = "SocialLogin.aspx?email=" + email + "&name=" + name + "&social=" + social + "&socialType=" + socialtype + "&image=" +image;
                            
                            
                      }
                       }

                  })

              }, { scope: 'email' });
              
}
