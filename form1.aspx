<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false"  EnableEventValidation="false" CodeFile="form1.aspx.cs" Inherits="form1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Hope in tomorrow</title>
    <script src="jquery-1.10.2.js" type="text/jscript"> </script>
        <script type="text/javascript" src="http://merchant.com/javascript.js" ></script>
 <link rel="stylesheet" href="http://merchant.com/style.css" type="text/css" />
       
   
 <script type="text/javascript">

     function sendForm() {

         var identifier = document.getElementById('x_fp_hash').value;

         if (identifier) {

             //document.ppForm.action = "https://demo.globalgatewaye4.firstdata.com/payment";
             // $('#ppForm').attr('action', 'https://demo.globalgatewaye4.firstdata.com/payment');
             //$('#ppForm').submit();

             document.getElementById('ppForm').action = 'https://demo.globalgatewaye4.firstdata.com/payment';
             document.getElementById('ppForm').submit();
            


             // this.ppForm.action = "https://checkout.globalgatewaye4.firstdata.com/payment";
             // document.getElementById('ppForm').action = 'https://checkout.globalgatewaye4.firstdata.com/payment';

             //document.getElementById(".ppForm").submit();
             //document.ppForm.submit();
         }
     }
</script>
</head>
<body onload="sendForm();">

<form id="ppForm" name="form1" runat="server" method='post'>
        <input type='hidden' runat="server" name='x_login' id='x_login' />
      <input type='hidden' runat="server" name='x_fp_sequence' id='x_fp_sequence' />
     <input type='hidden' runat="server" name='x_fp_timestamp' id='x_fp_timestamp' />
       <input type='hidden' runat="server" name='x_fp_hash' id='x_fp_hash' />
      <input type='hidden' runat="server" name='x_test_request' id='x_test_request' />
        <input type='hidden' runat="server" name='x_show_form' id='x_show_form' />
       
        <input type='hidden' runat="server" name='x_amount' id='x_amount' maxlength="6" size="12" />
        
    </form>
</body>
</html>