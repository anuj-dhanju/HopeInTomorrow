﻿function PostValue() {


    if (document.getElementById("div_blog_body").innerText.trim() != "" && document.getElementById("txtBlogTitle").value.trim() != "") {
        document.getElementById("hid_blog_body").value = document.getElementById("div_blog_body").innerHTML;
    }
    else {
        alert("Please do not leave any field blank");
        return false;
    }
}


$(function () {

    $("#btnMessageOkButton").click(function () {

        $("#div_message").css("display", "none");

        window.open("BlogWriter.aspx","_self");

    });

});