<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UserMasterPage.master" CodeFile="fundUtilization.aspx.cs" Inherits="fundUtilization" %>

<asp:Content ClientIDMode="Static" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <link href="css/fundUtilization.css" type="text/css" rel="stylesheet" />
    <script src="js/fundUtilization.js" type="text/javascript"></script>
    <div id="lower_middle_main"> 
             
    	<div id="lower_middle_cont" >
            <div class="uper">
                 <p style="font-size:25px; overflow:hidden ;color:#244b73">HOW FUND WILL BE UTILIZED?</p>
                <p style="font-size:14px;text-align:justify">
                    <asp:Label ID="upper_desc" runat="server" Text="">For the longest time, Android was an operating system that eschewed visual flair 
                    in favour of giving flexibility and power to the user, and since third party developers took their cues
                     from the OS itself, their apps tended to be complex and unabashedly ugly.For the longest time, Android was an operating system that eschewed visual flair 
                    in favour.</asp:Label>
                    <br /></p>

            </div>
            <div class="pai_div">
                <div class="pai_outer">
                   

                </div>
                <div class="pai_inner">
                    <p style="font-size:20px;">Transparency<br /></p><p style="font-size:40px;">100%</p>


                </div>

                </div>
            <div class="left_part">
                <div class="First_part">
                    <p style="font-size:14px;text-align:justify">
                    <img src="../img/clinic-64.png"  height="25" width="25"/><asp:Label ID="first_desc" runat="server" Text="">
                   </asp:Label>
                    <br /></p>

                </div>
                <div class="First_part"><p style="font-size:14px; text-align:justify">
                     <img src="../img/tear-of-calendar-64%20(2).png"   height="25" width="25"/><asp:Label ID="second_desc" runat="server" Text="">
                   </asp:Label>
                    </p>
                </div>
                <div class="First_part">
                    <p style="font-size:14px;text-align:justify">
                     <img src="../img/screenshot-64.png"   height="25" width="25"/><asp:Label ID="third_desc" runat="server" Text="">
                    
                         </asp:Label>

                    
                   </p>
                </div>
                 <div class="First_part">
                      <p style="font-size:14px;text-align:justify">
                          <img src="../img/network-64.png"  height="25" width="25"/><asp:Label ID="fourth_desc" runat="server" Text="">
                     </asp:Label>
                  
                </div>


            </div>
            
            
        </div>
  


</asp:Content>