<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ProfileMasterPage.master" CodeFile="UserProfileHome.aspx.cs" Inherits="UserProfileHome" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ClientIDMode="Static" runat="server">
<script src="js/redirect.js" type="text/javascript"></script>
                
                
                 <div style="height:1px;width:100%"></div>

                <div class="div_user_updates_news_container">
                    <div class="div_user_profile_news_row">
                        <span style="font-size:18px;  margin-left:18px;vertical-align:central; ">
                                Latest News

                        </span> 

                    </div>
            <asp:DataList ID="news" runat="server">
            <ItemTemplate>
                    <div class="div_user_profile_news_row">
                      
                         <div class="div_update_title">
                             
                        <a href="NewsView.aspx?id=<%# DataBinder.Eval(Container.DataItem,"news_id").ToString()%>" target="_blank"><%# DataBinder.Eval(Container.DataItem,"news_title").ToString() %></a>
                        </div>
                         <div class="div_update_date" >
                          <asp:Label ID="Label1" runat="server" Text='<%# datelongformat( (DateTime) DataBinder.Eval(Container.DataItem,"date_time_of_post")) %>'></asp:Label>
                        </div>
             
                    </div>
                </ItemTemplate>
                           </asp:DataList>
                    
                </div>
                  <div style="height:1px;width:100%"></div>
                
                 <div style="height:1px;width:100%">
                 </div>
                <div class="div_user_updates_news_container">
                     <div class="div_user_profile_news_row">
                          <span style="font-size:18px;  margin-left:18px;vertical-align:central; ">
                                Upcoming Events

                        </span>

                    </div>
                     <asp:DataList ID="top5EventsDL" runat="server">
            <ItemTemplate>
                    <div class="div_user_profile_news_row">
              
                        <div class="div_update_title">
                          <a href="EventView.aspx?id=<%# DataBinder.Eval(Container.DataItem,"event_id").ToString()%>" target="_blank"><%# DataBinder.Eval(Container.DataItem,"event_title").ToString() %></a>
                        </div>
                        <div class="div_update_date" >
                          <asp:Label ID="eventdate" runat="server" Text='<%# datelongformat( (DateTime) DataBinder.Eval(Container.DataItem,"date_time_of_post")) %>'></asp:Label>
                        </div>
              

                    </div>
                  </ItemTemplate></asp:DataList>



                </div>
    

</asp:Content>