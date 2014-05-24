$(function () {

    var i = 0;


    $("#img_calender").click(function () {

        $("#div_calendar_event_date").slideDown('fast');

    });

});


function postval()
{
    if (document.getElementById('txtEventTitle').value.trim() != "" && document.getElementById('txtEventDate').value.trim() != "" && document.getElementById('txtEventPlace').value.trim() != "" && document.getElementById('txtEventTime').value.trim() != "" && document.getElementById('txtEventDesc').value.trim() != "")
    {
        return true;
    }
    {
        alert("Please do not leave any field blank ");
        return false;
    }
}
//function validate() {
//    var chkPostBack = '<%= Page.IsPostBack ? "true" : "false" %>';
//    if (chkPostBack == 'true') {

//        if (!confirm('Are you Sure to submit your File or Data?')) {
//            document.getElementById('<%= HiddenField1.ClientID %>').value = 0;

//        }
//        $.showprogress();
//    }
//    else
//        document.getElementById('<%= HiddenField1.ClientID %>').value = 1;

//}
   function postvalcheck()
{
 
    if (document.getElementById('txtNewsDesc').value.trim() != "" && document.getElementById('txtnewsheading').value.trim() != "")
    {
    }
    else
    {
        alert("Please do not leave any field blank ");
        return false;
    }
}