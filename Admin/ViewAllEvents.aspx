<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAllEvents.aspx.cs" Inherits="ViewAllEvents" MasterPageFile="~/Admin/EventMaster.master" Title="AllEvents"%>
<%@ Import Namespace="System.Data.SqlClient" %>

<asp:Content ContentPlaceHolderID="contentChildBody" ID="AllEvents" runat="server" >
    <link href="css/VeiwAllEvents.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.10.2.js" type="text/javascript"></script>

  <div id="div_event_list_container">           <!-- Event List container -->
                    
                      
                        <asp:DataList ID="dlEvent" runat="server" Height="88px" Width="980px" style="margin-left:10px;" >
                        
                            <ItemTemplate>
                        
                                   <div class="div_event_body">
                                   
                                       <div class="div_event_title">
                                           <div class="div_event_t itle_text">

                                                    <asp:Label ID="lbleventTitle" runat="server"  CssClass="event_title" Text='<%# ChangeStringFormat(DataBinder.Eval(Container.DataItem,"event_title").ToString()) %>'> </asp:Label>
                                            
                                                <div class="div_event_options">
                                                    <a href="EventViwer.aspx?type=View&&id=<%# DataBinder.Eval(Container.DataItem,"event_id") %>"  id="lbtnView" >View</a>&emsp;
                                                    <a href="EventsEdit.aspx?type=Edit&&id=<%# DataBinder.Eval(Container.DataItem,"event_id") %>"  id="lbtnEdit" >Edit</a>&emsp;
                                                    <a href="ViewAllEvents.aspx?type=Delete&&id=<%# DataBinder.Eval(Container.DataItem,"event_id") %>"  id="lbtnDelete" >Delete</a>
                                                    <%--<asp:LinkButton ID="lbtnView"  runat="server" OnCommand="lbtnView_Command"  CommandArgument='<%# DataBinder.Eval(Container.DataItem,"event_id") %>' > View</asp:LinkButton> &emsp;
                                                    <asp:LinkButton ID="lbtnEdit" runat="server" OnCommand="lbtnEdit_Command" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"event_id") %>' >Edit</asp:LinkButton> &emsp;
                                                    <asp:LinkButton ID="lbtnDelete" runat="server" OnCommand="lbtnDelete_Command" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"event_id") %>'>Delete</asp:LinkButton>--%>
                                                </div>
                                            </div>
                                       </div>

                                       <div class="div_event_place">
                                           <div class="div_event_place_text" >
                                               
                                               Event Place

                                               <div class="div_event_place_value">
                                                        <asp:Label ID="lblEventPlace" runat="server"  CssClass="lbl_event_place" Text='<%# ChangeStringFormat(DataBinder.Eval(Container.DataItem,"event_place").ToString()) %>'> </asp:Label>
                                               </div>
                                           </div>
                                       </div> 


                                       <div class="div_event_datetime">
                                           <div class="div_event_datetime_text" >
                                               
                                               Date & Time

                                               <div class="div_event_datetime_value">
                                                        <asp:Label ID="lblEventDatetime" runat="server"  CssClass="lbl_event_datetime" Text='<%# DateTimeFormatting_full((DateTime)DataBinder.Eval(Container.DataItem,"event_time")) %>'> </asp:Label>
                                               </div>
                                           </div>
                                       </div> 


                                       <div class="div_event_views">
                                           <div class="div_event_post_time">
                                           
                                                <asp:label ID="lblEventPostTime" runat="server" CssClass="lblEventDateTime" Text='<%# DateTimeFormatting((DateTime)DataBinder.Eval(Container.DataItem,"date_time_of_post")) %>'> </asp:label>
                                           </div>
                                       </div>
                            
                                    </div>
                            
                                
                        
                            </ItemTemplate>
                   
                         </asp:DataList>

                    </div>                   <!-- End of Event list container --> 

</asp:Content>