

$(document).ready(function(){ 
    $("#a_menu_createNewblog").css("color","rgb(255,255,255)");
    $("#li_4").css("background", "rgb(21,112,166)");


   

});

function PostValue() {


    if (document.getElementById("div_blog_body").innerText.trim() != "" && document.getElementById("txtBlogTitle").value.trim() != "")
    {
        document.getElementById("hid_blog_body").value = document.getElementById("div_blog_body").innerHTML;  
    }
    else
    {
        alert("Please do not leave any field blank");
        return false;
    }


}