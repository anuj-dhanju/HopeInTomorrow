<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="Event.aspx.cs" Inherits="Event" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="js/redirect.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="css/event_stylesheet.css" rel="stylesheet" />
    <link href="css/MessageBox.css" rel="stylesheet" type="text/css" />
    <script type='text/javascript'>

        function SignInMessage()
        {
            document.getElementById('div_message').style.display = 'block';

        };


        function MessageBoxDismiss() {

            document.getElementById('div_message').style.display = 'none';
        }

    </script>"


    
   <div id="div_message" >                                   <!-- Message box -->
        <div id="div_message_body">
            <div id="div_message_text" runat="server">
               Please Sign In First to Subcsribe To Any Event 
            </div>
             <div id="div_message_button"  >
                    <input type="button" value="OK" id="btnMessageOkButton" onclick="MessageBoxDismiss();"  style="width:100px" />
             </div>
        </div>

    </div>

     <div id="lower_middle_main"> 
             
    	<div id="lower_middle_cont" >
            <div class="v_spacer"></div>
            <span style="font-size:25px; font-stretch:extra-condensed; margin-left:60px; color:#888">News & Events</span>
            <div class="v_spacer"></div>
            
            <div class="news_left">
               
                <div style="float:left">
               
                        <asp:DataList ID="eventLoad" runat="server"  OnItemDataBound="eventLoad_ItemDataBound">
                           <ItemTemplate>
                               
                           
                                <div class="news_box">
                                    <div class="div_news_img">
                                        <%-- Loading image --%>
                                      <img runat="server" height="150" width="250"  src='<%# DataBinder.Eval(Container.DataItem,"event_pic").ToString() %>'/>

                                    </div>
                               
                                    <div id="event_title" runat="server" class="div_news_heading">
                                        <span class="event_news_heading">
                                          <a href="EventView.aspx?id=<%# DataBinder.Eval(Container.DataItem,"event_id").ToString()%>" target="_blank"><%# DataBinder.Eval(Container.DataItem,"event_title").ToString() %></a>
                                       </span>
                                            <div class="event_date_time" >
                                               On &nbsp; <asp:Label runat="server" CssClass="lbldatetimeofevent" ID="lbleventdate" Text='<%# datelongformat((DateTime)DataBinder.Eval(Container.DataItem,"event_time")) %>' ></asp:Label> <br />
                                                At &nbsp;  <asp:Label runat="server" CssClass="lbldatetimeofevent" ID="Label1" Text='<%#  timeshortformat((DateTime)DataBinder.Eval(Container.DataItem,"event_time")) %>' ></asp:Label>
                                                </div> 
                                    </div>
                                    <div class="div_bottom">
                                        <div id="subscribe" runat="server">

                                        </div>

                                    </div>
                                   
                                   
                                </div>
                            </ItemTemplate>
                           
                        </asp:DataList>
                </div>             

            </div>

        </div>
            
  </div >
    </asp:content>
   
  