(function () {
    var po = document.createElement('script');
    po.type = 'text/javascript';
    po.async = true;
    po.src = 'https://apis.google.com/js/client:plusone.js?onload=render';
    var s = document.getElementsByTagName('script')[0];
    s.parentNode.insertBefore(po, s);
})();

function render() {
    gapi.signin.render('googlesignup', {
        'callback': 'signinCallback',
        'approvalprompt': 'force',
        'clientid': '783528094584.apps.googleusercontent.com',
        'cookiepolicy': 'single_host_origin',
        'height': 'short',
        'requestvisibleactions': 'http://schemas.google.com/AddActivity',
        'scope': 'https://www.googleapis.com/auth/plus.login https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/userinfo.profile'
    });
}

function signinCallback(authResult) {
    if (authResult) {
        if (authResult['access_token']) {
            // Successfully authorized
            // Hide the sign-in button now that the user is authorized, for example:
            gapi.auth.setToken(authResult);
            // document.getElementById('customBtn').setAttribute('style', 'display: none');
            // document.getElementById('logout').setAttribute('style', 'display: block');
            getemail();

        }
        else if (authResult['error']) {
            // There was an error.

        }
    }
}
function getemail() {

    gapi.client.load('oauth2', 'v2', function () {

        var request = gapi.client.oauth2.userinfo.get();

        request.execute(getEmailCallback);
    });

    // this is used for image also. 

    // gapi.client.load('plus', 'v1', function () {
    //    var request = gapi.client.plus.people.get({
    //        'userId': 'me'
    //    });
    //    request.execute(function (resp) {
    //        // console.log('Retrieved profile for:' + resp.displayName);
    //       alert(resp.displayName);
    //        // alert(resp.email);
    //       // alert(Object.keys(resp));
    //    });
    //});

}

function getEmailCallback(obj) {
    //alert(Object.keys(obj));
    // Here obj stores data in json format
    var email = '';
    var name = '';
    var id = '';
    if (obj['email']) {

        email = obj['email'];
    }

    if (obj['name']) {

        name = obj['name'];
    }
    if (obj['id']) {

        id = obj['id'];
    }
    //alert(id);
    var socialtype = "GOOGLE";
    var social = "yes";
    var image = "https://plus.google.com/s2/photos/profile/"+id+"?sz=100";
        document.location.href = "SocialLogin.aspx?email=" + email + "&name=" + name + "&social=" + social + "&socialType=" + socialtype + "&image=" + image;
}