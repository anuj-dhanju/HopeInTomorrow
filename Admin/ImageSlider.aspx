<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImageSlider.aspx.cs" Inherits="Admin_ImageSlider" MasterPageFile="~/Admin/AdminMaster.master" Title="Image Slider" %>


<asp:Content ID="AdminHome_main" ContentPlaceHolderID="content_body" runat="server" ClientIDMode="Static">
    <script src="Scripts/jquery-1.10.2.js"></script>
    <link href="css/ImageSlider.css" rel="stylesheet" /> 
     <script type="text/javascript"> 




         $(function () {


         });


         function showInfoText(j) 
         {
             if (document.getElementById('div_deleteWarning' + j).style.display != 'block' && document.getElementById('div_editImage'+j).style.display != 'block')
             {
                 document.getElementById('div_info' + j).style.display = 'block';
             }
         } 
         
         function hideInfoText(j) 
         { 
            document.getElementById('div_info'+j).style.display = 'none' ; 
         } 

         function showDeleteWarning(j)
         {
             document.getElementById('div_info' + j).style.display = 'none';
             document.getElementById('div_editImage'+j).style.display = 'none';
             document.getElementById('div_deleteWarning' + j).style.display = 'block';
         }
         

         function hideDeleteWarning(j)
         {
             document.getElementById('div_deleteWarning' + j).style.display = 'none';
         }

         function showEditPanel(j)
         {
             document.getElementById('div_info' + j).style.display = 'none';
             document.getElementById('div_editImage' + j).style.display = 'block';
             document.getElementById('div_deleteWarning' + j).style.display = 'none';
         }

         function hideEditPanel(j)
         {
             document.getElementById('div_editImage' + j).style.display = 'none';
         }

     </script>
     <div id="div_main_contianer">            <!-- The main container-->  
           
            
            
            <div id="div_middle">                <!-- The Middle Body --> 
   
                
                <div id="div_menu_bar">          <!-- Admin Menu Bar --> 
                    
                    <ul> 
                        <li id="li_1"> <a href="AdminHome.aspx" class="a_menu"> Home </a> </li> 
                        <li id="li_2"> <a href="ViewAllUsers.aspx" class="a_menu"> User Management </a> </li>  
                        <li id="li_3"> <a href="AdminBlog.aspx" class="a_menu" id="a_menu_BlogManagement" runat="server"> Blog Management </a> </li>  
                        <li id="li_4"> <a href="ViewAllEvents.aspx" class="a_menu"> Events </a> </li>  
                        <li id="li_5"> <a href="AdminHome.aspx" class="a_menu"> News </a> </li> 
                        <li id="li_6"> <a href="ImageSlider.aspx" class="a_menu" id="a_menu_imageSlider"> Image Slider </a> </li> 
                        <li id="li_7"> <a href="AdminHome.aspx" class="a_menu">Contacts </a> </li>
                    </ul> 
                    
                </div>                           <!-- End OF Admin Menu Bar --> 
                



                <div id="div_main_imageUpload"> 
                    <div id="div_addnewimage" >
                        <span id="spn_addnewpic_text" >Add a new picture to Image Slider : </span>
                        <asp:FileUpload ID="NewImageUpload" runat="server" />
                        &emsp; 
                        <asp:Button ID="btnAddNewImage" runat="server" OnClick="btnAddNewImage_Click" Text="Add" />

                    </div>

                    <div id="div_hr"> </div>

                    <div id="div_images" runat="server">

                    </div>
                </div> 


                
            </div>                               <!-- End OF The Middle Body --> 
            
            
            
            
            
            
            
            <div id="div_footer">                <!-- The Footer --> 
            </div>                               <!-- End Of The Footer --> 
            
        </div>                                  <!-- End Of The main container-->



</asp:Content>