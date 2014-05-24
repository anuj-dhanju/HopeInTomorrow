<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/EventMaster.master" AutoEventWireup="true" CodeFile="EventsEdit.aspx.cs" Inherits="Admin_newsEdit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentChildBody" Runat="Server" ClientIDMode="Static">
     <link href="css/ViewAllEvents.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="Scripts/NewEvent.js"></script>
    

  
                
                
                <div id="div_newevent_container">           <!-- User list container -->
                    
                     <div style="margin-left:40px; float:left;"> 

                         <br/>
                        <br/>
                        <br/>


                       
<%--<asp:DataList ID="dlEvent" runat="server"><ItemTemplate>--%>

                        <table style="height: 131px; width: 631px"> 
                            <tr>
                                <td colspan="2" style="text-align:center">
                                    New Event
                                </td>

                            </tr>

                             <tr>
                                <td style="width: 143px" >
                                    <asp:Label ID="lblEventTitle" runat="server" > Event Title </asp:Label>
                                </td>
                                 <td style="width: 404px">
                                     <asp:TextBox ID="txtEventTitle" runat="server" placeholder="Event Title" style="margin-left: 0px" Width="391px"></asp:TextBox> 
                                 </td>
                            </tr>
                             <tr>
                                <td style="width:143px;"> <asp:Label ID="Label18" runat="server"> Image </asp:Label></td>
                                  <td> <asp:Image runat="server" ID="pic" ImageUrl="~/img/no_image.gif" Height="150px" Width="391px" style="border:1px solid black"/><br />
                                <asp:FileUpload ID="pic_uploader" runat="server" /></td>
                                <%--<asp:Image runat="server" ID="event_pic" ImageUrl="~/img/question-mark.png" Height="100px" Width="100px"; />--%>
                            </tr>
                            <tr>
                                <td style="width: 143px" >
                                    <asp:Label ID="Label1" runat="server"> Date </asp:Label>
                                </td>
                                 <td style="width: 404px">
                                    

                                     <%--<asp:ScriptManager runat="server" ></asp:ScriptManager>--%>

                                     <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server"></asp:ToolkitScriptManager>
                                     <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                         <ContentTemplate>--%>
                                             <div id="div_txt_event_datetime" style="float:left;">
                                                <asp:TextBox ID="txtEventDate" runat="server" ReadOnly="true" Width="360px"  ></asp:TextBox> &emsp; &emsp;
                                               
                                             </div> 

                                             <div id="div_calendar_event_date" Style="float:left;margin-left:-30px;">
                                                 <asp:imagebutton id="img_calender"  runat="server" imageurl="Resources/Images/webpage_images/calender.png" height="23px" width="22px" /> 
                                                 
                                                 <asp:calendarextender id="event_date_calendarextender" enabled="true" targetcontrolid="txtEventDate" popupbuttonid="img_calender"  runat="server">
                     </asp:calendarextender>
                                             </div>
                                                                                          
                                         <%--</ContentTemplate>


                                         
                                     </asp:UpdatePanel>--%>
                                     <%--<img src="Resources/Images/webpage_images/calender.png" style="height:23px;width:22px" id="img_calender"/>--%>
                                 </td>
                            </tr>

                            <tr>
                                <td style="width: 143px" >
                                    <asp:Label ID="Label2" runat="server" > Place </asp:Label>
                                </td>
                                 <td style="width: 404px">                                   
                                     <asp:TextBox ID="txtEventPlace" runat="server" TextMode="MultiLine" placeholder="Place" style="margin-left: 0px" Rows="3" Columns="47" ></asp:TextBox> 
                                 </td>
                            </tr>



                             <tr>
                                <td style="width: 143px" >
                                    <asp:Label ID="Label4" runat="server"> Time </asp:Label>
                                </td>
                                 <td style="width: 404px">                                   
                                     <input id="txtEventTime" required="required" runat="server" style="width: 391px"  />
                                 </td>
                            </tr>
                           

                             <tr>
                                <td style="width: 143px" >
                                    <asp:Label ID="Label3" runat="server"> Description </asp:Label>
                                </td>
                                 <td style="width: 404px">                                   
                                      <asp:TextBox ID="txtEventDesc" runat="server" TextMode="MultiLine" Rows="8" Columns="47"></asp:TextBox>
                                 </td>
                            </tr>

                             <tr>
                                <td style="width: 143px" >
                                    
                                </td>
                                 <td style="width: 404px"> 
                                     &emsp; &emsp;   
                                     <asp:Button ID="btnUpdateEvent" runat="server" OnClick="btnUpdateEvent_Click" Text="Update Event" Height="30px" />  &emsp; &emsp;   &emsp; &emsp;                                  
                                     <input type="reset" value="Reset" style="height: 30px" />
                                  </td>
                            </tr>
                            

                        </table>
        

    <%--</ItemTemplate></asp:DataList>--%>

                    </div>
             </div> 
   
</asp:Content>

