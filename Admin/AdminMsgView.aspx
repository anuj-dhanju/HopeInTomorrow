<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminMsgView.aspx.cs" MasterPageFile="~/Admin/AdminMaster.master" Inherits="Admin_AdminMsgView" %>

<asp:Content  ContentPlaceHolderID="content_body" runat="server" ClientIDMode="Static">

    <link href="css/BlogViewer.css" rel="stylesheet" media="screen" />
    <style>
        #a_vertical_menu8
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
                       
                        

                        <div id="div_blog_body" contenteditable ="false" runat="server">

                        </div> 
                        

                        <div id="div_button_bar"> 
                            <div id="div_poster_name_time" runat="server">
                                Sender <span id="spn_posterName" runat="server"> <br /> </span> at <span id="spn_timeOfPost" runat="server"></span>
                            </div>

                             <div id="div_btnClose">
                                    <asp:Button ID="btnClose"  Text="CLOSE" runat="server" OnClick="btnClose_Click" />
                                </div>
                                
                            
                        </div> 
                    
                </div> 
                
                
            </div>                               <!-- End OF The Middle Body --> 

            
        </div>                                  <!-- End Of The main container-->

    </asp:Content>

