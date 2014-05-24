<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/NewsMaster.master" AutoEventWireup="true" CodeFile="ViewAllNews.aspx.cs" Inherits="Admin_ViewAllNews" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<asp:Content ContentPlaceHolderID="contentChildBody" ID="AllEvents" runat="server" >
    <link href="css/VeiwAllEvents.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.10.2.js" type="text/javascript"></script>

  <div id="div_event_list_container">           <!-- Event List container -->
                    
                      
                        <asp:DataList ID="dlnews" runat="server" Height="88px" Width="980px" style="margin-left:10px;" >
                        
                            <ItemTemplate>
                        
                                   <div class="div_event_body">
                                   
                                       <div class="div_event_title">
                                           <div class="div_event_title_text">

                                                    <asp:Label ID="lbleventTitle" runat="server"  CssClass="event_title" Text='<%# ChangeStringFormat(DataBinder.Eval(Container.DataItem,"news_title").ToString()) %>'> </asp:Label>
                                            
                                                <div class="div_event_options">
                                                     <a href="NewsView.aspx?type=View&&id=<%# DataBinder.Eval(Container.DataItem,"news_id") %>"  id="A1" >View</a>&emsp;
                                                    <a href="ViewAllNews.aspx?type=Delete&&id=<%# DataBinder.Eval(Container.DataItem,"news_id") %>"  id="A3" >Delete</a>
                                                   
                                                </div>
                                            </div>
                                       </div>

                                       <div class="div_event_place">
                                           <div class="div_event_place_text" >
                                               
                                               News

                                               <div class="div_event_place_value">
                                                        <asp:Label ID="lblEventPlace" runat="server"  CssClass="lbl_event_place" Text='<%# ChangeStringFormat(DataBinder.Eval(Container.DataItem,"news_desc").ToString()) %>'> </asp:Label>
                                               </div>
                                           </div>
                                       </div> 


                                     <div class="div_event_views">
                                           <div class="div_event_post_time">
                                           
                                                <asp:Label ID="lblEventPostTime" runat="server" CssClass="lblEventDateTime" Text='<%# DateTimeFormatting((DateTime)DataBinder.Eval(Container.DataItem,"date_time_of_post")) %>'> </asp:Label>
                                           </div>
                                       </div>
                            
                                    </div>
                            
                                
                        
                            </ItemTemplate>
                   
                         </asp:DataList>
      <%--<div id="lightback" style="display:none;background:rgba(0, 0, 0, 0.49);height:100%; width:100%;">
          <div id-="msgbox" style="background:#fff;height:50px;width:150px;font-family:Arial;color:red; "

      </div>--%>
                    </div>                   <!-- End of Event list container --> 
</asp:Content>

