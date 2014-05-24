<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminHome.aspx.cs" Inherits="Admin_AdminHome" MasterPageFile="~/Admin/AdminMaster.master" Title="AdminHome" %>

<asp:Content ID="AdminHome_main" ContentPlaceHolderID="content_body" runat="server" >
    <link href="Css/hitStyle.css" rel="stylesheet" />
     <div id="div_main_contianer">            <!-- The main container--> 
           
            
            
            <div id="div_middle">                <!-- The Middle Body --> 
   
                
                <div id="div_menu_bar">          <!-- Admin Menu Bar --> 
                    
                    <ul> 
                        <li id="li_1"> <a href="AdminHome.aspx" class="a_menu"> Home </a> </li> 
                        <li id="li_2"> <a href="ViewAllUsers.aspx" class="a_menu"> User Management </a> </li>  
                        <li id="li_3"> <a href="AdminBlog.aspx" class="a_menu" id="a_menu_BlogManagement" runat="server"> Blog Management </a> </li>  
                        <li id="li_4"> <a href="ViewAllEvents.aspx" class="a_menu"> Events </a> </li>  
                        <li id="li_5"> <a href="AdminHome.aspx" class="a_menu"> News </a> </li> 
                        <li id="li_6"> <a href="ImageSlider.aspx" class="a_menu"> Image Slider </a> </li> 
                        <li id="li_8"> <a href="AdminInbox.aspx" class="a_menu">Inbox<asp:Label ID="newMsg" runat="server" Text=""></asp:Label></a> </li>
                         <li id="li_9"> <a href="admin_fund_utilization.aspx" class="a_menu">Fund Utilization</a> </li>
                        <li id="li_7"> <a href="AdminHome.aspx" class="a_menu">Contacts </a> </li>

                    </ul> 
                    
                </div>                           <!-- End OF Admin Menu Bar --> 
                
                
            </div>                               <!-- End OF The Middle Body --> 
            
            
            
            
            
            
            
            <div id="div_footer">                <!-- The Footer --> 
            </div>                               <!-- End Of The Footer --> 
            
        </div>                                  <!-- End Of The main container-->



</asp:Content>
