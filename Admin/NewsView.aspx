<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="NewsView.aspx.cs" Inherits="Admin_NewsView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content_body" Runat="Server" ClientIDMode="Static">

       <link href="css/BlogViewer.css" rel="stylesheet" media="screen" />
    <style>
         #a_vertical_menu5
        {
            background-color : rgb(21,112,166); 
            color : rgb(255,255,255);
        }
    </style>
        <div id="div_main_contianer">            <!-- The main container--> 
           
            <div id="div_middle">               <!-- The Middle Body --> 
                
            
                
                
                
                
                <div id="div_blog_container">           <!-- Blog container -->
                    
                        <div id="div_blog_title" runat="server" contenteditable ="false">
                          
                        </div> 

                        <div id="div_blog_date_time" runat="server" contenteditable ="false">

                        </div> 

                         <div id="div_blog_body" style="overflow-y: auto; -ms-word-break: break-all; word-break: break-all; -ms-word-wrap: break-word; word-wrap: break-word;">
                            <div style="width:550px;float:left;">
                            <asp:Label ID="news_body" runat="server" style="float:left;"></asp:Label>
                                </div>
                           
                            <div style="float:right;">
                            <asp:Image runat="server" ID="pic" ImageUrl="~/img/no_image.gif"  Width="390px" />
                                </div>
                        </div> 
                        

                        <div id="div_button_bar"> 
                            <div id="div_poster_name_time" runat="server">
                                Posted by <span id="spn_posterName" runat="server"> </span> at <span id="spn_timeOfPost" runat="server"></span>
                            </div>

                             <div id="div_btnClose">
                                    <asp:Button ID="btnClose"  Text="CLOSE" runat="server" OnClick="btnClose_Click" />
                                </div>
                                <div id="div_btnEdit">
                                    <asp:Button ID="btnEdit" Text="Delete" runat="server" OnClick="btnEdit_Click" />
                                </div> 
                            
                        </div> 
                    
                </div> 
                
                
            </div>                               <!-- End OF The Middle Body --> 

            
        </div>                                  <!-- End Of The main container-->

</asp:Content>

