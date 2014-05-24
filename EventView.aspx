<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventView.aspx.cs" MasterPageFile="~/UserMasterPage.master" Inherits="EventView" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <script src="js/redirect.js" type="text/javascript"></script>
    <link href="css/event_view.css" rel="stylesheet" />
   <div id="lower_middle_main"> 
             
    	<div id="lower_middle_cont" >
            <div class="event_container">
                <span style="font-size:12px;margin-top:10px; color:#244b73">Event</span>
                 <asp:DataList ID="eventLoad" runat="server">
                           <ItemTemplate>
                               
               
                    <div class="div_h5_spacer"></div>
                   
                    <div class="event_title">
                        <span class="event_news_heading ">
                             <asp:Label ID="EventTitleLoad" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"event_title").ToString() %>'></asp:Label>
                        </span>

                    </div>
                   

                    <div class="div_h20_spacer"></div>
                    <div class="event_left">
                   
                        <div class="event_image_back">
                        <div class="event_image">
                          
                                    <img id="Img1" runat="server" height="280" width="740"  src='<%# DataBinder.Eval(Container.DataItem,"event_pic").ToString() %>'/>
                            
                        </div>

                    </div>
                        <div class="div_h20_spacer"></div>
                        <div class="event_detail">
                         <span>
                        <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"event_time").ToString() %>'></asp:Label>     <br />
                         <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"event_place").ToString() %>'></asp:Label>     

                         </span>
                    </div>
                        <div class="event_desc">
                        <span class="event_news_desc">
                      <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"event_desc").ToString() %>'></asp:Label>
                        </span>
                    </div>
                        

                </div>
                                <div class="event_left_bottom">

                </div>
                
                               </ItemTemplate>
                     </asp:DataList>
                               

            </div>
        </div>

   </div>
    
</asp:Content>