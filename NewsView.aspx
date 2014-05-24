<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsView.aspx.cs" MasterPageFile="~/UserMasterPage.master" Inherits="NewsView" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="js/redirect.js" type="text/javascript"></script>
    <link href="css/event_view.css" rel="stylesheet" />
    
   <div id="lower_middle_main"> 
             
    	<div id="lower_middle_cont" >
            <div class="event_container">
                 <span style="font-size:12px;margin-top:10px; color:#244b73">News ></span>
                 <asp:DataList ID="newsLoad" runat="server">
                           <ItemTemplate>
                               
               
                    <div class="div_h5_spacer"></div>
                   
                   <div class="event_title">
                        <span class="event_news_heading">
                             <asp:Label ID="NewsTitleLoad" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"news_title").ToString() %>'></asp:Label>
                        </span>

                    </div>

                    <div class="div_h20_spacer"></div>
                                <div class="event_left">
                     <div class="event_image_back">
                        <div class="event_image">
                           
                                    <img id="Img1" runat="server"  height="280" width="740"  src='<%# DataBinder.Eval(Container.DataItem,"news_pic").ToString() %>'/>
                           
                        </div>

                    </div>
                     <div class="div_h20_spacer"></div>
                    <div class="event_detail">
                         <span>
                           <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"date_time_of_post").ToString() %>'></asp:Label>    <br />
                     
                         </span>
                    </div>
                   <div class="event_desc">
                        <span class="event_news_desc">
                      <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"news_desc").ToString() %>'></asp:Label>
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